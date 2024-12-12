using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {

        private readonly IFavouritesService _favouriteService;

        private readonly AppDbContext _context;

      

        public FavouritesController(IFavouritesService favouriteService , AppDbContext context)
        {
            _favouriteService = favouriteService;
            _context = context;
        }

        [HttpGet("add/{userId}/{movieId}")]
        public async Task<IActionResult> AddToFavourite( Guid userId, Guid movieId)
        {
            try
            {
                await _favouriteService.AddToFavouriteAsync(userId, movieId);
                return Ok(new { message = "Movie added to favorites" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFavouriteMovies(Guid userId)
        {
            var favouriteMovies = await _favouriteService.GetFavouriteMoviesAsync(userId);
            if (favouriteMovies == null || !favouriteMovies.Any())
            {
                return NotFound(new { message = "No favourite movies found" });
            }

            return Ok(favouriteMovies);
        }
        [HttpDelete("delete/{favouriteId}")]
        public async Task<IActionResult> DeleteFavourite(Guid favouriteId)
        {
            try
            {
                // Call the service to delete the favourite
                await _favouriteService.DeleteFavouriteAsync(favouriteId);
                return Ok(new { message = "Favourite movie removed successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while removing the favourite", details = ex.Message });
            }
        }



    }
}
    
