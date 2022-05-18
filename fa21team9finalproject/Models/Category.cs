using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
    public class Category
    {
        // all properties

        // primary key
        public Int32 CategoryID { get; set; }

        // name of the category
        [Required(ErrorMessage = "Category name is required!")]
        [Display(Name = "Category Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Category name may only contain letters")]
        public string CategoryName { get; set; }
        // Evan: Changing Category Name to list, because it will be added to, can ask Derek? - this is wrong bc we need to be able to make categories by Brittany 

        //public List<string> CategoryName = new List<string> { "Apartment", "Cabin", "Condo", "Hotel", "House" };
        // relational properties

        // category will have many properties
        public List<Property> Properties { get; set; }



        // methods for relational properties
        public Category()
        {
            if (Properties == null)
            {
                Properties = new List<Property>();
            }

        }
    }
}
