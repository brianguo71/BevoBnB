using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
    // enum for dispute status
    // when review is created, automatically set dStatus to notViewedYet
    // hosts can see all reviews notViewedYet and change to inDispute
    // admin can see all reviews that are listed as inDispute and Accept or Reject the dispute
    // Accepted if admin agrees with host —> review removed from site
    // Rejected if admin agrees with customer —> customer review kept on site
    public enum disputeStatus { notViewedYet, inDispute, Accepted, Rejected }


    public class PropertyReview
    {
        // all properties for property review

        // primary key
        public Int32 PropertyReviewID { get; set; }

        // property for rating
        [Required(ErrorMessage = "Rating is required!")]
        [Display(Name = "Rating")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public Int32 Rating { get; set; }

        // property for review description
        // this is optional
        [Display(Name = "Comment")]
        [StringLength(280, ErrorMessage = "Comment cannot exceed 280 characters. ")]
        public String Review { get; set; }

        // property to allow for dispute from host of a review
        // optional, but only available to hosts
        public String Dispute { get; set; }

        // property when host disputes a review and admin is looking over reviews
        // when this value is True (inDispute), then review rating doesn't factor into average rating
        public disputeStatus dStatus { get; set; }



        // relational properties

        // each property review is only associated with one user
        public AppUser User { get; set; }

        // each property review is only associated with one property
        public Property Property { get; set; }



        // method for relational properties
        public PropertyReview()
        {
        }
    }
}
