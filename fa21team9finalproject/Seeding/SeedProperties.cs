using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;

namespace fa21team9finalproject.Seeding
{
	public static class SeedingProperties
	{
		public static async Task SeedProperties(AppDbContext db)
		{
			//Create a counter and a flag so we will know which record is causing problems
			Int32 intPropertiesAdded = 0;
			Int32 intPropertyNumber = 3000;
			List<Property> Properties = new List<Property>();

			try
			{
				//Add the list of properties
				Property p1 = new Property()
				{
					PropertyNumber = 3001,
					ZipCode = "72227",
					State = StateList.PA,
					StreetAddress = "8714 Mann Plaza",
					AptNum = null,
					City = "Lisaside",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 171.57m,
					PricePerWeekday = 152.68m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 8.88m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 9,
				};
				p1.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");

				//Add this book to the list of properties to add 
				Properties.Add(p1);
				Property p2 = new Property()
				{
					PropertyNumber = 3002,
					ZipCode = "05565",
					State = StateList.FL,
					StreetAddress = "96593 White View",
					AptNum = "Apt. 094",
					City = "Jonesberg",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 148.15m,
					PricePerWeekday = 120.81m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 8.02m,
					NumberBed = 7,
					NumberBath = 8,
					NumberGuests = 8,
				};
				p2.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");

				//Add this book to the list of properties to add 
				Properties.Add(p2);
				Property p3 = new Property()
				{
					PropertyNumber = 3003,
					ZipCode = "80819",
					State = StateList.MD,
					StreetAddress = "848 Melissa Springs",
					AptNum = "Suite 947",
					City = "Kellerstad",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 132.99m,
					PricePerWeekday = 127.96m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.37m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 8,
				};
				p3.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p3);
				Property p4 = new Property()
				{
					PropertyNumber = 3004,
					ZipCode = "79428",
					State = StateList.ND,
					StreetAddress = "30413 Norton Isle",
					AptNum = "Suite 012",
					City = "North Lisa",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 185.35m,
					PricePerWeekday = 80.2m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 5.57m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 14,
				};
				p4.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p4);
				Property p5 = new Property()
				{
					PropertyNumber = 3005,
					ZipCode = "63315",
					State = StateList.DE,
					StreetAddress = "39916 Mitchell Crescent",
					AptNum = null,
					City = "New Andrewburgh",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 100.37m,
					PricePerWeekday = 170.25m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.64m,
					NumberBed = 2,
					NumberBath = 3,
					NumberGuests = 12,
				};
				p5.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p5);
				Property p6 = new Property()
				{
					PropertyNumber = 3006,
					ZipCode = "24135",
					State = StateList.NE,
					StreetAddress = "086 Mary Cliff",
					AptNum = null,
					City = "North Deborah",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 162.6m,
					PricePerWeekday = 220.24m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 10.83m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 2,
				};
				p6.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p6);
				Property p7 = new Property()
				{
					PropertyNumber = 3007,
					ZipCode = "58475",
					State = StateList.PA,
					StreetAddress = "91634 Strong Mountains",
					AptNum = "Apt. 302",
					City = "West Alyssa",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 204.87m,
					PricePerWeekday = 213.37m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 25.04m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 9,
				};
				p7.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p7);
				Property p8 = new Property()
				{
					PropertyNumber = 3008,
					ZipCode = "10865",
					State = StateList.WA,
					StreetAddress = "6984 Price Shoals",
					AptNum = null,
					City = "Erictown",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 140.89m,
					PricePerWeekday = 159.69m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 27.13m,
					NumberBed = 2,
					NumberBath = 3,
					NumberGuests = 8,
				};
				p8.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p8);
				Property p9 = new Property()
				{
					PropertyNumber = 3009,
					ZipCode = "51359",
					State = StateList.ME,
					StreetAddress = "423 Bell Heights",
					AptNum = null,
					City = "Brittanyberg",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 295.39m,
					PricePerWeekday = 200.73m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 14.91m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 4,
				};
				p9.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p9);
				Property p10 = new Property()
				{
					PropertyNumber = 3010,
					ZipCode = "87296",
					State = StateList.WI,
					StreetAddress = "93523 Dana Lane",
					AptNum = null,
					City = "Johnsonshire",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 110.8m,
					PricePerWeekday = 170.39m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 8.67m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 3,
				};
				p10.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p10);
				Property p11 = new Property()
				{
					PropertyNumber = 3011,
					ZipCode = "07035",
					State = StateList.NH,
					StreetAddress = "1427 Odonnell Rapids",
					AptNum = null,
					City = "North Troyport",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 126.29m,
					PricePerWeekday = 217.15m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 26.48m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 14,
				};
				p11.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p11);
				Property p12 = new Property()
				{
					PropertyNumber = 3012,
					ZipCode = "37198",
					State = StateList.ME,
					StreetAddress = "81206 Stewart Forest",
					AptNum = "Apt. 089",
					City = "East Davidborough",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 293.26m,
					PricePerWeekday = 205.21m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 28.74m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 8,
				};
				p12.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p12);
				Property p13 = new Property()
				{
					PropertyNumber = 3013,
					ZipCode = "85034",
					State = StateList.SD,
					StreetAddress = "76104 Marsh Crescent",
					AptNum = null,
					City = "Dennishaven",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 126.99m,
					PricePerWeekday = 123.13m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.73m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 4,
				};
				p13.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p13);
				Property p14 = new Property()
				{
					PropertyNumber = 3014,
					ZipCode = "60619",
					State = StateList.SD,
					StreetAddress = "0003 Grant Lakes",
					AptNum = null,
					City = "Port Karafort",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 188.81m,
					PricePerWeekday = 89.19m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.98m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 14,
				};
				p14.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p14);
				Property p15 = new Property()
				{
					PropertyNumber = 3015,
					ZipCode = "21978",
					State = StateList.KY,
					StreetAddress = "236 Smith Drive",
					AptNum = "Suite 555",
					City = "West Kimberlyton",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 132.96m,
					PricePerWeekday = 198.3m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.96m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 11,
				};
				p15.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p15);
				Property p16 = new Property()
				{
					PropertyNumber = 3016,
					ZipCode = "14742",
					State = StateList.MT,
					StreetAddress = "6824 Timothy Garden",
					AptNum = "Apt. 428",
					City = "West Richardmouth",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 297.31m,
					PricePerWeekday = 181.5m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 10.09m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 10,
				};
				p16.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p16);
				Property p17 = new Property()
				{
					PropertyNumber = 3017,
					ZipCode = "11894",
					State = StateList.SC,
					StreetAddress = "5517 Holly Meadow",
					AptNum = "Apt. 452",
					City = "Lake Anne",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 139.22m,
					PricePerWeekday = 134.09m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 9.75m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 1,
				};
				p17.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p17);
				Property p18 = new Property()
				{
					PropertyNumber = 3018,
					ZipCode = "28976",
					State = StateList.TX,
					StreetAddress = "30601 Hawkins Highway",
					AptNum = null,
					City = "Morashire",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 160.61m,
					PricePerWeekday = 187.65m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 7.5m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 9,
				};
				p18.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p18);
				Property p19 = new Property()
				{
					PropertyNumber = 3019,
					ZipCode = "28798",
					State = StateList.AZ,
					StreetAddress = "49263 Wilson View",
					AptNum = "Apt. 873",
					City = "South Raymondborough",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 133.25m,
					PricePerWeekday = 206.95m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 14.04m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 5,
				};
				p19.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p19);
				Property p20 = new Property()
				{
					PropertyNumber = 3020,
					ZipCode = "68819",
					State = StateList.NE,
					StreetAddress = "76582 Vanessa Oval",
					AptNum = null,
					City = "New Richard",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 242.89m,
					PricePerWeekday = 99.54m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.61m,
					NumberBed = 5,
					NumberBath = 4,
					NumberGuests = 12,
				};
				p20.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p20);
				Property p21 = new Property()
				{
					PropertyNumber = 3021,
					ZipCode = "50177",
					State = StateList.FL,
					StreetAddress = "7389 Alec Squares",
					AptNum = "Suite 508",
					City = "Port Jonathan",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 165.32m,
					PricePerWeekday = 112.62m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 24.26m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 12,
				};
				p21.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p21);
				Property p22 = new Property()
				{
					PropertyNumber = 3022,
					ZipCode = "66355",
					State = StateList.NC,
					StreetAddress = "18013 Billy Bridge",
					AptNum = "Suite 522",
					City = "Schmitthaven",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 119.02m,
					PricePerWeekday = 199.21m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.63m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 2,
				};
				p22.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p22);
				Property p23 = new Property()
				{
					PropertyNumber = 3023,
					ZipCode = "51431",
					State = StateList.NJ,
					StreetAddress = "891 Bullock Ford",
					AptNum = null,
					City = "Amandachester",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 244.93m,
					PricePerWeekday = 179.05m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 21.78m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 11,
				};
				p23.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p23);
				Property p24 = new Property()
				{
					PropertyNumber = 3024,
					ZipCode = "50853",
					State = StateList.MT,
					StreetAddress = "02489 Cook Park",
					AptNum = null,
					City = "Sherriport",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 227.35m,
					PricePerWeekday = 207.24m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 5.5m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 6,
				};
				p24.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p24);
				Property p25 = new Property()
				{
					PropertyNumber = 3025,
					ZipCode = "20341",
					State = StateList.UT,
					StreetAddress = "23450 Timothy Divide",
					AptNum = null,
					City = "Wuland",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 278.36m,
					PricePerWeekday = 116.01m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 24.73m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 11,
				};
				p25.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p25);
				Property p26 = new Property()
				{
					PropertyNumber = 3026,
					ZipCode = "85565",
					State = StateList.OH,
					StreetAddress = "0976 Williams Mountains",
					AptNum= "Apt. 009",
					City = "Lake Mario",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 293.42m,
					PricePerWeekday = 225.14m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 10.42m,
					NumberBed = 6,
					NumberBath = 7,
					NumberGuests = 7,
				};
				p26.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p26);
				Property p27 = new Property()
				{
					PropertyNumber = 3027,
					ZipCode = "51884",
					State = StateList.WY,
					StreetAddress = "1097 Santos Springs",
					AptNum = "Suite 264",
					City = "New Michelleborough",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 126.45m,
					PricePerWeekday = 70.24m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.69m,
					NumberBed = 2,
					NumberBath = 2,
					NumberGuests = 4,
				};
				p27.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p27);
				Property p28 = new Property()
				{
					PropertyNumber = 3028,
					ZipCode = "66353",
					State = StateList.SC,
					StreetAddress = "5100 Scott Burg",
					AptNum = null,
					City = "East Clayton",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 224.07m,
					PricePerWeekday = 186.38m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 28.24m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 3,
				};
				p28.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p28);
				Property p29 = new Property()
				{
					PropertyNumber = 3029,
					ZipCode = "57004",
					State = StateList.NV,
					StreetAddress = "412 Snow Manors",
					AptNum = "Apt. 161",
					City = "South Kimtown",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 120.93m,
					PricePerWeekday = 112.47m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 23.28m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 9,
				};
				p29.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p29);
				Property p30 = new Property()
				{
					PropertyNumber = 3030,
					ZipCode = "48447",
					State = StateList.IN,
					StreetAddress = "5415 David Square",
					AptNum = null,
					City = "West Michaeltown",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 100.02m,
					PricePerWeekday = 214.81m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 17.78m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 1,
				};
				p30.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p30);
				Property p31 = new Property()
				{
					PropertyNumber = 3031,
					ZipCode = "62982",
					State = StateList.DE,
					StreetAddress = "03104 Norris Rapids",
					AptNum = null,
					City = "Port Donald",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 161.6m,
					PricePerWeekday = 159.87m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 10.34m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 11,
				};
				p31.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p31);
				Property p32 = new Property()
				{
					PropertyNumber = 3032,
					ZipCode = "16915",
					State = StateList.FL,
					StreetAddress = "03557 Phillips Wells",
					AptNum = "Suite 291",
					City = "New Beverlyburgh",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 203.6m,
					PricePerWeekday = 70.55m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 5.09m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 4,
				};
				p32.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p32);
				Property p33 = new Property()
				{
					PropertyNumber = 3033,
					ZipCode = "39742",
					State = StateList.MT,
					StreetAddress = "332 Watson Shore",
					AptNum = "Apt. 290",
					City = "Millerland",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 299.34m,
					PricePerWeekday = 176.37m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 17.38m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 2,
				};
				p33.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p33);
				Property p34 = new Property()
				{
					PropertyNumber = 3034,
					ZipCode = "54060",
					State = StateList.MS,
					StreetAddress = "645 John Roads",
					AptNum = null,
					City = "Danahaven",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 229.98m,
					PricePerWeekday = 172.83m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 23.55m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 14,
				};
				p34.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p34);
				Property p35 = new Property()
				{
					PropertyNumber = 3035,
					ZipCode = "55774",
					State = StateList.HI,
					StreetAddress = "3547 Stephanie Underpass",
					AptNum = "Apt. 418",
					City = "Port Jacqueline",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 143.71m,
					PricePerWeekday = 177.08m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 19.21m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 5,
				};
				p35.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p35);
				Property p36 = new Property()
				{
					PropertyNumber = 3036,
					ZipCode = "59363",
					State = StateList.UT,
					StreetAddress = "5825 Welch Corners",
					AptNum = null,
					City = "Fischerport",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 113.86m,
					PricePerWeekday = 76.66m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 27.87m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 10,
				};
				p36.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p36);
				Property p37 = new Property()
				{
					PropertyNumber = 3037,
					ZipCode = "71770",
					State = StateList.IN,
					StreetAddress = "41489 Roger Terrace",
					AptNum = null,
					City = "Davisfort",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 299.09m,
					PricePerWeekday = 177.37m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 23.78m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 6,
				};
				p37.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p37);
				Property p38 = new Property()
				{
					PropertyNumber = 3038,
					ZipCode = "05147",
					State = StateList.CO,
					StreetAddress = "014 Aaron Locks",
					AptNum = "Suite 714",
					City = "Justinborough",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 158.42m,
					PricePerWeekday = 104.05m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 5.36m,
					NumberBed = 2,
					NumberBath = 2,
					NumberGuests = 5,
				};
				p38.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p38);
				Property p39 = new Property()
				{
					PropertyNumber = 3039,
					ZipCode = "28062",
					State = StateList.SC,
					StreetAddress = "8518 Pamela Track",
					AptNum = "Apt. 164",
					City = "Aprilshire",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 210.59m,
					PricePerWeekday = 199.37m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 8.83m,
					NumberBed = 3,
					NumberBath = 2,
					NumberGuests = 1,
				};
				p39.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p39);
				Property p40 = new Property()
				{
					PropertyNumber = 3040,
					ZipCode = "88090",
					State = StateList.OH,
					StreetAddress = "864 Ramos Port",
					AptNum = "Apt. 211",
					City = "Moralesmouth",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 153.69m,
					PricePerWeekday = 94.48m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 16.85m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 9,
				};
				p40.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p40);
				Property p41 = new Property()
				{
					PropertyNumber = 3041,
					ZipCode = "28775",
					State = StateList.RI,
					StreetAddress = "637 Neal Island",
					AptNum = "Suite 074",
					City = "Lake Tyler",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 196.14m,
					PricePerWeekday = 88.82m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.97m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 14,
				};
				p41.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p41);
				Property p42 = new Property()
				{
					PropertyNumber = 3042,
					ZipCode = "75585",
					State = StateList.WV,
					StreetAddress = "0811 Smith Canyon",
					AptNum = "Apt. 904",
					City = "Jessicabury",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 123.22m,
					PricePerWeekday = 119.58m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.45m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 2,
				};
				p42.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p42);
				Property p43 = new Property()
				{
					PropertyNumber = 3043,
					ZipCode = "17438",
					State = StateList.MD,
					StreetAddress = "7562 Fisher Spur",
					AptNum = null,
					City = "Hernandezberg",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 283.77m,
					PricePerWeekday = 218.87m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 19.07m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 2,
				};
				p43.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p43);
				Property p44 = new Property()
				{
					PropertyNumber = 3044,
					ZipCode = "07027",
					State = StateList.VT,
					StreetAddress = "5667 Blair Underpass",
					AptNum = null,
					City = "South Shelby",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 239.76m,
					PricePerWeekday = 76.19m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.37m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 13,
				};
				p44.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p44);
				Property p45 = new Property()
				{
					PropertyNumber = 3045,
					ZipCode = "01008",
					State = StateList.MI,
					StreetAddress = "6708 Carpenter Overpass",
					AptNum = "Suite 735",
					City = "Bobbyton",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 229.04m,
					PricePerWeekday = 161.17m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 25.01m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 7,
				};
				p45.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p45);
				Property p46 = new Property()
				{
					PropertyNumber = 3046,
					ZipCode = "60236",
					State = StateList.ND,
					StreetAddress = "16396 Shawn Junction",
					AptNum = null,
					City = "New Nicolemouth",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 220.69m,
					PricePerWeekday = 106.06m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.82m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 6,
				};
				p46.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p46);
				Property p47 = new Property()
				{
					PropertyNumber = 3047,
					ZipCode = "01707",
					State = StateList.CA,
					StreetAddress = "4486 Olson Well",
					AptNum = null,
					City = "North Kevin",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 138.96m,
					PricePerWeekday = 151.44m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 6.72m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 10,
				};
				p47.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p47);
				Property p48 = new Property()
				{
					PropertyNumber = 3048,
					ZipCode = "33233",
					State = StateList.HI,
					StreetAddress = "67771 Christopher Courts",
					AptNum = "Apt. 637",
					City = "Port Ronaldfurt",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 134.28m,
					PricePerWeekday = 102.43m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 19.81m,
					NumberBed = 5,
					NumberBath = 5,
					NumberGuests = 2,
				};
				p48.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p48);
				Property p49 = new Property()
				{
					PropertyNumber = 3049,
					ZipCode = "79756",
					State = StateList.NY,
					StreetAddress = "5561 Bishop Turnpike",
					AptNum = null,
					City = "Lake Kenneth",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 259.87m,
					PricePerWeekday = 94.31m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 22.33m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 11,
				};
				p49.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p49);
				Property p50 = new Property()
				{
					PropertyNumber = 3050,
					ZipCode = "36216",
					State = StateList.SD,
					StreetAddress = "3019 Gerald Mall",
					AptNum = "Apt. 340",
					City = "Trevinoville",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 263.32m,
					PricePerWeekday = 151.69m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.27m,
					NumberBed = 5,
					NumberBath = 5,
					NumberGuests = 1,
				};
				p50.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p50);
				Property p51 = new Property()
				{
					PropertyNumber = 3051,
					ZipCode = "43477",
					State = StateList.NY,
					StreetAddress = "84331 Leonard Fort",
					AptNum = "Suite 749",
					City = "East Lisa",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 204.28m,
					PricePerWeekday = 204.04m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.07m,
					NumberBed = 7,
					NumberBath = 8,
					NumberGuests = 10,
				};
				p51.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p51);
				Property p52 = new Property()
				{
					PropertyNumber = 3052,
					ZipCode = "17819",
					State = StateList.VA,
					StreetAddress = "62281 Kathy Tunnel",
					AptNum = null,
					City = "Hudsonborough",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 224.19m,
					PricePerWeekday = 165.51m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 24.26m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 9,
				};
				p52.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p52);
				Property p53 = new Property()
				{
					PropertyNumber = 3053,
					ZipCode = "97149",
					State = StateList.NM,
					StreetAddress = "9927 Christina Burg",
					AptNum = "Suite 774",
					City = "East Angelaburgh",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 121.74m,
					PricePerWeekday = 106.87m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 5.62m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 6,
				};
				p53.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p53);
				Property p54 = new Property()
				{
					PropertyNumber = 3054,
					ZipCode = "45480",
					State = StateList.IA,
					StreetAddress = "142 Warner View",
					AptNum = "Suite 460",
					City = "North Leslie",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 148.76m,
					PricePerWeekday = 212.32m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.2m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 9,
				};
				p54.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p54);
				Property p55 = new Property()
				{
					PropertyNumber = 3055,
					ZipCode = "03720",
					State = StateList.AR,
					StreetAddress = "5240 Berry Centers",
					AptNum = null,
					City = "West Andrew",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 111.01m,
					PricePerWeekday = 164.02m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 26.21m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 12,
				};
				p55.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p55);
				Property p56 = new Property()
				{
					PropertyNumber = 3056,
					ZipCode = "85576",
					State = StateList.HI,
					StreetAddress = "51056 Patricia Forge",
					AptNum = null,
					City = "Grahamstad",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 167.53m,
					PricePerWeekday = 117.45m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 24.75m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 10,
				};
				p56.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p56);
				Property p57 = new Property()
				{
					PropertyNumber = 3057,
					ZipCode = "92199",
					State = StateList.VA,
					StreetAddress = "0648 Malone Port",
					AptNum = "Apt. 662",
					City = "New Devonhaven",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 176.53m,
					PricePerWeekday = 209.47m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 5.83m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 12,
				};
				p57.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p57);
				Property p58 = new Property()
				{
					PropertyNumber = 3058,
					ZipCode = "05261",
					State = StateList.SC,
					StreetAddress = "23028 Jennifer Meadow",
					AptNum = "Apt. 972",
					City = "West Matthewfurt",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 199.1m,
					PricePerWeekday = 153.04m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 18.62m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 14,
				};
				p58.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p58);
				Property p59 = new Property()
				{
					PropertyNumber = 3059,
					ZipCode = "72649",
					State = StateList.LA,
					StreetAddress = "2738 Martin Terrace",
					AptNum = "Suite 547",
					City = "Smithhaven",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 199.22m,
					PricePerWeekday = 196.56m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.71m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 11,
				};
				p59.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p59);
				Property p60 = new Property()
				{
					PropertyNumber = 3060,
					ZipCode = "97488",
					State = StateList.KY,
					StreetAddress = "984 Stephen Stravenue",
					AptNum = null,
					City = "South Michaelton",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 178.29m,
					PricePerWeekday = 117.03m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 6.47m,
					NumberBed = 4,
					NumberBath = 6,
					NumberGuests = 3,
				};
				p60.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p60);
				Property p61 = new Property()
				{
					PropertyNumber = 3061,
					ZipCode = "42837",
					State = StateList.LA,
					StreetAddress = "98522 Mathis Viaduct",
					AptNum = "Apt. 909",
					City = "West Michael",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 252.79m,
					PricePerWeekday = 133.35m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 9.15m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 1,
				};
				p61.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p61);
				Property p62 = new Property()
				{
					PropertyNumber = 3062,
					ZipCode = "56059",
					State = StateList.OH,
					StreetAddress = "620 Ashley Mills",
					AptNum = "Apt. 507",
					City = "Julieborough",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 296.05m,
					PricePerWeekday = 171.15m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.26m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 9,
				};
				p62.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p62);
				Property p63 = new Property()
				{
					PropertyNumber = 3063,
					ZipCode = "02288",
					State = StateList.LA,
					StreetAddress = "212 Shelly Roads",
					AptNum = null,
					City = "Fischerview",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 163.88m,
					PricePerWeekday = 132.81m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 7.46m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 10,
				};
				p63.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p63);
				Property p64 = new Property()
				{
					PropertyNumber = 3064,
					ZipCode = "50851",
					State = StateList.OK,
					StreetAddress = "8885 Lee Tunnel",
					AptNum = "Suite 208",
					City = "Port Donna",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 140.73m,
					PricePerWeekday = 228.84m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 17.13m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 7,
				};
				p64.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p64);
				Property p65 = new Property()
				{
					PropertyNumber = 3065,
					ZipCode = "03009",
					State = StateList.NM,
					StreetAddress = "693 Michael Estate",
					AptNum = null,
					City = "Lake Michael",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 139.83m,
					PricePerWeekday = 155.03m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 21.05m,
					NumberBed = 4,
					NumberBath = 5,
					NumberGuests = 13,
					Discount = 15,
					DiscountDays = 4 
				};
				p65.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p65);
				Property p66 = new Property()
				{
					PropertyNumber = 3066,
					ZipCode = "92905",
					State = StateList.NY,
					StreetAddress = "342 Miller Mission",
					AptNum = null,
					City = "Lake Jennifer",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 249.24m,
					PricePerWeekday = 128.41m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.63m,
					NumberBed = 4,
					NumberBath = 5,
					NumberGuests = 1,
				};
				p66.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p66);
				Property p67 = new Property()
				{
					PropertyNumber = 3067,
					ZipCode = "65056",
					State = StateList.AK,
					StreetAddress = "71664 Kim Throughway",
					AptNum = null,
					City = "Chelsealand",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 286.53m,
					PricePerWeekday = 163.68m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 25.57m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 9,
				};
				p67.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p67);
				Property p68 = new Property()
				{
					PropertyNumber = 3068,
					ZipCode = "11181",
					State = StateList.AZ,
					StreetAddress = "66660 Gomez Port",
					AptNum = "Apt. 945",
					City = "South Thomashaven",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 137.17m,
					PricePerWeekday = 93.86m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 28.18m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 2,
				};
				p68.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p68);
				Property p69 = new Property()
				{
					PropertyNumber = 3069,
					ZipCode = "53480",
					State = StateList.FL,
					StreetAddress = "0131 Williams Ville",
					AptNum = "Apt. 562",
					City = "Richardberg",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 120.61m,
					PricePerWeekday = 86.25m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.39m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 13,
				};
				p69.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p69);
				Property p70 = new Property()
				{
					PropertyNumber = 3070,
					ZipCode = "11353",
					State = StateList.OR,
					StreetAddress = "22708 Madison Spurs",
					AptNum = null,
					City = "Herringstad",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 241.25m,
					PricePerWeekday = 182.46m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 18.29m,
					NumberBed = 6,
					NumberBath = 7,
					NumberGuests = 2,
				};
				p70.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p70);
				Property p71 = new Property()
				{
					PropertyNumber = 3071,
					ZipCode = "05560",
					State = StateList.FL,
					StreetAddress = "3454 Holmes Motorway",
					AptNum = null,
					City = "Port Rachel",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 123.04m,
					PricePerWeekday = 89.88m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 19.14m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 1,
				};
				p71.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p71);
				Property p72 = new Property()
				{
					PropertyNumber = 3072,
					ZipCode = "93500",
					State = StateList.GA,
					StreetAddress = "805 James Turnpike",
					AptNum = null,
					City = "Carrmouth",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 219.86m,
					PricePerWeekday = 81.55m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 13.38m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 12,
				};
				p72.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p72);
				Property p73 = new Property()
				{
					PropertyNumber = 3073,
					ZipCode = "44515",
					State = StateList.NV,
					StreetAddress = "8081 Smith Trail",
					AptNum = null,
					City = "North Ronaldstad",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 196.09m,
					PricePerWeekday = 130.47m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 14.53m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 3,
				};
				p73.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p73);
				Property p74 = new Property()
				{
					PropertyNumber = 3074,
					ZipCode = "07347",
					State = StateList.MS,
					StreetAddress = "125 Ian Crossroad",
					AptNum = "Apt. 593",
					City = "South Deannaport",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 136.82m,
					PricePerWeekday = 148.1m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 15.57m,
					NumberBed = 2,
					NumberBath = 1,
					NumberGuests = 4,
				};
				p74.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p74);
				Property p75 = new Property()
				{
					PropertyNumber = 3075,
					ZipCode = "54532",
					State = StateList.NH,
					StreetAddress = "1607 Munoz River",
					AptNum = null,
					City = "Emilyshire",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 209.77m,
					PricePerWeekday = 147.55m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 27.65m,
					NumberBed = 6,
					NumberBath = 7,
					NumberGuests = 3,
				};
				p75.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p75);
				Property p76 = new Property()
				{
					PropertyNumber = 3076,
					ZipCode = "65516",
					State = StateList.UT,
					StreetAddress = "3615 David Keys",
					AptNum = "Apt. 269",
					City = "West Stephenside",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 126.47m,
					PricePerWeekday = 86.8m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 17.6m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 3,
				};
				p76.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p76);
				Property p77 = new Property()
				{
					PropertyNumber = 3077,
					ZipCode = "20721",
					State = StateList.AZ,
					StreetAddress = "640 Mary Common",
					AptNum = null,
					City = "Michaelville",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 173.01m,
					PricePerWeekday = 121.75m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 12.53m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 7,
				};
				p77.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p77);
				Property p78 = new Property()
				{
					PropertyNumber = 3078,
					ZipCode = "43567",
					State = StateList.LA,
					StreetAddress = "395 Timothy Road",
					AptNum = null,
					City = "Williamsbury",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 198.1m,
					PricePerWeekday = 160.23m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 10.82m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 5,
				};
				p78.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p78);
				Property p79 = new Property()
				{
					PropertyNumber = 3079,
					ZipCode = "01239",
					State = StateList.OR,
					StreetAddress = "3267 Walter Dam",
					AptNum = null,
					City = "Cunninghamtown",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 127.7m,
					PricePerWeekday = 110.64m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 26.67m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 7,
				};
				p79.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p79);
				Property p80 = new Property()
				{
					PropertyNumber = 3080,
					ZipCode = "03966",
					State = StateList.MS,
					StreetAddress = "00580 Brandon Creek",
					AptNum = null,
					City = "Port Eric",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 236.71m,
					PricePerWeekday = 227.6m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 20.22m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 2,
				};
				p80.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p80);
				Property p81 = new Property()
				{
					PropertyNumber = 3081,
					ZipCode = "29996",
					State = StateList.MS,
					StreetAddress = "325 Amanda Cliffs",
					AptNum = "Apt. 695",
					City = "South Paulabury",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 135.59m,
					PricePerWeekday = 115.37m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 29.8m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 13,
				};
				p81.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p81);
				Property p82 = new Property()
				{
					PropertyNumber = 3082,
					ZipCode = "93980",
					State = StateList.CT,
					StreetAddress = "40956 Amanda Walk",
					AptNum = "Apt. 260",
					City = "Simonfurt",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 271.49m,
					PricePerWeekday = 93.35m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 8.54m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 5,
				};
				p82.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p82);
				Property p83 = new Property()
				{
					PropertyNumber = 3083,
					ZipCode = "23687",
					State = StateList.KS,
					StreetAddress = "25762 Gill Creek",
					AptNum = "Suite 525",
					City = "Mccoyton",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 247.15m,
					PricePerWeekday = 171.37m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 17.22m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 5,
				};
				p83.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p83);
				Property p84 = new Property()
				{
					PropertyNumber = 3084,
					ZipCode = "04593",
					State = StateList.GA,
					StreetAddress = "6048 Johnson Loop",
					AptNum = "Suite 635",
					City = "East Daniel",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 299.6m,
					PricePerWeekday = 95.59m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 24.3m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 8,
				};
				p84.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p84);
				Property p85 = new Property()
				{
					PropertyNumber = 3085,
					ZipCode = "96954",
					State = StateList.RI,
					StreetAddress = "1168 Gary Fords",
					AptNum = "Apt. 308",
					City = "Port Trevor",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 278.17m,
					PricePerWeekday = 194.84m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 5.88m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 11,
					Discount = 40,
					DiscountDays = 7
				};
				p85.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p85);
				Property p86 = new Property()
				{
					PropertyNumber = 3086,
					ZipCode = "62271",
					State = StateList.MS,
					StreetAddress = "164 Matthew Parkway",
					AptNum = "Suite 826",
					City = "Jimmyfurt",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 100.08m,
					PricePerWeekday = 112.03m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 28.82m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 8,
				};
				p86.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p86);
				Property p87 = new Property()
				{
					PropertyNumber = 3087,
					ZipCode = "05222",
					State = StateList.CO,
					StreetAddress = "1220 Heidi Rue",
					AptNum = "Apt. 998",
					City = "West Haleyburgh",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 182.77m,
					PricePerWeekday = 127.97m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.02m,
					NumberBed = 5,
					NumberBath = 4,
					NumberGuests = 1,
				};
				p87.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p87);
				Property p88 = new Property()
				{
					PropertyNumber = 3088,
					ZipCode = "22365",
					State = StateList.SD,
					StreetAddress = "751 Wood Square",
					AptNum = "Suite 732",
					City = "Port Melissaburgh",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 186.01m,
					PricePerWeekday = 120.07m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 26.71m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 13,
				};
				p88.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p88);
				Property p89 = new Property()
				{
					PropertyNumber = 3089,
					ZipCode = "53609",
					State = StateList.OR,
					StreetAddress = "376 Smith Dale",
					AptNum = "Suite 279",
					City = "South Sarahland",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 122.31m,
					PricePerWeekday = 137.96m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 26.29m,
					NumberBed = 2,
					NumberBath = 2,
					NumberGuests = 9,
				};
				p89.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p89);
				Property p90 = new Property()
				{
					PropertyNumber = 3090,
					ZipCode = "09478",
					State = StateList.CA,
					StreetAddress = "79148 Pierce Lock",
					AptNum = "Suite 423",
					City = "Erikberg",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 234.61m,
					PricePerWeekday = 226.57m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 16.41m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 6,
				};
				p90.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p90);
				Property p91 = new Property()
				{
					PropertyNumber = 3091,
					ZipCode = "01425",
					State = StateList.ID,
					StreetAddress = "147 Lisa Hill",
					AptNum = "Apt. 512",
					City = "Port Elizabethshire",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 145.15m,
					PricePerWeekday = 95.73m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 9.93m,
					NumberBed = 4,
					NumberBath = 6,
					NumberGuests = 10,
				};
				p91.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p91);
				Property p92 = new Property()
				{
					PropertyNumber = 3092,
					ZipCode = "29941",
					State = StateList.KY,
					StreetAddress = "971 Hansen Well",
					AptNum = "Suite 103",
					City = "South Mary",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 145.72m,
					PricePerWeekday = 161.68m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 24.36m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 4,
				};
				p92.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p92);
				Property p93 = new Property()
				{
					PropertyNumber = 3093,
					ZipCode = "47577",
					State = StateList.WY,
					StreetAddress = "511 Berry Fork",
					AptNum = "Suite 623",
					City = "Sharonfort",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 260.18m,
					PricePerWeekday = 183.81m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 7.46m,
					NumberBed = 4,
					NumberBath = 5,
					NumberGuests = 3,
				};
				p93.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p93);
				Property p94 = new Property()
				{
					PropertyNumber = 3094,
					ZipCode = "94134",
					State = StateList.WI,
					StreetAddress = "65873 Chen Knolls",
					AptNum = null,
					City = "Ramirezfurt",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 117.17m,
					PricePerWeekday = 215.38m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 24.31m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 14,
				};
				p94.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p94);
				Property p95 = new Property()
				{
					PropertyNumber = 3095,
					ZipCode = "57039",
					State = StateList.IN,
					StreetAddress = "8799 Emma Parkway",
					AptNum = "Suite 735",
					City = "North Thomasfurt",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 242.21m,
					PricePerWeekday = 145.51m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 11.89m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 11,
				};
				p95.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p95);
				Property p96 = new Property()
				{
					PropertyNumber = 3096,
					ZipCode = "23718",
					State = StateList.ND,
					StreetAddress = "30068 David View",
					AptNum = "Apt. 173",
					City = "New Peggychester",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 161.21m,
					PricePerWeekday = 142.76m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.92m,
					NumberBed = 4,
					NumberBath = 6,
					NumberGuests = 7,
				};
				p96.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p96);
				Property p97 = new Property()
				{
					PropertyNumber = 3097,
					ZipCode = "26932",
					State = StateList.MD,
					StreetAddress = "298 Johnathan Cove",
					AptNum = "Apt. 402",
					City = "South Jamie",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 176.37m,
					PricePerWeekday = 170.07m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 8.54m,
					NumberBed = 6,
					NumberBath = 7,
					NumberGuests = 13,
				};
				p97.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p97);
				Property p98 = new Property()
				{
					PropertyNumber = 3098,
					ZipCode = "74554",
					State = StateList.CO,
					StreetAddress = "171 Harrison Motorway",
					AptNum = null,
					City = "Davidview",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 234.81m,
					PricePerWeekday = 145.08m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 26.14m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 10,
				};
				p98.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p98);
				Property p99 = new Property()
				{
					PropertyNumber = 3099,
					ZipCode = "32097",
					State = StateList.NE,
					StreetAddress = "3576 Sergio Avenue",
					AptNum = null,
					City = "Benjaminmouth",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 260.62m,
					PricePerWeekday = 111.73m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 15.89m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 1,
				};
				p99.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p99);
				Property p100 = new Property()
				{
					PropertyNumber = 3100,
					ZipCode = "21519",
					State = StateList.RI,
					StreetAddress = "37457 Tanya Pike",
					AptNum = "Apt. 348",
					City = "North Ericton",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 214.62m,
					PricePerWeekday = 70.63m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 5.29m,
					NumberBed = 2,
					NumberBath = 1,
					NumberGuests = 13,
				};
				p100.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p100);
				Property p101 = new Property()
				{
					PropertyNumber = 3101,
					ZipCode = "76875",
					State = StateList.PA,
					StreetAddress = "3673 Peter Turnpike",
					AptNum = "Suite 835",
					City = "New Sandra",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 172.79m,
					PricePerWeekday = 229.03m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 14.05m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 6,
				};
				p101.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p101);
				Property p102 = new Property()
				{
					PropertyNumber = 3102,
					ZipCode = "80451",
					State = StateList.TX,
					StreetAddress = "939 Johnson Oval",
					AptNum = "Suite 830",
					City = "North Dennismouth",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 133.53m,
					PricePerWeekday = 169.34m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.06m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 6,
				};
				p102.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p102);
				Property p103 = new Property()
				{
					PropertyNumber = 3103,
					ZipCode = "51726",
					State = StateList.NV,
					StreetAddress = "645 Jennings Estates",
					AptNum = null,
					City = "Angelastad",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 109.44m,
					PricePerWeekday = 155.52m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 8.28m,
					NumberBed = 2,
					NumberBath = 3,
					NumberGuests = 4,
				};
				p103.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p103);
				Property p104 = new Property()
				{
					PropertyNumber = 3104,
					ZipCode = "77240",
					State = StateList.MT,
					StreetAddress = "1231 Stephanie Lock",
					AptNum = "Suite 835",
					City = "North Richardland",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 182.33m,
					PricePerWeekday = 180.2m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 17.78m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 5,
				};
				p104.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p104);
				Property p105 = new Property()
				{
					PropertyNumber = 3105,
					ZipCode = "98152",
					State = StateList.CO,
					StreetAddress = "302 Parker Plains",
					AptNum = "Apt. 197",
					City = "East Robertstad",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 212.7m,
					PricePerWeekday = 212.86m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.82m,
					NumberBed = 3,
					NumberBath = 2,
					NumberGuests = 1,
				};
				p105.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p105);
				Property p106 = new Property()
				{
					PropertyNumber = 3106,
					ZipCode = "98277",
					State = StateList.MS,
					StreetAddress = "098 Hernandez Green",
					AptNum = null,
					City = "New Sergiobury",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 262.3m,
					PricePerWeekday = 188.71m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 21.88m,
					NumberBed = 4,
					NumberBath = 6,
					NumberGuests = 8,
				};
				p106.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p106);
				Property p107 = new Property()
				{
					PropertyNumber = 3107,
					ZipCode = "80082",
					State = StateList.NE,
					StreetAddress = "94102 Sims Port",
					AptNum = "Suite 187",
					City = "Florestown",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 128.05m,
					PricePerWeekday = 83.34m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.29m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 8,
					Discount = 25,
					DiscountDays = 5
				};
				p107.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p107);
				Property p108 = new Property()
				{
					PropertyNumber = 3108,
					ZipCode = "71531",
					State = StateList.ND,
					StreetAddress = "01630 Baker Crescent",
					AptNum = null,
					City = "Kellyborough",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 125.27m,
					PricePerWeekday = 204.02m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 21.15m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 4,
				};
				p108.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p108);
				Property p109 = new Property()
				{
					PropertyNumber = 3109,
					ZipCode = "14157",
					State = StateList.OK,
					StreetAddress = "70452 Forbes Courts",
					AptNum = null,
					City = "Mosesland",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 172.1m,
					PricePerWeekday = 90.98m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 18.09m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 9,
				};
				p109.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p109);
				Property p110 = new Property()
				{
					PropertyNumber = 3110,
					ZipCode = "26899",
					State = StateList.MO,
					StreetAddress = "0835 Angela Station",
					AptNum = null,
					City = "East Heather",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 299.91m,
					PricePerWeekday = 158.64m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 23.09m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 9,
				};
				p110.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p110);
				Property p111 = new Property()
				{
					PropertyNumber = 3111,
					ZipCode = "42872",
					State = StateList.VT,
					StreetAddress = "2458 Jason Village",
					AptNum = "Suite 248",
					City = "North Donnamouth",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 189.3m,
					PricePerWeekday = 107.97m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 9.05m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 4,
				};
				p111.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p111);
				Property p112 = new Property()
				{
					PropertyNumber = 3112,
					ZipCode = "78301",
					State = StateList.CO,
					StreetAddress = "1243 Grimes Corners",
					AptNum = null,
					City = "Shawchester",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 193.24m,
					PricePerWeekday = 214.14m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 26.1m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 2,
				};
				p112.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p112);
				Property p113 = new Property()
				{
					PropertyNumber = 3113,
					ZipCode = "34523",
					State = StateList.DC,
					StreetAddress = "558 Williams Station",
					AptNum = null,
					City = "Port Pamela",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 192.46m,
					PricePerWeekday = 106.3m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 17.59m,
					NumberBed = 6,
					NumberBath = 7,
					NumberGuests = 4,
				};
				p113.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p113);
				Property p114 = new Property()
				{
					PropertyNumber = 3114,
					ZipCode = "63064",
					State = StateList.VT,
					StreetAddress = "4934 Lozano Place",
					AptNum = "Suite 716",
					City = "Gavinton",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 257.37m,
					PricePerWeekday = 116.99m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 5.63m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 6,
				};
				p114.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p114);
				Property p115 = new Property()
				{
					PropertyNumber = 3115,
					ZipCode = "35700",
					State = StateList.LA,
					StreetAddress = "41227 Patricia Lake",
					AptNum = null,
					City = "Martinezbury",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 108.28m,
					PricePerWeekday = 203.03m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 11.35m,
					NumberBed = 2,
					NumberBath = 1,
					NumberGuests = 3,
				};
				p115.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p115);
				Property p116 = new Property()
				{
					PropertyNumber = 3116,
					ZipCode = "55206",
					State = StateList.VA,
					StreetAddress = "028 Harris Drive",
					AptNum = "Apt. 422",
					City = "Amyburgh",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 262.77m,
					PricePerWeekday = 163.3m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.74m,
					NumberBed = 2,
					NumberBath = 2,
					NumberGuests = 14,
				};
				p116.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p116);
				Property p117 = new Property()
				{
					PropertyNumber = 3117,
					ZipCode = "98240",
					State = StateList.IA,
					StreetAddress = "06268 Lewis Place",
					AptNum = "Suite 121",
					City = "Port Patriciatown",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 108.52m,
					PricePerWeekday = 156.25m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 23.66m,
					NumberBed = 3,
					NumberBath = 2,
					NumberGuests = 4,
				};
				p117.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p117);
				Property p118 = new Property()
				{
					PropertyNumber = 3118,
					ZipCode = "87205",
					State = StateList.WI,
					StreetAddress = "5641 Brenda Streets",
					AptNum = "Apt. 008",
					City = "Lake Seanmouth",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 153.42m,
					PricePerWeekday = 178.27m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 24.69m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 12,
				};
				p118.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p118);
				Property p119 = new Property()
				{
					PropertyNumber = 3119,
					ZipCode = "58221",
					State = StateList.ME,
					StreetAddress = "92555 Shaw Spurs",
					AptNum = "Suite 207",
					City = "New Randy",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 184.92m,
					PricePerWeekday = 92.51m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 12.82m,
					NumberBed = 7,
					NumberBath = 8,
					NumberGuests = 13,
				};
				p119.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p119);
				Property p120 = new Property()
				{
					PropertyNumber = 3120,
					ZipCode = "18885",
					State = StateList.NY,
					StreetAddress = "559 Foster Locks",
					AptNum = "Suite 933",
					City = "Robinsonhaven",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 225.85m,
					PricePerWeekday = 224.62m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 17.9m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 6,
				};
				p120.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p120);
				Property p121 = new Property()
				{
					PropertyNumber = 3121,
					ZipCode = "00638",
					State = StateList.WY,
					StreetAddress = "4647 Kristine Fields",
					AptNum = "Suite 710",
					City = "New Dakota",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 174.02m,
					PricePerWeekday = 112.61m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 17.48m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 10,
				};
				p121.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p121);
				Property p122 = new Property()
				{
					PropertyNumber = 3122,
					ZipCode = "31451",
					State = StateList.ME,
					StreetAddress = "92594 Emily Shoals",
					AptNum = null,
					City = "North Cathyburgh",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 119.06m,
					PricePerWeekday = 189.98m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 25.11m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 1,
				};
				p122.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p122);
				Property p123 = new Property()
				{
					PropertyNumber = 3123,
					ZipCode = "26297",
					State = StateList.MS,
					StreetAddress = "551 Casey Squares",
					AptNum = "Apt. 209",
					City = "Michaelborough",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 114.73m,
					PricePerWeekday = 72.03m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 18.38m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 6,
				};
				p123.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p123);
				Property p124 = new Property()
				{
					PropertyNumber = 3124,
					ZipCode = "04610",
					State = StateList.PA,
					StreetAddress = "2998 Willis Wall",
					AptNum = null,
					City = "North Brian",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 144.51m,
					PricePerWeekday = 216.21m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 10.81m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 3,
				};
				p124.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p124);
				Property p125 = new Property()
				{
					PropertyNumber = 3125,
					ZipCode = "86618",
					State = StateList.MD,
					StreetAddress = "164 Schultz Road",
					AptNum = null,
					City = "Lake Bryan",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 233.9m,
					PricePerWeekday = 132.69m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 15.8m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 13,
				};
				p125.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p125);
				Property p126 = new Property()
				{
					PropertyNumber = 3126,
					ZipCode = "80124",
					State = StateList.GA,
					StreetAddress = "9541 Brock Estate",
					AptNum = "Apt. 848",
					City = "Franklinchester",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 285.05m,
					PricePerWeekday = 220.97m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 20.98m,
					NumberBed = 2,
					NumberBath = 1,
					NumberGuests = 9,
				};
				p126.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p126);
				Property p127 = new Property()
				{
					PropertyNumber = 3127,
					ZipCode = "63590",
					State = StateList.MS,
					StreetAddress = "588 Alan Rest",
					AptNum = null,
					City = "Port Stephanieville",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 180.86m,
					PricePerWeekday = 224.98m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.91m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 12,
				};
				p127.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p127);
				Property p128 = new Property()
				{
					PropertyNumber = 3128,
					ZipCode = "53548",
					State = StateList.MT,
					StreetAddress = "216 Brandon Loop",
					AptNum = "Apt. 096",
					City = "New Jessica",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 239.97m,
					PricePerWeekday = 221.98m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 9.24m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 12,
				};
				p128.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p128);
				Property p129 = new Property()
				{
					PropertyNumber = 3129,
					ZipCode = "35611",
					State = StateList.LA,
					StreetAddress = "782 Dawn Radial",
					AptNum = null,
					City = "Port Christopher",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 297.25m,
					PricePerWeekday = 76.56m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.42m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 1,
				};
				p129.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p129);
				Property p130 = new Property()
				{
					PropertyNumber = 3130,
					ZipCode = "42879",
					State = StateList.WA,
					StreetAddress = "008 Nancy Route",
					AptNum = "Suite 228",
					City = "North Stephanie",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 129.36m,
					PricePerWeekday = 128.71m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 23.76m,
					NumberBed = 2,
					NumberBath = 3,
					NumberGuests = 3,
				};
				p130.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p130);
				Property p131 = new Property()
				{
					PropertyNumber = 3131,
					ZipCode = "71569",
					State = StateList.MO,
					StreetAddress = "115 Jon Isle",
					AptNum = "Suite 788",
					City = "North Lesliefurt",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 210.63m,
					PricePerWeekday = 114.21m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 21.08m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 9,
				};
				p131.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p131);
				Property p132 = new Property()
				{
					PropertyNumber = 3132,
					ZipCode = "87566",
					State = StateList.DE,
					StreetAddress = "132 Poole Pass",
					AptNum = "Suite 212",
					City = "North Patrick",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 280.37m,
					PricePerWeekday = 146.82m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 26.78m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 11,
				};
				p132.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p132);
				Property p133 = new Property()
				{
					PropertyNumber = 3133,
					ZipCode = "67652",
					State = StateList.WY,
					StreetAddress = "457 Vargas Island",
					AptNum = "Suite 853",
					City = "Lake Patrickstad",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 249.39m,
					PricePerWeekday = 134.72m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 19.19m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 1,
				};
				p133.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p133);
				Property p134 = new Property()
				{
					PropertyNumber = 3134,
					ZipCode = "45184",
					State = StateList.HI,
					StreetAddress = "1569 Amy Path",
					AptNum = null,
					City = "North Ashleyton",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 111.23m,
					PricePerWeekday = 111.6m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 13.48m,
					NumberBed = 7,
					NumberBath = 8,
					NumberGuests = 7,
				};
				p134.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p134);
				Property p135 = new Property()
				{
					PropertyNumber = 3135,
					ZipCode = "04078",
					State = StateList.IL,
					StreetAddress = "0375 Sandra Trace",
					AptNum = "Suite 826",
					City = "Gailshire",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 168.47m,
					PricePerWeekday = 89m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 14.93m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 3,
				};
				p135.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p135);
				Property p136 = new Property()
				{
					PropertyNumber = 3136,
					ZipCode = "50437",
					State = StateList.MN,
					StreetAddress = "759 Good Port",
					AptNum = null,
					City = "New Russell",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 208.35m,
					PricePerWeekday = 208.64m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 7.09m,
					NumberBed = 5,
					NumberBath = 5,
					NumberGuests = 6,
				};
				p136.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p136);
				Property p137 = new Property()
				{
					PropertyNumber = 3137,
					ZipCode = "34147",
					State = StateList.WV,
					StreetAddress = "3895 Allen Junction",
					AptNum = null,
					City = "West John",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 195.41m,
					PricePerWeekday = 172.51m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 21.53m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 3,
				};
				p137.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p137);
				Property p138 = new Property()
				{
					PropertyNumber = 3138,
					ZipCode = "36340",
					State = StateList.MS,
					StreetAddress = "7329 Jacobs Station",
					AptNum = null,
					City = "New Tylerborough",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 146.12m,
					PricePerWeekday = 163.15m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 18.98m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 8,
				};
				p138.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p138);
				Property p139 = new Property()
				{
					PropertyNumber = 3139,
					ZipCode = "88806",
					State = StateList.MD,
					StreetAddress = "5003 Cassandra Estates",
					AptNum = "Suite 148",
					City = "Haleychester",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 161.49m,
					PricePerWeekday = 81.5m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 16.41m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 9,
				};
				p139.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p139);
				Property p140 = new Property()
				{
					PropertyNumber = 3140,
					ZipCode = "76853",
					State = StateList.TN,
					StreetAddress = "10524 Parker Mall",
					AptNum = "Suite 531",
					City = "Port Courtneyhaven",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 120.73m,
					PricePerWeekday = 177.94m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 9.5m,
					NumberBed = 5,
					NumberBath = 7,
					NumberGuests = 13,
				};
				p140.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Hotel");
				//Add this book to the list of properties to add 
				Properties.Add(p140);
				Property p141 = new Property()
				{
					PropertyNumber = 3141,
					ZipCode = "93533",
					State = StateList.MO,
					StreetAddress = "300 Madison Stream",
					AptNum = null,
					City = "Christophershire",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 187.08m,
					PricePerWeekday = 121.01m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 16.48m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 6,
				};
				p141.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p141);
				Property p142 = new Property()
				{
					PropertyNumber = 3142,
					ZipCode = "96763",
					State = StateList.FL,
					StreetAddress = "4229 Derrick Wells",
					AptNum = null,
					City = "West Tyler",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 241.45m,
					PricePerWeekday = 199.68m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 25.94m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 6,
				};
				p142.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p142);
				Property p143 = new Property()
				{
					PropertyNumber = 3143,
					ZipCode = "92174",
					State = StateList.VA,
					StreetAddress = "26239 Michael Shoals",
					AptNum = null,
					City = "Gregoryview",
					HostEmail = "morales@aol.com",
					PricePerWeekend = 111.91m,
					PricePerWeekday = 162.01m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 14.35m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 9,
				};
				p143.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p143);
				Property p144 = new Property()
				{
					PropertyNumber = 3144,
					ZipCode = "88294",
					State = StateList.IN,
					StreetAddress = "302 Joy Spring",
					AptNum = "Apt. 622",
					City = "Ryanhaven",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 163.73m,
					PricePerWeekday = 173.36m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 25.35m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 12,
				};
				p144.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p144);
				Property p145 = new Property()
				{
					PropertyNumber = 3145,
					ZipCode = "23464",
					State = StateList.CA,
					StreetAddress = "734 Craig Overpass",
					AptNum = "Suite 589",
					City = "Jefferyside",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 287.28m,
					PricePerWeekday = 216.1m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 22.2m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 8,
				};
				p145.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p145);
				Property p146 = new Property()
				{
					PropertyNumber = 3146,
					ZipCode = "35243",
					State = StateList.CA,
					StreetAddress = "272 Green Street",
					AptNum = null,
					City = "Port Lacey",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 247.34m,
					PricePerWeekday = 211.51m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 11.73m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 7,
				};
				p146.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p146);
				Property p147 = new Property()
				{
					PropertyNumber = 3147,
					ZipCode = "61935",
					State = StateList.IL,
					StreetAddress = "8056 Dunn Trail",
					AptNum = "Apt. 049",
					City = "Blackshire",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 189.08m,
					PricePerWeekday = 111.4m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 19.58m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 2,
				};
				p147.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p147);
				Property p148 = new Property()
				{
					PropertyNumber = 3148,
					ZipCode = "72324",
					State = StateList.CA,
					StreetAddress = "86187 Antonio Fort",
					AptNum = null,
					City = "North Carmen",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 109.87m,
					PricePerWeekday = 150.69m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 13.3m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 7,
				};
				p148.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p148);
				Property p149 = new Property()
				{
					PropertyNumber = 3149,
					ZipCode = "84393",
					State = StateList.NJ,
					StreetAddress = "71318 Cassandra Plaza",
					AptNum = null,
					City = "Burkeview",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 227.55m,
					PricePerWeekday = 184.21m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 19.52m,
					NumberBed = 7,
					NumberBath = 7,
					NumberGuests = 10,
				};
				p149.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p149);
				Property p150 = new Property()
				{
					PropertyNumber = 3150,
					ZipCode = "62346",
					State = StateList.NH,
					StreetAddress = "5303 Lewis Springs",
					AptNum = null,
					City = "Port Adrian",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 207.51m,
					PricePerWeekday = 204.67m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 26.36m,
					NumberBed = 2,
					NumberBath = 1,
					NumberGuests = 2,
				};
				p150.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p150);
				Property p151 = new Property()
				{
					PropertyNumber = 3151,
					ZipCode = "02837",
					State = StateList.IA,
					StreetAddress = "465 Wiley Corners",
					AptNum = "Apt. 759",
					City = "East Michellechester",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 213.84m,
					PricePerWeekday = 129.14m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 12.81m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 11,
				};
				p151.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p151);
				Property p152 = new Property()
				{
					PropertyNumber = 3152,
					ZipCode = "68847",
					State = StateList.LA,
					StreetAddress = "521 Flores Stream",
					AptNum = null,
					City = "West Rebeccaborough",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 254.37m,
					PricePerWeekday = 77.06m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 6.03m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 3,
				};
				p152.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p152);
				Property p153 = new Property()
				{
					PropertyNumber = 3153,
					ZipCode = "35218",
					State = StateList.NE,
					StreetAddress = "0271 Soto Drives",
					AptNum = "Apt. 975",
					City = "New Edgar",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 233.17m,
					PricePerWeekday = 179.91m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.04m,
					NumberBed = 4,
					NumberBath = 5,
					NumberGuests = 9,
				};
				p153.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p153);
				Property p154 = new Property()
				{
					PropertyNumber = 3154,
					ZipCode = "32697",
					State = StateList.NM,
					StreetAddress = "27862 Kent Mountains",
					AptNum = null,
					City = "Lake Michaelville",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 153.38m,
					PricePerWeekday = 90.54m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.91m,
					NumberBed = 6,
					NumberBath = 5,
					NumberGuests = 14,
				};
				p154.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p154);
				Property p155 = new Property()
				{
					PropertyNumber = 3155,
					ZipCode = "95889",
					State = StateList.OR,
					StreetAddress = "917 Mclaughlin Glens",
					AptNum = null,
					City = "Martinville",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 226.89m,
					PricePerWeekday = 225.59m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 28.99m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 2,
				};
				p155.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p155);
				Property p156 = new Property()
				{
					PropertyNumber = 3156,
					ZipCode = "82153",
					State = StateList.KY,
					StreetAddress = "3032 Michelle Drives",
					AptNum = null,
					City = "North Daniel",
					HostEmail = "rankin@yahoo.com",
					PricePerWeekend = 157.15m,
					PricePerWeekday = 203.25m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 15.68m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 13,
				};
				p156.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p156);
				Property p157 = new Property()
				{
					PropertyNumber = 3157,
					ZipCode = "32202",
					State = StateList.SD,
					StreetAddress = "601 Maria Mission",
					AptNum = "Apt. 554",
					City = "Myerstown",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 269.55m,
					PricePerWeekday = 223.27m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 11.35m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 9,
				};
				p157.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p157);
				Property p158 = new Property()
				{
					PropertyNumber = 3158,
					ZipCode = "17431",
					State = StateList.OH,
					StreetAddress = "238 Shawn Well",
					AptNum = null,
					City = "Port Johnshire",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 112.64m,
					PricePerWeekday = 173.63m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 6.38m,
					NumberBed = 7,
					NumberBath = 8,
					NumberGuests = 14,
				};
				p158.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p158);
				Property p159 = new Property()
				{
					PropertyNumber = 3159,
					ZipCode = "37901",
					State = StateList.SC,
					StreetAddress = "41743 Berger Inlet",
					AptNum = "Apt. 527",
					City = "South Tammymouth",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 163.2m,
					PricePerWeekday = 176.23m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 14.77m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 9,
				};
				p159.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p159);
				Property p160 = new Property()
				{
					PropertyNumber = 3160,
					ZipCode = "17895",
					State = StateList.MO,
					StreetAddress = "9983 Mary Grove",
					AptNum = "Apt. 643",
					City = "Beardview",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 209.33m,
					PricePerWeekday = 219.53m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 24.51m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 9,
				};
				p160.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p160);
				Property p161 = new Property()
				{
					PropertyNumber = 3161,
					ZipCode = "90576",
					State = StateList.HI,
					StreetAddress = "03541 Ryan Islands",
					AptNum = "Apt. 562",
					City = "East Michaelfort",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 269.63m,
					PricePerWeekday = 126.25m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 8.27m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 10,
				};
				p161.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p161);
				Property p162 = new Property()
				{
					PropertyNumber = 3162,
					ZipCode = "94980",
					State = StateList.SC,
					StreetAddress = "6591 Angela Mission",
					AptNum = "Apt. 108",
					City = "Penabury",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 286.86m,
					PricePerWeekday = 143.98m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.48m,
					NumberBed = 5,
					NumberBath = 6,
					NumberGuests = 14,
				};
				p162.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p162);
				Property p163 = new Property()
				{
					PropertyNumber = 3163,
					ZipCode = "44974",
					State = StateList.CO,
					StreetAddress = "492 Ramirez Crossing",
					AptNum = null,
					City = "Aaronberg",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 144.6m,
					PricePerWeekday = 121.91m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.Yes,
					CleaningFee = 10.12m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 10,
				};
				p163.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p163);
				Property p164 = new Property()
				{
					PropertyNumber = 3164,
					ZipCode = "66170",
					State = StateList.DE,
					StreetAddress = "35974 Sharon Locks",
					AptNum = "Apt. 101",
					City = "Jennyport",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 114.46m,
					PricePerWeekday = 137.8m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 17.74m,
					NumberBed = 7,
					NumberBath = 9,
					NumberGuests = 1,
				};
				p164.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p164);
				Property p165 = new Property()
				{
					PropertyNumber = 3165,
					ZipCode = "22495",
					State = StateList.UT,
					StreetAddress = "89403 Gabriella Mills",
					AptNum = null,
					City = "East Steven",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 155.1m,
					PricePerWeekday = 128.63m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 23.05m,
					NumberBed = 3,
					NumberBath = 4,
					NumberGuests = 11,
				};
				p165.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p165);
				Property p166 = new Property()
				{
					PropertyNumber = 3166,
					ZipCode = "85059",
					State = StateList.NH,
					StreetAddress = "601 Kyle Roads",
					AptNum = null,
					City = "Clarkfurt",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 284.39m,
					PricePerWeekday = 209.11m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 6.25m,
					NumberBed = 4,
					NumberBath = 5,
					NumberGuests = 4,
				};
				p166.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p166);
				Property p167 = new Property()
				{
					PropertyNumber = 3167,
					ZipCode = "61092",
					State = StateList.IN,
					StreetAddress = "60969 Justin Passage",
					AptNum = "Suite 774",
					City = "Joshuaburgh",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 121m,
					PricePerWeekday = 128.59m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 19.36m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 7,
				};
				p167.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p167);
				Property p168 = new Property()
				{
					PropertyNumber = 3168,
					ZipCode = "43986",
					State = StateList.PA,
					StreetAddress = "7943 Tina Mount",
					AptNum = null,
					City = "East Lisa",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 104.47m,
					PricePerWeekday = 122.88m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 25.31m,
					NumberBed = 4,
					NumberBath = 3,
					NumberGuests = 14,
				};
				p168.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p168);
				Property p169 = new Property()
				{
					PropertyNumber = 3169,
					ZipCode = "91397",
					State = StateList.NC,
					StreetAddress = "6775 James Ford",
					AptNum = null,
					City = "South Victorialand",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 275.5m,
					PricePerWeekday = 211.24m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 15.74m,
					NumberBed = 1,
					NumberBath = 3,
					NumberGuests = 9,
				};
				p169.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p169);
				Property p170 = new Property()
				{
					PropertyNumber = 3170,
					ZipCode = "67849",
					State = StateList.VT,
					StreetAddress = "431 Johnson Neck",
					AptNum = "Suite 039",
					City = "Mariechester",
					HostEmail = "rice@yahoo.com",
					PricePerWeekend = 126.24m,
					PricePerWeekday = 124.65m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 24.3m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 9,
				};
				p170.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p170);
				Property p171 = new Property()
				{
					PropertyNumber = 3171,
					ZipCode = "20687",
					State = StateList.NM,
					StreetAddress = "15666 Justin Locks",
					AptNum = null,
					City = "Lake Ryanport",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 112.05m,
					PricePerWeekday = 70.11m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 27.45m,
					NumberBed = 6,
					NumberBath = 6,
					NumberGuests = 3,
				};
				p171.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p171);
				Property p172 = new Property()
				{
					PropertyNumber = 3172,
					ZipCode = "30222",
					State = StateList.TX,
					StreetAddress = "9947 Torres Viaduct",
					AptNum = "Apt. 506",
					City = "Benjaminport",
					HostEmail = "ingram@gmail.com",
					PricePerWeekend = 152.09m,
					PricePerWeekday = 174.87m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 18.44m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 11,
				};
				p172.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Apartment");
				//Add this book to the list of properties to add 
				Properties.Add(p172);
				Property p173 = new Property()
				{
					PropertyNumber = 3173,
					ZipCode = "21190",
					State = StateList.NJ,
					StreetAddress = "20866 Keith Mill",
					AptNum = null,
					City = "Susanton",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 174.06m,
					PricePerWeekday = 96.8m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 28.15m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 10,
				};
				p173.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p173);
				Property p174 = new Property()
				{
					PropertyNumber = 3174,
					ZipCode = "04838",
					State = StateList.AL,
					StreetAddress = "04374 Nicholas Cliff",
					AptNum = "Suite 001",
					City = "Adrianport",
					HostEmail = "jacobs@yahoo.com",
					PricePerWeekend = 108.24m,
					PricePerWeekday = 205.01m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 6.56m,
					NumberBed = 1,
					NumberBath = 1,
					NumberGuests = 10,
				};
				p174.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Condo");
				//Add this book to the list of properties to add 
				Properties.Add(p174);
				Property p175 = new Property()
				{
					PropertyNumber = 3175,
					ZipCode = "80130",
					State = StateList.CA,
					StreetAddress = "271 Andrew Summit",
					AptNum = null,
					City = "Port Craig",
					HostEmail = "gonzalez@aol.com",
					PricePerWeekend = 148.39m,
					PricePerWeekday = 197.52m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 20.55m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 7,
				};
				p175.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p175);
				Property p176 = new Property()
				{
					PropertyNumber = 3176,
					ZipCode = "96166",
					State = StateList.MN,
					StreetAddress = "17611 Robbins Mission",
					AptNum = null,
					City = "New Curtis",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 286.13m,
					PricePerWeekday = 219.69m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 10.64m,
					NumberBed = 3,
					NumberBath = 3,
					NumberGuests = 9,
				};
				p176.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p176);
				Property p177 = new Property()
				{
					PropertyNumber = 3177,
					ZipCode = "40702",
					State = StateList.MO,
					StreetAddress = "80831 Kemp Pines",
					AptNum = null,
					City = "Annashire",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 123.93m,
					PricePerWeekday = 91.26m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 19.36m,
					NumberBed = 1,
					NumberBath = 2,
					NumberGuests = 7,
				};
				p177.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p177);
				Property p178 = new Property()
				{
					PropertyNumber = 3178,
					ZipCode = "86023",
					State = StateList.IL,
					StreetAddress = "96545 Smith Alley",
					AptNum = null,
					City = "West Joy",
					HostEmail = "martinez@aol.com",
					PricePerWeekend = 254.38m,
					PricePerWeekday = 132.54m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 14.83m,
					NumberBed = 6,
					NumberBath = 8,
					NumberGuests = 7,
				};
				p178.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p178);
				Property p179 = new Property()
				{
					PropertyNumber = 3179,
					ZipCode = "70897",
					State = StateList.MT,
					StreetAddress = "6146 Johnson Isle",
					AptNum = null,
					City = "South Arthur",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 228.04m,
					PricePerWeekday = 227.96m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 6.99m,
					NumberBed = 2,
					NumberBath = 4,
					NumberGuests = 1,
				};
				p179.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p179);
				Property p180 = new Property()
				{
					PropertyNumber = 3180,
					ZipCode = "69154",
					State = StateList.MN,
					StreetAddress = "0415 Smith Springs",
					AptNum = null,
					City = "Jeremyburgh",
					HostEmail = "loter@yahoo.com",
					PricePerWeekend = 228.81m,
					PricePerWeekday = 140.93m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 29.74m,
					NumberBed = 4,
					NumberBath = 4,
					NumberGuests = 3,
				};
				p180.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p180);
				Property p181 = new Property()
				{
					PropertyNumber = 3181,
					ZipCode = "53524",
					State = StateList.HI,
					StreetAddress = "3999 Ricky Via",
					AptNum = null,
					City = "West Adamburgh",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 255.43m,
					PricePerWeekday = 137.35m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.Yes,
					CleaningFee = 16.62m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 6,
				};
				p181.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "House");
				//Add this book to the list of properties to add 
				Properties.Add(p181);
				Property p182 = new Property()
				{
					PropertyNumber = 3182,
					ZipCode = "24886",
					State = StateList.MN,
					StreetAddress = "83787 Stuart Key",
					AptNum = null,
					City = "Davetown",
					HostEmail = "chung@yahoo.com",
					PricePerWeekend = 146.75m,
					PricePerWeekday = 172.99m,
					PetsAllowed = YesNo.Yes,
					FreeParking = YesNo.No,
					CleaningFee = 26.24m,
					NumberBed = 7,
					NumberBath = 6,
					NumberGuests = 4,
				};
				p182.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p182);
				Property p183 = new Property()
				{
					PropertyNumber = 3183,
					ZipCode = "56713",
					State = StateList.TX,
					StreetAddress = "690 Christina Park",
					AptNum = null,
					City = "Toddburgh",
					HostEmail = "tanner@utexas.edu",
					PricePerWeekend = 157.96m,
					PricePerWeekday = 188.53m,
					PetsAllowed = YesNo.No,
					FreeParking = YesNo.No,
					CleaningFee = 6.69m,
					NumberBed = 3,
					NumberBath = 5,
					NumberGuests = 1,
				};
				p183.Category = db.Categories.FirstOrDefault(p => p.CategoryName == "Cabin");
				//Add this book to the list of properties to add 
				Properties.Add(p183);

				try
                {
					foreach (Property propertyToAdd in Properties)
					{
						intPropertyNumber = propertyToAdd.PropertyNumber;
						// search current properties and see if the property number already exists
						Property dbProperty = db.Properties.FirstOrDefault(p => p.PropertyNumber == propertyToAdd.PropertyNumber);

						if (dbProperty == null) //property doesn't exist
						{
							db.Properties.Add(propertyToAdd);
							db.SaveChanges();
							intPropertiesAdded += 1;
						}
						else //property exists - update values
                        {
							dbProperty.PropertyNumber = propertyToAdd.PropertyNumber;
							dbProperty.StreetAddress = propertyToAdd.StreetAddress;
							dbProperty.AptNum = propertyToAdd.AptNum;
							dbProperty.ZipCode = propertyToAdd.ZipCode;
							dbProperty.State = propertyToAdd.State;
							dbProperty.City = propertyToAdd.City;
							dbProperty.HostEmail = propertyToAdd.HostEmail;
							dbProperty.PricePerWeekend = propertyToAdd.PricePerWeekend;
							dbProperty.PricePerWeekday = propertyToAdd.PricePerWeekday;
							dbProperty.PetsAllowed = propertyToAdd.PetsAllowed;
							dbProperty.FreeParking = propertyToAdd.FreeParking;
							dbProperty.CleaningFee = propertyToAdd.CleaningFee;
							dbProperty.NumberBath = propertyToAdd.NumberBath;
							dbProperty.NumberBed = propertyToAdd.NumberBed;
							dbProperty.NumberGuests = propertyToAdd.NumberGuests;
							dbProperty.Category = propertyToAdd.Category;
							db.Update(dbProperty);
							db.SaveChanges();
							intPropertiesAdded += 1;
						}
					}
				}
				catch (Exception ex)
				{
					String msg = "  Repositories added:" + intPropertiesAdded + "; Error on " + intPropertyNumber;
					throw new InvalidOperationException(ex.Message + msg);
				}
			}
			catch (Exception e)
			{
				throw new InvalidOperationException(e.Message);
			}
		}
	}
}