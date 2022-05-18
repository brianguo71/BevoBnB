using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
namespace fa21team9finalproject.Seeding
{
    public static class SeedingCategories
    {
        public static async Task SeedCategories(AppDbContext db)
        {
            //Create a counter and a flag so we will know which record is causing problems 
            Int32 intCategoriesAdded = 0;
            String strCategoryName = "House";
            //Add the list of categories 
            List<Category> Categories = new List<Category>();
            Category c1 = new Category()
            {
                CategoryName = "House"
            };
            //Add this category to the list of properties to add 
            Categories.Add(c1);
            Category c2 = new Category()
            {
                CategoryName = "Cabin"
            };
            //Add this category to the list of properties to add 
            Categories.Add(c2);
            Category c3 = new Category()
            {
                CategoryName = "Apartment"
            };
            //Add this category to the list of properties to add 
            Categories.Add(c3);
            Category c4 = new Category()
            {
                CategoryName = "Condo"
            };
            //Add this category to the list of properties to add 
            Categories.Add(c4);
            Category c5 = new Category()
            {
                CategoryName = "Hotel"
            };
            //Add this category to the list of properties to add 
            Categories.Add(c5);

            try  //attempt to add or update the category 
            {
                //loop through each of the categories in the list 
                foreach (Category categoryToAdd in Categories)
                {
                    //set the flag to the current title to help with debugging 
                    strCategoryName = categoryToAdd.CategoryName;
                    //look to see if the category is in the database - this assumes that no 
                    //two books have the same title 
                    Category dbCategory = db.Categories.FirstOrDefault(b => b.CategoryName == categoryToAdd.CategoryName);
                    //if the dbCategory is null, this name is not in the database 
                    if (dbCategory == null)
                    {
                        //add the Category to the database and save changes 
                        db.Categories.Add(categoryToAdd);
                        db.SaveChanges();
                        //update the counter to help with debugging 
                        intCategoriesAdded += 1;
                    }
                    else //dbCategory is not null - this name *is* in the database 
                    {
                        //update all of the category's properties 
                        dbCategory.CategoryName = categoryToAdd.CategoryName;
                        //update the database and save the changes 
                        db.Update(dbCategory);
                        db.SaveChanges();
                        //update the counter to help with debugging 
                        intCategoriesAdded += 1;
                    } //this is the end of the else 
                } //this is the end of the foreach loop for the categories 
            }//this is the end of the try block 
            catch (Exception ex)//something went wrong with adding or updating 
            {
                //Build a messsage using the flags we created 
                String msg = " Repositories added:" + intCategoriesAdded + "; Error on " + strCategoryName;

                //throw the exception with the new message 
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}