using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class MovieRepository: IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDVDAsync(Movie dvd)
        {
            await _context.Movies.AddAsync(dvd);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDVDAsync(Movie dvd)
        {
            var existingDVD = await _context.Movies.FindAsync(dvd.Id);
            if (existingDVD != null)
            {
                existingDVD.MovieName = dvd.MovieName;
                existingDVD.directorId = dvd.directorId;
                existingDVD.GenreId = dvd.GenreId;
                existingDVD.ReleaseDate = dvd.ReleaseDate;
                existingDVD.Price = dvd.Price;
                existingDVD.Description = dvd.Description;
                existingDVD.ImageUrl = dvd.ImageUrl;

                _context.Movies.Update(existingDVD);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDVDAsync(Guid id)
        {
            var dvd = await _context.Movies.FindAsync(id);
            if (dvd != null)
            {
                _context.Movies.Remove(dvd);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie> GetDVDByIdAsync(Guid id)
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.director)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
