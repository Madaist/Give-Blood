using System;

namespace Give_Blood.Services.DonationService
{
    public interface IDonationService
    {
        public Boolean CreateDonation(string userId, string donationCode);
    }
}
