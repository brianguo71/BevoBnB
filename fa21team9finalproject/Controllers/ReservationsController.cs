using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Controllers
{
    //[Authorize(Roles = "Admin,Customer")]
    //[AllowAnonymous]
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        //DONE
        [Authorize(Roles = "Host,Customer")]
        public IActionResult Index(string Message)
        {
            // find logged in user
            AppUser userLoggedIn = _context.Users.Include(u=> u.Orders).FirstOrDefault(u => u.UserName == User.Identity.Name);

            //if a host, want to find all reservations of properties tied to the host
            List<Property> HostProperties = new List<Property>();

            if (User.IsInRole("Host"))
            {
                foreach (Property property in _context.Properties.Include(p => p.Reservations).ThenInclude(p => p.Order).ThenInclude(p => p.User).Include(p => p.PropertyReviews).ThenInclude(p => p.User).ToList())
                {
                    if (userLoggedIn.Email == property.HostEmail)
                    {
                        HostProperties.Add(property);
                    }
                }
            }

            //create a query to limit reservations before sorting into the past, upcoming, cancelled lists
            List<Reservation> narrowedReservations = new List<Reservation>();

            if (User.IsInRole("Host"))
            {
                foreach (Property property in HostProperties)
                {
                    foreach (Reservation reservation in property.Reservations.Where(r => r.Status != rStatus.Delete))
                    {
                        narrowedReservations.Add(reservation);
                    }
                }
            }
            else //user is a customer
            {
                foreach (Order order in _context.Orders.Include(o => o.User).Include(o => o.Reservations).ThenInclude(o => o.Property).Include(o => o.User).Where(o => o.User.Email == userLoggedIn.Email))
                {
                    foreach (Reservation reservation in order.Reservations)
                    {
                        narrowedReservations.Add(reservation);
                    }
                }
            }

            DateTime now = DateTime.Today;

            // creates new list of all past, upcoming, and cancelled types
            List<Reservation> Past = new List<Reservation>();
            List<Reservation> Upcoming = new List<Reservation>();
            List<Reservation> Cancelled = new List<Reservation>();
            List<Reservation> Pending = new List<Reservation>();
            List<Reservation> Unavailable = new List<Reservation>();

            //loop through each of the existing reservations
            foreach (Reservation reservation in narrowedReservations)
            {
                if (reservation.Order != null)
                {
                    if (User.IsInRole("Host"))
                    {
                        if (reservation.Order.User.Email == userLoggedIn.Email)
                        {
                            Unavailable.Add(reservation);
                        }
                    }
                    if (reservation.Status == rStatus.Active && reservation.Order.Status == oStatus.Confirmed && (reservation.CheckInDate - now).TotalDays > 0)
                    {
                        Upcoming.Add(reservation);
                    }
                    if (reservation.Status == rStatus.Cancelled)
                    {
                        Cancelled.Add(reservation);
                    }
                    if (reservation.Status == rStatus.Active && reservation.Order.Status == oStatus.Confirmed && (reservation.CheckInDate - now).TotalDays <= 0)
                    {
                        Past.Add(reservation);
                    }
                    if (reservation.Status == rStatus.Pending && reservation.Order.Status == oStatus.InProgress)
                    {
                        Pending.Add(reservation);
                    }
                }
            }

            //create new instance of the reservation index view model
            ReservationIndexViewModel rivm = new ReservationIndexViewModel();

            //find order id
            Order o  = userLoggedIn.Orders.FirstOrDefault(o => o.Status == oStatus.InProgress);

            //populate properties of the reservation index view model
            rivm.User = userLoggedIn;
            rivm.Past = Past;
            rivm.Upcoming = Upcoming;
            rivm.Cancelled = Cancelled;
            rivm.Pending = Pending;
            rivm.Unavailable = Unavailable;

            if (o != null)
            {
                rivm.OrderID = o.OrderID;
            }
            if (Message != null)
            {
                ViewBag.Message = Message;
            }
            return View(rivm);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Specify a reservation to view!" });
            }

            //find the reservation in the database
            Reservation reservation = await _context.Reservations
                                              .Include(r => r.Property)
                                              .Include(r => r.Order)
                                              .ThenInclude(r => r.User)
                                              .ThenInclude(r => r.PropertyReviews)
                                              .FirstOrDefaultAsync(m => m.ReservationID == id);

            // find logged in user
            AppUser userLoggedIn = _context.Users.Include(u => u.Orders).FirstOrDefault(u => u.UserName == User.Identity.Name);

            //make sure this reservation belongs to this user
            if (reservation.Order.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "This is not your reservation!  Don't be such a snoop!" });
            }

            //registration was not found in the database
            if (reservation == null)
            {
                return View("Error", new String[] { "This reservation was not found!" });
            }

            return View(reservation);
        }

        //POST:Reservations/Index
        //This method is the method that cancels a reservation
        [Authorize(Roles = "Host,Customer")]
        public ActionResult Cancel(ReservationModificationModel rmm)
        {
            //if RoleModificationModel is valid, add new users
            if (ModelState.IsValid)
            {
                //if there are users to make inactive (terminate for admins), inactivate them
                if (rmm.IdsToCancel != null)
                {
                    //loop through all the ids to make inactive
                    foreach (Int32 reservationId in rmm.IdsToCancel)
                    {
                        //find the reservation in the database using their id
                        Reservation reservation = _context.Reservations.Include(r => r.Order).ThenInclude(o => o.User).FirstOrDefault(r => r.ReservationID == reservationId);

                        // attempt to change status of the reservation to cancelled
                        try
                        {
                            reservation.Status = rStatus.Cancelled;
                            //save the changes
                            _context.Update(reservation);
                            _context.SaveChanges();

                            //SENDNG EMAIL: sending email that reservation has been cancelled
                            String emailSubject = "Reservation Has Been Cancelled";
                            String emailBod = "Your reservation has been cancelled. If you did not make this action, the host did. Please contact the host with any questions or concerns.";
                            Utilities.EmailMessaging.SendEmail(reservation.Order.User.Email, emailSubject, emailBod);
                        }
                        // if attempt did not work, show user the error page
                        catch (Exception ex)
                        {
                            return View("Error", ex);
                        }
                    }
                }
                //this is the happy path - all edits worked
                //take the user back to the RoleAdmin Index page
                return RedirectToAction("Index");
            }
            //this is a sad path - the status was not found
            //show the user the error page
            return View("Error", new string[] { "Unable to cancel reservation." });
        }

        // GET: Reservations/Create
        //DONE
        [Authorize]
        public IActionResult Create(int id)
        {
            // creates list of properties joining categories and assigns that to Properties variable
            List<Property> Properties = _context.Properties.Include(p => p.Category).ToList();

            // finds the desired property using id from the Properties list
            Property property = Properties.FirstOrDefault(m => m.PropertyID == id);
            var pid = property.PropertyID;

            // create a new reservation
            Reservation reservation = new Reservation();

            reservation.Property = property;

            if (property == null)
            {
                return View("Error", new String[] { "That property was not found in the database." });
            }

            ViewBag.PropertyID = pid;

            // needs to be a reservation object that's passed through
            ViewBag.AllCustomers = GetAllCustomersAsync();
            return View(reservation);
        }

        // POST: Reservations/Create
        //DONE???
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // dont add to database, add to either existing Order or  a new Order
        public async Task<IActionResult> Create([Bind("ReservationID,PropertyID,CheckInDate,CheckOutDate,NumberOfGuests")] Reservation reservation, String email)
        {

            // creates list of properties joining categories and assigns that to Properties variable
            List<Property> Properties = _context.Properties.Include(p => p.Category).ToList();

            // finds the desired property using id from the Properties list
            Property property = Properties.FirstOrDefault(m => m.PropertyID == reservation.PropertyID);

            //if the property is inactive, they shouldn't be able to make a reservation
            if (property.Status == pStatus.notActive)
            {
                return View("Error", new String[] { "This property is no longer active." });
            }

            // create a new reservation
            reservation.Property = property;
            reservation.CleaningFee = property.CleaningFee;
            reservation.PricePerWeekday = property.PricePerWeekday;
            reservation.PricePerWeekend = property.PricePerWeekend;
            reservation.Status = rStatus.Pending;

            //check that number of guests that they want to bring is less than guest limit of property
            try
            {
                reservation.CheckGuestNumber();
                reservation.CalcDates();
            }
            catch (Exception ex)
            {
                ViewBag.AllCustomers = GetAllCustomersAsync();
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.PropertyID = reservation.PropertyID;
                return View("Create", reservation);
            }

            if (User.IsInRole("Admin") && email == null)
            {
                return View("Error", new String[] { "Specify a customer to make a reservation for!" });
            }

            // calculate number of weekends and weekdays
            // calculate total price
            reservation.CalcNumberOfWeekdaysAndWeekends();
            reservation.CalcTotalPrice();

            _context.Update(reservation);
            _context.SaveChanges();

            //make sure all properties are valid
            if (ModelState.IsValid == false)
            {
                ViewBag.AllCustomers = GetAllCustomersAsync();
                ViewBag.ErrorMessage = "There is an error!";
                ViewBag.PropertyID = reservation.PropertyID;
                return View(reservation);
            }

            String _email = "";

            if (User.IsInRole("Customer") || User.IsInRole("Host"))
            {
                // find logged in user
                AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

                _email = userLoggedIn.Email;
            }
            else
            {
                AppUser customer = _context.Users.FirstOrDefault(u => u.Email == email);

                _email = customer.Email;
            }

            // create list of orders
            List<Order> orders = _context.Orders.Include(o => o.User).Include(o => o.Reservations).ThenInclude(r => r.Property).ThenInclude(p => p.PropertyReviews).Where(o => o.User.Email == _email && o.Status == oStatus.InProgress).ToList();

            // create a list of reservations for this property that are active
            List<Reservation> CurrentReservations = new List<Reservation>();
            List<Reservation> ReservationsInCart = new List<Reservation>();

            if (User.IsInRole("Admin") || User.IsInRole("Customer"))
            {
                // loop through all reservations and add to this list if the reservation is active and for this property
                foreach (Reservation r in _context.Reservations.Include(r => r.Property).ThenInclude(p => p.PropertyReviews).Include(r => r.Order).ThenInclude(o => o.User).ToList())
                {
                    // checks if the reservation is for the property we are trying to reserve
                    // also checks if the reservation status is active
                    if ((r.PropertyID == reservation.Property.PropertyID) && (r.Status == rStatus.Active))
                    {
                        // checks dates conflicting
                        if ((r.CheckOutDate > reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckInDate < reservation.CheckOutDate) || (r.CheckInDate <= reservation.CheckInDate && r.CheckOutDate >= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate))
                        {
                            CurrentReservations.Add(r);
                        }
                    }
                }

                //loop through reservations of orders tied to the user, whether confirmed or in the user's cart
                foreach (Order order in _context.Orders.Include(o => o.User).Include(o => o.Reservations).ThenInclude(o => o.Property).Where(o => o.User.Email == _email).ToList())
                {
                    foreach (Reservation r in order.Reservations)
                    {
                        // if reservation is active or pending, it can conflict. Reservations that have been deleted or cancelled cannot conflict
                        if (r.Status == rStatus.Active || r.Status == rStatus.Pending)
                        {
                            // this checks the dates to be conflicting or not
                            if ((r.CheckOutDate > reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckInDate < reservation.CheckOutDate) || (r.CheckInDate <= reservation.CheckInDate && r.CheckOutDate >= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate))
                            {
                                ReservationsInCart.Add(r);
                            }
                        }
                    }
                }
            }

            //if current reservations is greater than 0, there is a conflict
            //throw an error
            if (CurrentReservations.Count > 0)
            {
                ViewBag.AllCustomers = GetAllCustomersAsync();
                ViewBag.ErrorMessage = "There is already an active reservation for this property on your dates! Please choose different dates.";
                ViewBag.PropertyID = reservation.PropertyID;
                return View(reservation);
            }
            if (ReservationsInCart.Count > 0)
            {
                if (User.IsInRole("Admin"))
                {
                    ViewBag.ErrorMessage = "The customer already has a reservation conflicting with these dates.";
                }
                else if (User.IsInRole("Host"))
                {
                    ViewBag.ErrorMessage = "You have an unavailability made for this property that conflicts with this new unavailability. Please directly edit this on your property management page under 'Edit Unavailabilities'.";
                }
                else
                {
                    ViewBag.ErrorMessage = "A reservation that you have made or have in your cart conflicts with this reservation's dates.";
                }
                ViewBag.AllCustomers = GetAllCustomersAsync();
                ViewBag.PropertyID = reservation.PropertyID;
                return View(reservation);
            }

            //save reservation object
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            // if the count of orders is 0, create a new order
            if (orders.Count == 0)
            {
                try
                {
                    //create a new order for this user
                    Order order = new Order();

                    // find user with email
                    AppUser user = _context.Users.FirstOrDefault(u => u.Email == _email);

                    //specify new order information
                    order.Status = oStatus.InProgress;
                    order.User = user;
                    order.OrderDate = DateTime.Now;
                    //NOTE: confirmation number generated when user confirms order
                    //Move this line elsewhere
                    //order.OrderNumber = Utilities.GenerateNextConfirmationNumber.GetNextConfrimationNumber(_context);

                    //add order to the database
                    _context.Add(order);
                    await _context.SaveChangesAsync();

                    // add reservation to order
                    reservation.Order = order;
                    _context.Add(reservation);

                    _context.Update(reservation);
                    //_context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return View("Error", new String[] { "There was an error adding the reservation to cart!", ex.Message });
                }
            }
            else if (orders.Count == 1)
            {
                //add reservation to this order
                Int32 oid = new Int32();

                foreach (Order o in orders)
                {
                    oid = o.OrderID;
                }

                //find order based on oid
                Order Order = orders.FirstOrDefault(o => o.OrderID == oid);

                // create new list of reservations object
                List<Reservation> Reservations = new List<Reservation>();

                // populate list of reservations with Order.Reservations
                foreach (Reservation r in Order.Reservations)
                {
                    Reservations.Add(r);
                }

                // add reservation we just made
                Reservations.Add(reservation);

                // reassign order reservations list to be the new list we just made
                Order.Reservations = Reservations;

                //update and save changes
                _context.Update(reservation);
                _context.Update(Order);
                await _context.SaveChangesAsync();

                //go to order edit page???
            }
            else
            {
                // user has multiple orders inprogress
                // combine these orders
                Order order = new Order();
                List<Reservation> Reservations = new List<Reservation>();

                // loop through all reservstions in the orders in progress
                foreach (Order o in orders)
                {
                    foreach (Reservation r in o.Reservations)
                    {
                        // respecify the new order to be tied to this reservation instead of the old order
                        r.Order = order;
                        Reservations.Add(r);
                        _context.Update(r.Order);
                    }
                    //change order status of all those orders to cancelled
                    o.Status = oStatus.Cancelled;
                    //empty the reservations the old order is associated with
                    o.Reservations = new List<Reservation>();

                    //update to database
                    _context.Update(o);
                    await _context.SaveChangesAsync();
                }
                // add all reservations to the new order
                Reservations.Add(reservation);
                order.Reservations = Reservations;
                order.Status = oStatus.InProgress;

                //save to database
                _context.Update(reservation);
                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            //send the user on to the action that will allow them to view their reservations
            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Reservations");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Create", "Orders", new { oid = reservation.Order.OrderID });
            }
            else
            {

                reservation.Status = rStatus.Active;
                reservation.Order.Status = oStatus.HostUnavailability;
                _context.Update(reservation);
                _context.SaveChanges();
                ViewBag.CreatedReservation = "Unavailability listed.";
                return RedirectToAction("Index", "Properties");
            }
        }

        //POST:Reservations/Delete
        //This method is the method that deletes a reservation
        [Authorize(Roles = "Customer,Host")]
        public ActionResult Delete(ReservationModificationModel rmm)
        {
            //if RoleModificationModel is valid, add new users
            if (ModelState.IsValid)
            {
                //if there are users to make inactive (terminate for admins), inactivate them
                if (rmm.IdsToCancel != null)
                {
                    //loop through all the ids to make inactive
                    foreach (Int32 reservationId in rmm.IdsToCancel)
                    {
                        //find the reservation in the database using their id
                        Reservation reservation = _context.Reservations.Include(r => r.Order).ThenInclude(o => o.User).FirstOrDefault(r => r.ReservationID == reservationId);

                        // attempt to change status of the reservation to delete
                        try
                        {
                            reservation.Status = rStatus.Delete;
                            //save the changes
                            _context.Update(reservation);
                            _context.SaveChanges();
                        }
                        // if attempt did not work, show user the error page
                        catch (Exception ex)
                        {
                            return View("Error", ex);
                        }
                    }
                }
                //this is the happy path - all edits worked
                //take the user back to the RoleAdmin Index page
                return RedirectToAction("Index");
            }
            //this is a sad path - the status was not found
            //show the user the error page
            return View("Error", new string[] { "Unable to remove reservation from cart." });
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationID == id);
        }

        // get all customers 
        private SelectList GetAllCustomersAsync()
        {
            
            //Make list to hold customers
            List<AppUser> Customers = new List<AppUser>();

            foreach (AppUser user in _context.Users.Where(u => u.Role == "Customer" && u.IsActive == aStatus.Active).ToList())
            {
                Customers.Add(user);
            }

            //convert the list to a SelectList by calling SelectList constructor
            SelectList customerSelectList = new SelectList(Customers.OrderBy(c => c.Email), "Email", "Email");

            //return the electList
            return customerSelectList;
        }
    }
}


