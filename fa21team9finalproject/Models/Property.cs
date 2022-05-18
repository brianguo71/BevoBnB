using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

//NOTE: property is like product in HW5
namespace fa21team9finalproject.Models
{
	// enum to define list of all states in US
	public enum StateList
	{
		[Display(Name = "Alabama")] AL,
		[Display(Name = "Alaska")] AK,
		[Display(Name = "Arizona")] AZ,
		[Display(Name = "Arkansas")] AR,
		[Display(Name = "California")] CA,
		[Display(Name = "Colorado")] CO,
		[Display(Name = "Connecticut")] CT,
		[Display(Name = "Delaware")] DE,
		[Display(Name = "Florida")] FL,
		[Display(Name = "Georgia")] GA,
		[Display(Name = "Hawaii")] HI,
		[Display(Name = "Idaho")] ID,
		[Display(Name = "Illinois")] IL,
		[Display(Name = "Indiana")] IN,
		[Display(Name = "Iowa")] IA,
		[Display(Name = "Kansas")] KS,
		[Display(Name = "Kentucky")] KY,
		[Display(Name = "Louisiana")] LA,
		[Display(Name = "Maine")] ME,
		[Display(Name = "Maryland")] MD,
		[Display(Name = "Massachusetts")] MA,
		[Display(Name = "Michigan")] MI,
		[Display(Name = "Minnesota")] MN,
		[Display(Name = "Mississippi")] MS,
		[Display(Name = "Missouri")] MO,
		[Display(Name = "Montana")] MT,
		[Display(Name = "Nebraska")] NE,
		[Display(Name = "Nevada")] NV,
		[Display(Name = "New Hampshire")] NH,
		[Display(Name = "New Jersey")] NJ,
		[Display(Name = "New Mexico")] NM,
		[Display(Name = "New York")] NY,
		[Display(Name = "North Carolina")] NC,
		[Display(Name = "North Dakota")] ND,
		[Display(Name = "Ohio")] OH,
		[Display(Name = "Oklahoma")] OK,
		[Display(Name = "Oregon")] OR,
		[Display(Name = "Pennsylvania")] PA,
		[Display(Name = "Rhode Island")] RI,
		[Display(Name = "South Carolina")] SC,
		[Display(Name = "South Dakota")] SD,
		[Display(Name = "Tennessee")] TN,
		[Display(Name = "Texas")] TX,
		[Display(Name = "Utah")] UT,
		[Display(Name = "Vermont")] VT,
		[Display(Name = "Virginia")] VA,
		[Display(Name = "Washington")] WA,
		[Display(Name = "West Virginia")] WV,
		[Display(Name = "Wisconsin")] WI,
		[Display(Name = "Wyoming")] WY,
		[Display(Name = "Washington D.C.")] DC
	}

	// enum to define status (active / not active) of the property
	// Host can delete their listing permanently by changing this to notActive
	public enum pStatus
    {
		Active,
		[Display(Name = "Not Active")] notActive
    }

	public enum YesNo
	{
		Yes,
		No
	}

	// all properties of property model
	public class Property
	{
		// variable for percent of revenue hosts get to keep
		public Decimal HOST_REVENUE = 0.9m;

		// ALL PROPERTIES FOR SEARCHING ON CUSTOMER'S END
		// primary key
		public Int32 PropertyID { get; set; }

		// we can edit property number
		[Display(Name = "Property Number")]
		public Int32 PropertyNumber { get; set; }

		// relation to user
		[EmailAddress]
		[Display(Name = "Host Email")]
		public String HostEmail { get; set; }

		// NOTE: not required for project
		// when host makes property, they write in street address
		[Required]
		[Display(Name = "Street Address")]
		public String StreetAddress { get; set; }

		// optional place for apartment number
		[Display(Name = "Apartment Number")]
		public String AptNum { get; set; }

		// city
		[Required]
		[Display(Name = "City")]
		public String City { get; set; }

		// state
		[Required]
		[Display(Name = "State")]
		public StateList State { get; set; }

		// zipcode
		[Required]
		[Display(Name = "Zip Code")]
		public String ZipCode { get; set; }

		// NOTE: not required for project
		// this displays the full address
		[Display(Name = "Full Address")]
		public String FullAddress
		{
			get { return StreetAddress + " " + AptNum + " " + City + ", " + State + " " + ZipCode; }
		}

		// guest ratings
		// TODO: put calculation in controller for property
		[Display(Name = "Average Rating")]
		[DisplayFormat(DataFormatString = "{0:F1}")]
		public Decimal AverageRating { get; set; }

		// number of guests
		[Required(ErrorMessage = "Must specify guest limit.")]
		[Display(Name = "Guest Limit")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Number of guests cannot be less than 0.")]

		public Int32 NumberGuests { get; set; }

		// daily price specific to price per weekday
		[Required(ErrorMessage = "Must specify weekday price.")]
		[Display(Name = "Price per Weekday")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Price cannot be less than $0")]
		public Decimal PricePerWeekday { get; set; }

		// displays price per weekend
		[Required(ErrorMessage = "Must specify weekend price.")]
		[Display(Name = "Price per Weekend")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Price cannot be less than $0")]
		public Decimal PricePerWeekend { get; set; }

		// number of bedrooms
		[Required(ErrorMessage = "Must specify number of beds.")]
		[Display(Name = "Number of Beds")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Number of beds cannot be less than 0.")]
		public Int32 NumberBed { get; set; }

		// number of bathrooms
		[Required(ErrorMessage = "Must specify number of baths.")]
		[Display(Name = "Number of Baths")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Number of beds cannot be less than 0.")]
		public Int32 NumberBath { get; set; }

		// whether or not pets are allowed
		[Required(ErrorMessage = "Must specify if pets are allowed.")]
		[Display(Name = "Pets Allowed?")]
		public YesNo PetsAllowed { get; set; }

		// whether or not parking available
		[Required(ErrorMessage = "Must specify if free parking is available.")]
		[Display(Name = "Free Parking Available?")]
		public YesNo FreeParking { get; set; }

		// hosts can deactivate properties for maintenance, etc
		// status property to allow hosts to do this
		// NOTE: when property is made, automatically set to notActive until admin checks it
		[Display(Name = "Property Activity Status")]
		public pStatus Status { get; set; }

		// variable to determine if approved by admin or not
		// this will be used upon first creation of a property
		[Display(Name = "Property Approval Status")]
		public pStatus ApprovalStatus { get; set; }

		// Discount as a percentage
		[Range(minimum: 0, maximum: 100, ErrorMessage = "You cannot set a discount less than 0% or greater than 100%.")]
		public Int32 Discount { get; set; }

		// property for cleaning fee
		// this can be modified by the host
		[Display(Name = "Cleaning Fee")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Cleaning fee cannot be less than $0.")]
		public Decimal CleaningFee { get; set; }

		//holds number of days required to get discount on reservation
		[Display(Name = "Number of Days Required for Discount")]
		[Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Number of days cannot be less than 0.")]
		public Int32 DiscountDays { get; set; }


		// ALL PROPERTIES FOR ADMIN REPORT

		// property's all stay revenue
		[Display(Name = "All Stay Revenue")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal AllStayRevenue
		{
			get { return Reservations.Sum(r => r.TotalPrice); }
		}

		// property's total stay revenue, which is amount Hosts get to keep
		[Display(Name = "BevoBnB Commission")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal Commission
		{
			get { return AllStayRevenue - TotalStayRevenue; }
		}

		


		// ALL PROPERTIES FOR HOST REPORT ON HOST END
		// TODO: does there need to be a property for the date range that the host wants the host report to be between? NOTE: if the cut off dates fall in the middle of a reservation, then include the reservation in the report. ALSO NOTE: host should be able to select criteria for a single value or range of values for the date

		// property's total stay revenue, which is amount Hosts get to keep
		[Display(Name = "Total Stay Revenue")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal TotalStayRevenue
		{
			get { return AllStayRevenue * HOST_REVENUE; }
		}

		// property for total cleaning fees collected
		[Display(Name = "Total Cleaning Fees")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal TotalCleaningFees
		{
			get { return Reservations.Sum(r => r.CleaningFee); }
		}

		// property for sum of revenue and cleaning fees
		[Display(Name = "Total Amount to Host")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal TotalCollected
		{
			get { return TotalStayRevenue + TotalCleaningFees; }
		}

		// property of number of completed reservations
		[Display(Name = "Total Number of Completed Reservations")]
		public Int32 CompletedReservations
		{
			// TODO: determine what to return... just copleted? put an if statement on checkout date? when host wants to specify date range they want the host report over, does this value change?
			get { return -1; }
		}







		// relational properties

		// category
		// a property has a single category
		public Category Category { get; set; }

		//TODO: I don't think this is needed... are reservations and properties directly connected??
		// each property can have multiple reservations (just across diff dates)
		public List<Reservation> Reservations { get; set; }

		// each property has multiple property reviews
		public List<PropertyReview> PropertyReviews { get; set; }

		// method for relational properties
		public Property()
		{
			if (Reservations == null)
            {
				Reservations = new List<Reservation>();
			}

			if (PropertyReviews == null)
			{
				PropertyReviews = new List<PropertyReview>();
			}
		}

		// variables to do math for AverageRating
		public decimal _sumRatings { get { return PropertyReviews.Where(pr => pr.dStatus == disputeStatus.notViewedYet || pr.dStatus == disputeStatus.Rejected).Sum(pr => pr.Rating); } }

		//method to check average rating is updated
		public void CheckRating()
        {
			if (_sumRatings == 0)
			{
				AverageRating = 0;
			}
			else
			{
				AverageRating = Math.Round((Decimal)PropertyReviews.Where(pr => pr.dStatus == disputeStatus.notViewedYet || pr.dStatus == disputeStatus.Rejected).Average(pr => pr.Rating), 1);
			}
		}
	}
}

