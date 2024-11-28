using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository dvdRepository)
        {
            _movieRepository = dvdRepository;
        }
   

        public async Task<Movie> AddDvdAsync(MovieRequestDTO movieRequestDTO)
        {
            var genre = await _movieRepository.GetOrCreateGenreAsync(movieRequestDTO.GenreId, movieRequestDTO.GenreName);

            var director = await _movieRepository.GetOrCreateDirectorAsync(movieRequestDTO.DirectorId, movieRequestDTO.DirectorName);
       
                        var dvd = new Movie
            {
                Id = Guid.NewGuid(),
                MovieName = movieRequestDTO.MovieName,
                GenreId = genre.Id,
                DirectorId = director.Id,
                ReleaseDate = movieRequestDTO.ReleaseDate,
                Price = movieRequestDTO.Price,
                Description = movieRequestDTO.Description,
                ImageUrl = movieRequestDTO.ImageUrl ?? "default-image-url.jpg",
                TotalCopies = movieRequestDTO.Totalcopies,
                //Rentals = new List<Rental>(),
                Reviews = new List<Review>(),
                //Reservations = new List<Reservation>()
            };

            var addedDvd = await _movieRepository.AddDvdAsync(dvd);

            var inventory = new Inventory
            {
                Id = Guid.NewGuid(),
                MovieId = addedDvd.Id,
                Totalcopies = movieRequestDTO.Totalcopies,
                Availablecopies = movieRequestDTO.Totalcopies,
                //LastRestock = DateTime.UtcNow,
                Movie = addedDvd
            };

            await _movieRepository.AddInventoryAsync(inventory);

            return addedDvd;
        }




        public async Task<Movie> GetDvdByIdAsync(Guid id)
        {
            return await _movieRepository.GetDvdByIdAsync(id);
        }

        // Update DVD
        public async Task<Movie> UpdateDvdAsync(Guid id, MovieRequestDTO updateDvdDto)
        {
            var dvd = await _movieRepository.GetDvdByIdAsync(id);
            if (dvd == null)
            {
                throw new KeyNotFoundException("DVD not found.");
            }

            // Update DVD details
            dvd.MovieName = updateDvdDto.MovieName ?? dvd.MovieName;
            dvd.Description = updateDvdDto.Description ?? dvd.Description;
            if (updateDvdDto.Price != 0)
            {
                dvd.Price = updateDvdDto.Price;
            }

            if (updateDvdDto.ReleaseDate != default(DateTime))
            {
                dvd.ReleaseDate = updateDvdDto.ReleaseDate;
            }

            dvd.ImageUrl = updateDvdDto.ImageUrl ?? dvd.ImageUrl;

            var genre = await _movieRepository.GetOrCreateGenreAsync(updateDvdDto.GenreId, updateDvdDto.GenreName);
            dvd.GenreId = genre.Id;

            var director = await _movieRepository.GetOrCreateDirectorAsync(updateDvdDto.DirectorId, updateDvdDto.DirectorName);
            dvd.DirectorId = director.Id;

            var updatedDvd = await _movieRepository.UpdateDvdAsync(dvd);

            var inventory = await _movieRepository.GetInventoryByDvdIdAsync(dvd.Id);
            if (inventory != null)
            {
                inventory.Totalcopies = updateDvdDto.Totalcopies;
                inventory.Availablecopies = updateDvdDto.Totalcopies;
                await _movieRepository.UpdateInventoryAsync(inventory);
            }

            return updatedDvd;
        }

        public async Task<string> DeleteDvdAsync(Guid id, int quantityToDelete)
        {
            try
            {
                if (quantityToDelete <= 0)
                {
                    throw new ArgumentException("Quantity to delete must be greater than zero.", nameof(quantityToDelete));
                }

                string result = await _movieRepository.DeleteDvdAsync(id, quantityToDelete);

                return result;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Invalid quantity provided.", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException("The specified DVD or inventory does not exist.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Error processing the deletion request. Not enough copies available.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while attempting to delete DVD copies.", ex);
            }
        }


        public async Task<ICollection<Movie>> GetAllDvdsAsync()
        {
            var moviesData = await _movieRepository.GetAllDvdsAsync();
            return moviesData;
        }

    }


}

