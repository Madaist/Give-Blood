using Give_Blood.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BloodType { get; set; }
        public int? Weight { get; set; }
        public int? NumberOfPoints { get; set; }
        public string LeagueId { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<UserBadges> UserBadges { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
