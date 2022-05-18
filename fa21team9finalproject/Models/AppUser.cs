using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace fa21team9finalproject.Models
{
    // enum for is_active property
    public enum aStatus { Active, [Display(Name = "Not Active")] notActive }


    public class AppUser : IdentityUser
    {
        // properties not inherited from identity that we need
        // NOTE: email, phone number, and role are all inherited from IdentityUser
        // TODO: check that all properties are listed right

        // first name is required
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        // middle initial is required
        [Display(Name = "Middle Initial")]
        public String MI { get; set; }

        // last name is required
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        // NOTE: not required in project
        // Full name
        [Display(Name = "Full Name")]
        public String FullName
        {
            get { return FirstName + " " + MI + " " + LastName; }
        }

        // street address
        [Required]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        // city
        [Display(Name = "City")]
        public String City { get; set; }

        // state
        [Display(Name = "State")]
        public StateList State { get; set; }

        // zip code
        // NOTE: not required by project
        [Required]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }



        // NOTE: this is just for us, if we want to display it
        // address is required
        // address includes street address, city, state
        [Display(Name = "Full Address")]
        public String FullAddress 
        {
            get { return StreetAddress + " " + City + ", " + State + " " + ZipCode; }
        }

        // birthday is required
        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        // property to determine if user is active or deavtivated
        [Display(Name = "Activity Status")]
        public aStatus IsActive { get; set; }

        // relational properties between model classes
        // TODO: check that relational properties are right

        // AppUser can have many orders —> this equates to "reservation details"
        public List<Order> Orders { get; set; }

        // AppUser can create multiple property reviews
        public List<PropertyReview> PropertyReviews { get; set; }

        // AppUser can list many properties (host only)
        public List<Property> Properties { get; set; }

        //for trying to search through roles later
        public string Role { get; set; }

        // methods for relational properties
        // TODO: check that this is correct
        public AppUser()
        {
            // whenever any property from another model is null, pull all data from that table
            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            if (PropertyReviews == null)
            {
                PropertyReviews = new List<PropertyReview>();
            }

            if (Properties == null)
            {
                Properties = new List<Property>();
            }
        }
    }
}