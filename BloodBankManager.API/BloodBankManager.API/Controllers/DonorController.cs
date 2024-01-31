using BloodBankManager.Application.InputModels;
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var donor = await _donorService.GetById(id);

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewDonorInputModel newDonorInputModel)
        {
            var newDonor = await _donorService.Create(newDonorInputModel);

            if (!newDonor.Item1)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new {id = newDonor.Item2.Id}, newDonor);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDonorInputModel donor)
        {
            if (id == null)
                return BadRequest();

            var updatedSuccessfully = await _donorService.Update(id, donor);
            
            if (!updatedSuccessfully)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _donorService.Remove(id);

            if (id == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
