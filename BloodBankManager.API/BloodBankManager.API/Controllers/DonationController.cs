using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _donationService.GetAll();

            return Ok(donors);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var donor = await _donationService.GetById(id);

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewDonationInputModel newDonationInputModel)
        {
            var newDonor = await _donationService.Create(newDonationInputModel);

            if (!newDonor.Item1)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = newDonor.Item2.Id }, newDonor);
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
