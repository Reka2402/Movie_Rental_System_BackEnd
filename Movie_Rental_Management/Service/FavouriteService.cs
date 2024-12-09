using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using static Movie_Rental_Management.Service.FavouriteService;

namespace Movie_Rental_Management.Service
{
    public class FavouriteService: IFavouritesService
    {
        
            private readonly IFavouirtesRepository _favouriteRepository;

            public FavouriteService(IFavouirtesRepository favouriteRepository)
            {
                _favouriteRepository = favouriteRepository;
            }

            public async Task AddToFavouriteAsync(Guid userId, Guid movieId)
            {
                await _favouriteRepository.AddToFavouriteAsync(userId, movieId);
            }

            public async Task<IEnumerable<Movie>> GetFavouriteMoviesAsync(Guid userId)
            {
                return await _favouriteRepository.GetFavouriteMoviesAsync(userId);
            }
        
    }
}
