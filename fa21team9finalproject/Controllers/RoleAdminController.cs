using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace fa21team9finalproject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        //create private variables for the services needed in this controller
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        //RoleAdminController constructor
        public RoleAdminController(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //populate the values of the variables passed into the controller
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /RoleAdmin/
        //DONE
        public async Task<ActionResult> Index()
        {
            //Create a list of roles that will need to be edited
            List<RoleEditModel> roles = new List<RoleEditModel>();

            //loop through each of the existing roles
            foreach (IdentityRole role in _roleManager.Roles)
            {
                //this is a list of all the users who ARE in this role (members)
                List<AppUser> RoleMembers = new List<AppUser>();

                //this is a list of all the users who ARE NOT in this role (non-members)
                List<AppUser> RoleNonMembers = new List<AppUser>();

                //loop through ALL the users and decide if they are in the role(member) or not (non-member)
                //every user will be evaluated for every role, so this is a SLOW chunk of code because
                //it accesses the database so many times
                foreach (AppUser user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name) == true) //user is in the role
                    {
                        //add user to list of members
                        RoleMembers.Add(user);
                    }
                    else //user is NOT in the role
                    {
                        //add user to list of non-members
                        RoleNonMembers.Add(user);
                    }
                }

                //create a new instance of the role edit model
                RoleEditModel rem = new RoleEditModel();

                //populate the properties of the role edit model
                rem.Role = role; //role from database
                rem.RoleMembers = RoleMembers; //list of users in this role
                rem.RoleNonMembers = RoleNonMembers; //list of users NOT in this role

                //add this role to the list of role edit models
                roles.Add(rem);
            }

            //pass the list of roles to the view
            return View(roles);
        }

        // GET: RoleAdmin/EditRole
        //DONE
        public async Task<ActionResult> EditRole(string id)
        {
            //NOTE: first, we separate users by the role we want to edit
            //this is essentially narrowing down the datapool of users

            //look up the role requested by the user
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            //create a list for the members of the role
            List<AppUser> RoleMembers = new List<AppUser>();

            //create a list for the non-members of the role
            List<AppUser> RoleNonMembers = new List<AppUser>();

            //through ALL the users and decide if they are in the role(member) or not (non-member)
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name) == true) //user is in the role
                {
                    //add the user to the list of members
                    RoleMembers.Add(user);
                }
                else //user is NOT in the role
                {
                    RoleNonMembers.Add(user);
                }
            }

            //NOTE: then we want to specify who is active and inactive
            //this is just sorting the reduced pool found from above

            //create a list for all active members of the role
            List<AppUser> ActiveMembers = new List<AppUser>();

            //create a list for all inactive members of the role
            List<AppUser> InactiveMembers = new List<AppUser>();

            //loop through users in RoleMembers and determine if they are active or inactive
            foreach (AppUser user in RoleMembers)
            {
                if (user.IsActive == aStatus.Active) //user is active
                {
                    //add the user to the list of active members
                    ActiveMembers.Add(user);
                }
                else //user is NOT active (inactive)
                {
                    InactiveMembers.Add(user);
                }
            }

            //create a new instance of the active profile edit model
            ActiveProfileEditModel apem = new ActiveProfileEditModel();

            //populate the properties of the active profile edit model
            apem.Role = role; //role looked up from database
            apem.ActiveMembers = ActiveMembers; //list of active users
            apem.InactiveMembers = InactiveMembers; //list of inactive users

            //send user to view with populated role edit model
            return View(apem);
        }

        // POST: RoleAdmin/EditRole
        //DONE
        [HttpPost]
        public async Task<ActionResult> EditRole(ActiveModificationModel amm)
        {
            //if RoleModificationModel is valid, add new users
            if (ModelState.IsValid)
            {
                //if there are users to make inactive (terminate for admins), inactivate them
                if (amm.IdsToInactivate != null)
                {
                    //loop through all the ids to make inactive
                    foreach (string userId in amm.IdsToInactivate)
                    {
                        //find the user in the database using their id
                        AppUser user = await _userManager.FindByIdAsync(userId);

                        // attempt to change activity status of user
                        try
                        {
                            user.IsActive = aStatus.notActive;
                            //save the changes
                            _context.Update(user);
                            _context.SaveChanges();
                        }
                        // if attempt did not work, show user the error page
                        catch (Exception ex)
                        {
                            return View("Error", ex);
                        }
                    }
                }

                //if there are users to make active (rehire for admins), activate them
                if (amm.IdsToActivate != null)
                {
                    //loop through all the ids to make active
                    foreach (string userId in amm.IdsToActivate)
                    {
                        //find the user in the database using their id
                        AppUser user = await _userManager.FindByIdAsync(userId);

                        // attempt to change activity status of user
                        try
                        {
                            user.IsActive = aStatus.Active;
                            //save the changes
                            _context.Update(user);
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
            return View("Error", new string[] { "Status of Account Not Found" });
        }

        //GET: RoleAdmin/EditProfile
        // this will bring admin to user's profile
        //DONE
        public async Task<IActionResult> EditProfile(string id)
        {
            IndexViewModel ivm = new IndexViewModel();

            //find the user in the database using their id
            AppUser user = await _userManager.FindByIdAsync(id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.FullName = user.FullName;
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FullAddress = user.FullAddress;
            ivm.PhoneNumber = user.PhoneNumber;
            ivm.Birthday = user.Birthday;

            //send data to the view
            return View(ivm);
        }

        // GET: RoleAdmin/ApproveProperties
        //DONE
        public ActionResult ApproveProperties(string id)
        {
            //NOTE: first, we separate properties by whether they have been approved or not

            //create a list for the properties that have been approved
            List<Property> ApprovedProperties = new List<Property>();

            //create a list for the properties that have not been approved
            List<Property> NotApprovedProperties = new List<Property>();

            // loop through ALL the properties that are active (not deleted) and decide if they have or have not been approved yet
            foreach (Property property in _context.Properties.Include(p => p.Category).Where(p => p.Status == pStatus.Active))
            {
                if (property.ApprovalStatus == pStatus.Active) //property has been approved already
                {
                    //add the user to the list of members
                    ApprovedProperties.Add(property);
                }
                else //property has not been approved yet
                {
                    NotApprovedProperties.Add(property);
                }
            }

            //create a new instance of the approve properties model
            ApprovePropertiesModel apm = new ApprovePropertiesModel();

            //populate the properties of the approve properties model
            apm.ApprovedProperties = ApprovedProperties; //list of approved properties
            apm.NotApprovedProperties = NotApprovedProperties; //list of not approved properties

            //send user to view with populated approve properties model
            return View(apm);
        }

        // POST: RoleAdmin/ApproveProperties
        //DONE
        [HttpPost]
        public ActionResult ApproveProperties(PropertyApprovalModificationModel pamm)
        {
            //if PropertyApprovalModificationModel is valid, approve/disapprove properties
            if (ModelState.IsValid)
            {
                //if there are properties to approve, approve them
                if (pamm.IdsApproved != null)
                {
                    //loop through all the ids to make active
                    foreach (Int32 propertyId in pamm.IdsApproved)
                    {
                        //find the property in the database using their id
                        Property property = _context.Properties.FirstOrDefault(p => p.PropertyID == propertyId);

                        // attempt to change approval status of property
                        try
                        {
                            property.ApprovalStatus = pStatus.Active;
                            //save the changes
                            _context.Update(property);
                            _context.SaveChanges();
                        }
                        // if attempt did not work, show user the error page
                        catch (Exception ex)
                        {
                            return View("Error", ex);
                        }
                    }
                }

                //if there are users to make active (rehire for admins), activate them
                if (pamm.IdsNotApproved != null)
                {
                    //loop through all the ids to make active
                    foreach (Int32 propertyId in pamm.IdsNotApproved)
                    {
                        //find the property in the database using their id
                        Property property = _context.Properties.FirstOrDefault(p => p.PropertyID == propertyId);

                        // attempt to change activity status of user
                        try
                        {
                            property.ApprovalStatus = pStatus.notActive;
                            //save the changes
                            _context.Update(property);
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
                return RedirectToAction("ApproveProperties");
            }
            //this is a sad path - the status was not found
            //show the user the error page
            return View("Error", new string[] { "Status of Property Not Found" });
        }





        //TODO: delete????
        /***********************

        // GET: RoleAdmin/Create
        // this page creates allows admin to create a new role
        public ActionResult Create() 
        {
            return View();
        }

        // POST: RoleAdmin/Create
        // this page creates the new role
        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                //attempt to create the new role using the role manager
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                //if the role was created successfully, take the user to the index page
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else //role was not added succesfully, so add errors to model 
                //and let the user try again
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            //if code gets this far, we need to show an error
            return View(name);
        }

        
        //GET: RoleAdmin/EditUsers
        public async Task<ActionResult> EditUsers(string id)
        {
            //look up the role requested by the user
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            //create a list for the members of the role
            List<AppUser> RoleMembers = new List<AppUser>();

            //through ALL the users and decide if they are in the role(member)
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name) == true) //user is in the role
                {
                    //add the user to the list of members
                    RoleMembers.Add(user);
                }
            }

            //create a new instance of the role edit model
            RoleEditModel rem = new RoleEditModel();

            //populate the properties of the role edit model
            rem.Role = role; //role looked up from database
            rem.RoleMembers = RoleMembers; //list of users in the role

            //send user to view with populated role edit model
            return View(rem);
        }


        ***********************/





    }
}