using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Services.BadgeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Give_Blood.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeService _badgeService;

        public BadgeController(IBadgeService badgeService)
        {
            _badgeService = badgeService;
        }

        [HttpGet("GetUnassigned")]
        public ICollection<BadgeDTO> GetAllUnassigned()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of the logged in user
            return _badgeService.GetUnassignedBadgesDTO(userId);
        }
    }
}
