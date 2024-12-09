using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.IService
{
    public interface IFavouritesService
    {
        Task AddToFavouriteAsync(Guid userId, Guid movieId);
        Task<IEnumerable<Movie>> GetFavouriteMoviesAsync(Guid userId);
    }
}
