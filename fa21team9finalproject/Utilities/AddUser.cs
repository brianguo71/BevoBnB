﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;

using fa21team9finalproject.Models;
using fa21team9finalproject.DAL;

namespace fa21team9finalproject.Utilities
{
    public static class AddUser
    {
        public async static Task<IdentityResult> AddUserWithRoleAsync(AddUserModel aum, UserManager<AppUser> userManager, AppDbContext _context)
        {
            //check to see if the user already exists in the database
            AppUser dbUser = await userManager.FindByEmailAsync(aum.User.Email);

            //create a variable for result
            IdentityResult result;

            //if user hasn't been created, then add them
            if (dbUser == null)
            {
                try
                {
                    //NOTE: Attempt to add the user using the UserManager
                    //Read the password of the user
                    result = await userManager.CreateAsync(aum.User, aum.Password);
                }
                catch (Exception ex)
                {
                    StringBuilder msg = new StringBuilder();
                    msg.Append("There was an error adding the user with the email ");
                    msg.Append(aum.User.Email);
                    msg.Append(". This often happens because you are missing a required field on AppUser");
                    throw new Exception(msg.ToString(), ex);
                }
                //if the user was not added succesfully, throw an exception
                //so the user knows what happened
                if (result.Succeeded == false)
                {
                    //Create a new string builder object to hold the error message(s)
                    StringBuilder msg = new StringBuilder();

                    //loop through all of the errors and add them to the message
                    foreach (var error in result.Errors)
                    {
                        msg.AppendLine(error.ToString());
                    }

                    //throw a new exception to tell the user something is wrong
                    throw new Exception("This user can't be added:" + msg.ToString());
                }

                dbUser = await userManager.FindByEmailAsync(aum.User.Email);
            }
            // NOTE: registercustomer() and registerhost() will not allow any account with duplicate
            // email to get this far in AddUser
            else //user is already in database, update the fields
            {
                //update the fields that you inherit from identity
                //email and user name do not change
                dbUser.PhoneNumber = aum.User.PhoneNumber;

                //Update any fields that you added to appuser
                dbUser.FirstName = aum.User.FirstName;
                dbUser.MI = aum.User.MI;
                dbUser.LastName = aum.User.LastName;
                dbUser.StreetAddress = aum.User.StreetAddress;
                dbUser.City = aum.User.City;
                dbUser.State = aum.User.State;
                dbUser.ZipCode = aum.User.ZipCode;
                dbUser.Birthday = aum.User.Birthday;
                dbUser.Role = aum.RoleName;

                //update the database
                _context.Update(dbUser);
                _context.SaveChanges();

                //reset the password
                //generate a reset password
                var token = await userManager.GeneratePasswordResetTokenAsync(dbUser);
                result = await userManager.ResetPasswordAsync(dbUser, token, aum.Password);
            }

            //Add the user to the role specified in the AddUserRoleModel
            if (await userManager.IsInRoleAsync(dbUser, aum.RoleName) == false)
            {
                await userManager.AddToRoleAsync(dbUser, aum.RoleName);
            }

            return result;
        }
    }

    public class AddUserModel
    {
        public AppUser User { get; set; }
        public String Password { get; set; }
        public String RoleName { get; set; }
    }
}