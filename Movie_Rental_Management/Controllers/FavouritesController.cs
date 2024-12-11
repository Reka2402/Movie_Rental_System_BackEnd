using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.IService;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {

        private readonly IFavouritesService _favouriteService;

        public FavouritesController(IFavouritesService favouriteService)
        {
            _favouriteService = favouriteService;
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
    }
}
    
