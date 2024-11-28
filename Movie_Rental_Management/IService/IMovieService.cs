using Movie_Rental_Management.Entities;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.IService
{
    public interface IMovieService
    {
        Task<Movie> AddDvdAsync(MovieRequestDTO movieRequestDTO);
        Task<Movie> GetDvdByIdAsync(Guid id);
        Task<Movie> UpdateDvdAsync(Guid id, MovieRequestDTO updateDvdDto);
        Task<string> DeleteDvdAsync(Guid id, int quantityToDelete);
        Task<ICollection<Movie>> GetAllDvdsAsync();
    }
}
