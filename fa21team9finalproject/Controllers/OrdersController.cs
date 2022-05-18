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

namespace fa21team9finalproject.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify an order to view!" });
            }

            //find the order in the database
            Order order = await _context.Orders
                                              .Include(r => r.Reservations)
                                              .ThenInclude(r => r.Property)
                                              .Include(r => r.User)
                                              .FirstOrDefaultAsync(m => m.OrderID == id);

            //order was not found in the database
            if (order == null)
            {
                return View("Error", new String[] { "This order was not found!" });
            }

            //make sure this order belongs to this user
            if (User.IsInRole("Customer") && order.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "This is not your order! Don't be such a snoop!" });
            }

            List<Reservation> updatedReservs = new List<Reservation>();

            if (order.Status == oStatus.InProgress)
            {
                foreach (Reservation reservation in order.Reservations)
                {

                    // Initialize discount variable
                    Int32 _discount = 0;
                    reservation.TotalStayDays = (int)(reservation.CheckOutDate - reservation.CheckInDate).TotalDays + 1;

                    // If the reservation meets the required number of days, then set discount 
                    if (reservation.TotalStayDays >= reservation.Property.DiscountDays)
                    {
                        _discount = reservation.Property.Discount;
                        _context.Update(reservation);
                        await _context.SaveChangesAsync();

                    }
                    // This should be individual reservation total
                    reservation.CalcTotalReservationPrice(_discount);

                    _context.Update(reservation);
                    await _context.SaveChangesAsync();

                    updatedReservs.Add(reservation);
                }
                order.Reservations = updatedReservs;
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            
            //Send the user to the details page
            if (order.Status == oStatus.InProgress)
            {
                ViewBag.Status = "In Progress";
            }
            else if (order.Status == oStatus.Confirmed)
            {
                ViewBag.Status = "Active";
            }
            else
            {
                ViewBag.Status = "Cancelled";
            }
            //User is about to confirm order, send them to the create Get
            return View(order);
        }

        // GET: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Search through reservations in a order, find reservations associated with order id
        // Check reservations in order, make sure reservation dates do not conflict with any active reservation
        // It will say conflicting with active reservation, throw error 
        // Loop through reservations, if passes everything, change all reservations to active, change order to active, generate confirmation number for order
        // Send them to confirmation page to congratulate
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Create(Int32? oid)
        {
            if (oid == null)
            {
                return View("Error", new String[] { "Unable to specify order to confirm." });
            }

            // Find the order that includes reservations, properties, and users associated with this order
            Order order = _context.Orders.
                Include(o => o.Reservations).
                ThenInclude(r => r.Property).
                Include(m => m.User).FirstOrDefault(o => o.OrderID == oid);
            // create a list of unavailable addresses 
            List<String> UnavailAddresses = new List<string>();
            List<String> DatesPast = new List<string>();

            //loop through each reservation in the order
            foreach (Reservation reservation in order.Reservations.Where(r => r.Status == rStatus.Pending))
            {
                // List that holds unavailable reservation
                List<Reservation> Unavailable = new List<Reservation>();

                // loop through each reservation in the database
                foreach (Reservation r in _context.Reservations.Include(r => r.Property))
                {
                    if (reservation.Property.PropertyID == r.Property.PropertyID)
                    {
                        // check if the status is active and if the reservation in the order conflicts with a reservation in the database
                        if (r.Status == rStatus.Active)
                        {
                            if ((r.CheckOutDate > reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckInDate < reservation.CheckOutDate) || (r.CheckInDate <= reservation.CheckInDate && r.CheckOutDate >= reservation.CheckOutDate) || (r.CheckInDate >= reservation.CheckInDate && r.CheckOutDate <= reservation.CheckOutDate))
                            {
                                // if it does, add to unavaiable
                                Unavailable.Add(reservation);
                            }
                        }
                    }
                    // if unavailable is > 0, add the full address of the properties to unavailable addresses
                    if (Unavailable.Count > 0)
                    {
                        // add reservations full address to UnavailAddresses
                        UnavailAddresses.Add(reservation.Property.FullAddress);
                    }
                }
                if ((reservation.CheckInDate - DateTime.Now).TotalDays < 0)
                {
                    DatesPast.Add(reservation.Property.FullAddress);
                }
            }
            if (UnavailAddresses.Count() > 0)
            {
                String _strAddyList = null;

                foreach (String Address in UnavailAddresses)
                {
                    if (_strAddyList != null)
                    {
                        _strAddyList += ", ";
                    }
                    _strAddyList += Address;
                }
                // returns an error list if the unavailable addresses are not empty
                return View("Error", new String[] {"Oops! Looks like reservations have been made by other users that conflict with reservations in your cart. Please delete or change the following reservations: ",
                    _strAddyList });
            }
            if (DatesPast.Count() > 0)
            {
                String _strAddyList = null;

                foreach (String Address in DatesPast)
                {
                    if (_strAddyList != null)
                    {
                        _strAddyList += ", ";
                    }
                    _strAddyList += Address;
                }
                // returns an error list if the unavailable addresses are not empty
                return View("Error", new String[] {"Oops! Looks like your cart has reservations with check-in dates that have past. Please delete or change the following reservations:"
                     + _strAddyList });
            }
            // Once you reach this point, set order status to confirmed and loop through reservations to make each of them actvie
            order.Status = oStatus.Confirmed;
            order.OrderDate = DateTime.Today;
            order.OrderNumber = Utilities.GenerateNextConfirmationNumber.GetNextConfirmationNumber(_context);
            _context.Update(order);

            await _context.SaveChangesAsync();

            foreach(Reservation r in order.Reservations.Where(r => r.Status == rStatus.Pending))
            {
                r.Status = rStatus.Active;
                _context.Update(r);
                await _context.SaveChangesAsync();
            }

            if (User.IsInRole("Admin"))
            {
                foreach (Reservation reservation in order.Reservations)
                {
                    // Initialize discount variable
                    Int32 _discount = 0;
                    reservation.TotalStayDays = (int)(reservation.CheckOutDate - reservation.CheckInDate).TotalDays;

                    // If the reservation meets the required number of days, then set discount 
                    if (reservation.TotalStayDays >= reservation.Property.DiscountDays)
                    {
                        _discount = reservation.Property.Discount;
                        _context.Update(reservation);
                        await _context.SaveChangesAsync();

                    }
                    // This should be individual reservation total
                    reservation.CalcTotalReservationPrice(_discount);

                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
            }

            //SENDING EMAIL: email customer that they have confirmed their order
            AppUser user = order.User;
            String emailSubject = "Order Confirmed";
            String emailBod = "Your order at BevoBnb has successfully been created! We look forward to your stay with us!";
            Utilities.EmailMessaging.SendEmail(order.User.Email, emailSubject, emailBod);

            //Redirect to Confirmation page
            return RedirectToAction("Confirm", new { oid = order.OrderID });
        }

        // GET: Orders/Confirm
        // This is the confirmation page
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Confirm(Int32? oid)
        {
            if (oid == null)
            {
                return View("Error", new String[] { "There was an error confirming this order!" });
            }
            //Find the order associated with order id
            Order order = _context.Orders.
                Include(o => o.Reservations).
                ThenInclude(r => r.Property).
                Include(m => m.User).
                ThenInclude(d => d.PropertyReviews).
                FirstOrDefault(o => o.OrderID == oid);

            return View(order);
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderNumber,OrderDate,Status")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return View("Error", new String[] { "" });
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
