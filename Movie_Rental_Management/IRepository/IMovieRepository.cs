using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IMovieRepository
    {
        Task<Movie> AddDvdAsync(Movie movie);
        Task<Genre> GetGenreByIdAsync(int genreId);
        Task<Director> GetDirectorByIdAsync(int directorId);
        Task<Genre> GetOrCreateGenreAsync(int genreId, string genreName);
        Task<Director> GetOrCreateDirectorAsync(int directorId, string directorName);


        Task<Inventory> GetInventoryByDvdIdAsync(Guid dvdId);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Movie> GetDvdByIdAsync(Guid id);
        Task<Movie> UpdateDvdAsync(Movie dvd);
        Task<string> DeleteDvdAsync(Guid id, int quantityToDelete);
        Task<ICollection<Movie>> GetAllDvdsAsync();
        Task UpdateInventoryAsync(Inventory inventory);
        Task RemoveInventory(Inventory inventory);
     
    }
}
