using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
using fa21team9finalproject.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

//I BELIEVE THIS CONTROLLER IS DONE
//PLS DON'T MESS WITH IT UNTIL YOU TEST AND STUFF IS BROKEN
namespace fa21team9finalproject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        //DONE
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // GET: /Account/RegisterHost
        //DONE
        [AllowAnonymous]
        public IActionResult RegisterHost()
        {
            return View();
        }

        // POST: /Account/RegisterHost
        //DONE
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterHost(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //check that age of user is 18 or greater
            try
            {
                rvm.CalcAge();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("RegisterHost", rvm);
            }


            //SENDING EMAIL: sending email when host creates an account
            String emailSubject = "Confirmation Account Email";
            String emailBod = "Thank you for creating an account with BevoBnB!";
            Utilities.EmailMessaging.SendEmail(rvm.Email, emailSubject, emailBod);


            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,

                //TODO: Add the rest of the custom user fields here
                //FirstName is included as an example
                FirstName = rvm.FirstName,
                MI = rvm.MI,
                LastName = rvm.LastName,
                StreetAddress = rvm.StreetAddress,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                Birthday = rvm.Birthday,
                IsActive = aStatus.Active,
                Role = "Host"
            };

            //check if email is already in use
            AppUser dbUser = await _userManager.FindByEmailAsync(newUser.Email);
            if (dbUser != null)
            {
                ViewBag.ErrorMessage = "Oops! There is already a user by this email. Use a different email to create a new account or login.";
                return View("RegisterHost", rvm);
            }

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,
                RoleName = "Host"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            {
                //NOTE: This code logs the user into the account that they just created
                //You may or may not want to log a user in directly after they register - check
                //the business rules!
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);

                //Send the user to the home page
                return RedirectToAction("Index", "Home");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/RegisterCustomer
        //DONE
        [AllowAnonymous]
        public IActionResult RegisterCustomer()
        {
            return View();
        }

        // POST: /Account/RegisterCustomer
        //DONE
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterCustomer(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //check that age of user is 18 or greater
            try
            {
                rvm.CalcAge();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("RegisterCustomer", rvm);
            }

            //SENDING EMAIL: sending email when customer creates an account
            String emailSubject = "Confirmation Account Email";
            String emailBod = "Thank you for creating an account with BevoBnB!";
            Utilities.EmailMessaging.SendEmail(rvm.Email, emailSubject, emailBod);


            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,

                //TODO: Add the rest of the custom user fields here
                //FirstName is included as an example
                FirstName = rvm.FirstName,
                MI = rvm.MI,
                LastName = rvm.LastName,
                StreetAddress = rvm.StreetAddress,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                Birthday = rvm.Birthday,
                IsActive = aStatus.Active,
                Role = "Customer"
            };

            //check if email is already in use
            AppUser dbUser = await _userManager.FindByEmailAsync(newUser.Email);
            if (dbUser != null)
            {
                ViewBag.ErrorMessage = "Oops! There is already a user by this email. Use a different email to create a new account or login.";
                return View("RegisterCustomer", rvm);
            }

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,
                RoleName = "Customer"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            {
                //NOTE: This code logs the user into the account that they just created
                //You may or may not want to log a user in directly after they register - check
                //the business rules!
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);

                //Send the user to the home page
                return RedirectToAction("Index", "Home");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/RegisterAdmin
        //DONE
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        // POST: /Account/RegisterAdmin
        //DONE
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAdmin(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //check that age of user is 18 or greater
            try
            {
                rvm.CalcAge();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("RegisterAdmin", rvm);
            }

            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,

                //TODO: Add the rest of the custom user fields here
                //FirstName is included as an example
                FirstName = rvm.FirstName,
                MI = rvm.MI,
                LastName = rvm.LastName,
                StreetAddress = rvm.StreetAddress,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                Birthday = rvm.Birthday,
                IsActive = aStatus.Active, // for admin, this means the employee is hired
                Role = "Admin"
            };

            //check if email is already in use
            AppUser dbUser = await _userManager.FindByEmailAsync(newUser.Email);
            if (dbUser != null)
            {
                ViewBag.ErrorMessage = "Oops! There is already a user by this email. Use a different email to create a new account or login.";
                return View("RegisterAdmin", rvm);
            }

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,
                RoleName = "Admin"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            {
                //TODO: send user an email that an account has been created for them

                //Send the user to edit admin page
                // find role of user
                return RedirectToAction("Index", "RoleAdmin");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }
            AppUser user = await _userManager.FindByEmailAsync(lvm.Email);

            if (user == null)
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt. This email is not registered in our system. Please register a new user or sign in under a different email.");
                //send user back to login page to try again
                return View(lvm);
            }

            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            // if user is not active, add error message to model to show invalid login
            if (user.IsActive == aStatus.notActive)
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt. This profile is no longer active.");
                //send user back to login page to try again
                return View(lvm);
            }

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                //this means that the user profile is a profile in the system
                //however, all inactive profiles should not be able to log in
                //check if profile is inactive

                //find the user in the database using their email

                // if user is not active, add error message to model to show invalid login
                if (user.IsActive == aStatus.notActive)
                {
                    //add an error to the model to show invalid attempt
                    ModelState.AddModelError("", "Invalid login attempt. This profile is no longer active.");
                    //send user back to login page to try again
                    return View(lvm);
                }
                else
                {
                    //return ?? "/" means if returnUrl is null, substitute "/" (home)
                    return Redirect(returnUrl ?? "/");
                }
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        //GET: Account/Index
        //DONE
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

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

        //Logic for change address
        // GET: /Account/ChangeAddress
        //DONE
        public IActionResult ChangeAddress(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .FirstOrDefault(u => u.Email == id);

            // case if registration not found in the database
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            //registration does not belong to this user
            if ((User.IsInRole("Customer") || User.IsInRole("Host")) && user.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this profile!" });
            }

            return View(user);
        }

        // POST: Account/ChangeAddress
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //DONE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeAddress(string id, [Bind("Email,StreetAddress,City,State,ZipCode")] AppUser user)
        {
            string loggedInUser = User.Identity.Name;

            //if code gets this far, update the record
            try
            {
                //find the user in the database
                AppUser dbuser = await _userManager.FindByEmailAsync(user.Email);

                //update the user's address
                dbuser.StreetAddress = user.StreetAddress;
                dbuser.City = user.City;
                dbuser.State = user.State;
                dbuser.ZipCode = user.ZipCode;

                // save changes
                _context.Update(dbuser);
                await _context.SaveChangesAsync();

                // return user to respective account profile page
                if (loggedInUser == user.Email)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    return RedirectToAction("EditProfile", "RoleAdmin", new { id = dbuser.Id });
                }
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this profile!", ex.Message });
            }
        }

        //Logic for change name
        // GET: /Account/ChangeName
        //DONE
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeName(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .FirstOrDefault(u => u.Email == id);

            // case if registration not found in the database
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            return View(user);
        }

        // POST: Account/ChangeName
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //DONE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeName(string id, [Bind("Email,FirstName,MI,LastName")] AppUser user)
        {
            string loggedInUser = User.Identity.Name;

            //if code gets this far, update the record
            try
            {
                //find the user in the database
                AppUser dbuser = await _userManager.FindByEmailAsync(user.Email);

                //update the user's name
                dbuser.FirstName = user.FirstName;
                dbuser.MI = user.MI;
                dbuser.LastName = user.LastName;

                //save changes
                _context.Update(dbuser);
                await _context.SaveChangesAsync();

                //return admin to user edit profile page
                return RedirectToAction("EditProfile", "RoleAdmin", new { id = dbuser.Id });
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this profile!", ex.Message });
            }
        }

        //Logic for change phone number
        // GET: /Account/ChangePhoneNumber
        //DONE
        public IActionResult ChangePhoneNumber(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .FirstOrDefault(u => u.Email == id);

            // case if registration not found in the database
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            return View(user);
        }

        // POST: Account/ChangePhoneNumber
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //DONE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePhoneNumber(string id, [Bind("Email,PhoneNumber")] AppUser user)
        {
            string loggedInUser = User.Identity.Name;

            //if code gets this far, update the record
            try
            {
                //find the user in the database
                AppUser dbuser = await _userManager.FindByEmailAsync(user.Email);

                //update the user's phone number
                dbuser.PhoneNumber = user.PhoneNumber;

                //save changes
                _context.Update(dbuser);
                await _context.SaveChangesAsync();

                // return user to respective account profile page
                if (loggedInUser == user.Email)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    return RedirectToAction("EditProfile", "RoleAdmin", new { id = dbuser.Id });
                }
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this profile!", ex.Message });
            }
        }

        //Logic for change birthday
        // GET: /Account/ChangeBirthday
        //DONE
        public IActionResult ChangeBirthday(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .FirstOrDefault(u => u.Email == id);

            // case if registration not found in the database
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            return View(user);
        }

        // POST: Account/ChangeBirthday
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //DONE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeBirthday(string id, [Bind("Email,Birthday")] AppUser user)
        {
            string loggedInUser = User.Identity.Name;

            //check that age of user is 18 or greater with updated birthday
            try
            {
                ChangeBirthdayViewModel cbvm = new ChangeBirthdayViewModel();
                cbvm.NewBirthday = user.Birthday;
                cbvm.CalcAge();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this profile!", ex.Message });
            }

            //if code gets this far, update the record
            try
            {
                //find the user in the database
                AppUser dbuser = await _userManager.FindByEmailAsync(user.Email);

                //update the user's birthday
                dbuser.Birthday = user.Birthday;

                //save changes
                _context.Update(dbuser);
                await _context.SaveChangesAsync();

                // return user to respective account profile page
                if (loggedInUser == user.Email)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    return RedirectToAction("EditProfile", "RoleAdmin", new { id = dbuser.Id });
                }
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this profile!", ex.Message });
            }
        }

        //Logic for change password
        // GET: /Account/ChangePassword
        //DONE — given by Katie
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        //DONE — given by Katie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using ,the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }





        //Logic for admin changing other people's password
        // GET: /Account/AdminChangePassword
        //
        [Authorize(Roles = "Admin")]
        public IActionResult AdminChangePassword(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .FirstOrDefault(u => u.Email == id);

            // case if registration not found in the database
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            // create new instance of ChangePassword
            ChangePasswordViewModel cpvm = new ChangePasswordViewModel();

            //update cpvm with parallel variables from user
            cpvm.Email = user.Email;
            cpvm.FullName = user.FullName;

            return View(cpvm);
        }

        // POST: Account/AdminChangePassword
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminChangePassword(string id, [Bind("Email,NewPassword")] ChangePasswordViewModel cpvm)
        {
            //find the user in the database
            AppUser dbuser = await _userManager.FindByEmailAsync(cpvm.Email);

            // generate password reset token
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(dbuser);
            IdentityResult result = await _userManager.ResetPasswordAsync(dbuser, resetToken, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //send the user back to the user's profile page
                return RedirectToAction("EditProfile", "RoleAdmin", new { id = dbuser.Id });
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            //send the user back to the change password page to try again
            return View(cpvm);
        }








        //GET:/Account/AccessDenied
        //DONE — given to us by Katie
        public IActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        //DONE — given by Katie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Host")]
        public async Task<IActionResult> HostDeleteAccount()
        {

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .Include(u => u.Properties)
                        .ThenInclude(p => p.Reservations)
                        .Include(u => u.Properties)
                        .ThenInclude(p => p.PropertyReviews)
                        .FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return View("Error", new String[] { "This user was not found in the database!" });
            }

            user.IsActive = aStatus.notActive;

            List<Property> properties = _context.Properties.Where(r => r.HostEmail == user.Email).ToList();
            foreach(Property property in properties)
            {
                property.Status = pStatus.notActive;
                _context.Update(property);

                List<Reservation> reservations = _context.Reservations.Where(r => r.Property.PropertyID == property.PropertyID).ToList();
                foreach(Reservation r in reservations)
                {
                    if (r.Status == rStatus.Active && r.CheckInDate >= DateTime.Now)
                    {
                        r.Status = rStatus.Cancelled;

                        //SENDNG EMAIL: sending email that reservation has been cancelled when host deletes property
                        String eSubject = "Reservation Has Been Cancelled";
                        String eBod = "Your reservation has been cancelled because the host has removed their property listing. You should expect to receive a refund from BevoBnB in the next 3-5 business days. Please contact admin@BevoBnB.com with any questions, comments, or concerns.";
                        Utilities.EmailMessaging.SendEmail(r.Order.User.Email, eSubject, eBod);
                    }
                    else if (r.Status == rStatus.Pending)
                    {
                        r.Status = rStatus.Delete;
                    }
                    _context.Update(r);
                }
                _context.Update(reservations);

                List<PropertyReview> reviews = _context.PropertyReviews.Include(p => p.Property).Where(p => p.Property.PropertyID == property.PropertyID).ToList();
                foreach(PropertyReview review in reviews)
                {
                    review.dStatus = disputeStatus.Accepted;
                    _context.Update(review);
                }

            }
            _context.Update(user);
            await _context.SaveChangesAsync();
            await _signInManager.SignOutAsync();

            //SENDING EMAIL: send email to host when they delete their account
            String emailSubject = "Customer Account Deleted";
            String emailBod = "Your account has been deleted. All upcoming reservations have been cancelled.";
            Utilities.EmailMessaging.SendEmail(user.Email, emailSubject, emailBod);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CustomerDeleteAccount(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a user to edit" });
            }

            // assigns user, an instance of AppUser, to be user in db with Email == id
            AppUser user = _context.Users
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Reservations)
                        .FirstOrDefault(u => u.Email == id);
            user.IsActive = aStatus.notActive;
            _context.Update(user);
            await _context.SaveChangesAsync();
            List<Order> orders = _context.Orders.Include(o => o.User).Include(o => o.Reservations).ThenInclude(o => o.Property).Where(o => o.User.Email == user.Email).ToList();


            foreach(Order o in orders)
            {
                // List<Reservation> reservations = _context.Reservations.Include(r => r.Order).Where(r => r.Order.OrderID == o.OrderID).ToList();
                foreach(Reservation r in o.Reservations)
                {
                    if (r.Status == rStatus.Active && r.CheckInDate >= DateTime.Now)
                    {
                        r.Status = rStatus.Cancelled;
                        _context.Update(r);
                        await _context.SaveChangesAsync();
                    }
                }
                
            }
            //SENDING EMAIL: send email to customer when they delete their account
            String emailSubject = "Customer Account Deleted";
            String emailBod = "Your account has been deleted. All upcoming reservations have been cancelled.";
            Utilities.EmailMessaging.SendEmail(user.Email, emailSubject, emailBod);

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

