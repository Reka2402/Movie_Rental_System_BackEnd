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

        public async Task<Movie> AddDVDAsync(Movie dvd)
        {
            _context.Movies.Add(dvd);
            await _context.SaveChangesAsync();
            return dvd;
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
                        Name = genreName,
                    };
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();

                }
            }
            return genre;
        }
        public async Task<Director> GetOrCreateDirectorAsync(int directorId, string directorName, string directordescription)
        {
            var director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == directorId);
            if (director == null)
            {
                director = await _context.Directors.FirstOrDefaultAsync(d => d.DirectorName == directorName);
                if (director == null)
                {
                    director = new Director
                    {
                        DirectorName = directorName,
                        Description = directordescription
                    };
                    _context.Directors.Add(director);
                    await _context.SaveChangesAsync();
                }
            }
            return director;
        }
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
        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _context.Movies.Include(d => d.Genre).Include(d => d.director).FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Movie> UpdateDVDAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        //    public async Task<string> DeleteMovieAsync(Guid id, int quantityToDelete)
        //    {
        //        var movie = await _context.Movies.FirstOrDefaultAsync(d => d.Id == id);
        //        if (movie != null)
        //        {
        //            throw new KeyNotFoundException("DVD not found");
        //        }
        //        var inventory = await _context

        //}



    }
}
        //public async Task UpdateDVDAsync(Movie dvd)
        //{
        //    var existingDVD = await _context.Movies.FindAsync(dvd.Id);
        //    if (existingDVD != null)
        //    {
        //        existingDVD.MovieName = dvd.MovieName;
        //        existingDVD.directorId = dvd.directorId;
        //        existingDVD.GenreId = dvd.GenreId;
        //        existingDVD.ReleaseDate = dvd.ReleaseDate;
        //        existingDVD.Price = dvd.Price;
        //        existingDVD.Description = dvd.Description;
        //        existingDVD.ImageUrl = dvd.ImageUrl;

        //        _context.Movies.Update(existingDVD);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task DeleteDVDAsync(Guid id)
        //{
        //    var dvd = await _context.Movies.FindAsync(id);
        //    if (dvd != null)
        //    {
        //        _context.Movies.Remove(dvd);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<Movie> GetDVDByIdAsync(Guid id)
        //{
        //    return await _context.Movies
        //        .Include(m => m.Genre)
        //        .Include(m => m.director)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //}
