using System;

namespace Give_Blood.DTOs
{
    public class DonationDTO
    {
        public string Type { get; set; }
        public Double Quantity { get; set; }
        public DateTime Date { get; set; }
        public string QrCode { get; set; }
    }
}
