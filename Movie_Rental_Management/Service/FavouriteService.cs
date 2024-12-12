using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using static Movie_Rental_Management.Service.FavouriteService;

namespace Movie_Rental_Management.Service
{
    public class FavouriteService: IFavouritesService
    {

      

        private readonly AppDbContext _context;



      
        private readonly IFavouirtesRepository _favouriteRepository;

            public FavouriteService(IFavouirtesRepository favouriteRepository , AppDbContext context)
            {
                _favouriteRepository = favouriteRepository;
            _context = context;
        }

            public async Task AddToFavouriteAsync(Guid userId, Guid movieId)
            {
                await _favouriteRepository.AddToFavouriteAsync(userId, movieId);
            }

            public async Task<IEnumerable<Movie>> GetFavouriteMoviesAsync(Guid userId)
            {
                return await _favouriteRepository.GetFavouriteMoviesAsync(userId);
            }
        public async Task DeleteFavouriteAsync(Guid favouriteId)
        {
            var favourite = await _context.Favourites.FirstOrDefaultAsync(f=>f.Id==favouriteId);

            if (favourite == null)
            {
                throw new KeyNotFoundException("Favourite not found");
            }

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();
        }

    }
}
