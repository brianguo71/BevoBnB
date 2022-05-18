using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace fa21team9finalproject.Models
{
    //NOTE: This is the view model used to allow the user to login
    //The user only needs the email and password to login
    //DONE
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    //DONE
    public class RegisterViewModel
    {
        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Add any fields that you need for creating a new user
        //NOTE: First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle initial is required.")]
        [Display(Name = "Middle Initial")]
        public string MI { get; set; }

        //NOTE: Here is the property for last name
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // street address
        [Required(ErrorMessage = "Street address is required.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        // city
        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        // state
        [Required(ErrorMessage = "You must select a state.")]
        [Display(Name = "State")]
        public StateList State { get; set; }

        // zip code
        // NOTE: not required by project
        [Required(ErrorMessage = "Zip code is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        // birthday is required
        [Required(ErrorMessage = "You must select a date.")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // Activity status of user is automatically made active when they
        // register for an account — this is done in the AccountController
        // TODO: this may be able to be deleted???
        public static aStatus IsActive { get; set; }

        // private backing to hold age variable
        public Int32? _intAge;

        // method to calculate age
        public void CalcAge()
        {
            DateTime now = DateTime.Today;
            _intAge = now.Year - Birthday.Year;
            if (now.Month < Birthday.Month || (now.Month == Birthday.Month && now.Day < Birthday.Day))
            {
                _intAge--;
            }

            // throw an error if age is less than 18
            if (_intAge < 18)
            {
                throw new Exception("Invalid! You must be 18 years or older to register.");
            }
        }
    }

    //NOTE: This is the view model used to allow the user to 
    //change their password
    //DONE — given to us by Katie
    public class ChangePasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
 
    //NOTE: This is the view model used to allow the user to 
    //change their birthday
    public class ChangeBirthdayViewModel
    {
        [Required(ErrorMessage = "You must select a date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Update Birthday")]
        public DateTime NewBirthday { get; set; }

        // private backing to hold age variable
        public Int32? _intAge;

        // method to calculate age
        public void CalcAge()
        {
            DateTime now = DateTime.Today;
            _intAge = now.Year - NewBirthday.Year;
            if (now.Month < NewBirthday.Month || (now.Month == NewBirthday.Month && now.Day < NewBirthday.Day))
            {
                _intAge--;
            }

            // throw an error if age is less than 18
            if (_intAge < 18)
            {
                throw new Exception("Invalid update! You cannot be younger than 18 years old to be a member of BevoBnB.");
            }
        }
    }

    //NOTE: This is the view model used to display basic user information
    //on the index page
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
        public String FullAddress { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}