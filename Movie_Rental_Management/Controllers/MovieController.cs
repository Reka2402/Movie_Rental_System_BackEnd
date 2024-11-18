using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _dvdService;

        public MovieController(IMovieService dvdService)
        {
            _dvdService = dvdService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDVD([FromBody] MovieRequestDTO dvdDto)
        {
            await _dvdService.AddDVDAsync(dvdDto);
            return Ok("DVD added successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDVD([FromBody] MovieRequestDTO dvdDto)
        {
            await _dvdService.UpdateDVDAsync(dvdDto);
            return Ok("DVD updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDVD(Guid id)
        {
            await _dvdService.DeleteDVDAsync(id);
            return Ok("DVD deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDVDById(Guid id)
        {
            var dvd = await _dvdService.GetDVDByIdAsync(id);
            if (dvd == null) return NotFound("DVD not found.");

            return Ok(dvd);
        }

    }
}
