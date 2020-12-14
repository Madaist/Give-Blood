using Give_Blood.DTOs;
using Give_Blood.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Give_Blood.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public UserDTO GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of the logged in user
            return _userService.GetUserInfo(userId);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]

        public ICollection<UserDTO> GetFirst3ForLeaderboard()
        {

            return _userService.GetLeaderboardUsers();
        }

        [HttpGet("GetLeagueUsers")]
        public ICollection<UserDTO> GetLogedUsersTop()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of the logged in user
            return _userService.GetLeaderboardLeagueUsers(userId);
        }


    }
}
