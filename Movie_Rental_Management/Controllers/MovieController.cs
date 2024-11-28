using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _managerService;
        public MovieController(IMovieService managerService)
        {
            _managerService = managerService;
        }
        [HttpPost("AddDvd")]
        public async Task<IActionResult> AddDvd([FromBody] MovieRequestDTO createDvdDto)
        {

            if (string.IsNullOrWhiteSpace(createDvdDto.ImageUrl))
            {
                return BadRequest("ImageUrl is required and cannot be null or empty.");
            }

            if (createDvdDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var dvd = await _managerService.AddDvdAsync(createDvdDto);

                return CreatedAtAction(nameof(GetDvdById), new { id = dvd.Id }, dvd);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetDvdById{id}")]
        public async Task<ActionResult<Movie>> GetDvdById(Guid id)
        {
            var dvd = await _managerService.GetDvdByIdAsync(id);
            if (dvd == null)
            {
                return NotFound();
            }

            return Ok(dvd);
        }

        [HttpPut("UpdateDvd/{id}")]
        public async Task<IActionResult> UpdateDvd(Guid id, [FromBody] MovieRequestDTO updateDvdDto)
        {
            if (updateDvdDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var updatedDvd = await _managerService.UpdateDvdAsync(id, updateDvdDto);
                return Ok(updatedDvd);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("delete-dvd/{dvdId}")]
        public async Task<IActionResult> DeleteDvd(Guid dvdId, [FromBody] int quantityToDelete)
        {
            try
            {
                var result = await _managerService.DeleteDvdAsync(dvdId, quantityToDelete);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllDvds")]
        public async Task<IActionResult> GetAllDvds()
        {
            var dvds = await _managerService.GetAllDvdsAsync();
            return Ok(dvds);
        }

    }
}
