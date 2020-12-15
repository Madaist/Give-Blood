using Give_Blood.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Services.LeaderboardService
{
    public interface ILeaderboardService
    {
        public ICollection<UserDTO> GetLeaderboard(string userId);
        public ICollection<UserDTO> GetTopThree();
    }
}
