using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using fa21team9finalproject.Models;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
    public class ReservationIndexViewModel
    {
        // this holds the user
        public AppUser User { get; set; }
        public Int32 OrderID { get; set; }

        // this holds the different reservations
        public IEnumerable<Reservation> Past { get; set; }
        public IEnumerable<Reservation> Upcoming { get; set; }
        public IEnumerable<Reservation> Cancelled { get; set; }
        public IEnumerable<Reservation> Pending { get; set; }
        public IEnumerable<Reservation> Unavailable { get; set; }
    }

    public class ReservationModificationModel
    {
        [Required]
        public Int32 ReservationID { get; set; }
        public Int32[] IdsToCancel { get; set; }
    }
}
