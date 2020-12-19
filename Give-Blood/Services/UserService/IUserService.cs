using Give_Blood.DTOs;
using Give_Blood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Services.UserService
{
    public interface IUserService
    {
        public UserDTO GetUserInfo(string userId);

        public void UpdateUserInfo(UserDTO userDTO);

        public void UpdateLeagueandBadges(string userId);
    }
}
