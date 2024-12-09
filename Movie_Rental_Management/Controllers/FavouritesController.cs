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

        [HttpPost("add")]
        public async Task<IActionResult> AddToFavourite(Guid userId, Guid movieId)
        {
            await _favouriteService.AddToFavouriteAsync(userId, movieId);
            return Ok(new { message = "Movie added to favourites" });
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
    
