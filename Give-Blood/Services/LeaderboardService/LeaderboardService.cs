using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.UserService;
using System.Collections.Generic;
using System.Linq;

namespace Give_Blood.Services.LeaderboardService
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ILeagueRepository _leagueRepository;

        public LeaderboardService(IUserRepository userRepository, IUserService userService, ILeagueRepository leagueRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
            _leagueRepository = leagueRepository;
        }
        public ICollection<UserDTO> GetTopThree()
        {
            ICollection<UserDTO> topUsersDTO = new List<UserDTO>();
            var topUsers = _userRepository.GetAll().OrderByDescending(x => x.NrOfPoints);
            if (topUsers.Count() >= 3)
            {
                foreach (ApplicationUser user in topUsers.Take(3))
                {
                    topUsersDTO.Add(_userService.GetUserInfo(user.Id));
                }
            }
            else
            {
                foreach (ApplicationUser user in topUsers)
                {
                    topUsersDTO.Add(_userService.GetUserInfo(user.Id));
                }
            }
            return topUsersDTO;
        }
        public ICollection<UserDTO> GetLeaderboard(string Id)
        {
            var loggedUser = _userRepository.FindById(Id);
            League league = _leagueRepository.FindById(loggedUser.LeagueId);
            ICollection<UserDTO> topUsersDTO = new List<UserDTO>();
            var topUsers = _userRepository.GetAll().Where(x => x.LeagueId == league.Id).OrderByDescending(x => x.NrOfPoints);

            foreach (ApplicationUser user in topUsers)
            {
                topUsersDTO.Add(_userService.GetUserInfo(user.Id));
            }

            return topUsersDTO;
        }
    }
}
