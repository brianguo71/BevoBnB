using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
    // enum for status on whether order is in progress, pending, confirmed, or cancelled
    public enum oStatus { InProgress, Confirmed, Cancelled, HostUnavailability }

    public class Order
    {
        // constants used
        // TODO: check the correct tax rate
        private const Decimal TAX_RATE = 0.0825m;

        // Primary key
        public Int32 OrderID { get; set; }

        [Display(Name = "Order Number")]
        public Int32 OrderNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        // status on order
        public oStatus Status { get; set; }


        // TODO: insert properties needed here




        // public properties that are readonly
        // This is the total stay price of all reservations in the order
        [Display(Name = "Total Stay Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalStayPrice
        {
            get { return Reservations.Where(r => r.Status != rStatus.Cancelled && r.Status != rStatus.Delete).Sum(r => r.TotalPrice); }
        }
        // This sales tax is the total sales tax across all active reservations i
        [Display(Name = "Sales Tax")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax
        {
            get { return (TotalStayPrice + CleaningFeeTotal) * TAX_RATE; }
        }
        // Subtotal
        [Display(Name = "Subtotal")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal
        {
            get { return TotalStayPrice + CleaningFeeTotal - TotalDiscount; }
        }
        // Grand total
        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal GrandTotal
        {
            get { return Subtotal + SalesTax; }
        }

        // TODO: does there need to be a property that sums all the cleaning fees from each reservation?
        [Display(Name = "Cleaning Fee Total")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal CleaningFeeTotal
        {
            get { return Reservations.Where(r => r.Status != rStatus.Cancelled && r.Status != rStatus.Delete).Sum(r => r.CleaningFee); }
        }
        [Display(Name = "Discount Total")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TotalDiscount
        {
            get { return Reservations.Where(r => r.Status == rStatus.Pending || r.Status == rStatus.Active).Sum(r => r.Discount); }
            // relational properties
        }
        // an order can have many reservations
        public List<Reservation> Reservations { get; set; }

        // orders are only associated with a single user
        public AppUser User { get; set; }



        // method for the relational properties
        public Order()
        {
            if (Reservations == null)
            {
                Reservations = new List<Reservation>();
            }

        }

        internal IEnumerable<object> Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
