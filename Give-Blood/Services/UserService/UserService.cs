using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using System;
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
            UpdateLeagueandBadges(userId);

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
                Donations = user.Donations,
                NumberOfPoints =user.NrOfPoints
            };

            League league = _leagueRepository.FindById(user.LeagueId);
            LeagueDTO leagueDTO = new LeagueDTO { Name = league.Name, Icon = league.Icon };
            userDTO.League = leagueDTO;

            int nrOfPeopleHelped = 0;
            
            int nrOfDonations = 0;
            double totalBloodQuantity = 0;
            if (user.Donations != null && user.Donations.Any())
            {
                foreach (Donation donation in user.Donations)
                {
                    nrOfPeopleHelped += donation.DonationInfo.NrOfPeopleHelped;
                    nrOfDonations++;
                    totalBloodQuantity += donation.Quantity;
                }
            }
            userDTO.NrOfPeopleHelped = nrOfPeopleHelped;
      
            userDTO.NrOfDonations = nrOfDonations;
            userDTO.DonatedBlood = totalBloodQuantity;

            return userDTO;
        }

        public void UpdateLeagueandBadges(string userId)
        {
            ApplicationUser user = _userRepository.FindById(userId);
            _badgeService.AssignBadges(user);
            if (user.NrOfPoints >=0 && user.NrOfPoints <= 35) user.LeagueId ="1";
            if (user.NrOfPoints >35 && user.NrOfPoints <= 70) user.LeagueId = "2";
            if (user.NrOfPoints >70  && user.NrOfPoints <=120) user.LeagueId = "3";
            if (user.NrOfPoints > 120 && user.NrOfPoints <= 160) user.LeagueId = "4";
            if (user.NrOfPoints > 160 && user.NrOfPoints <= 200) user.LeagueId = "5";
            if (user.NrOfPoints > 200 && user.NrOfPoints <= 250) user.LeagueId = "6";
            if (user.NrOfPoints > 250 && user.NrOfPoints <= 290) user.LeagueId = "7";
            if (user.NrOfPoints > 290 && user.NrOfPoints <= 400) user.LeagueId = "8";
            if (user.NrOfPoints > 400) user.LeagueId = "9";




        }



       
    }
}
