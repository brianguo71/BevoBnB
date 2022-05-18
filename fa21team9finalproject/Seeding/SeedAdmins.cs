using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
using fa21team9finalproject.Utilities;
using Microsoft.AspNetCore.Identity;
namespace fa21team9finalproject.Seeding
{
	public static class SeedingAdmins
	{
		public static async Task<IdentityResult> SeedAdmins(UserManager<AppUser> userManager, AppDbContext context)
		{
			//Create a list of AddUserModels 
			List<AddUserModel> Admins = new List<AddUserModel>();
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "taylor@bevobnb.com",
					UserName = "taylor@bevobnb.com",
					FirstName = "Albert",
					LastName = "Taylor",
					ZipCode = "75237",
					PhoneNumber = "2149036025",
					StreetAddress = "467 Nueces St.",
					Birthday = new DateTime(1954, 8, 14),
					Role = "Admin"
				},
				Password = "TRY563",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "sheffield@bevobnb.com",
					UserName = "sheffield@bevobnb.com",
					FirstName = "Molly",
					LastName = "Sheffield",
					ZipCode = "78736",
					PhoneNumber = "5124749225",
					StreetAddress = "3886 Avenue A",
					Birthday = new DateTime(1986, 8, 27),
					Role = "Admin"
				},
				Password = "longsnores",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "macleod@bevobnb.com",
					UserName = "macleod@bevobnb.com",
					FirstName = "Jenny",
					LastName = "MacLeod",
					ZipCode = "78731",
					PhoneNumber = "5124723769",
					StreetAddress = "2504 Far West Blvd.",
					Birthday = new DateTime(1984, 12, 5),
					Role = "Admin"
				},
				Password = "kittys",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "rhodes@bevobnb.com",
					UserName = "rhodes@bevobnb.com",
					FirstName = "Michelle",
					LastName = "Rhodes",
					ZipCode = "78293",
					PhoneNumber = "2102520380",
					StreetAddress = "4587 Enfield Rd.",
					Birthday = new DateTime(1972, 7, 2),
					Role = "Admin"
				},
				Password = "puppies",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "stuart@bevobnb.com",
					UserName = "stuart@bevobnb.com",
					FirstName = "Evan",
					LastName = "Stuart",
					ZipCode = "78279",
					PhoneNumber = "2105415031",
					StreetAddress = "5576 Toro Ring",
					Birthday = new DateTime(1984, 4, 17),
					Role = "Admin"
				},
				Password = "coolboi",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "swanson@bevobnb.com",
					UserName = "swanson@bevobnb.com",
					FirstName = "Ron",
					LastName = "Swanson",
					ZipCode = "78731",
					PhoneNumber = "5124818542",
					StreetAddress = "245 River Rd",
					Birthday = new DateTime(1991, 7, 25),
					Role = "Admin"
				},
				Password = "swanbong",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "white@bevobnb.com",
					UserName = "white@bevobnb.com",
					FirstName = "Jabriel",
					LastName = "White",
					ZipCode = "77045",
					PhoneNumber = "8175025605",
					StreetAddress = "12 Valley View",
					Birthday = new DateTime(1986, 3, 17),
					Role = "Admin"
				},
				Password = "456789",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "montgomery@bevobnb.com",
					UserName = "montgomery@bevobnb.com",
					FirstName = "Washington",
					LastName = "Montgomery",
					ZipCode = "77030",
					PhoneNumber = "8178817122",
					StreetAddress = "210 Blanco Dr",
					Birthday = new DateTime(1961, 5, 4),
					Role = "Admin"
				},
				Password = "python4",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "walker@bevobnb.com",
					UserName = "walker@bevobnb.com",
					FirstName = "Lisa",
					LastName = "Walker",
					ZipCode = "75238",
					PhoneNumber = "2143196301",
					StreetAddress = "9 Bison Circle",
					Birthday = new DateTime(2003, 4, 18),
					Role = "Admin"
				},
				Password = "walkameter",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "chang@bevobnb.com",
					UserName = "chang@bevobnb.com",
					FirstName = "Gregory",
					LastName = "Chang",
					ZipCode = "78260",
					PhoneNumber = "2103521329",
					StreetAddress = "9003 Joshua St",
					Birthday = new DateTime(1958, 4, 26),
					Role = "Admin"
				},
				Password = "pupgang",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "derek@bevobnb.com",
					UserName = "derek@bevobnb.com",
					FirstName = "Derek",
					LastName = "Dreibrodt",
					ZipCode = "78705",
					PhoneNumber = "5125556789",
					StreetAddress = "4 Privet Dr",
					Birthday = new DateTime(2001, 1, 1),
					Role = "Admin"
				},
				Password = "2cool4u",
				RoleName = "Admin"
			});
			Admins.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "rester@bevobnb.com",
					UserName = "rester@bevobnb.com",
					FirstName = "Amy",
					LastName = "Rester",
					ZipCode = "78705",
					PhoneNumber = "2103521329",
					StreetAddress = "2110 Speedway",
					Birthday = new DateTime(2000, 1, 1),
					Role = "Admin"
				},
				Password = "KIzGreat",
				RoleName = "Admin"
			});
			//Create a flag so we will know which record is causing problems 
			String strAdminEmail = "Begin";
			//create an identity result 
			IdentityResult result = new IdentityResult();
			//call the method to seed the user 
			try
			{
				//loop through each of the host in the list 
				foreach (AddUserModel adminToAdd in Admins)
				{
					//set the flag to the current title to help with debugging 
					strAdminEmail = adminToAdd.User.Email;
					result = await Utilities.AddUser.AddUserWithRoleAsync(adminToAdd, userManager, context);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("There was a problem adding the user with email: "
					 + strAdminEmail, ex);
			}
			return result;
		}
	}
}