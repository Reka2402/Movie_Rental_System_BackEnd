using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddDvdAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Genre> GetGenreByIdAsync(int genreId)
        {
            return await _context.Movies.Where(d => d.GenreId == genreId).Select(d => d.Genre).FirstOrDefaultAsync();
        }
        public async Task<Director> GetDirectorByIdAsync(int directorId)
        {
            return await _context.Movies.Where(d => d.DirectorId == directorId).Select(d => d.director).FirstOrDefaultAsync();
        }

        public async Task<Genre> GetOrCreateGenreAsync(int genreId, string genreName)
        {
            Genre genre = null;

            if (genreId != null)
            {
                genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
            }

            if (genre == null)
            {
                genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = genreName
                    };

                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();
                }
            }

            return genre;
        }


        public async Task<Director> GetOrCreateDirectorAsync(int directorId, string directorName)
        {
            var director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == directorId);

            if (director == null)
            {
                director = await _context.Directors.FirstOrDefaultAsync(d => d.Name == directorName);

                if (director == null)
                {
                    director = new Director
                    {
                        Name = directorName,
                      
                    };

                    _context.Directors.Add(director);
                    await _context.SaveChangesAsync();
                }
            }

            return director;
        }

        // Get Inventory by DVD ID
        public async Task<Inventory> GetInventoryByDvdIdAsync(Guid dvdId)
        {
            return await _context.Inventories.FirstOrDefaultAsync(i => i.MovieId == dvdId);
        }


        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Movie> GetDvdByIdAsync(Guid id)
        {
            return await _context.Movies.Include(d => d.Genre).Include(d => d.director).FirstOrDefaultAsync(d => d.Id == id);
        }

        // Update DVD
        public async Task<Movie> UpdateDvdAsync(Movie dvd)
        {
            _context.Movies.Update(dvd);
            await _context.SaveChangesAsync();
            return dvd;
        }

        public async Task<string> DeleteDvdAsync(Guid id, int quantityToDelete)
        {
            var dvd = await _context.Movies.FirstOrDefaultAsync(d => d.Id == id);
            if (dvd == null)
            {
                throw new KeyNotFoundException("DVD not found.");
            }

            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.MovieId == id);
            if (inventory == null)
            {
                throw new KeyNotFoundException("Inventory for the specified DVD not found.");
            }

            if (inventory.Availablecopies < quantityToDelete)
            {
                throw new InvalidOperationException("Not enough copies available to delete.");
            }
            if (inventory.Totalcopies < quantityToDelete)
            {
                throw new InvalidOperationException("Not enough copies available to delete.");
            }

            inventory.Availablecopies -= quantityToDelete;
            inventory.Totalcopies -= quantityToDelete;

            if (inventory.Availablecopies == 0 || inventory.Totalcopies == 0)
            {
                _context.Inventories.Remove(inventory);
                _context.Inventories.Remove(inventory);
            }
            else
            {
                _context.Inventories.Update(inventory);
            }

            await _context.SaveChangesAsync();

            return $"Successfully deleted {quantityToDelete} copies of '{dvd.MovieName}'.";
        }


        // Get All DVDs
        public async Task<ICollection<Movie>> GetAllDvdsAsync()
        {
           var movies = await _context.Movies.Include(d => d.Genre).Include(d => d.director).ToListAsync();
            return movies;
        }

        // Update Inventory
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }




        // Remove Inventory
        public async Task RemoveInventory(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
//       