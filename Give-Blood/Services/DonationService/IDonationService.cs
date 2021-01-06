using Give_Blood.Models;
using System;
using System.Collections.Generic;

namespace Give_Blood.Services.DonationService
{
    public interface IDonationService
    {
        public Boolean CreateDonation(string userId, string donationCode);

        public IEnumerable<Donation> GetDonationsHistory(string userId);
    }
}
