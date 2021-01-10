using Give_Blood.DTOs;
using Give_Blood.Services.DonationService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Give_Blood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpPost]
        public IActionResult CreateDonation([FromBody] string donationCode)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of the logged in user
            var isDonationCreated = _donationService.CreateDonation(userId, donationCode);
            if (isDonationCreated)
                return Ok();
            else
                return BadRequest("Code already exists");
        }

        [HttpGet]
        public IEnumerable<DonationHistoryDTO> GetDonationsHistory()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _donationService.GetDonationsHistory(userId);
        }
    }
}
