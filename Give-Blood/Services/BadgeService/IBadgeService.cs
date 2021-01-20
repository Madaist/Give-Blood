using Give_Blood.DTOs;
using Give_Blood.Models;
using System.Collections.Generic;

namespace Give_Blood.Services.BadgeService
{
    public interface IBadgeService
    {
        public void AssignBadges(ApplicationUser user);
        public bool Check3DonationsIn9MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckFirstSpecialDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckCovidPlasmaDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckHolidayDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckDonationAfter3MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckDonationAfterLongTimeBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public bool CheckFirstDonationBadge(ApplicationUser user, ICollection<string> assignedBadges);
        public void AssignBadgeToUser(string badgeName, ApplicationUser user);
        public ICollection<string> GetAssignedBadges(ApplicationUser user);
        public ICollection<BadgeDTO> GetAssignedBadgesDTO(ApplicationUser user);
        public ICollection<Badge> GetAll();
        public ICollection<BadgeDTO> GetUnassignedBadgesDTO(string userId);

    }
}
