using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa21team9finalproject.DAL;
using fa21team9finalproject.Models;
namespace fa21team9finalproject.Seeding
{
	public static class SeedingReviews
	{
		public static async Task SeedReviews(AppDbContext db)
		{
			//Create a counter and a flag so we will know which record is causing problems 
			Int32 intReviewsAdded = 0;
			Int32 intReviewID = 1;
			string strEmail = "Begin";
			string strAddress = "Begin";

			//Add the list of reviews 
			List<PropertyReview> Reviews = new List<PropertyReview>();
			PropertyReview r1 = new PropertyReview()
			{
				Rating = 4,
				Review = null
			};
			r1.User = db.Users.FirstOrDefault(r => r.Email == "father.Ingram@aool.com");
			r1.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "588 Alan Rest");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r1);
			PropertyReview r2 = new PropertyReview()
			{
				Rating = 3,
				Review = "It was meh, ya know? It was really close to the coast, but the beaches were kinda trashed. The apartment was nice, but there wasn't an elevator."
			};
			r2.User = db.Users.FirstOrDefault(r => r.Email == "orielly@foxnets.com");
			r2.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1168 Gary Fords");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r2);
			PropertyReview r3 = new PropertyReview()
			{
				Rating = 4,
				Review = null
			};
			r3.User = db.Users.FirstOrDefault(r => r.Email == "father.Ingram@aool.com");
			r3.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "03541 Ryan Islands");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r3);
			PropertyReview r4 = new PropertyReview()
			{
				Rating = 2,
				Review = null
			};
			r4.User = db.Users.FirstOrDefault(r => r.Email == "tuck33@puppy.com");
			r4.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "588 Alan Rest");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r4);
			PropertyReview r5 = new PropertyReview()
			{
				Rating = 3,
				Review = "Nebraska was... interesting"
			};
			r5.User = db.Users.FirstOrDefault(r => r.Email == "father.Ingram@aool.com");
			r5.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "94102 Sims Port");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r5);
			PropertyReview r6 = new PropertyReview()
			{
				Rating = 1,
				Review = "There was corn EVERYWHERE! I looked left and BAM, CORN. Looked right, BAM, CORN"
			};
			r6.User = db.Users.FirstOrDefault(r => r.Email == "tfreeley@puppy.com");
			r6.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "94102 Sims Port");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r6);
			PropertyReview r7 = new PropertyReview()
			{
				Rating = 1,
				Review = "Worst. Stay. Ever. Never using BevoBnB again"
			};
			r7.User = db.Users.FirstOrDefault(r => r.Email == "ra@aoo.com");
			r7.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "94102 Sims Port");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r7);
			PropertyReview r8 = new PropertyReview()
			{
				Rating = 5,
				Review = null
			};
			r8.User = db.Users.FirstOrDefault(r => r.Email == "orielly@foxnets.com");
			r8.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "693 Michael Estate");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r8);
			PropertyReview r9 = new PropertyReview()
			{
				Rating = 2,
				Review = null
			};
			r9.User = db.Users.FirstOrDefault(r => r.Email == "orielly@foxnets.com");
			r9.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "457 Vargas Island ");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r9);
			PropertyReview r10 = new PropertyReview()
			{
				Rating = 1,
				Review = "It was SO hard to book this place. Who coded this site anyway? ;)"
			};
			r10.User = db.Users.FirstOrDefault(r => r.Email == "tfreeley@puppy.com");
			r10.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "693 Michael Estate");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r10);
			PropertyReview r11 = new PropertyReview()
			{
				Rating = 4,
				Review = null
			};
			r11.User = db.Users.FirstOrDefault(r => r.Email == "tuck33@puppy.com");
			r11.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "71664 Kim Throughway");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r11);
			PropertyReview r12 = new PropertyReview()
			{
				Rating = 5,
				Review = "This place rocked!"
			};
			r12.User = db.Users.FirstOrDefault(r => r.Email == "ra@aoo.com");
			r12.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "693 Michael Estate");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r12);
			PropertyReview r13 = new PropertyReview()
			{
				Rating = 4,
				Review = null
			};
			r13.User = db.Users.FirstOrDefault(r => r.Email == "fd@puppy.com");
			r13.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "693 Michael Estate");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r13);
			PropertyReview r14 = new PropertyReview()
			{
				Rating = 4,
				Review = null
			};
			r14.User = db.Users.FirstOrDefault(r => r.Email == "lamemartin.Martin@aool.com");
			r14.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "457 Vargas Island");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r14);
			PropertyReview r15 = new PropertyReview()
			{
				Rating = 1,
				Review = "There were 1...5...22 roaches? I lost count."
			};
			r15.User = db.Users.FirstOrDefault(r => r.Email == "fd@puppy.com");
			r15.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "94102 Sims Port");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r15);
			PropertyReview r16 = new PropertyReview()
			{
				Rating = 1,
				Review = null
			};
			r16.User = db.Users.FirstOrDefault(r => r.Email == "sheff44@puppy.com");
			r16.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1168 Gary Fords");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r16);
			PropertyReview r17 = new PropertyReview()
			{
				Rating = 4,
				Review = "I LOVED the place! Had a nice view of the mountains"
			};
			r17.User = db.Users.FirstOrDefault(r => r.Email == "fd@puppy.com");
			r17.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1220 Heidi Rue");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r17);
			PropertyReview r18 = new PropertyReview()
			{
				Rating = 5,
				Review = null
			};
			r18.User = db.Users.FirstOrDefault(r => r.Email == "tuck33@puppy.com");
			r18.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "1220 Heidi Rue");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r18);
			PropertyReview r19 = new PropertyReview()
			{
				Rating = 5,
				Review = "My stay was amazing! Saved my marriage"
			};
			r19.User = db.Users.FirstOrDefault(r => r.Email == "orielly@foxnets.com");
			r19.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "588 Alan Rest");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r19);
			PropertyReview r20 = new PropertyReview()
			{
				Rating = 2,
				Review = null
			};
			r20.User = db.Users.FirstOrDefault(r => r.Email == "sheff44@puppy.com");
			r20.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "457 Vargas Island");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r20);
			PropertyReview r21 = new PropertyReview()
			{
				Rating = 2,
				Review = "My wife's attitude was the only thing rougher than the sand at the nearby beaches"
			};
			r21.User = db.Users.FirstOrDefault(r => r.Email == "orielly@foxnets.com");
			r21.Property = db.Properties.FirstOrDefault(p => p.StreetAddress == "03541 Ryan Islands");
			//Add this property to the list of Reviews to add 
			Reviews.Add(r21);


			try  //attempt to add or update the Reviews 
			{
				//loop through each of the reviews in the list 
				foreach (PropertyReview reviewToAdd in Reviews)
				{
					//set the flag to the current title to help with debugging
					intReviewID = reviewToAdd.PropertyReviewID;
					strEmail = reviewToAdd.User.Email;
					strAddress = reviewToAdd.Property.StreetAddress;

					//look to see if the review is in the database - this assumes that no
					//two reviews have same user and streetaddress
 					PropertyReview dbReview = db.PropertyReviews.FirstOrDefault(r => r.User.Email == reviewToAdd.User.Email && r.Property.StreetAddress == reviewToAdd.Property.StreetAddress);

					//if the dbReview is null, this id is not in the database review is not yet in the database
					if (dbReview == null)
					{
						//add the review to the database and save changes 
						db.PropertyReviews.Add(reviewToAdd);
						db.SaveChanges();

						//update the counter to help with debugging 
						intReviewsAdded += 1;
					}
					else //dbReview is not null - this id *is* in the database 
					{
						//update all of the review's properties
						dbReview.Rating = reviewToAdd.Rating;
						dbReview.Review = reviewToAdd.Review;
						//since we found the correct user and property object in a previous step, 
						//this update is easy - both dbReview and reviewToAdd have a User and Property 
						//object for this review 
						dbReview.Property = reviewToAdd.Property;
						dbReview.User = reviewToAdd.User;
						//update the database and save the changes 
						db.Update(dbReview);
						db.SaveChanges();
						//update the counter to help with debugging 
						intReviewsAdded += 1;
					} //this is the end of the else 
				} //this is the end of the foreach loop for the properties 
			}//this is the end of the try block 
			catch (Exception ex)//something went wrong with adding or updating 
			{
				//Build a messsage using the flags we created 
				String msg = " Repositories added:" + intReviewsAdded + "; Error on " + strEmail + "'s review of property " + strAddress;

				//throw the exception with the new message 
				throw new InvalidOperationException(ex.Message + msg);
			}
		}
	}
}