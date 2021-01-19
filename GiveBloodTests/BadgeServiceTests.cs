using Give_Blood.Models;
using Give_Blood.Repositories.BagdeRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.UserBadgesRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using Give_Blood.Services.DonationService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GiveBloodTests
{
    public class BadgeServiceTests
    {
        private Mock<IBadgeRepository> badgeRepositoryMock;
        private Mock<IUserBadgesRepository> userBadgesRepositoryMock;
        private Mock<IDonationRepository> donationRepositoryMock;
        private Mock<IUserRepository> userRepositoryMock;
        private BadgeService badgeService;

        internal void Setup()
        {
            badgeRepositoryMock = new Mock<IBadgeRepository>();
            userBadgesRepositoryMock = new Mock<IUserBadgesRepository>();
            donationRepositoryMock = new Mock<IDonationRepository>();
            userRepositoryMock = new Mock<IUserRepository>();

            badgeService = new BadgeService(
                badgeRepositoryMock.Object,
                userBadgesRepositoryMock.Object,
                donationRepositoryMock.Object,
                userRepositoryMock.Object
                );
        }

        [Fact]
        public void Check3DonationsIn9MonthsBadgeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now.AddDays(-90) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now.AddDays(-180) }
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "3", Name = "3_DONĂRI_ÎN_9_LUNI", NrOfPoints = 40, Icon = "https://i.ibb.co/CzCdhfC/three-months.png" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.ThreeDonationsIn9Months)).Returns(badge);
            Assert.True(badgeService.Check3DonationsIn9MonthsBadge(user, new List<string>()));
        }

        [Fact]
        public void Check3DonationsIn9MonthsBadgeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
            {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now.AddDays(-30) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now.AddDays(-60) }
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "3", Name = "3_DONĂRI_ÎN_9_LUNI", NrOfPoints = 40, Icon = "https://i.ibb.co/CzCdhfC/three-months.png" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.ThreeDonationsIn9Months)).Returns(badge);
            Assert.False(badgeService.Check3DonationsIn9MonthsBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckFirstSpecialDonationBadgeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now, Type = DonationTypes.SpecialDonation },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "6", Name = "PRIMA_DONARE_SPECIALĂ" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.FirstSpecialDonation)).Returns(badge);
            Assert.True(badgeService.CheckFirstSpecialDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckFirstSpecialDonationBadgeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now, Type = DonationTypes.OrdinaryDonation },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "6", Name = "PRIMA_DONARE_SPECIALĂ" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.FirstSpecialDonation)).Returns(badge);
            Assert.False(badgeService.CheckFirstSpecialDonationBadge(user, new List<string>()));
        }
    }
}
