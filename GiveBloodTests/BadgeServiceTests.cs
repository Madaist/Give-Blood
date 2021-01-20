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
            // Arrange

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


            //Act & Assert
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
            Assert.False(badgeService.CheckFirstSpecialDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckCovidPlasmaDonationBadgeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now, Type = DonationTypes.CovidPlasmaDonation },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "5", Name = "DONARE_DE_PLASMĂ_COVID" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.CovidPlasmaDonation)).Returns(badge);
            Assert.True(badgeService.CheckCovidPlasmaDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckCovidPlasmaDonationBadgeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = DateTime.Now, Type = DonationTypes.OrdinaryDonation },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            Assert.False(badgeService.CheckCovidPlasmaDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckHolidayDonationBadgeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "4", Name = "DONARE_DE_SĂRBĂTORI" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.HolidayDonation)).Returns(badge);
            Assert.True(badgeService.CheckHolidayDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckHolidayDonationBadgeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 10, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            Assert.False(badgeService.CheckHolidayDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckDonationAfterLongTimeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2018, 12, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "2", Name = "DONARE_DUPĂ_MULT_TIMP" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.DonationAfterLongTime)).Returns(badge);
            Assert.True(badgeService.CheckDonationAfterLongTimeBadge(user, new List<string>()));
        }


        [Fact]
        public void CheckDonationAfterLongTimeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 5, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            Assert.False(badgeService.CheckDonationAfterLongTimeBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckDonationAfter3MonthsIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 9, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "3", Name = "DONARE_DUPĂ_3_LUNI" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.DonationAfter3Months)).Returns(badge);
            Assert.True(badgeService.CheckDonationAfter3MonthsBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckDonationAfter3MonthsIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 8, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "3", Name = "DONARE_DUPĂ_3_LUNI" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.DonationAfter3Months)).Returns(badge);
            Assert.False(badgeService.CheckDonationAfter3MonthsBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckFirstDonationBadgeIsTrue()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            Donation[] userDonations =
             {
                new Donation{ Id = Guid.NewGuid().ToString(), UserId = user.Id, Date = new DateTime(2020, 12, 15) },
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(userDonations);
            var badge = new Badge { Id = "1", Name = "PRIMA_DONARE" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.FirstDonationBadge)).Returns(badge);
            Assert.True(badgeService.CheckFirstDonationBadge(user, new List<string>()));
        }

        [Fact]
        public void CheckFirstDonationBadgeIsFalse()
        {
            Setup();
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString() };
            donationRepositoryMock.Setup(u => u.FindByUserId(user.Id)).Returns(new List<Donation>());
            var badge = new Badge { Id = "1", Name = "PRIMA_DONARE" };
            badgeRepositoryMock.Setup(b => b.FindByName(BadgeTypes.FirstDonationBadge)).Returns(badge);
            Assert.False(badgeService.CheckFirstDonationBadge(user, new List<string>()));
        }




    }
}
