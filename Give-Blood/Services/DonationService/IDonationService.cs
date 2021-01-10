using Give_Blood.DTOs;
using System;
using System.Collections.Generic;

namespace Give_Blood.Services.DonationService
{
    public interface IDonationService
    {
        public Boolean CreateDonation(string userId, string donationCode);
        public IEnumerable<DonationHistoryDTO> GetDonationsHistory(string userId);
    }
}
