using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
	// enum for reservation status
	// host may cancel a reservation if more than a day out
	// TODO: check if this is right
	// Evan & Brynne: Changed Cancelled to Inactive, if the reservation is passed or cancelled, reservation is inactive, covers both categories
	//dete is for Reservation never completed (such as in case when reservation is added to order but order not confirmed til later and now reservation dates are booked... so reservation needs to not exist but is already in database. Thus, we set to delete)
	public enum rStatus { Active, Cancelled, Delete, Pending }

	public class Reservation
	{
		// all properties of reservation model

		// primary key
		public Int32 ReservationID {get; set;}

		// check in date is required
		//TODO: must be after today and must not be booked - is this done in an action method on controller??
		[Required(ErrorMessage = "Check-in Date is required!")]
		[Display(Name = "Check-in Date")]
		[DisplayFormat(DataFormatString = "{0:MM / dd / yyyy}")]
		[DataType(DataType.Date)]
		public DateTime CheckInDate { get; set; }

		// check out date is required
		[Required(ErrorMessage = "Check-out Date is required!")]
		[Display(Name = "Check-out Date")]
		[DisplayFormat(DataFormatString = "{0:MM / dd / yyyy}")]
		[DataType(DataType.Date)]
		public DateTime CheckOutDate { get; set; }

		// number of guests is required
		[Required(ErrorMessage = "Number of guests is required!")]
		[Display(Name = "Number of Guests")]
		[Range(minimum: 1, maximum: double.PositiveInfinity, ErrorMessage = "Number of guests must be at least 1.")]
		public Int32 NumberOfGuests { get; set; }

		// total price of reservations in the order (this doesn't include cleaning fee)
		// TODO: might be private set - should this be readonly???
		// TODO: believe this should be only get and should be function of num of each type of day * price of that type of day
		// TODO: does this include the cleaning fee or just the sum of the rent?
		// TODO: do we need to include a sales tax for this individual reservation or is that just on order class?
		// Evan: Sales tax should just be in the order
		// this does not include cleaning fee or discount
		[Display(Name = "Stay Price")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal TotalPrice { get; set; }

		// includes cleaning fee and discount
		[Display(Name = "Individual Reservation Total")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal ReservationTotal { get; set; }

		//displays total price plus cleaning fee (DOESN"T INCLUDE DISCOUNT YET)
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal Subtotal { get { return CleaningFee + TotalPrice; } }

		// price of cleaning fee
		// TODO: should this be readonly??? - only get??
		// this number needs to be pulled directly from the property model
		[Display(Name = "Cleaning Fee")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal CleaningFee { get; set; }

		// status displaying if reservation is active or has been cancelled
		// can only be modified by the host
		// can be seen by the customer
		[Display(Name = "Status")]
		public rStatus Status { get; set; }

		public Int32 NumberOfWeekdays { get; set; }
		public Int32 NumberOfWeekends { get; set; }

		// to help carry property id through creating a reservation
		public Int32 PropertyID { get; set; }

		// variables to hold price per weekday and weekend of property when reservation is first created
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal PricePerWeekday { get; set; }

		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal PricePerWeekend { get; set; }

		// relational properties

		// a reservation is only associated with a single property
		public Property Property { get; set; }

		// a reservation is only associated with a single order
		public Order Order { get; set; }

		//Total number of days stayed
		public Int32 TotalStayDays { get; set; }

		//sets discount offered to reservation when user confirms reservation
		[DisplayFormat(DataFormatString = "{0:c}")]
		public Decimal Discount { get; set; }

		// private backing
		private DateTime _startDate;
		private Int32 _weekdays;
		private Int32 _weekends;
		private DayOfWeek _currentDayOfWeek;

		// method to calculate number of weekends and weekdays
		public void CalcNumberOfWeekdaysAndWeekends()
		{
			// check if checkout date is after checkin date
			if (CheckOutDate <= CheckInDate)
			{
				// if checkout date is before check in date, throw an exception
				// TODO: add a try/catch exception to ReservationController
				throw new Exception("Check-out date must be after check-in date!");
			}
			if (DateTime.Now >= CheckInDate)
			{
				throw new Exception("This date has already passed!");
			}
			// instantiate a new date equal to CheckInDate for the purpose of iterating through each day
			// TODO: does startDate need to be defined as a variable before this method?
			_startDate = CheckInDate;

			_weekdays = 0;
			_weekends = 0;

			// iterates for each day between startDate and CheckOutDate
			while(_startDate < CheckOutDate)
			{
				// Check if the day of week is a weekend or weekday and add 1 to respective value
				_currentDayOfWeek = _startDate.DayOfWeek;

				if ((_currentDayOfWeek == DayOfWeek.Saturday) || (_currentDayOfWeek == DayOfWeek.Sunday))
				{
					_weekends ++;
				}
				else
				{
					_weekdays ++;
				}

				_startDate = _startDate.AddDays(1);
			}

			// update values
			NumberOfWeekdays = _weekdays;
			NumberOfWeekends = _weekends;
			TotalStayDays = NumberOfWeekdays + NumberOfWeekends;
		}

        // method to check check-in check-out date
        public void CalcDates()
		{
			DateTime now = DateTime.Today;

			// get difference between CheckInDate and CheckOutDate dates
			double _lengthOfStay = (CheckOutDate - CheckInDate).TotalDays;

			if (_lengthOfStay < 0)
			{
				throw new Exception("Invalid dates! Check-out date must be later than check-in date.");
			}
			else if (_lengthOfStay == 0)
			{
				throw new Exception("Invalid dates! Check-in and check-out dates cannot be the same.");
			}

			// get difference between today's date both check in or check out dates
			double _daysFromToday = (CheckInDate - now).TotalDays;

			if (_daysFromToday <= 0)
			{
				throw new Exception("Invalid dates! Check-in date must be after today's date!");
			}
		}

		// checks the guest number against property guest limit
		public void CheckGuestNumber()
        {
			if (NumberOfGuests > Property.NumberGuests)
            {
				throw new Exception("Error! Your guest list exceeds the guest limit for this property.");
            }
        }

		// calculate total price
		public void CalcTotalPrice()
        {
			TotalPrice = NumberOfWeekdays * PricePerWeekday + NumberOfWeekends * PricePerWeekend;
        }

		public void CalcTotalReservationPrice(Int32 _discount)
		{
			//sets discount that the reservation gets as a monetary amount
			Discount = TotalPrice * (Convert.ToDecimal(_discount) / 100);
			ReservationTotal = (TotalPrice - Discount) + CleaningFee ;
		}
	}
}	