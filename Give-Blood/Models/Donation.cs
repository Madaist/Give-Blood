using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Give_Blood.Models
{
    public class Donation
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("DonationInfo")]
        public string Type { get; set; }

        public string QrCode { get; set; }

        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual DonationInfo DonationInfo { get; set;}
    }
}
