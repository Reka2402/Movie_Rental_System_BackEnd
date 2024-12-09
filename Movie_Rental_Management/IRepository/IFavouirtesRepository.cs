using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IFavouirtesRepository
    {
        Task AddToFavouriteAsync(Guid userId, Guid movieId);
        Task<IEnumerable<Movie>> GetFavouriteMoviesAsync(Guid userId);
    }
}
