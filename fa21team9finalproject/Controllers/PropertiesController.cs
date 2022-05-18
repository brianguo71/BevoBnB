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
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Properties
        //DONE???
        public IActionResult Index()
        {
            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            foreach (Property property in _context.Properties.Include(p => p.PropertyReviews))
            {
                property.CheckRating();
                _context.Update(property);
            }
            _context.SaveChanges();

            // if user is a host, limit property view to their properties only
            if (User.IsInRole("Host"))
            {
                var query = from p in _context.Properties
                            join c in _context.Categories
                            on p.Category.CategoryID equals c.CategoryID
                            select p;


                query = query.Where(p => p.HostEmail == userLoggedIn.Email);
                query = query.Where(p => p.Status == pStatus.Active);

                // use the .ToList() method to execute the query
                // add an include statement so that you get the navigational data
                List<Property> HostProperties = query.Include(p => p.Category).ToList();

                ViewBag.SelectedProperties = HostProperties.Count;
                ViewBag.AllProperties = HostProperties.Count;

                // return statement to the view
                return View("Index", HostProperties);
            }
            else
            {
                // create an LINQ query to filter the properties we want from the search
                var query = from p in _context.Properties
                            join c in _context.Categories
                            on p.Category.CategoryID equals c.CategoryID
                            select p;

                // use LINQ to limit the query to properties that have been approved by admin and properties that are active according to host
                query = query.Where(p => p.ApprovalStatus == pStatus.Active);
                query = query.Where(p => p.Status == pStatus.Active);

                // use the .ToList() method to execute the query
                // add an include statement so that you get the navigational data
                List<Property> ApprovedProperties = query.Include(p => p.Category).ToList();

                ViewBag.SelectedProperties = ApprovedProperties.Count;
                ViewBag.AllProperties = ApprovedProperties.Count;

                // return statement to the view
                return View("Index", ApprovedProperties);
            }
        }

        // GET: Properties/Details/5
        //DONE
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a property to view!" });
            }

            // creates list of properties joining categories and assigns that to Properties variable
            List<Property> Properties = _context.Properties.Include(p => p.Category).ToList();

            // finds the desired property using id from the Properties list
            Property property = Properties.FirstOrDefault(m => m.PropertyID == id);

            if (property == null)
            {
                return View("Error", new String[] { "That property was not found in the database." });
            }

            //if property is not active, customer cannot see the details of it
            if (property.ApprovalStatus == pStatus.notActive)
            {
                if (User.IsInRole("Host") == false || User.IsInRole("Admin") == false)
                {
                    return View("Error", new String[] { "This property does not exist." });
                }
            }


            return View(property);
        }

        // GET: Properties/Create
        [Authorize(Roles = "Host")]
        public IActionResult Create()
        {
            // this allows user to see dropdown list of all categories when making new properties
            ViewBag.AllCategories = GetAllCategories();
            return View();
        }

        // POST: Properties/Create
        //DONE???
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Create([Bind("PropertyID,StreetAddress,AptNum,City,State,ZipCode,NumberGuests,PricePerWeekday,PricePerWeekend,NumberBed,NumberBath,PetsAllowed,FreeParking,CleaningFee,DiscountDays,Discount")] Property property, int SelectedCategory)
        {
            //Find the next property number from the utilities class
            property.PropertyNumber = Utilities.GenerateNextPropertyNumber.GetNextPropertyNumber(_context);

            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            //Associate the property with the logged-in host
            property.HostEmail = userLoggedIn.Email;

            //find the category to be associated with this property
            Category dbCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == SelectedCategory);

            //set the property's category to be equal to the one we just found
            property.Category = dbCategory;

            // property status should be Active when first created because Host wants property to be available
            property.Status = pStatus.Active;

            // property approvalStatus should be notActive when first created because Admin has not approved of the property yet
            property.ApprovalStatus = pStatus.notActive;

            //make sure all properties are valid
            if (ModelState.IsValid == false)
            {
                return View(property);
            }

            //if code gets this far, add the order to the database
            _context.Add(property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Properties/DetailedSearch
        public IActionResult DetailedSearch()
        {
            // this allows user to see dropdown list of all categories when making new properties
            ViewBag.AllCategories = GetSelectAllCategories();
            return View();
        }

        // POST: Properties/DetailedSearch
        // action method to return search results from user
        [HttpPost, ActionName("DetailedSearch")]
        public IActionResult DisplaySearchResults(PropertySearchViewModel psvm, int SelectedCategory)
        {
            // create a query
            var query = from p in _context.Properties
                        select p;

            //check that search dates of user are valid
            try
            {
                psvm.CalcSearchDates();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.AllCategories = GetSelectAllCategories();
                return View("DetailedSearch", psvm);
            }

            // query to search by check-in date availabilities
            if ((psvm.SearchCheckIn != null) && (psvm.SearchCheckOut != null))
            {
                //search for dates
                List<Property> UnAvailable = new List<Property>();
                foreach (Property property in _context.Properties.Include(p => p.Reservations))
                {
                    Boolean Available = true;

                    foreach (Reservation r in property.Reservations)
                    {
                        // finds all wrong dates
                        if (((r.CheckOutDate > psvm.SearchCheckIn && r.CheckInDate < psvm.SearchCheckIn) || (r.CheckInDate < psvm.SearchCheckOut && r.CheckOutDate > psvm.SearchCheckOut) || (r.CheckInDate < psvm.SearchCheckIn && r.CheckOutDate > psvm.SearchCheckOut) || (r.CheckInDate >= psvm.SearchCheckIn && r.CheckOutDate <= psvm.SearchCheckOut)) && r.Status == rStatus.Active)
                        {
                            Available = false;
                        }
                    }

                    if (Available == false)
                    {
                        UnAvailable.Add(property);
                    }
                    foreach (Property propertyUnavailable in UnAvailable)
                    {
                        query = query.Where(p => p.PropertyID != propertyUnavailable.PropertyID);
                    }
                }
            }

            // query to check search by Category
            // -1 means they chose all categories
            // cannot select multiple categories at a time right now -- Do we need this functionality???
            if (SelectedCategory != -1)
            {
                Category dbCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == SelectedCategory);
                query = query.Where(p => p.Category.CategoryID == dbCategory.CategoryID);
            }

            // query to check search by City
            if (psvm.SearchCity != null)
            {
                query = query.Where(p => p.City == psvm.SearchCity);
            }

            // query to check search by State
            if (psvm.SearchState != null)
            {
                query = query.Where(p => p.State == psvm.SearchState);
            }

            // query to check search by Average Guest Rating
            if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax != null))
            {
                query = query.Where(p => p.AverageRating >= psvm.SearchGuestRatingMin && p.AverageRating <= psvm.SearchGuestRatingMax);
            }
            else if ((psvm.SearchGuestRatingMax != null) && (psvm.SearchGuestRatingMin == null))
            {
                query = query.Where(p => p.AverageRating <= psvm.SearchGuestRatingMax);
            }
            else if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax == null))
            {
                query = query.Where(p => p.AverageRating >= psvm.SearchGuestRatingMin);
            }

            // query to check search by Number of Guests
            if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax != null))
            {
                query = query.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin && p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMax != null) && (psvm.SearchNumGuestsMin == null))
            {
                query = query.Where(p => p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax == null))
            {
                query = query.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin);
            }

            // query to check search by Weekend Price
            if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax != null))
            {
                query = query.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMax != null) && (psvm.SearchWeekendPriceMin == null))
            {
                query = query.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax == null))
            {
                query = query.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
            }

            // query to check search by Weekday Price
            if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax != null))
            {
                query = query.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMax != null) && (psvm.SearchWeekdayPriceMin == null))
            {
                query = query.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax == null))
            {
                query = query.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
            }

            // query to check search by Number of Beds
            if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax != null))
            {
                query = query.Where(p => p.NumberBed >= psvm.SearchNumBedsMin && p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMax != null) && (psvm.SearchNumBedsMin == null))
            {
                query = query.Where(p => p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax == null))
            {
                query = query.Where(p => p.NumberBed >= psvm.SearchNumBedsMin);
            }

            // query to check search by Number of Baths
            if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax != null))
            {
                query = query.Where(p => p.NumberBath >= psvm.SearchNumBathsMin && p.NumberBath <= psvm.SearchNumBathsMax);
            }
            else if ((psvm.SearchNumBathsMax != null) && (psvm.SearchNumBathsMin == null))
            {
                query = query.Where(p => p.NumberBath <= psvm.SearchNumBathsMax);
            }
            else if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax == null))
            {
                query = query.Where(p => p.NumberBath >= psvm.SearchNumBathsMin);
            }

            // query to check search by Pet Policy
            if (psvm.SearchPetsAllowed != null)
            {
                query = query.Where(p => p.PetsAllowed == psvm.SearchPetsAllowed);
            }

            // query to check search by Free Parking Availability
            if (psvm.SearchFreeParking != null)
            {
                query = query.Where(p => p.FreeParking == psvm.SearchFreeParking);
            }


            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);




            // create a query for all properties
            var queryAll = from p in _context.Properties
                           select p;

            // if user is a host, limit property view to their properties only
            if (User.IsInRole("Host"))
            {
                query = query.Where(p => p.HostEmail == userLoggedIn.Email);
                query = query.Where(p => p.Status == pStatus.Active);
                queryAll = queryAll.Where(p => p.HostEmail == userLoggedIn.Email);
                queryAll = queryAll.Where(p => p.Status == pStatus.Active);
            }
            else //just make sure property is available and approved
            {

                queryAll = queryAll.Where(p => p.ApprovalStatus == pStatus.Active);
                queryAll = queryAll.Where(p => p.Status == pStatus.Active);
                query = query.Where(p => p.ApprovalStatus == pStatus.Active);
                query = query.Where(p => p.Status == pStatus.Active);
            }

            // use the .ToList() method to execute the query
            // add an include statement so that you get the navigational data
            List<Property> SelectedProperties = query.Include(p => p.Category).ToList();
            List<Property> AllProperties = queryAll.Include(p => p.Category).ToList();

            // add counts to the ViewBag AllBooks
            ViewBag.AllProperties = AllProperties.Count;

            // add counts to the ViewBag SelectedBooks
            ViewBag.SelectedProperties = SelectedProperties.Count;

            return View("Index", SelectedProperties.OrderBy(p => p.PropertyNumber));
        }

        // GET: Properties/Edit/5
        //DONE
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Please specify a property to edit!" });
            }

            Property property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return View("Error", new string[] { "This property was not found!" });
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        // DONE???
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyID,StreetAddress,City,State,ZipCode,AverageRating,NumberGuests,PricePerWeekday,PricePerWeekend,NumberBed,NumberBath,PetsAllowed,FreeParking,Status,ApprovalStatus,Discount,CleaningFee,HostEmail,PropertyNumber,DiscountDays")] Property property)
        {
            if (id != property.PropertyID)
            {
                return View("Error", new string[] { "Please try again!" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.PropertyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }


        // GET: Properties/Delete/5
        //DONE
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Please specify a property to delete!" });
            }

            Property property = await _context.Properties
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return View("Error", new string[] { "This property was not found!" });
            }

            return View(property);
        }

        // POST: Properties/Delete/5
        //DONE
        [Authorize(Roles = "Host")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // find property to delete based on PropertyID
            Property property = await _context.Properties.FindAsync(id);

            // delete property by changing status to notActive
            property.Status = pStatus.notActive;

            //find all reservations associated with the property and if active, set to cancelled
            List<Reservation> reservations = _context.Reservations.Include(r => r.Order).ThenInclude(r => r.User).Include(r => r.Property).Where(r => r.Property.PropertyID == property.PropertyID).ToList();

            //loop through all reservations attached to this property and set to cancel if pending or if active and reservation is coming up
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Status == rStatus.Pending)
                {
                    reservation.Status = rStatus.Delete;
                    //SENDING EMAIL: email to user when host deletes property bc reservation for property becomes deleted from cart
                    AppUser user = reservation.Order.User;
                    String emailSubject = "Property Removed from BevoBnB";
                    String emailBod = "The host has removed their property listing from BevoBnB. Your pending reservation has been removed from your cart.";
                    Utilities.EmailMessaging.SendEmail(reservation.Order.User.Email, emailSubject, emailBod);
                }
                else if (reservation.Status == rStatus.Active && reservation.CheckInDate > DateTime.Now)
                {
                    reservation.Status = rStatus.Cancelled;
                    //SENDING EMAIL: email to user when host deletes property bc reservation for property becomes cancelled
                    AppUser user = reservation.Order.User;
                    String emailSubject = "Reservation Cancelled By Host";
                    String emailBod = "The host has removed their property listing from BevoBnB. Your upcoming reservation has been cancelled. Please allow 3-5 business days for a refund. Contact admin@BevoBnB.com with any questions, comments, or concerns.";
                    Utilities.EmailMessaging.SendEmail(reservation.Order.User.Email, emailSubject, emailBod);
                }
                _context.Update(reservation);
                await _context.SaveChangesAsync();
            }

            // save changes
            _context.Update(property);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyID == id);
        }

        // method to show all categories on dropdown when needing to select a category
        private SelectList GetAllCategories()
        {
            //Get the list of categories from the database
            List<Category> categoryList = _context.Categories.ToList();

            //convert the list to a SelectList by calling SelecStList constructor
            //CategoryID and CategoryName are the names of the properties on the Category class
            //CategoryID is the primary key
            SelectList categorySelectList = new SelectList(categoryList.OrderBy(c => c.CategoryID), "CategoryID", "CategoryName");

            //return the electList
            return categorySelectList;
        }

        // get all category method that has dummy variable for all categories
        private SelectList GetSelectAllCategories()
        {
            //Get the list of categories from the database
            List<Category> categoryList = _context.Categories.ToList();

            //add a dummy entry so the user can select all genres
            Category SelectAll = new Category() { CategoryID = -1, CategoryName = "All Categories" };
            categoryList.Add(SelectAll);

            //convert the list to a SelectList by calling SelecStList constructor
            //CategoryID and CategoryName are the names of the properties on the Category class
            //CategoryID is the primary key
            SelectList categorySelectList = new SelectList(categoryList.OrderBy(c => c.CategoryID), "CategoryID", "CategoryName");

            //return the electList
            return categorySelectList;
        }

        // GET: Properties/SeeDeleted
        //DONE
        [Authorize(Roles = "Host")]
        public IActionResult SeeDeleted()
        {
            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var query = from p in _context.Properties
                        select p;

            query = query.Where(p => p.HostEmail == userLoggedIn.Email);
            query = query.Where(p => p.Status == pStatus.notActive);

            // use the .ToList() method to execute the query
            // add an include statement so that you get the navigational data
            List<Property> HostProperties = query.Include(p => p.Category).ToList();

            if (HostProperties.Count == 0)
            {
                ViewBag.noResults = "You have no deleted listings.";
            }

            // return statement to the view
            return View("SeeDeleted", HostProperties);
        }

        // GET: Properties/Reactivate/5
        //DONE
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Reactivate(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Please specify a property to reactivate!" });
            }

            Property property = await _context.Properties
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return View("Error", new string[] { "This property was not found!" });
            }

            return View(property);
        }

        // POST: Properties/Reactivate/5
        //DONE
        [Authorize(Roles = "Host")]
        [HttpPost, ActionName("Reactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReactivateConfirmed(int id)
        {
            // find property to delete based on PropertyID
            Property property = await _context.Properties.FindAsync(id);

            // reactivate property by changing status to Active
            property.Status = pStatus.Active;

            // save changes
            _context.Update(property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// POST: Properties/HostReport
        //// action method to return search results from host
        //// host gets to choose how they want to narrow down the properties in their search
        //// similar idea as detailed search for searching, but different view returned
        //[HttpPost, ActionName("HostReportSearch")]
        //[Authorize(Roles ="Host")]

        //public IActionResult HostReportSearch(PropertySearchViewModel psvm, int SelectedCategory)
        //{
        //    // create a query
        //    var query = from p in _context.Properties
        //                select p;

        //    //check that search dates of user are valid
        //    try
        //    {
        //        psvm.CalcSearchDates();
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMessage = ex.Message;
        //        ViewBag.AllCategories = GetSelectAllCategories();
        //        return View("DetailedSearch", psvm);
        //    }

        //    // query to check search by Category
        //    // -1 means they chose all categories
        //    // cannot select multiple categories at a time right now -- Do we need this functionality???
        //    if (SelectedCategory != -1)
        //    {
        //        Category dbCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == SelectedCategory);
        //        query = query.Where(p => p.Category.CategoryID == dbCategory.CategoryID);
        //    }

        //    // query to check search by City
        //    if (psvm.SearchCity != null)
        //    {
        //        query = query.Where(p => p.City == psvm.SearchCity);
        //    }

        //    // query to check search by State
        //    if (psvm.SearchState != null)
        //    {
        //        query = query.Where(p => p.State == psvm.SearchState);
        //    }

        //    // query to check search by Average Guest Rating
        //    if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax != null))
        //    {
        //        query = query.Where(p => p.AverageRating >= psvm.SearchGuestRatingMin && p.AverageRating <= psvm.SearchGuestRatingMax);
        //    }
        //    else if ((psvm.SearchGuestRatingMax != null) && (psvm.SearchGuestRatingMin == null))
        //    {
        //        query = query.Where(p => p.AverageRating <= psvm.SearchGuestRatingMax);
        //    }
        //    else if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax == null))
        //    {
        //        query = query.Where(p => p.AverageRating >= psvm.SearchGuestRatingMin);
        //    }

        //    // query to check search by Number of Guests
        //    if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax != null))
        //    {
        //        query = query.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin && p.NumberGuests <= psvm.SearchNumGuestsMax);
        //    }
        //    else if ((psvm.SearchNumGuestsMax != null) && (psvm.SearchNumGuestsMin == null))
        //    {
        //        query = query.Where(p => p.NumberGuests <= psvm.SearchNumGuestsMax);
        //    }
        //    else if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax == null))
        //    {
        //        query = query.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin);
        //    }

        //    // query to check search by Weekend Price
        //    if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax != null))
        //    {
        //        query = query.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
        //    }
        //    else if ((psvm.SearchWeekendPriceMax != null) && (psvm.SearchWeekendPriceMin == null))
        //    {
        //        query = query.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
        //    }
        //    else if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax == null))
        //    {
        //        query = query.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
        //    }

        //    // query to check search by Weekday Price
        //    if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax != null))
        //    {
        //        query = query.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
        //    }
        //    else if ((psvm.SearchWeekdayPriceMax != null) && (psvm.SearchWeekdayPriceMin == null))
        //    {
        //        query = query.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
        //    }
        //    else if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax == null))
        //    {
        //        query = query.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
        //    }

        //    // query to check search by Number of Beds
        //    if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax != null))
        //    {
        //        query = query.Where(p => p.NumberBed >= psvm.SearchNumBedsMin && p.NumberBed <= psvm.SearchNumBedsMax);
        //    }
        //    else if ((psvm.SearchNumBedsMax != null) && (psvm.SearchNumBedsMin == null))
        //    {
        //        query = query.Where(p => p.NumberBed <= psvm.SearchNumBedsMax);
        //    }
        //    else if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax == null))
        //    {
        //        query = query.Where(p => p.NumberBed >= psvm.SearchNumBedsMin);
        //    }

        //    // query to check search by Number of Baths
        //    if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax != null))
        //    {
        //        query = query.Where(p => p.NumberBath >= psvm.SearchNumBathsMin && p.NumberBath <= psvm.SearchNumBathsMax);
        //    }
        //    else if ((psvm.SearchNumBathsMax != null) && (psvm.SearchNumBathsMin == null))
        //    {
        //        query = query.Where(p => p.NumberBath <= psvm.SearchNumBathsMax);
        //    }
        //    else if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax == null))
        //    {
        //        query = query.Where(p => p.NumberBath >= psvm.SearchNumBathsMin);
        //    }

        //    // query to check search by Pet Policy
        //    if (psvm.SearchPetsAllowed != null)
        //    {
        //        query = query.Where(p => p.PetsAllowed == psvm.SearchPetsAllowed);
        //    }

        //    // query to check search by Free Parking Availability
        //    if (psvm.SearchFreeParking != null)
        //    {
        //        query = query.Where(p => p.FreeParking == psvm.SearchFreeParking);
        //    }

        //    // find logged in user
        //    AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

        //    // create a query for all properties
        //    var queryAll = from p in _context.Properties
        //                   select p;

        //    //REDO BELOW THIS

        //    // if user is a host, limit property view to their properties only
        //    // we should be checking if reservation is active, not property
        //    if (User.IsInRole("Host"))
        //    {
        //        query = query.Where(p => p.HostEmail == userLoggedIn.Email);
        //        query = query.Where(p => p.Status == pStatus.Active);
        //        queryAll = queryAll.Where(p => p.HostEmail == userLoggedIn.Email);
        //        queryAll = queryAll.Where(p => p.Status == pStatus.Active);
        //    }

        //    // use the .ToList() method to execute the query
        //    // add an include statement so that you get the navigational data
        //    List<Property> SelectedProperties = query.Include(p => p.Category).Include(p => p.Reservations).ToList();
        //    List<Property> AllProperties = queryAll.Include(p => p.Category).ToList();

        //    //create new list of all reservations
        //    List<Reservation> Reservations = new List<Reservation>();

        //    foreach (Reservation reservation in _context.Reservations.Include(r => r.Property).Include(r => r.Order).ThenInclude(o => o.User))
        //    {
        //        //check if Reservation belongs to
        //        //if (reservation.Property in SelectedProperties)
        //        //{

        //        //}
        //    }
        //    // query to search by check-in date availabilities
        //    if ((psvm.SearchCheckIn != null) && (psvm.SearchCheckOut != null))
        //    {
        //        // query we don't want
        //        var noInclude = from p in _context.Properties
        //                        join r in _context.Reservations
        //                        on p.PropertyID equals r.Property.PropertyID
        //                        where r.CheckOutDate <= psvm.SearchCheckIn || r.CheckInDate >= psvm.SearchCheckOut
        //                        select p;

        //        query = query.Except(noInclude);
        //    }

        //    //STEP1: if searching by date, find all reservations where the date doesn't conflict
        //    //STEP2: loop through all those reservations we just found and only keep reservations that are tied to properties the host owns (use HostEmail)
        //    //STEP3: loop through all those reservations and only include properties from the previous queries called "query"
        //    //STEP4: use the remaining reservations to build the report


        //    // add counts to the ViewBag AllBooks
        //    ViewBag.AllProperties = AllProperties.Count;

        //    // add counts to the ViewBag SelectedBooks
        //    ViewBag.SelectedProperties = SelectedProperties.Count;

        //    return View("Index", SelectedProperties.OrderBy(p => p.PropertyNumber));
        //}


        //admin report to display all of the information
        [Authorize(Roles = "Admin")]
        public IActionResult AdminReport(AdminReportViewModel arvm)
        {

            List<Reservation> AllReservations = _context.Reservations.ToList();
            //create an empty list of past reservations
            List<Reservation> past_reservations = new List<Reservation>();

            //create a count to count reservations
            Int32 reservationCount = 0;
            
            //if the reservation was not cancelled and has passed or falls in the middle of the date, include the reservation in the past reservations list
            foreach (Reservation reservation in AllReservations)
            {
                if (reservation.Status == rStatus.Active)
                {
                    // TODO: might need to add condition statement for reservation in the past
                    past_reservations.Add(reservation);
                    reservationCount++;
                }
            }

            //create new variable to keep track of total commission
            Decimal TotalCommission = 0.0m;

            //for each reservation in the past reservation list add the reservation total to the commission
            foreach (Reservation reservation in past_reservations)
            {
                TotalCommission += 0.10m * (reservation.TotalPrice - reservation.Discount);
            }

            //set the object commission equal to the commission calculated above
            arvm.BnBTotalCommission = TotalCommission;


            //find total number reservations
            arvm.BnBTotalReservations = reservationCount;

            if (reservationCount == 0)
            {
                arvm.BnBAvgCommission = 0.0m;
            }
            //find avg commission
            else
            {
                arvm.BnBAvgCommission = TotalCommission / reservationCount;
            }
            //find BevoBnB Total Properties

            //create a count to count properties
            Int32 propertyCount = 0;
            //if the property is active include it in the list
            foreach (Property property in _context.Properties)
            {
                if (property.Status == pStatus.Active)
                {
                    propertyCount++;
                }
            }

            arvm.BnBSelectedProperties = propertyCount;

            List<Reservation> AllBnBReservations = new List<Reservation>();
            foreach (Reservation r in _context.Reservations.Where(r => r.Status == rStatus.Active))
            {
                AllBnBReservations.Add(r);
            }
            //find how many total reservations there are
            ViewBag.AllReservations = AllBnBReservations.Count();
            return View("AdminReport", arvm);
        }

        // GET: Properties/AdminReportSearch
        
        [Authorize(Roles = "Admin")]
        public IActionResult AdminReportSearch()
        {
            // this allows admins to see dropdown list of all categories when searching for different things
            ViewBag.AllCategories = GetSelectAllCategories();
            return View();
        }

        //POST: Properties/AdminReportSearch
        //admin report to for specific search
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AdminReportSearch(int SelectedCategory, PropertySearchViewModel psvm)
        {

            // create a query
            var reservationsQuery = from r in _context.Reservations
                        join p in _context.Properties
                        on r.Property.PropertyID equals p.PropertyID
                        join c in _context.Categories
                        on p.Category.CategoryID equals c.CategoryID
                        select r;
            var propertiesQuery = from p in _context.Properties
                        join c in _context.Categories
                        on p.Category.CategoryID equals c.CategoryID
                        select p;

            //check that search dates of user are valid
            try
            {
                psvm.CalcSearchDates();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.AllCategories = GetSelectAllCategories();
                //TODO: Change the name of the view it returns
                return View("AdminReportSearch", psvm);
            }

            if ((psvm.SearchCheckIn != null) && (psvm.SearchCheckOut != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.CheckInDate >= psvm.SearchCheckIn && r.CheckOutDate <= psvm.SearchCheckOut && r.Status == rStatus.Active);

            }
            else
            {
                reservationsQuery = reservationsQuery.Where(r => r.Status == rStatus.Active);
            }
            // query to check search by Category
            // -1 means they chose all categories
            // cannot select multiple categories at a time right now -- Do we need this functionality???
            if (SelectedCategory != -1)
            {
                Category dbCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == SelectedCategory);
                reservationsQuery = reservationsQuery.Where(r => r.Property.Category.CategoryID == dbCategory.CategoryID);
                propertiesQuery = propertiesQuery.Where(p => p.Category.CategoryID == dbCategory.CategoryID);
            }

            // query to check search by City
            if (psvm.SearchCity != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.City == psvm.SearchCity);
                propertiesQuery = propertiesQuery.Where(p => p.City == psvm.SearchCity);
            }

            // query to check search by State
            if (psvm.SearchState != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.State == psvm.SearchState);
                propertiesQuery = propertiesQuery.Where(p => p.State == psvm.SearchState);
            }

            // query to check search by Average Guest Rating
            if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating >= psvm.SearchGuestRatingMin && r.Property.AverageRating <= psvm.SearchGuestRatingMax);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMin);
            }
            else if ((psvm.SearchGuestRatingMax != null) && (psvm.SearchGuestRatingMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating <= psvm.SearchGuestRatingMax);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMax);
            }
            else if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating >= psvm.SearchGuestRatingMin);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMin);
            }

            // query to check search by Number of Guests
            if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests >= psvm.SearchNumGuestsMin && r.Property.NumberGuests <= psvm.SearchNumGuestsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin && p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMax != null) && (psvm.SearchNumGuestsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests <= psvm.SearchNumGuestsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests >= psvm.SearchNumGuestsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin);
            }

            // query to check search by Weekend Price
            if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax != null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMax != null) && (psvm.SearchWeekendPriceMin == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
            }

            // query to check search by Weekday Price
            if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax != null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMax != null) && (psvm.SearchWeekdayPriceMin == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
            }

            // query to check search by Number of Beds
            if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed >= psvm.SearchNumBedsMin && r.Property.NumberBed <= psvm.SearchNumBedsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed >= psvm.SearchNumBedsMin && p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMax != null) && (psvm.SearchNumBedsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed <= psvm.SearchNumBedsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed >= psvm.SearchNumBedsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed >= psvm.SearchNumBedsMin);
            }

            // query to check search by Number of Baths
            if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath >= psvm.SearchNumBathsMin && r.Property.NumberBath <= psvm.SearchNumBathsMax);
                propertiesQuery = propertiesQuery.Where(p => p.State == psvm.SearchState);
            }
            else if ((psvm.SearchNumBathsMax != null) && (psvm.SearchNumBathsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath <= psvm.SearchNumBathsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBath <= psvm.SearchNumBathsMax);
            }
            else if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath >= psvm.SearchNumBathsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBath >= psvm.SearchNumBathsMin);
            }

            // query to check search by Pet Policy
            if (psvm.SearchPetsAllowed != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.PetsAllowed == psvm.SearchPetsAllowed);
                propertiesQuery = propertiesQuery.Where(p => p.PetsAllowed == psvm.SearchPetsAllowed);
            }

            // query to check search by Free Parking Availability
            if (psvm.SearchFreeParking != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.FreeParking == psvm.SearchFreeParking);
                propertiesQuery = propertiesQuery.Where(p => p.FreeParking == psvm.SearchFreeParking);
            }

            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            //just make sure property is available and approved
            propertiesQuery = propertiesQuery.Where(p => p.ApprovalStatus == pStatus.Active);
            propertiesQuery = propertiesQuery.Where(p => p.Status == pStatus.Active);

            // use the .ToList() method to execute the query
            // add an include statement so that you get the navigational data
            List<Property> SelectedProperties = propertiesQuery.ToList();
            List<Property> PropertiesWithReservations = new List<Property>();
            List<Reservation> SelectedReservations = reservationsQuery.ToList();

            foreach (Property p in SelectedProperties)
            {
                Int32 Seen = 0;
                foreach(Reservation r in p.Reservations)
                {
                    foreach(Reservation r2 in SelectedReservations)
                    {
                        if (r.ReservationID == r2.ReservationID)
                        {
                            Seen += 1;
                        }
                    }
                }
                if (Seen > 0)
                {
                    PropertiesWithReservations.Add(p);
                }

            }
            

            List<Property> AllProperties = propertiesQuery.Include(p => p.Category).ToList();

            Int32 NumProperties = PropertiesWithReservations.Count;

            

            AdminReportViewModel arvm = new AdminReportViewModel();
            //use the selected properties to calculate admin report data
            List<Reservation> SelectedPropertyReservations = SelectedReservations.ToList();

            //create new variable to keep track of total commission
            Decimal TotalCommission = 0.0m;

            //for each reservation in the past reservation list add the reservation total to the commission
            foreach (Reservation reservation in SelectedReservations)
            {
                TotalCommission += 0.10m * (reservation.ReservationTotal);
            }

            //set the object commission equal to the commission calculated above
            arvm.BnBTotalCommission = TotalCommission;


            //find total number reservations
            arvm.BnBTotalReservations = SelectedReservations.Count;

            if (SelectedReservations.Count == 0)
            {
                arvm.BnBAvgCommission = 0.0m;
            }
            //find avg commission
            else
            {
                arvm.BnBAvgCommission = TotalCommission / SelectedReservations.Count;
            }

            arvm.BnBSelectedProperties = NumProperties;

            List<Reservation> AllBnBReservations = new List<Reservation>();
            foreach (Reservation r in _context.Reservations.Where(r => r.Status == rStatus.Active))
            {
                AllBnBReservations.Add(r);
            }
            //find how many total reservations there are
            ViewBag.AllReservations = AllBnBReservations.Count();
            return View("AdminReport", arvm);
        }

        //host report to display all of the information
        [Authorize(Roles = "Host")]
        public IActionResult HostReport(HostReportViewModel hpvm)
        {
            // first create a list of every property the host owns
            List<Property> all_properties = new List<Property>();
            foreach (Property property in _context.Properties.Include(p => p.Reservations))
            {
                if (property.HostEmail == User.Identity.Name)
                {
                    all_properties.Add(property);
                }
            }

            Decimal TotalDailyPrice = 0.0m;
            Decimal TotalCleaningRevenue = 0.0m;
            Int32 TotalCompletedReservations = 0;
            Decimal TotalDiscount = 0.0m;

            List<HostReportPropertyViewModel> PVMList = new List<HostReportPropertyViewModel>();
            foreach (Property property in all_properties)
            {
                HostReportPropertyViewModel newPVM = new HostReportPropertyViewModel();
                Decimal newPVMStayRevenue = 0.0m;
                Decimal newPVMCleaningFees = 0.0m;
                Int32 newPVMCompletedReservations = 0;
                Decimal newPVMDiscount = 0.0m;

                foreach (Reservation reservation in property.Reservations)
                {
                    if (reservation.Status == rStatus.Active)
                    {
                        newPVMStayRevenue += reservation.TotalPrice;
                        newPVMCleaningFees += reservation.CleaningFee;
                        newPVMDiscount = reservation.Discount;
                        newPVMCompletedReservations += 1;
                    }

                }
                TotalDailyPrice += newPVMStayRevenue;
                TotalCleaningRevenue += newPVMCleaningFees;
                TotalCompletedReservations += newPVMCompletedReservations;
                TotalDiscount += newPVMDiscount;
                newPVM.Report = hpvm;
                newPVM.pTotalStayRevenue = newPVMStayRevenue;
                newPVM.pTotalCleaningFees = newPVMCleaningFees;
                newPVM.pCompletedReservations = newPVMCompletedReservations;
                newPVM.pTotalDiscount = newPVMDiscount;
                newPVM.property = property;
                PVMList.Add(newPVM);
            }
            hpvm.TotalCleaningFees = TotalCleaningRevenue;
            hpvm.TotalHostDiscount = TotalDiscount;
            hpvm.TotalDailyPrice = TotalDailyPrice;
            Decimal TotalStayRevenue = TotalDailyPrice - TotalDiscount;
            hpvm.TotalStayRevenue = TotalStayRevenue;
            hpvm.TotalHostStayRevenue = 0.90m * TotalStayRevenue;
            hpvm.HostPayout = 0.90m * TotalStayRevenue + TotalCleaningRevenue;
            hpvm.CompletedReservations = TotalCompletedReservations;
            hpvm.IndividualPropertyReports = PVMList;

            List<Reservation> AllReservations = new List<Reservation>();
            foreach (Reservation r in _context.Reservations.Where(r => r.Property.HostEmail == User.Identity.Name && r.Status == rStatus.Active))
            {
                AllReservations.Add(r);
            }    
            //find how many total reservations there are
            ViewBag.AllReservations = AllReservations.Count();
            return View("HostReport", hpvm);
        }


        // HOSTREPORTSEARCH 
        // GET: Properties/HostReportSearch
        [Authorize(Roles = "Host")]
        public IActionResult HostReportSearch()
        {
            // this allows admins to see dropdown list of all categories when searching for different things
            ViewBag.AllCategories = GetSelectAllCategories();
            return View();
        }

        //POST: Properties/HostReportSearch
        //Host report to for specific search
        [Authorize(Roles = "Host")]
        [HttpPost]
        public ActionResult HostReportSearch(int SelectedCategory, PropertySearchViewModel psvm)
        {

            // create a query
            var reservationsQuery = from r in _context.Reservations
                                    join p in _context.Properties
                                    on r.Property.PropertyID equals p.PropertyID
                                    join c in _context.Categories
                                    on p.Category.CategoryID equals c.CategoryID
                                    select r;
            var propertiesQuery = from p in _context.Properties
                                  join c in _context.Categories
                                  on p.Category.CategoryID equals c.CategoryID
                                  select p;
            // find logged in user
            AppUser userLoggedIn = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            propertiesQuery = propertiesQuery.Where(p => p.HostEmail == userLoggedIn.Email);

            try
            {
                psvm.CalcSearchDates();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.AllCategories = GetSelectAllCategories();
                //TODO: Change the name of the view it returns
                return View("HostReportSearch", psvm);
            }

            if ((psvm.SearchCheckIn != null) && (psvm.SearchCheckOut != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.CheckInDate >= psvm.SearchCheckIn && r.CheckOutDate <= psvm.SearchCheckOut && r.Status == rStatus.Active);

            }
            else
            {
                reservationsQuery = reservationsQuery.Where(r => r.Status == rStatus.Active);
            }
            // query to check search by Category
            // -1 means they chose all categories
            // cannot select multiple categories at a time right now -- Do we need this functionality???
            if (SelectedCategory != -1)
            {
                Category dbCategory = _context.Categories.FirstOrDefault(c => c.CategoryID == SelectedCategory);
                reservationsQuery = reservationsQuery.Where(r => r.Property.Category.CategoryID == dbCategory.CategoryID);
                propertiesQuery = propertiesQuery.Where(p => p.Category.CategoryID == dbCategory.CategoryID);
            }

            // query to check search by City
            if (psvm.SearchCity != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.City == psvm.SearchCity);
                propertiesQuery = propertiesQuery.Where(p => p.City == psvm.SearchCity);
            }

            // query to check search by State
            if (psvm.SearchState != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.State == psvm.SearchState);
                propertiesQuery = propertiesQuery.Where(p => p.State == psvm.SearchState);
            }

            // query to check search by Average Guest Rating
            if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating >= psvm.SearchGuestRatingMin && r.Property.AverageRating <= psvm.SearchGuestRatingMax);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMin);
            }
            else if ((psvm.SearchGuestRatingMax != null) && (psvm.SearchGuestRatingMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating <= psvm.SearchGuestRatingMax);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMax);
            }
            else if ((psvm.SearchGuestRatingMin != null) && (psvm.SearchGuestRatingMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.AverageRating >= psvm.SearchGuestRatingMin);
                propertiesQuery = propertiesQuery.Where(p => p.AverageRating == psvm.SearchGuestRatingMin);
            }

            // query to check search by Number of Guests
            if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests >= psvm.SearchNumGuestsMin && r.Property.NumberGuests <= psvm.SearchNumGuestsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin && p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMax != null) && (psvm.SearchNumGuestsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests <= psvm.SearchNumGuestsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests <= psvm.SearchNumGuestsMax);
            }
            else if ((psvm.SearchNumGuestsMin != null) && (psvm.SearchNumGuestsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberGuests >= psvm.SearchNumGuestsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberGuests >= psvm.SearchNumGuestsMin);
            }

            // query to check search by Weekend Price
            if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax != null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin && p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMax != null) && (psvm.SearchWeekendPriceMin == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend <= psvm.SearchWeekendPriceMax);
            }
            else if ((psvm.SearchWeekendPriceMin != null) && (psvm.SearchWeekendPriceMax == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekend >= psvm.SearchWeekendPriceMin);
            }

            // query to check search by Weekday Price
            if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax != null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin && p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMax != null) && (psvm.SearchWeekdayPriceMin == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday <= psvm.SearchWeekdayPriceMax);
            }
            else if ((psvm.SearchWeekdayPriceMin != null) && (psvm.SearchWeekdayPriceMax == null))
            {
                reservationsQuery = reservationsQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
                propertiesQuery = propertiesQuery.Where(p => p.PricePerWeekday >= psvm.SearchWeekdayPriceMin);
            }

            // query to check search by Number of Beds
            if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed >= psvm.SearchNumBedsMin && r.Property.NumberBed <= psvm.SearchNumBedsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed >= psvm.SearchNumBedsMin && p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMax != null) && (psvm.SearchNumBedsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed <= psvm.SearchNumBedsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed <= psvm.SearchNumBedsMax);
            }
            else if ((psvm.SearchNumBedsMin != null) && (psvm.SearchNumBedsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBed >= psvm.SearchNumBedsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBed >= psvm.SearchNumBedsMin);
            }

            // query to check search by Number of Baths
            if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax != null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath >= psvm.SearchNumBathsMin && r.Property.NumberBath <= psvm.SearchNumBathsMax);
                propertiesQuery = propertiesQuery.Where(p => p.State == psvm.SearchState);
            }
            else if ((psvm.SearchNumBathsMax != null) && (psvm.SearchNumBathsMin == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath <= psvm.SearchNumBathsMax);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBath <= psvm.SearchNumBathsMax);
            }
            else if ((psvm.SearchNumBathsMin != null) && (psvm.SearchNumBathsMax == null))
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.NumberBath >= psvm.SearchNumBathsMin);
                propertiesQuery = propertiesQuery.Where(p => p.NumberBath >= psvm.SearchNumBathsMin);
            }

            // query to check search by Pet Policy
            if (psvm.SearchPetsAllowed != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.PetsAllowed == psvm.SearchPetsAllowed);
                propertiesQuery = propertiesQuery.Where(p => p.PetsAllowed == psvm.SearchPetsAllowed);
            }

            // query to check search by Free Parking Availability
            if (psvm.SearchFreeParking != null)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Property.FreeParking == psvm.SearchFreeParking);
                propertiesQuery = propertiesQuery.Where(p => p.FreeParking == psvm.SearchFreeParking);
            }


            //just make sure property is available and approved
            propertiesQuery = propertiesQuery.Where(p => p.ApprovalStatus == pStatus.Active);
            propertiesQuery = propertiesQuery.Where(p => p.Status == pStatus.Active);

            // use the .ToList() method to execute the query
            // add an include statement so that you get the navigational data
            List<Property> SelectedProperties = propertiesQuery.ToList();
            List<Property> PropertiesWithReservations = new List<Property>();
            List<Reservation> SelectedReservations = reservationsQuery.ToList();

            foreach (Property p in SelectedProperties)
            {
                Int32 Seen = 0;
                foreach (Reservation r in p.Reservations)
                {
                    foreach (Reservation r2 in SelectedReservations)
                    {
                        if (r.ReservationID == r2.ReservationID)
                        {
                            Seen += 1;
                        }
                    }
                }
                if (Seen > 0)
                {
                    PropertiesWithReservations.Add(p);
                }

            }

            HostReportViewModel hpvm = new HostReportViewModel();


            //use the selected properties to calculate admin report data
            List<Reservation> SelectedPropertyReservations = new List<Reservation>();


            Decimal TotalCleaningRevenue = 0.0m;
            Int32 TotalCompletedReservations = 0;
            Decimal TotalDiscount = 0.0m;
            Decimal TotalDailyPrice = 0.0m;

            // List to hold the PVM
            List<HostReportPropertyViewModel> PVMList = new List<HostReportPropertyViewModel>();
            List<Property> removeDupes = new List<Property>();
            foreach (Property p in SelectedProperties)
            {
                if (removeDupes.Contains(p) == false)
                {
                    removeDupes.Add(p);
                }
            }
            foreach (Property property in SelectedProperties)
            {
                HostReportPropertyViewModel newPVM = new HostReportPropertyViewModel();
                Decimal newPVMStayRevenue = 0.0m;
                Decimal newPVMCleaningFees = 0.0m;
                Int32 newPVMCompletedReservations = 0;
                Decimal newPVMDiscount = 0.0m;

                foreach (Reservation reservation in property.Reservations)
                {
                    if (reservation.Status == rStatus.Active && SelectedReservations.Contains(reservation))
                    {
                        newPVMStayRevenue += reservation.TotalPrice;
                        newPVMCleaningFees += reservation.CleaningFee;
                        newPVMDiscount = reservation.Discount;
                        newPVMCompletedReservations += 1;
                    }
                }
                TotalDailyPrice += newPVMStayRevenue;
                TotalCleaningRevenue += newPVMCleaningFees;
                TotalCompletedReservations += newPVMCompletedReservations;
                TotalDiscount += newPVMDiscount;
                newPVM.Report = hpvm;
                // TODO: check if total stay revenue subtracts discount
                newPVM.pTotalStayRevenue = newPVMStayRevenue - newPVMDiscount;
                newPVM.pTotalCleaningFees = newPVMCleaningFees;
                newPVM.pCompletedReservations = newPVMCompletedReservations;
                newPVM.pTotalDiscount = newPVMDiscount;
                newPVM.property = property;
                PVMList.Add(newPVM);
            }
            hpvm.TotalCleaningFees = TotalCleaningRevenue;
            hpvm.TotalHostDiscount = TotalDiscount;
            hpvm.TotalDailyPrice = TotalDailyPrice;
            Decimal TotalStayRevenue = TotalDailyPrice - TotalDiscount;
            hpvm.TotalStayRevenue = TotalStayRevenue;
            hpvm.TotalHostStayRevenue = 0.90m * TotalStayRevenue;
            hpvm.HostPayout = 0.90m * TotalStayRevenue + TotalCleaningRevenue;
            hpvm.CompletedReservations = TotalCompletedReservations;
            hpvm.IndividualPropertyReports = PVMList;

            List<Reservation> AllReservations = new List<Reservation>();
            foreach (Reservation r in _context.Reservations.Where(r => r.Property.HostEmail == User.Identity.Name && r.Status == rStatus.Active))
            {
                AllReservations.Add(r);
            }
            //find how many total reservations there are
            ViewBag.AllReservations = AllReservations.Count();
            return View("HostReport", hpvm);
        }



    }
}