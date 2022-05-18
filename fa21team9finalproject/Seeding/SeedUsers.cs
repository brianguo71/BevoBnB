using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using fa21team9finalproject.Models;
using fa21team9finalproject.Utilities;
using fa21team9finalproject.DAL;
using System.Threading.Tasks;

//TODO: THIS IS IMPORTED FROM BRITTANY's HW5 SO CHANGE TO NEW SEEDING THING
namespace fa21team9finalproject.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    PhoneNumber = "(512)555-1234",

                    //TODO: [MAY BE DONE] Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Admin",
                    MI = "A",
                    LastName = "Admin",
                    StreetAddress = "Admin street",
                    City = "Admin city",
                    State = StateList.TX,
                    ZipCode = "12345"

                },
                Password = "Abc123!",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "bevo@example.com",
                    Email = "bevo@example.com",
                    PhoneNumber = "(512)555-5555",

                    //TODO: [MAY BE DONE] Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Bevo",
                    MI = "B",
                    LastName = "Longhorn",
                    StreetAddress = "Bevo street",
                    City = "Bevo city",
                    State = StateList.TX,
                    ZipCode = "12345"
                },
                Password = "Password123!",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "host@example.com",
                    Email = "host@example.com",
                    PhoneNumber = "(512)555-1234",

                    //TODO: [MAY BE DONE] Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Host",
                    MI = "H",
                    LastName = "Host",
                    StreetAddress = "host street",
                    City = "host city",
                    State = StateList.TX,
                    ZipCode = "12345"

                },
                Password = "Abc123!",
                RoleName = "Host"
            });

            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: "
                    + errorFlag, ex);
            }

            return result;
        }
    }
}