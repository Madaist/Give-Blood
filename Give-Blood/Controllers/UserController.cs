using Give_Blood.DTOs;
using Give_Blood.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut]
        public void UpdateInfo(UserDTO userDTO)
        {
            _userService.UpdateUserInfo(userDTO);
        }

        [HttpGet("WeightUpdateNeed")]
        public IActionResult WeightUpdateNeed()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(_userService.NeedsWeightUpdate(userId));
        }

        [HttpGet("CheckDonationNotification")]
        public IActionResult CheckDonationNotification()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notificationMessage = _userService.CheckNextPossibleDonationDate(userId);
            return Ok(new { text = notificationMessage });
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] int weight)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isUpdated = _userService.PatchUser(userId, weight);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound(new { message = "User not found" });
        }
    }
}
