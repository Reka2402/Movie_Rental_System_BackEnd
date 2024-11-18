using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IMovieRepository
    {
      
            Task AddDVDAsync(Movie dvd);
            Task UpdateDVDAsync(Movie dvd);
            Task DeleteDVDAsync(Guid id);
            Task<Movie> GetDVDByIdAsync(Guid id);


    }
}
