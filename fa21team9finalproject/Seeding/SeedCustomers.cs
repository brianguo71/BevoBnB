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
	public static class SeedingCustomer
	{
		public static async Task<IdentityResult> SeedCustomers(UserManager<AppUser> userManager, AppDbContext context)
		{
			//Create a list of AddUserModels 
			List<AddUserModel> Customers = new List<AddUserModel>();
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "cbaker@freezing.co.uk",
					UserName = "cbaker@freezing.co.uk",
					FirstName = "Christopher",
					LastName = "Baker",
					ZipCode = "78733",
					PhoneNumber = "5125595133",
					StreetAddress = "1245 Lake America Blvd.",
					Birthday = new DateTime(1968, 11, 28),
					Role = "Customer"
				},
				Password = "hellothere",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "mb@puppy.com",
					UserName = "mb@puppy.com",
					FirstName = "Michelle",
					LastName = "Bradicus",
					ZipCode = "78261",
					PhoneNumber = "2102702860",
					StreetAddress = "1300 Small Pine Lane",
					Birthday = new DateTime(1988, 2, 7),
					Role = "Customer"
				},
				Password = "555533",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "fd@puppy.com",
					UserName = "fd@puppy.com",
					FirstName = "Franco",
					LastName = "Broccoli",
					ZipCode = "77019",
					PhoneNumber = "8175683686",
					StreetAddress = "62 Cookie Rd",
					Birthday = new DateTime(1999, 11, 7),
					Role = "Customer"
				},
				Password = "666645",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "wendy@puppy.com",
					UserName = "wendy@puppy.com",
					FirstName = "Wendy",
					LastName = "Charile",
					ZipCode = "78713",
					PhoneNumber = "5125967209",
					StreetAddress = "202 Bellmoth Hall",
					Birthday = new DateTime(1992, 10, 27),
					Role = "Customer"
				},
				Password = "Kansas",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "limchou@puppy.com",
					UserName = "limchou@puppy.com",
					FirstName = "Lim",
					LastName = "Chou",
					ZipCode = "78266",
					PhoneNumber = "2107748586",
					StreetAddress = "1600 Barbara Lane",
					Birthday = new DateTime(1961, 11, 11),
					Role = "Customer"
				},
				Password = "Rockwall",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "444444.Dave@aool.com",
					UserName = "444444.Dave@aool.com",
					FirstName = "Shan",
					LastName = "Dave",
					ZipCode = "75208",
					PhoneNumber = "2142667242",
					StreetAddress = "234 Puppy Circle",
					Birthday = new DateTime(1972, 12, 19),
					Role = "Customer"
				},
				Password = "444444",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "louann@puppy.com",
					UserName = "louann@puppy.com",
					FirstName = "Lou Ann",
					LastName = "Feeley",
					ZipCode = "77010",
					PhoneNumber = "8172580736",
					StreetAddress = "700 S 9th Street W",
					Birthday = new DateTime(1958, 8, 1),
					Role = "Customer"
				},
				Password = "longhorns",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "tfreeley@puppy.com",
					UserName = "tfreeley@puppy.com",
					FirstName = "Tesa",
					LastName = "Freeley",
					ZipCode = "77009",
					PhoneNumber = "8173279674",
					StreetAddress = "4334 Meanview Ave.",
					Birthday = new DateTime(2001, 7, 12),
					Role = "Customer"
				},
				Password = "puppies",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "mgar@puppy.com",
					UserName = "mgar@puppy.com",
					FirstName = "Margaret",
					LastName = "Garcia",
					ZipCode = "77003",
					PhoneNumber = "8176617531",
					StreetAddress = "594 Puppyview",
					Birthday = new DateTime(1956, 11, 17),
					Role = "Customer"
				},
				Password = "horses",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "chaley@thug.com",
					UserName = "chaley@thug.com",
					FirstName = "Charles",
					LastName = "Harley",
					ZipCode = "75261",
					PhoneNumber = "2148499570",
					StreetAddress = "One Ranger Pkwy",
					Birthday = new DateTime(1998, 5, 29),
					Role = "Customer"
				},
				Password = "mycats",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "jeff@puppy.com",
					UserName = "jeff@puppy.com",
					FirstName = "Jeffrey",
					LastName = "Stark",
					ZipCode = "78705",
					PhoneNumber = "5127002600",
					StreetAddress = "337 40th St.",
					Birthday = new DateTime(1974, 5, 2),
					Role = "Customer"
				},
				Password = "jeffery",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "wjhearniii@umch.edu",
					UserName = "wjhearniii@umch.edu",
					FirstName = "John",
					LastName = "Hearn",
					ZipCode = "75237",
					PhoneNumber = "2148989608",
					StreetAddress = "4445 South First",
					Birthday = new DateTime(1983, 12, 29),
					Role = "Customer"
				},
				Password = "posicles",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "hicks43@puppy.com",
					UserName = "hicks43@puppy.com",
					FirstName = "Mark",
					LastName = "Hicks",
					ZipCode = "78239",
					PhoneNumber = "2105812952",
					StreetAddress = "32 NE Mark Ln., Ste 910",
					Birthday = new DateTime(1989, 12, 16),
					Role = "Customer"
				},
				Password = "guac45",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "bradsingram@mall.utexas.edu",
					UserName = "bradsingram@mall.utexas.edu",
					FirstName = "Brad",
					LastName = "Ingram",
					ZipCode = "78736",
					PhoneNumber = "5124702808",
					StreetAddress = "6548 La Chess St.",
					Birthday = new DateTime(1958, 9, 18),
					Role = "Customer"
				},
				Password = "father",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "father.Ingram@aool.com",
					UserName = "father.Ingram@aool.com",
					FirstName = "Todd",
					LastName = "Jacobs",
					ZipCode = "78731",
					PhoneNumber = "5124677352",
					StreetAddress = "4564 Palm St.",
					Birthday = new DateTime(1975, 12, 9),
					Role = "Customer"
				},
				Password = "555897",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "victoria@puppy.com",
					UserName = "victoria@puppy.com",
					FirstName = "Victoria",
					LastName = "Lawrence",
					ZipCode = "78761",
					PhoneNumber = "5129481386",
					StreetAddress = "6639 Butterfly Ln.",
					Birthday = new DateTime(1981, 5, 29),
					Role = "Customer"
				},
				Password = "something",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "lineback@flush.net",
					UserName = "lineback@flush.net",
					FirstName = "Brad",
					LastName = "Lineback",
					ZipCode = "78293",
					PhoneNumber = "2102473963",
					StreetAddress = "1300 Pirateland St",
					Birthday = new DateTime(1973, 5, 19),
					Role = "Customer"
				},
				Password = "treelover",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "elowe@netscrape.net",
					UserName = "elowe@netscrape.net",
					FirstName = "Evan",
					LastName = "Lowe",
					ZipCode = "78279",
					PhoneNumber = "2105368614",
					StreetAddress = "3201 Pineapple Drive",
					Birthday = new DateTime(1993, 6, 7),
					Role = "Customer"
				},
				Password = "headear",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "luce_chuck@puppy.com",
					UserName = "luce_chuck@puppy.com",
					FirstName = "Chuck",
					LastName = "Luce",
					ZipCode = "78268",
					PhoneNumber = "2107007535",
					StreetAddress = "2345 Silent Clouds",
					Birthday = new DateTime(1995, 6, 11),
					Role = "Customer"
				},
				Password = "gooseyloosey",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "mackcloud@pimpdaddy.com",
					UserName = "mackcloud@pimpdaddy.com",
					FirstName = "Jennifer",
					LastName = "MacLeod",
					ZipCode = "78731",
					PhoneNumber = "5124772125",
					StreetAddress = "2504 Far East Blvd.",
					Birthday = new DateTime(1965, 10, 11),
					Role = "Customer"
				},
				Password = "rainyday",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "liz@puppy.com",
					UserName = "liz@puppy.com",
					FirstName = "Elizabeth",
					LastName = "Markham",
					ZipCode = "78732",
					PhoneNumber = "5124603832",
					StreetAddress = "7861 Chevy Mace Rd",
					Birthday = new DateTime(1989, 6, 18),
					Role = "Customer"
				},
				Password = "ember22",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "mclarence@puppy.com",
					UserName = "mclarence@puppy.com",
					FirstName = "Clarence",
					LastName = "Martin",
					ZipCode = "77045",
					PhoneNumber = "8174979188",
					StreetAddress = "87 Alcedo St.",
					Birthday = new DateTime(1984, 4, 28),
					Role = "Customer"
				},
				Password = "lamemartin",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "lamemartin.Martin@aool.com",
					UserName = "lamemartin.Martin@aool.com",
					FirstName = "Gregory",
					LastName = "Martinez",
					ZipCode = "77030",
					PhoneNumber = "8178770705",
					StreetAddress = "8295 Moon Blvd.",
					Birthday = new DateTime(1981, 12, 27),
					Role = "Customer"
				},
				Password = "gregory",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "cmiller@mapster.com",
					UserName = "cmiller@mapster.com",
					FirstName = "Charles",
					LastName = "Miller",
					ZipCode = "77031",
					PhoneNumber = "8177482602",
					StreetAddress = "8962 Side St.",
					Birthday = new DateTime(1987, 5, 5),
					Role = "Customer"
				},
				Password = "mucky44",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "nelson.Kelly@puppy.com",
					UserName = "nelson.Kelly@puppy.com",
					FirstName = "Kelly",
					LastName = "Nelson",
					ZipCode = "78703",
					PhoneNumber = "5122950953",
					StreetAddress = "2601 Green River",
					Birthday = new DateTime(1969, 8, 3),
					Role = "Customer"
				},
				Password = "Tree34",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "jojoe@puppy.com",
					UserName = "jojoe@puppy.com",
					FirstName = "Joe",
					LastName = "Nguyen",
					ZipCode = "75238",
					PhoneNumber = "2143149884",
					StreetAddress = "1249 4th NW St.",
					Birthday = new DateTime(1956, 2, 6),
					Role = "Customer"
				},
				Password = "jvb485bg",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "orielly@foxnets.com",
					UserName = "orielly@foxnets.com",
					FirstName = "Bill",
					LastName = "O'Reilly",
					ZipCode = "78260",
					PhoneNumber = "2103474912",
					StreetAddress = "8800 Gringo Drive",
					Birthday = new DateTime(1989, 3, 14),
					Role = "Customer"
				},
				Password = "Bobbygirl",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "or@puppy.com",
					UserName = "or@puppy.com",
					FirstName = "Anka",
					LastName = "Radkovich",
					ZipCode = "75260",
					PhoneNumber = "2142369553",
					StreetAddress = "1300 Freaky",
					Birthday = new DateTime(1952, 10, 26),
					Role = "Customer"
				},
				Password = "radioactive",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "megrhodes@freezing.co.uk",
					UserName = "megrhodes@freezing.co.uk",
					FirstName = "Megan",
					LastName = "Rhodes",
					ZipCode = "78707",
					PhoneNumber = "5123768733",
					StreetAddress = "4587 Rightfield Rd.",
					Birthday = new DateTime(1958, 3, 18),
					Role = "Customer"
				},
				Password = "gopigs",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "erynrice@puppy.com",
					UserName = "erynrice@puppy.com",
					FirstName = "Eryn",
					LastName = "Rice",
					ZipCode = "78705",
					PhoneNumber = "5123900644",
					StreetAddress = "3405 Rio Small",
					Birthday = new DateTime(2000, 11, 2),
					Role = "Customer"
				},
				Password = "iloveme",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "jorge@hootmail.com",
					UserName = "jorge@hootmail.com",
					FirstName = "Jorge",
					LastName = "Rodriguez",
					ZipCode = "77057",
					PhoneNumber = "8178928361",
					StreetAddress = "6788 Cotten Street",
					Birthday = new DateTime(1979, 1, 1),
					Role = "Customer"
				},
				Password = "565656",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "ra@aoo.com",
					UserName = "ra@aoo.com",
					FirstName = "Allen",
					LastName = "Rogers",
					ZipCode = "78732",
					PhoneNumber = "5128776930",
					StreetAddress = "4965 Rabbit Hill",
					Birthday = new DateTime(2000, 3, 12),
					Role = "Customer"
				},
				Password = "treeman",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "o_st-jean@home.com",
					UserName = "o_st-jean@home.com",
					FirstName = "Olivier",
					LastName = "Saint-Jean",
					ZipCode = "78292",
					PhoneNumber = "2104169665",
					StreetAddress = "255 Slap Dr.",
					Birthday = new DateTime(1997, 5, 1),
					Role = "Customer"
				},
				Password = "55htrq",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "ss34@puppy.com",
					UserName = "ss34@puppy.com",
					FirstName = "Sarah",
					LastName = "Saunders",
					ZipCode = "78705",
					PhoneNumber = "5123521797",
					StreetAddress = "332 Fish C",
					Birthday = new DateTime(1994, 5, 31),
					Role = "Customer"
				},
				Password = "leaves",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "willsheff@email.com",
					UserName = "willsheff@email.com",
					FirstName = "William",
					LastName = "Sewell",
					ZipCode = "78709",
					PhoneNumber = "5124534071",
					StreetAddress = "2365 34st St.",
					Birthday = new DateTime(1951, 12, 10),
					Role = "Customer"
				},
				Password = "borbj44",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "sheff44@puppy.com",
					UserName = "sheff44@puppy.com",
					FirstName = "Martin",
					LastName = "Sheffield",
					ZipCode = "78705",
					PhoneNumber = "5125503154",
					StreetAddress = "3886 Road A",
					Birthday = new DateTime(1993, 7, 2),
					Role = "Customer"
				},
				Password = "ldiul485",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "johnsmith187@puppy.com",
					UserName = "johnsmith187@puppy.com",
					FirstName = "John",
					LastName = "Smith",
					ZipCode = "78280",
					PhoneNumber = "2108345875",
					StreetAddress = "23 Known Forge Dr.",
					Birthday = new DateTime(1985, 6, 13),
					Role = "Customer"
				},
				Password = "kribv75",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "dustroud@mail.com",
					UserName = "dustroud@mail.com",
					FirstName = "Dustin",
					LastName = "Stroud",
					ZipCode = "75221",
					PhoneNumber = "2142370654",
					StreetAddress = "1212 Henrietta Rd",
					Birthday = new DateTime(1974, 7, 14),
					Role = "Customer"
				},
				Password = "klavjkb48",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "eric_stuart@puppy.com",
					UserName = "eric_stuart@puppy.com",
					FirstName = "Eric",
					LastName = "Stuart",
					ZipCode = "78746",
					PhoneNumber = "5128202322",
					StreetAddress = "5576 Big Ring",
					Birthday = new DateTime(1968, 6, 17),
					Role = "Customer"
				},
				Password = "vkb451",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "peterstump@hootmail.com",
					UserName = "peterstump@hootmail.com",
					FirstName = "Peter",
					LastName = "Stump",
					ZipCode = "77018",
					PhoneNumber = "8174584890",
					StreetAddress = "1300 Kellen Square",
					Birthday = new DateTime(2001, 7, 23),
					Role = "Customer"
				},
				Password = "kdsiu4",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "tanner@puppy.com",
					UserName = "tanner@puppy.com",
					FirstName = "Jeremy",
					LastName = "Tanner",
					ZipCode = "77044",
					PhoneNumber = "8174614916",
					StreetAddress = "4347 Palmstead",
					Birthday = new DateTime(1973, 12, 28),
					Role = "Customer"
				},
				Password = "klrfbj45",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "taylordjay@puppy.com",
					UserName = "taylordjay@puppy.com",
					FirstName = "Allison",
					LastName = "Taylor",
					ZipCode = "78705",
					PhoneNumber = "5124772439",
					StreetAddress = "467 Nueces St.",
					Birthday = new DateTime(1999, 9, 30),
					Role = "Customer"
				},
				Password = "lraggrhb854",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "lraggrhb854.Taylor@aool.com",
					UserName = "lraggrhb854.Taylor@aool.com",
					FirstName = "Rachel",
					LastName = "Taylor",
					ZipCode = "78705",
					PhoneNumber = "5124536618",
					StreetAddress = "345 Shortview Dr.",
					Birthday = new DateTime(1956, 2, 24),
					Role = "Customer"
				},
				Password = "alsuib95",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "tee_frank@hootmail.com",
					UserName = "tee_frank@hootmail.com",
					FirstName = "Frank",
					LastName = "Tee",
					ZipCode = "77004",
					PhoneNumber = "8178789530",
					StreetAddress = "5590 Big Dr.",
					Birthday = new DateTime(1964, 11, 11),
					Role = "Customer"
				},
				Password = "kd1734",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "tuck33@puppy.com",
					UserName = "tuck33@puppy.com",
					FirstName = "Clent",
					LastName = "Tucker",
					ZipCode = "75315",
					PhoneNumber = "2148495141",
					StreetAddress = "3132 Main St.",
					Birthday = new DateTime(1990, 6, 25),
					Role = "Customer"
				},
				Password = "kjdb983",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "avelasco@puppy.com",
					UserName = "avelasco@puppy.com",
					FirstName = "Allen",
					LastName = "Velasco",
					ZipCode = "75207",
					PhoneNumber = "2144009625",
					StreetAddress = "634 W. 4th",
					Birthday = new DateTime(1966, 12, 13),
					Role = "Customer"
				},
				Password = "odrb02",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "westj@pioneer.net",
					UserName = "westj@pioneer.net",
					FirstName = "Jake",
					LastName = "West",
					ZipCode = "75323",
					PhoneNumber = "2148499231",
					StreetAddress = "RR 3244",
					Birthday = new DateTime(1968, 2, 6),
					Role = "Customer"
				},
				Password = "kndl847",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "louielouie@puppy.com",
					UserName = "louielouie@puppy.com",
					FirstName = "Louis",
					LastName = "Winthorpe",
					ZipCode = "78746",
					PhoneNumber = "2145674085",
					StreetAddress = "2500 Madre Blvd",
					Birthday = new DateTime(1961, 7, 23),
					Role = "Customer"
				},
				Password = "lb2394",
				RoleName = "Customer"
			});
			Customers.Add(new AddUserModel()
			{
				User = new AppUser()
				{
					Email = "rwood@voyager.net",
					UserName = "rwood@voyager.net",
					FirstName = "Reagan",
					LastName = "Wood",
					ZipCode = "78746",
					PhoneNumber = "5124569229",
					StreetAddress = "447 Westlake Dr.",
					Birthday = new DateTime(1988, 10, 24),
					Role = "Customer"
				},
				Password = "drai494",
				RoleName = "Customer"
			});
			//Create a counter and a flag so we will know which record is causing problems 
			String strCustomerEmail = "Begin";

			//create an identity result 
			IdentityResult result = new IdentityResult();

			//call the method to seed the user 
			try
			{
				//loop through each of the customer in the list 
				foreach (AddUserModel customerToAdd in Customers)
				{
					//set the flag to the current title to help with debugging 
					strCustomerEmail = customerToAdd.User.Email;
					result = await Utilities.AddUser.AddUserWithRoleAsync(customerToAdd, userManager, context);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("There was a problem adding the user with email: "
					 + strCustomerEmail, ex);
			}
			return result;
		}
	}
}