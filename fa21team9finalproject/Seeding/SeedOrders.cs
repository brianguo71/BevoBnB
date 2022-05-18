using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
namespace fa21team9finalproject.Seeding
{
	public static class SeedingOrders
	{
		public static async Task SeedOrders(AppDbContext db)
		{
			 //Create a counter and a flag so we will know which record is causing problems
			Int32 intOrdersAdded = 0; 
			Int32 intOrderNumber = 1;
			 
			//Add the list of orders
			List<Order> Orders = new List<Order>();
			Order o1 = new Order()
			{
				OrderNumber = 21901,
				Status = oStatus.Confirmed,
				Reservations = new List<Reservation>()
			};
			o1.User = db.Users.FirstOrDefault(p => p.Email == "fd@puppy.com");
			Orders.Add(o1);
			Order o2 = new Order()
			{ 
				 OrderNumber = 21902, 
				 Status = oStatus.Confirmed,
				Reservations = new List<Reservation>()
			};
				o2.User = db.Users.FirstOrDefault(p => p.Email == "tuck33@puppy.com");
			Orders.Add(o2);
			Order o3 = new Order()
			{ 
				 OrderNumber = 21903, 
				 Status = oStatus.Confirmed,
				 Reservations = new List<Reservation>()
			};
				o3.User = db.Users.FirstOrDefault(p => p.Email == "orielly@foxnets.com");
			Orders.Add(o3);
			Order o4 = new Order()
			{ 
				 OrderNumber = 21904, 
				 Status = oStatus.Confirmed,
				 Reservations = new List<Reservation>()
			};
				o4.User = db.Users.FirstOrDefault(p => p.Email == "orielly@foxnets.com");
			Orders.Add(o4);
			Order o5 = new Order()
			{ 
				 OrderNumber = 21905, 
				 Status = oStatus.Confirmed,
				 Reservations = new List<Reservation>()
			};
				o5.User = db.Users.FirstOrDefault(p => p.Email == "tfreeley@puppy.com");
			Orders.Add(o5);
			Order o6 = new Order()
			{ 
				 OrderNumber = 21906, 
				 Status = oStatus.Confirmed,
				 Reservations = new List<Reservation>()
			};
				o6.User = db.Users.FirstOrDefault(p => p.Email == "fd@puppy.com");
			Orders.Add(o6);
			Order o7 = new Order()
			{ 
				 OrderNumber = 21907, 
				 Status = oStatus.Confirmed,
				 Reservations = new List<Reservation>()
			};
			o7.User = db.Users.FirstOrDefault(p => p.Email == "tuck33@puppy.com");
			Orders.Add(o7);
			Order o9 = new Order()
			{
				OrderNumber = 21909,
				Status = oStatus.Confirmed,
				Reservations = new List<Reservation>()
			};
			o9.User = db.Users.FirstOrDefault(p => p.Email == "444444.Dave@aool.com");
			Orders.Add(o9);
			try  //attempt to add or update the reservation 
			 { 
				 //loop through each of the order in the list 
				 foreach (Order ordersToAdd in Orders) 
				 { 
					 //set the flag to the current title to help with debugging
					 intOrderNumber = ordersToAdd.OrderNumber; 
					 
					 //look to see if the book is in the database - this assumes that no
					 //two books have the same title 
					 Order dbOrder = db.Orders.FirstOrDefault(b => b.OrderNumber == ordersToAdd.OrderNumber); 
					  
					 //if the dbOrder is null, this title is not in the database 
					 if (dbOrder == null)
					{ 
						 //add the Reservations to the database and save changes 
						 db.Orders.Add(ordersToAdd); 
						 db.SaveChanges(); 
						 
						 //update the counter to help with debugging 
						 intOrdersAdded += 1; 
					 } 
					 else //dbReservation is not null - this title *is* in the database 
						 { 
						 //update all of the order's properties 
						 dbOrder.OrderNumber = ordersToAdd.OrderNumber; 
						 dbOrder.Status = ordersToAdd.Status;

						//since we found the correct category object in a previous step, 
						//this update is easy - both dbOrder and orderToAdd have a user.email 
						//object for this property 
						dbOrder.User = ordersToAdd.User;
						dbOrder.Reservations = new List<Reservation>();
						 
						 //update the database and save the changes 
						db.Update(dbOrder); 
						db.SaveChanges(); 
						 
						 //update the counter to help with debugging 
						 intOrdersAdded += 1; 
					 } //this is the end of the else 
				 } //this is the end of the foreach loop for the orders 
			 }//this is the end of the try block 
			 
			 catch (Exception ex)//something went wrong with adding or updating 
			{ 
				 //Build a messsage using the flags we created 
				 String msg = " Repositories added:" + intOrdersAdded + "; Error on " + intOrderNumber; 
				 
				 //throw the exception with the new message 
				 throw new InvalidOperationException(ex.Message + msg); 
			 } 
		 } 
	 } 
} 
