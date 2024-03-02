using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationAppService _donationService;

        public DonationController(IDonationAppService donationService)
        {
            _donationService = donationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReportOfTheLastThirtyDays()
        {
            var donations = await _donationService.GetAllInTheLastThirtyDays();

            return Ok(donations);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donation = await _donationService.GetById(id);

            return Ok(donation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewDonationInputModel newDonationInputModel)
        {
            var (canDonate, newDonation) = await _donationService.Create(newDonationInputModel);

            if (!canDonate)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = newDonation.Id }, newDonation);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _donationService.Remove(id);

            if (id == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
