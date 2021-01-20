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
using System.Net.Http;
using System.Threading.Tasks;
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

        [Fact]
        public void CheckNextPossibleDonationDateSendMail()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            userRepositoryMock.Setup(u => u.FindById(userId)).Returns(new ApplicationUser
            {
                Id = userId,
                FirstName = "Give Blood User"
            });
            Donation[] userDonations =
            {
                new Donation
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    Date = DateTime.Now.AddDays(-89)
                }
            };
            emailSenderMock.Setup(u => u.SendEmailAsync("email", "subject", "message")).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)));
            donationRepositoryMock.Setup(u => u.FindByUserId(userId)).Returns(userDonations);
            var message = userService.CheckNextPossibleDonationDate(userId);
            Assert.Contains("Poti dona din nou, incepand cu data de", message);
        }

        [Fact]
        public void CheckNextPossibleDonationDateAfter3Months()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            Donation[] userDonations =
            {
                new Donation
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    Date = DateTime.Now.AddDays(-91)
                }
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(userId)).Returns(userDonations);
            var message = userService.CheckNextPossibleDonationDate(userId);
            Assert.Equal("Au trecut deja 3 luni de la ultima donatie. Poti dona din nou!", message);
        }


        [Fact]
        public void CheckNextPossibleDonationDateReturnsNull()
        {
            Setup();
            var userId = Guid.NewGuid().ToString();
            Donation[] userDonations =
            {
                new Donation
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    Date = DateTime.Now.AddDays(-60)
                }
            };
            donationRepositoryMock.Setup(u => u.FindByUserId(userId)).Returns(userDonations);
            var message = userService.CheckNextPossibleDonationDate(userId);
            Assert.Null(message);
        }


    }
}
