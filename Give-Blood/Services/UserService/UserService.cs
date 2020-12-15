using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.DonationInfoRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using System.Collections.Generic;
using System.Linq;

namespace Give_Blood.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBadgeService _badgeService;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationInfoRepository _donationInfoRepository;

        public object Conssole { get; private set; }

        public UserService(IUserRepository userRepository, ILeagueRepository leagueRepository, IBadgeService badgeService, IDonationRepository donationRepository, IDonationInfoRepository donationInfoRepository)
        {
            _userRepository = userRepository;
            _leagueRepository = leagueRepository;
            _badgeService = badgeService;
            _donationRepository = donationRepository;
            _donationInfoRepository = donationInfoRepository;
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
                Weight = user.Weight,
                Address = user.Address,
                BloodType = user.BloodType,
                Badges = _badgeService.GetAssignedBadgesDTO(user),
                Donations = user.Donations,
                NumberOfPoints = user.NrOfPoints
            };

            League league = _leagueRepository.FindById(user.LeagueId);
            LeagueDTO leagueDTO = new LeagueDTO { Name = league.Name, Icon = league.Icon };
            userDTO.League = leagueDTO;

            int nrOfPeopleHelped = 0;
            int nrOfDonations = 0;

            var userDonations = _donationRepository.FindByUserId(userId);
            if (userDonations != null && userDonations.Any())
            {
                foreach (Donation donation in userDonations)
                {
                    nrOfPeopleHelped += _donationInfoRepository.FindById(donation.Type).NrOfPeopleHelped;
                    nrOfDonations++;
                }
            }
            userDTO.NrOfPeopleHelped = nrOfPeopleHelped;
            userDTO.NrOfDonations = nrOfDonations;
            userDTO.DonatedBlood = nrOfDonations * 450 / 1000.0;

            return userDTO;
        }

        public void UpdateLeagueandBadges(string userId)
        {
            ApplicationUser user = _userRepository.FindById(userId);
            _badgeService.AssignBadges(user);
            if (user.NrOfPoints >= 0 && user.NrOfPoints <= 35) user.LeagueId = "1";
            if (user.NrOfPoints > 35 && user.NrOfPoints <= 70) user.LeagueId = "2";
            if (user.NrOfPoints > 70 && user.NrOfPoints <= 120) user.LeagueId = "3";
            if (user.NrOfPoints > 120 && user.NrOfPoints <= 160) user.LeagueId = "4";
            if (user.NrOfPoints > 160 && user.NrOfPoints <= 200) user.LeagueId = "5";
            if (user.NrOfPoints > 200 && user.NrOfPoints <= 250) user.LeagueId = "6";
            if (user.NrOfPoints > 250 && user.NrOfPoints <= 290) user.LeagueId = "7";
            if (user.NrOfPoints > 290 && user.NrOfPoints <= 400) user.LeagueId = "8";
            if (user.NrOfPoints > 400) user.LeagueId = "9";

            _userRepository.Update(user);

        }


        public ICollection<UserDTO> GetLeaderboardUsers()
        { 
            ICollection<UserDTO> topUsersDTO = new List<UserDTO>();
           // int i = 0;
              var topUsers = _userRepository.GetAll().OrderByDescending(x => x.NrOfPoints);
            if (topUsers.Count() >= 3)
            {
                foreach (ApplicationUser user in topUsers.Take(3))
                { 
                    topUsersDTO.Add(GetUserInfo(user.Id));
                  
                }
            }
            else
            {
                foreach (ApplicationUser user in topUsers)
                { 
                    topUsersDTO.Add(GetUserInfo(user.Id));
                   
                }

            }

            
            return topUsersDTO;
        }
        public ICollection<UserDTO> GetLeaderboardLeagueUsers(string Id)
        {
            var logeduser = _userRepository.FindById(Id);
            League league = _leagueRepository.FindById(logeduser.LeagueId);

            ICollection<UserDTO> topLogedUsersDTO = new List<UserDTO>();
           
            var topLeagueUsers = _userRepository.GetAll().Where(x=>x.LeagueId==league.Id).OrderByDescending(x => x.NrOfPoints);
            
                foreach (ApplicationUser user in topLeagueUsers)
                {
                    topLogedUsersDTO.Add(GetUserInfo(user.Id));

                }

            
            return topLogedUsersDTO;



        }


    }
}
