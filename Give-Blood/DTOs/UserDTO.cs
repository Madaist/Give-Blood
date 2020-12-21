using Give_Blood.Models;
using System;
using System.Collections.Generic;

namespace Give_Blood.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BloodType { get; set; }
        public int? Weight { get; set; }
        public int? Age { get; set; }
        public int? NumberOfPoints { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int NrOfPeopleHelped { get; set; }
        public int NrOfDonations { get; set; }
        public double DonatedBlood { get; set; }

        public LeagueDTO League { get; set; }
        public ICollection<BadgeDTO> Badges { get; set; }

        public ICollection<Donation> Donations { get; set; }
    }

}