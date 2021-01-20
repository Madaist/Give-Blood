using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.BagdeRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.UserBadgesRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.DonationService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Give_Blood.Services.BadgeService
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IUserBadgesRepository _userBadgeRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IUserRepository _userRepository;

        public BadgeService(IBadgeRepository badgeRepository, IUserBadgesRepository userBadgeRepository, IDonationRepository donationRepository, IUserRepository userRepository)
        {
            _badgeRepository = badgeRepository;
            _userBadgeRepository = userBadgeRepository;
            _donationRepository = donationRepository;
            _userRepository = userRepository;
        }
        public void AssignBadges(ApplicationUser user)
        {
            var alreadyAssignedBadges = GetAssignedBadges(user);

            CheckFirstDonationBadge(user, alreadyAssignedBadges);
            CheckDonationAfterLongTimeBadge(user, alreadyAssignedBadges);
            CheckDonationAfter3MonthsBadge(user, alreadyAssignedBadges);
            CheckHolidayDonationBadge(user, alreadyAssignedBadges);
            CheckCovidPlasmaDonationBadge(user, alreadyAssignedBadges);
            CheckFirstSpecialDonationBadge(user, alreadyAssignedBadges);
            Check3DonationsIn9MonthsBadge(user, alreadyAssignedBadges);
        }

        public bool Check3DonationsIn9MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);

            if (!assignedBadges.Contains(BadgeTypes.ThreeDonationsIn9Months) && userDonations != null && userDonations.Count() >= 3)
            {
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationDate = userDonations.FirstOrDefault().Date;
                    var secondMostRecentDonationDate = userDonations.ElementAt(1).Date;
                    var thirdMostRecentDonationDate = userDonations.ElementAt(2).Date;
                    var period1 = (mostRecentDonationDate - secondMostRecentDonationDate).Days;
                    var period2 = (secondMostRecentDonationDate - thirdMostRecentDonationDate).Days;

                    if (period1 >= 85 && period1 <= 100 && period2 >= 85 && period2 <= 100)
                    {
                        AssignBadgeToUser(BadgeTypes.ThreeDonationsIn9Months, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckFirstSpecialDonationBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            if (!assignedBadges.Contains(BadgeTypes.FirstSpecialDonation))
            {
                var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationType = userDonations.FirstOrDefault().Type;
                    if (mostRecentDonationType == DonationTypes.SpecialDonation)
                    {
                        AssignBadgeToUser(BadgeTypes.FirstSpecialDonation, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckCovidPlasmaDonationBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            if (!assignedBadges.Contains(BadgeTypes.CovidPlasmaDonation))
            {
                var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationType = userDonations.FirstOrDefault().Type;
                    if (mostRecentDonationType == DonationTypes.CovidPlasmaDonation)
                    {
                        AssignBadgeToUser(BadgeTypes.CovidPlasmaDonation, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckHolidayDonationBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            if (!assignedBadges.Contains(BadgeTypes.HolidayDonation))
            {
                var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationDate = userDonations.FirstOrDefault().Date;
                    if (mostRecentDonationDate.Month == 12 || mostRecentDonationDate.Month == 1)
                    {
                        AssignBadgeToUser(BadgeTypes.HolidayDonation, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckDonationAfter3MonthsBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);
            if (!assignedBadges.Contains(BadgeTypes.DonationAfter3Months) && userDonations != null && userDonations.Count() >= 2)
            {
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationDate = userDonations.FirstOrDefault().Date;
                    var secondMostRecentDonationDate = userDonations.ElementAt(1).Date;
                    var period = (mostRecentDonationDate - secondMostRecentDonationDate).TotalDays;
                    if (period >= 85 && period <= 100)
                    {
                        AssignBadgeToUser(BadgeTypes.DonationAfter3Months, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckDonationAfterLongTimeBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            var userDonations = _donationRepository.FindByUserId(user.Id).OrderByDescending(x => x.Date);
            if (!assignedBadges.Contains(BadgeTypes.DonationAfterLongTime) && userDonations != null && userDonations.Count() >= 2)
            {
                if (userDonations != null && userDonations.Any())
                {
                    var mostRecentDonationDate = userDonations.FirstOrDefault().Date;
                    var secondMostRecentDonationDate = userDonations.ElementAt(1).Date;
                    var period = (mostRecentDonationDate - secondMostRecentDonationDate).TotalDays;
                    if (period >= 365)
                    {
                        AssignBadgeToUser(BadgeTypes.DonationAfterLongTime, user);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckFirstDonationBadge(ApplicationUser user, ICollection<string> assignedBadges)
        {
            if (!assignedBadges.Contains(BadgeTypes.FirstDonationBadge))
            {
                var userDonations = _donationRepository.FindByUserId(user.Id);
                if (userDonations != null && userDonations.Count() == 1)
                {
                    AssignBadgeToUser(BadgeTypes.FirstDonationBadge, user);
                    return true;
                }
            }
            return false;
        }

        public void AssignBadgeToUser(string badgeName, ApplicationUser user)
        {
            var badge = _badgeRepository.FindByName(badgeName);
            _userBadgeRepository.Create(new UserBadges { Id = Guid.NewGuid().ToString(), BadgeId = badge.Id, UserId = user.Id });
            _userBadgeRepository.SaveChanges();

            user.NrOfPoints += badge.NrOfPoints;
            _userRepository.Update(user);
        }

        public ICollection<string> GetAssignedBadges(ApplicationUser user)
        {
            ICollection<string> badgeNames = new List<string>();
            var userBadges = _userBadgeRepository.FindByUserId(user.Id);
            if (userBadges != null && userBadges.Any())
            {
                foreach (var userBadge in userBadges)
                {
                    badgeNames.Add(_badgeRepository.FindById(userBadge.BadgeId).Name);
                }
            }
            return badgeNames;
        }

        public ICollection<BadgeDTO> GetAssignedBadgesDTO(ApplicationUser user)
        {
            ICollection<BadgeDTO> badges = new List<BadgeDTO>();
            var userBadges = _userBadgeRepository.FindByUserId(user.Id);
            if (userBadges != null && userBadges.Any())
            {
                foreach (var userBadge in userBadges)
                {
                    var badge = _badgeRepository.FindById(userBadge.BadgeId);
                    var badgeName = badge.Name.Replace("_", " ");
                    badgeName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(badgeName.ToLower());
                    badges.Add(new BadgeDTO { Name = badgeName, Icon = badge.Icon, NrOfPoints = badge.NrOfPoints });
                }
            }
            return badges;
        }

        public ICollection<BadgeDTO> GetUnassignedBadgesDTO(string userId)
        {
            ICollection<BadgeDTO> unassignedBadges = new List<BadgeDTO>();
            var assignedBadgeIds = _userBadgeRepository.FindByUserId(userId).Select(x => x.BadgeId);
            var allPossibleBadges = GetAll().Select(x => x.Id);
            var unassignedBadgeIds = allPossibleBadges.Except(assignedBadgeIds);

            foreach (string badgeId in unassignedBadgeIds)
            {
                var badge = _badgeRepository.FindById(badgeId);
                var badgeName = badge.Name.Replace("_", " ");
                badgeName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(badgeName.ToLower());
                unassignedBadges.Add(new BadgeDTO { Name = badgeName, Icon = badge.Icon, NrOfPoints = badge.NrOfPoints });
            }
            return unassignedBadges;
        }

        public ICollection<Badge> GetAll()
        {
            return _badgeRepository.GetAll();
        }

    }
}
