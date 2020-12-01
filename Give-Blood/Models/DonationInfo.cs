using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Models
{
    public class DonationInfo
    {
        [Key]
        public string DonationType { get; set; }
        public int NrOfPoints { get; set; }
        public int NrOfPeopleHelped { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
