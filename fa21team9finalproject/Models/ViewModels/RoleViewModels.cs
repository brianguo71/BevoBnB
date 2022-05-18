using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using fa21team9finalproject.Models;
using Microsoft.AspNetCore.Identity;

namespace fa21team9finalproject.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> RoleMembers { get; set; }
        public IEnumerable<AppUser> RoleNonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

    public class ActiveProfileEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> ActiveMembers { get; set; }
        public IEnumerable<AppUser> InactiveMembers { get; set; }
    }

    public class ActiveModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToInactivate { get; set; }
        public string[] IdsToActivate { get; set; }
    }

    public class ApprovePropertiesModel
    {
        public IEnumerable<Property> ApprovedProperties { get; set; }
        public IEnumerable<Property> NotApprovedProperties { get; set; }
    }

    public class PropertyApprovalModificationModel
    {
        [Required]
        public Int32 PropertyID { get; set; }
        public Int32[] IdsApproved { get; set; }
        public Int32[] IdsNotApproved { get; set; }
    }
}