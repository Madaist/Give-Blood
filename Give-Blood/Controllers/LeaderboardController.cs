using Give_Blood.DTOs;
using Give_Blood.Services.LeaderboardService;
using Give_Blood.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Give_Blood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaderboardController : ControllerBase
    {
        private readonly ILeaderboardService _leaderboardService;
        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet("TopThree")]
        [AllowAnonymous]
        public ICollection<UserDTO> GetTopThree()
        {
            return _leaderboardService.GetTopThree();
        }

        [HttpGet("All")]
        public ICollection<UserDTO> GetTop()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of the logged in user
            return _leaderboardService.GetLeaderboard(userId);
        }
    }
}
