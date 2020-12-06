using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using System.Linq;

namespace Give_Blood.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBadgeService _badgeService;
        private readonly ILeagueRepository _leagueRepository;

        public UserService(IUserRepository userRepository, ILeagueRepository leagueRepository, IBadgeService badgeService)
        {
            _userRepository = userRepository;
            _leagueRepository = leagueRepository;
            _badgeService = badgeService;
        }

        public UserDTO GetUserInfo(string userId)
        {
            ApplicationUser user = _userRepository.FindById(userId);
            _badgeService.AssignBadges(user);

            UserDTO userDTO = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Weight = user.Weight,
                Description = user.Description,
                Address = user.Address,
                BloodType = user.BloodType,
                Badges = _badgeService.GetAssignedBadgesDTO(user),
                Donations = user.Donations
            };

            League league = _leagueRepository.FindById(user.LeagueId);
            LeagueDTO leagueDTO = new LeagueDTO { Name = league.Name, Icon = league.Icon };
            userDTO.League = leagueDTO;

            int nrOfPeopleHelped = 0;
            int nrOfPoints = 0;
            int nrOfDonations = 0;
            double totalBloodQuantity = 0;
            if (user.Donations != null && user.Donations.Any())
            {
                foreach (Donation donation in user.Donations)
                {
                    nrOfPeopleHelped += donation.DonationInfo.NrOfPeopleHelped;
                    nrOfPoints += donation.DonationInfo.NrOfPoints;
                    nrOfDonations++;
                    totalBloodQuantity += donation.Quantity;
                }
            }
            userDTO.NrOfPeopleHelped = nrOfPeopleHelped;
            userDTO.NumberOfPoints = nrOfPoints;
            userDTO.NrOfDonations = nrOfDonations;
            userDTO.DonatedBlood = totalBloodQuantity;

            return userDTO;
        }

       
    }
}
