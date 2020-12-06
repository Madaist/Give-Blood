using Give_Blood.DTOs;
using Give_Blood.Models;
using System.Collections.Generic;

namespace Give_Blood.Services.BadgeService
{
    public interface IBadgeService
    {
        //public List<string> getAssignedBadgIds(ApplicationUser user);
        public void AssignBadges(ApplicationUser user);
        public void Check3DonationsIn9MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckFirstSpecialDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckCovidPlasmaDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckHolidayDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckDonationAfter3MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckDonationAfterLongTimeBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void CheckFirstDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void AssignBadgeToUser(string badgeName, ApplicationUser user);
        public ICollection<string> GetAssignedBadges(ApplicationUser user);
        public ICollection<BadgeDTO> GetAssignedBadgesDTO(ApplicationUser user);

    }
}
