using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace fa21team9finalproject.Models
{
    //NOTE: This is the view model used to allow customer to search properties
    // displays all search properties — all categories are allowed to be null

    public class PropertySearchViewModel
    {
        [DataType(DataType.Date)]
        public DateTime? SearchCheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SearchCheckOut { get; set; }

        [Display(Name = "Search by City")]
        public String SearchCity { get; set; }

        [Display(Name = "Search by State")]
        public StateList? SearchState { get; set; }

        // min max for guest rating
        [Display(Name = "Search by Guest Rating")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Guest Rating cannot be less than 0.")]
        public Decimal? SearchGuestRatingMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Guest Rating cannot be less than 0.")]
        public Decimal? SearchGuestRatingMax { get; set; }

        // min max for guest limit
        [Display(Name = "Search by Guest Limit")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Guest Limit cannot be less than 0.")]
        public Int32? SearchNumGuestsMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Guest Limit cannot be less than 0.")]
        public Int32? SearchNumGuestsMax { get; set; }

        // min max for weekend price
        [Display(Name = "Search by Daily Price for Weekend")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Weekend Price cannot be less than $0.")]
        public Decimal? SearchWeekendPriceMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Weekend Price cannot be less than $0.")]
        public Decimal? SearchWeekendPriceMax { get; set; }

        // min max for weekday price
        [Display(Name = "Search by Daily Price for Weekday")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Weekday Price cannot be less than $0.")]
        public Decimal? SearchWeekdayPriceMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Weekday Price cannot be less than $0.")]
        public Decimal? SearchWeekdayPriceMax { get; set; }

        // min max for number of bedrooms
        [Display(Name = "Search by Number of Bedrooms")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Number of Beds cannot be less than 0.")]
        public Int32? SearchNumBedsMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Number of Beds cannot be less than 0.")]
        public Int32? SearchNumBedsMax { get; set; }

        // min max for number of bathrooms
        [Display(Name = "Search by Number of Bathrooms")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Number of Baths cannot be less than 0.")]
        public Int32? SearchNumBathsMin { get; set; }

        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Search Number of Baths cannot be less than 0.")]
        public Int32? SearchNumBathsMax { get; set; }

        // TODO: not sure if this is how we display categories or not
        [Display(Name = "Search by Category")]
        public Int32? CategoryID { get; set; }

        // boolean value
        [Display(Name = "Allows Pets?")]
        public YesNo? SearchPetsAllowed { get; set; }

        // boolean value
        [Display(Name = "Has Free Parking?")]
        public YesNo? SearchFreeParking { get; set; }

        // date values to manipulate in CalcSearchDate function
        public DateTime _searchCheckIn { get; set; }
        public DateTime _searchCheckOut { get; set; }

        // method to calculate date
        public void CalcSearchDates()
        {
            DateTime now = DateTime.Today;

            // if SearchCheckIn is not null, set it to the backing variable used to do calculations
            if (SearchCheckIn != null)
            {
                _searchCheckIn = (DateTime)SearchCheckIn;
            }
            else
            {
                _searchCheckIn = DateTime.MinValue;
            }

            // if SearchCheckOut is not null, set it to the backing variable used to do calculations
            if (SearchCheckOut != null)
            {
                _searchCheckOut = (DateTime)SearchCheckOut;
            }
            else
            {
                _searchCheckOut = DateTime.MinValue;
            }

            // if one of SearchCheckIn or SearchCheckOut is not null but other is null, throw error
            if ((_searchCheckOut != DateTime.MinValue) && (_searchCheckIn == DateTime.MinValue))
            {
                throw new Exception("To search by dates, you must select both a check-in and check-out date!");
            }
            else if ((_searchCheckIn != DateTime.MinValue) && (_searchCheckOut == DateTime.MinValue))
            {
                throw new Exception("To search by dates, you must select both a check-in and check-out date!");
            }

            if ((_searchCheckOut != DateTime.MinValue) && (_searchCheckIn != DateTime.MinValue))
            {
                // get difference between SearchCheckIn and SearchCheckOut dates
                double _lengthOfStay = (_searchCheckOut - _searchCheckIn).TotalDays;

                if (_lengthOfStay < 0)
                {
                    throw new Exception("Invalid dates! Check-out date must be later than check-in date.");
                }
                else if (_lengthOfStay == 0)
                {
                    throw new Exception("Invalid dates! Check-in and check-out dates cannot be the same.");
                }
            }
            
        }
    }


    public class DisputeReviewModel
    {
        public Int32[] IdstoApprove { get; set; }
        public Int32[] IdstoReject { get; set; }
    }

    public class HostReportViewModel
    {
        public AppUser Host { get; set; }

        public Int32 HostReportViewModelID { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Total Cleaning Fees")]
        public Decimal TotalCleaningFees { get; set; }

        [Display(Name = "Total Discount")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalHostDiscount { get; set; }
        [Display(Name = "Total Daily Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalDailyPrice { get; set; }

        [Display(Name = "Total Stay Revenue")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalStayRevenue { get; set; }

        [Display(Name = "Total Host Stay Revenue")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalHostStayRevenue { get; set; }

        [Display(Name = "Total Reservations Completed")]
        public Int32 CompletedReservations { get; set; }
        [Display(Name = "Total Payout")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal HostPayout { get; set; }
        
        public List<HostReportPropertyViewModel> IndividualPropertyReports { get; set; }
    }
    public class HostReportPropertyViewModel
    {
        public HostReportViewModel Report { get; set; }
        //TODO: i dont know if we need this
        public Int32 HostReportPropertyViewModelID { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal pTotalStayRevenue { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal pTotalCleaningFees { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal pTotalDiscount { get; set; }
        public Int32 pCompletedReservations { get; set; }
        public Property property { get; set; }
    }

    public class AdminReportViewModel
    {
        public AppUser Admin { get; set; }

        public Int32 AdminReportViewModelID {get;set;}

        [Display(Name = "BevoBnB Total Commission")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal BnBTotalCommission { get; set; }

        [Display(Name = "BevoBnB Total Past Completed Reservations")]
        public Int32 BnBTotalReservations { get; set; }

        [Display(Name = "BevoBnB Average Commission")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal BnBAvgCommission { get; set; }

        [Display(Name = "Number of BevoBnB Properties Associated with Current Report")]
        public Int32 BnBSelectedProperties{ get; set; }


    }

}