using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using static Movie_Rental_Management.Entities.Favouirtes;


namespace Movie_Rental_Management.Repository
{
  

        public class FavouriteRepository : IFavouirtesRepository
        {
            private readonly AppDbContext _context;

            public FavouriteRepository(AppDbContext context)
            {
                _context = context;
            }



        public async Task AddToFavouriteAsync(Guid userId, Guid movieId)
        {
            
            var existingFavourite = await _context.Favourites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);

            if (existingFavourite != null)
            {
               
                throw new InvalidOperationException("This movie is already added to the user's favorites.");
            }

           
            var favourite = new Favouirtes
            {
                Id = Guid.NewGuid(),
                UserId = userId,  
                MovieId = movieId
            };

            await _context.Favourites.AddAsync(favourite);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetFavouriteMoviesAsync(Guid userId)
            {
                return await _context.Favourites
                    .Where(f => f.UserId == userId)
                    .Select(f => f.Movie)
                    .ToListAsync();
            }
        }

    }

