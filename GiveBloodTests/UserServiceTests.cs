using Give_Blood.Models;
using Give_Blood.Repositories.DonationInfoRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using Give_Blood.Services.EmailSender;
using Give_Blood.Services.UserService;
using Moq;
using System;
using Xunit;

namespace GiveBloodTests
{
    public class UserServiceTests
    {

        private Mock<IUserRepository> userRepositoryMock;
        private Mock<ILeagueRepository> leagueRepositoryMock;
        private Mock<IDonationRepository> donationRepositoryMock;
        private Mock<IDonationInfoRepository> donationInfoRepositoryMock;
        private Mock<IBadgeService> badgeServiceMock;
        private Mock<IEmailSender> emailSenderMock;
        private UserService userService;

        internal void Setup()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            leagueRepositoryMock = new Mock<ILeagueRepository>();
            donationRepositoryMock = new Mock<IDonationRepository>();
            donationInfoRepositoryMock = new Mock<IDonationInfoRepository>();
            badgeServiceMock = new Mock<IBadgeService>();
            emailSenderMock = new Mock<IEmailSender>();

            userService = new UserService(userRepositoryMock.Object,
                leagueRepositoryMock.Object,
                badgeServiceMock.Object,
                donationRepositoryMock.Object,
                donationInfoRepositoryMock.Object,
                emailSenderMock.Object);
        }

        [Fact]
        public void NeedsWeightUpdateReturnsTrue()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            userRepositoryMock.Setup(u => u.FindById(userId)).Returns(new ApplicationUser
            {
                Id = userId,
                LastWeightUpdate = new DateTime(2020,10,20)
            });

            var response = userService.NeedsWeightUpdate(userId);
            Assert.True(response);
        }

        [Fact]
        public void NeedsWeightUpdateReturnsFale()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            userRepositoryMock.Setup(u => u.FindById(userId)).Returns(new ApplicationUser
            {
                Id = userId,
                LastWeightUpdate = DateTime.Now
            });

            var response = userService.NeedsWeightUpdate(userId);
            Assert.False(response);
        }

        [Fact]
        public void UpdateUserWeightIsSuccessfull()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            var weight = new Random().Next(40, 120);
            userRepositoryMock.Setup(u => u.FindById(userId)).Returns(new ApplicationUser
            {
                Id = userId,
            });

            userService.PatchUser(userId, weight);
            var updatedUser = userRepositoryMock.Object.FindById(userId);
            Assert.Equal(weight, updatedUser.Weight);
        }

       
    }
}
