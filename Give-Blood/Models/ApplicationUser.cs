using Give_Blood.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Give_Blood.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public int? Weight { get; set; }
        public int? Age { get; set; }
        public string LeagueId { get; set; }
        public string Address { get; set; }
        public int NrOfPoints { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastWeightUpdate { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<UserBadges> UserBadges { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }

    }
}
