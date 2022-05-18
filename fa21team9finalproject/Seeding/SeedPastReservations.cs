using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
namespace fa21team9finalproject.Seeding
{
	public static class SeedingPastReservations
	{
		public static async Task SeedPastReservations(AppDbContext db)
		{
			//Create a counter and a flag so we will know which record is causing problems
			Int32 intReservationsAdded = 0;
			Int32 strReservationEmail = 0;

			//Add the list of transactions
			List<Reservation> Reservations = new List<Reservation>();
			Reservation r1 = new Reservation()
			{
				CheckInDate = new DateTime(2015, 3, 4),
				CheckOutDate = new DateTime(2015, 3, 20),
				CleaningFee = 11.29m,
				Discount = 378.07m,
				TotalPrice = 1512.28m,
				ReservationTotal = 1142.68m,
				PricePerWeekday = 83.34m,
				PricePerWeekend = 128.05m,
				TotalStayDays = 16,
				NumberOfGuests = 4
			};
			r1.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "94102 Sims Port");
			r1.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21901);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r1);
			Reservation r2 = new Reservation()
			{
				CheckInDate = new DateTime(2018, 4, 4),
				CheckOutDate = new DateTime(2018, 4, 5),
				CleaningFee = 25.57m,
				Discount = 0m,
				TotalPrice = 163.68m,
				ReservationTotal = 189.25m,
				PricePerWeekday = 163.68m,
				PricePerWeekend = 286.53m,
				TotalStayDays = 1,
				NumberOfGuests = 7
			};
			r2.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "71664 Kim Throughway");
			r2.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21902);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r2);
			Reservation r3 = new Reservation()
			{
				CheckInDate = new DateTime(2018, 9, 21),
				CheckOutDate = new DateTime(2018, 9, 26),
				CleaningFee = 28.99m,
				Discount = 0m,
				TotalPrice = 1130.55m,
				ReservationTotal = 1159.54m,
				PricePerWeekday = 225.59m,
				PricePerWeekend = 226.89m,
				TotalStayDays = 5,
				NumberOfGuests = 2
			};
			r3.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "917 Mclaughlin Glens");
			r3.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21903);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r3);
			Reservation r4 = new Reservation()
			{
				CheckInDate = new DateTime(2019, 1, 3),
				CheckOutDate = new DateTime(2019, 1, 11),
				CleaningFee = 14.05m,
				Discount = 0m,
				TotalPrice = 1719.76m,
				ReservationTotal = 1733.81m,
				PricePerWeekday = 229.03m,
				PricePerWeekend = 172.79m,
				TotalStayDays = 8,
				NumberOfGuests = 3
			};
			r4.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "3673 Peter Turnpike");
			r4.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21904);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r4);
			Reservation r5 = new Reservation()
			{
				CheckInDate = new DateTime(2021, 2 ,2),
				CheckOutDate = new DateTime(2021, 2, 11),
				CleaningFee = 21.05m,
				Discount = 204.73m,
				TotalPrice = 1364.87m,
				ReservationTotal = 1178.03m,
				PricePerWeekday = 155.03m,
				PricePerWeekend = 139.83m,
				TotalStayDays = 9,
				NumberOfGuests = 1
			};
			r5.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "693 Michael Estate");
			r5.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21905);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r5);
			Reservation r6 = new Reservation()
			{
				CheckInDate = new DateTime(2021, 5, 2),
				CheckOutDate = new DateTime(2021, 5, 5),
				CleaningFee = 13.02m,
				Discount = 0m,
				TotalPrice = 383.91m,
				ReservationTotal = 396.93m,
				PricePerWeekday = 127.97m,
				PricePerWeekend = 182.77m,
				TotalStayDays = 3,
				NumberOfGuests = 1
			};
			r6.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1220 Heidi Rue");
			r6.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21906);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r6);
			Reservation r7 = new Reservation()
			{
				CheckInDate = new DateTime(2021, 11, 28),
				CheckOutDate = new DateTime(2021, 12, 13),
				CleaningFee = 13.02m,
				Discount = 0m,
				TotalPrice = 2138.75m,
				ReservationTotal = 2151.77m,
				PricePerWeekday = 127.97m,
				PricePerWeekend = 182.77m,
				TotalStayDays = 15,
				NumberOfGuests = 1
			};
			r7.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1220 Heidi Rue");
			r7.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21907);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r7);
			Reservation r9 = new Reservation()
			{
				CheckInDate = new DateTime(2021, 12, 3),
				CheckOutDate = new DateTime(2021, 12, 5),
				CleaningFee = 5.88m,
				Discount = 0m,
				TotalPrice = 556.34m,
				ReservationTotal = 562.22m,
				PricePerWeekday = 194.84m,
				PricePerWeekend = 278.17m,
				TotalStayDays = 2,
				NumberOfGuests = 6
			};
			r9.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1168 Gary Fords");
			r9.Order = db.Orders.FirstOrDefault(p => p.OrderNumber == 21909);
			//Add this reservation to the list of reservations to add 
			Reservations.Add(r9);
			try  //attempt to add or update the reservation 
			{
				//loop through each of the reservation in the list 
				foreach (Reservation reservationToAdd in Reservations)
				{
					//set the flag to the current title to help with debugging
					strReservationEmail = reservationToAdd.Order.OrderNumber;

					//look to see if the book is in the database - this assumes that no
					//two reservations have the same order 
					Reservation dbReservation = db.Reservations.FirstOrDefault(b => b.Order.OrderNumber == reservationToAdd.Order.OrderNumber);

					//if the dbReservation is null, this title is not in the database 
					if (dbReservation == null)
					{
						//add the Reservations to the database and save changes 
						db.Reservations.Add(reservationToAdd);
						db.SaveChanges();

						//update the counter to help with debugging 
						intReservationsAdded += 1;
					}
					else //dbReservation is not null - this title *is* in the database 
					{
						//update all of the reservation's properties 

						dbReservation.CleaningFee = reservationToAdd.CleaningFee;
						dbReservation.CheckInDate = reservationToAdd.CheckInDate;
						dbReservation.CheckOutDate = reservationToAdd.CheckOutDate;
						dbReservation.Discount = reservationToAdd.Discount;
						dbReservation.NumberOfGuests = reservationToAdd.NumberOfGuests;

						//since we found the correct category object in a previous step, 
						//this update is easy - both dbReservation and reservationToAdd have a Category 
						//object for this property 
						dbReservation.Property = reservationToAdd.Property;
						dbReservation.Order = reservationToAdd.Order;

						//update the database and save the changes 
						db.Update(dbReservation);
						db.SaveChanges();

						//update the counter to help with debugging 
						intReservationsAdded += 1;
					} //this is the end of the else 
				} //this is the end of the foreach loop for the properties 
			}//this is the end of the try block 

			catch (Exception ex)//something went wrong with adding or updating 
			{
				//Build a messsage using the flags we created 
				String msg = " Repositories added:" + intReservationsAdded + "; Error on " + strReservationEmail;

				//throw the exception with the new message 
				throw new InvalidOperationException(ex.Message + msg);
			}
		}
	}
}
