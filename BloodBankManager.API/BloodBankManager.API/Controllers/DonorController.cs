using BloodBankManager.API.Models.InputModels;
using BloodBankManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/donors")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _donorService.GetAll();

            return Ok(donors);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var donor = await _donorService.GetById(id);
            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewDonorInputModel newDonorInputModel)
        {
            var newDonor = await _donorService.Create(newDonorInputModel);

            if (newDonor == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new {id = newDonor.Id}, newDonor);
        }

        [HttpPut("id")]
        public IActionResult Update(int id, [FromBody] UpdateDonorInputModel donor)
        {
            if (donor == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Remove(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
