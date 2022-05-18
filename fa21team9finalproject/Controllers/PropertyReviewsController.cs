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

//I BELIEVE THIS CONTROLLER IS DONE
//PLS DON'T MESS WITH IT UNTIL YOU TEST AND STUFF IS BROKEN
namespace fa21team9finalproject.Controllers
{
    public class PropertyReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public PropertyReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PropertyReviews
        //DONE
        // a property will always be passed through when you want to view PropertyReviews/Index page
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Specify a property to view!" });
            }

            // creates list of properties joining categories and assigns that to Properties variable
            List<Property> Properties = _context.Properties.Include(p => p.Category).Include(p => p.PropertyReviews).ToList();

            // finds the desired property using id from the Properties list
            Property property = Properties.FirstOrDefault(m => m.PropertyID == id);
            Int32 pid = property.PropertyID;
            property.CheckRating();

            // create list of reviews that will need to be viewed (tied to property specified)
            List<PropertyReview> reviews = new List<PropertyReview>();

            // go through all property reviews and add to list above if for the property specified by id
            foreach (PropertyReview review in _context.PropertyReviews)
            {
                if (review.Property.PropertyID == pid)
                {
                    reviews.Add(review);
                }
            }

            // return a ViewBag if there are no reviews to this property
            if (property.PropertyReviews.Count == 0)
            {
                ViewBag.noResults = "No review has been made for this property yet.";
            }
            // returns viewbag to list property address
            ViewBag.Property = property.FullAddress;
            ViewBag.AverageRating = property.AverageRating;
            // returns Index view populated with reviews tied to the property
            return View(reviews);
        }

        // GET: PropertyReviews/Details/5
        // page that allows user to see list of reviews that they have made
        
        [Authorize(Roles = "Customer")]
        public IActionResult Details()
        {
            AppUser userLoggedIn = _context.Users.Include(u => u.Orders).ThenInclude(o => o.Reservations).ThenInclude(r => r.Property).Include(u => u.PropertyReviews).FirstOrDefault(u => u.UserName == User.Identity.Name);

            // find property reviews associated with logged in user
            List<PropertyReview> userReviews = new List<PropertyReview>();

            foreach (PropertyReview pr in _context.PropertyReviews.Include(pr => pr.User).Include(pr => pr.Property))
            {
                if (pr.User.Email == userLoggedIn.Email)
                {
                    //add property review to list of user reviews
                    userReviews.Add(pr);
                }
            }

            return View(userReviews);
        }

        // GET: PropertyReviews/Create
        // propertyID is passed through
        //DONE
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                View("Error", new String[] { "Please specify a property to review!" });
            }

            AppUser userLoggedIn = _context.Users.Include(u => u.Orders).ThenInclude(o => o.Reservations).ThenInclude(r => r.Property).Include(u => u.PropertyReviews).FirstOrDefault(u => u.UserName == User.Identity.Name);

            //find property using propertyID
            Property property = _context.Properties.Include(p => p.Reservations).Include(p => p.PropertyReviews).FirstOrDefault(p => p.PropertyID == id);

            //list to hold reservations at this property - flag variable to check
            List<Reservation> ReservationsOnProperty = new List<Reservation>();

            //make sure the current user has made a reservation at this property
            foreach (Order order in userLoggedIn.Orders.Where(o => o.Status == oStatus.Confirmed))
            {
                foreach (Reservation reservation in order.Reservations.Where(r => r.Status == rStatus.Active))
                {
                    if (reservation.Property.PropertyID == property.PropertyID)
                    {
                        ReservationsOnProperty.Add(reservation);
                    }
                }
            }

            // user has NOT stayed at this property before
            if (ReservationsOnProperty.Count == 0)
            {
                return View("Error", new String[] { "You can't leave a review on a property before you have stayed at the property!" });
            }

            //if user makes it this far, they have not made a review yet
            //show them the create review page
            ViewBag.PropertyAddress = property.FullAddress;
            ViewBag.PropertyID = property.PropertyID;
            return View();
        }

        // POST: PropertyReviews/Create
        //DONE
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("PropertyReviewID,Rating,Review")] PropertyReview propertyReview, int PropertyID)
        {
            //find property associated with propertyID
            Property property = _context.Properties.FirstOrDefault(p => p.PropertyID == PropertyID);

            if (ModelState.IsValid == false)
            {
                //creating didn't work
                ViewBag.PropertyID = property.PropertyID;
                ViewBag.PropertyAddress = property.FullAddress;
                return View(propertyReview);
            }
            
            AppUser userLoggedIn = _context.Users.Include(u => u.Orders).ThenInclude(o => o.Reservations).ThenInclude(r => r.Property).FirstOrDefault(u => u.UserName == User.Identity.Name);

            //specify things for propertyReview
            propertyReview.User = userLoggedIn;
            propertyReview.Property = property;
            propertyReview.dStatus = disputeStatus.notViewedYet;

            //search through database and see if user has already made a review for this property
            //replace this new review for the old one if they have
            List<PropertyReview> PreviousPRs = _context.PropertyReviews.Include(pr => pr.User).Include(pr => pr.Property).Where(pr => pr.Property.PropertyID == propertyReview.Property.PropertyID && pr.User.Email == userLoggedIn.Email).ToList();

            foreach (PropertyReview oldPR in PreviousPRs)
            {
                // change old review to have a dispute status of accepted, so it's no longer shown on the property
                oldPR.dStatus = disputeStatus.Accepted;
            }
            //add new property review to database and return user to list of reservations
            _context.Add(propertyReview);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Reservations");
        }

        // GET: PropertyReviews/Edit/5
        //TODO: done but not tested yet
        //passes in a property review id so we know which to edit
        [Authorize(Roles = "Customer")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                View("Error", new String[] { "Please specify a review to edit!" });
            }

            //find property review associated with this
            PropertyReview propertyReview =  _context.PropertyReviews.FirstOrDefault(pr => pr.PropertyReviewID == id);

            if (propertyReview == null)
            {
                View("Error", new String[] { "Review not found!" });
            }

            //property review can only be edited if status is notViewedyet
            if (propertyReview.dStatus == disputeStatus.inDispute)
            {
                View("Error", new String[] { "This property review is being disputed by the host and cannot be edited." });
            }
            if (propertyReview.dStatus == disputeStatus.Accepted)
            {
                View("Error", new String[] { "This property review has been rejected and cannot be edited." });
            }
            return View(propertyReview);
        }

        // POST: PropertyReviews/Edit/5
        //TODO: think this is done but hasn't been tested
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyReviewID,Rating,Review")] PropertyReview propertyReview)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    propertyReview.dStatus = disputeStatus.notViewedYet;
                    _context.Update(propertyReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyReviewExists(propertyReview.PropertyReviewID))
                    {
                        View("Error", new String[] { "This property review is cannot be found." });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details");
            }
            //not valid
            @ViewBag.ErrorMessage = "There was an error updating this review.";
            return View(propertyReview);
        }

        // GET: PropertyReviews/Delete/5
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                View("Error", new String[] { "Please specify a review to delete!" });
            }

            PropertyReview propertyReview = _context.PropertyReviews.Include(pr => pr.Property).Include(pr => pr.User).FirstOrDefault(pr => pr.PropertyReviewID == id);

            if (propertyReview == null)
            {
                View("Error", new String[] { "The property review could not be found." });
            }

            propertyReview.dStatus = disputeStatus.Accepted;
            _context.Update(propertyReview);
            await _context.SaveChangesAsync();
            //update property average rating
            propertyReview.Property.CheckRating();
            _context.Update(propertyReview.Property);
            _context.SaveChanges();

            if (User.IsInRole("Admin"))
            {
                //return admin to admindetails page
                return View("DetailsAdmin");
            }
            else
            {
                //return user to view of all property reviews
                return RedirectToAction("Index", "Reservations", new { Message = "Review successfully deleted!" });
            }
            
        }

        // GET: PropertyReviews/Dispute/5
        //DONE
        [Authorize(Roles = "Host")]
        public IActionResult DisputeHost(int? id)
        {
            if (id == null)
            {
                View("Error", new String[] { "Please specify a review to dispute!" });
            }

            PropertyReview propertyReview = _context.PropertyReviews.FirstOrDefault(pr => pr.PropertyReviewID == id);

            if (propertyReview == null)
            {
                View("Error", new String[] { "The property review could not be found." });
            }

            //all is good, so send host to the create dispute page
            return View(propertyReview);

            //return user to view of all property reviews
            //return View("Index", new { id = propertyReview.PropertyReviewID });
        }

        // POST: PropertyReviews/Dispute/5
        //TODO: think this is done but hasn't been tested
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> DisputeHost([Bind("PropertyReviewID,Rating,Review,Dispute")] PropertyReview propertyReview)
        {
            // find property review associated with this passed in property review to include Property
            PropertyReview pr = _context.PropertyReviews.Include(pr => pr.Property).Include(pr => pr.User).FirstOrDefault(pr => pr.PropertyReviewID == propertyReview.PropertyReviewID);
            pr.Dispute = propertyReview.Dispute;

            if (ModelState.IsValid)
            {
                try
                {
                    pr.dStatus = disputeStatus.inDispute;
                    _context.Update(pr);
                    await _context.SaveChangesAsync();
                    //update property average rating to remove this review from average score
                    pr.Property.CheckRating();
                    _context.Update(pr.Property);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyReviewExists(propertyReview.PropertyReviewID))
                    {
                        View("Error", new String[] { "This property review is cannot be found." });
                    }
                    else
                    {
                        throw;
                    }
                }
                //returns host to properties index if all is good
                return RedirectToAction("Index", "Reservations", new { Message = "Review has been successfully disputed!"});
            }
            //not valid
            @ViewBag.ErrorMessage = "There was an error saving your dispute request for this review.";
            return RedirectToAction("DisputeHost", propertyReview);
        }

        private bool PropertyReviewExists(int id)
        {
            return _context.PropertyReviews.Any(e => e.PropertyReviewID == id);
        }

        //GET: PropertyReviews/DetailsAdmin
        //shows the page that lists all reviews in dispute that admin can check out
        [Authorize(Roles = "Admin")]
        public IActionResult DetailsAdmin()
        {
            List<PropertyReview> PropertyReviews = _context.PropertyReviews.Include(pr => pr.Property).Include(pr => pr.User).ToList();
            return View(PropertyReviews);
        }

        // POST: PropertyReviews/DetailsAdmin
        //DONE
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsAdmin(DisputeReviewModel drm)
        {
            //if RoleModificationModel is valid, add new users
            if (ModelState.IsValid)
            {
                //if there are reviews to approve
                if (drm.IdstoApprove != null)
                {
                    //loop through all the ids to approve
                    foreach (Int32 prId in drm.IdstoApprove)
                    {
                        //find the review in the database using the id
                        PropertyReview propertyReview = _context.PropertyReviews.Include(pr => pr.Property).FirstOrDefault(pr => pr.PropertyReviewID == prId);

                        // attempt to change dispute status of review
                        try
                        {
                            propertyReview.dStatus = disputeStatus.Accepted;
                            //save the changes
                            _context.Update(propertyReview);
                            _context.SaveChanges();
                            //update property average rating to remove this review from average score
                            propertyReview.Property.CheckRating();
                            _context.Update(propertyReview.Property);
                            _context.SaveChanges();
                        }
                        // if attempt did not work, show user the error page
                        catch (Exception ex)
                        {
                            return View("Error", ex);
                        }
                    }
                }

                //if there are reviews to reject
                if (drm.IdstoReject != null)
                {
                    //loop through all the ids to reject
                    foreach (Int32 prId in drm.IdstoReject)
                    {
                        //find the review in the database using the id
                        PropertyReview propertyReview = _context.PropertyReviews.Include(pr => pr.Property).FirstOrDefault(pr => pr.PropertyReviewID == prId);

                        // attempt to change dispute status of review
                        try
                        {
                            propertyReview.dStatus = disputeStatus.Rejected;
                            //save the changes
                            _context.Update(propertyReview);
                            _context.SaveChanges();
                            //update property average rating
                            propertyReview.Property.CheckRating();
                            _context.Update(propertyReview.Property);
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
                //take the user back to the PropertyReviews DetailsAdmin page
                return RedirectToAction("DetailsAdmin", "PropertyReviews");
            }
            //this is a sad path - the status was not found
            //show the user the error page
            return View("Error", new string[] { "Status of Account Not Found" });
        }
    }
}
