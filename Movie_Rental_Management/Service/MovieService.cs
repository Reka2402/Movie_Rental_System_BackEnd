using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.Service
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository dvdRepository)
        {
            _movieRepository = dvdRepository;
        }

        public async Task AddDVDAsync(MovieRequestDTO dvdDto)
        {
            var dvd = new Movie
            {
                Id = Guid.NewGuid(),
                MovieName = dvdDto.MovieName,
                directorId = dvdDto.DirectorId,
                GenreId = dvdDto.GenreId,
                ReleaseDate = dvdDto.ReleaseDate,
                Price = dvdDto.Price,
                Description = dvdDto.Description,
                ImageUrl = dvdDto.ImageUrl
            };
            await _movieRepository.AddDVDAsync(dvd);
        }

        public async Task UpdateDVDAsync(MovieRequestDTO dvdDto)
        {
            var dvd = new Movie
            {
                Id = dvdDto.Id,
                MovieName = dvdDto.MovieName,
                directorId = dvdDto.DirectorId,
                GenreId = dvdDto.GenreId,
                ReleaseDate = dvdDto.ReleaseDate,
                Price = dvdDto.Price,
                Description = dvdDto.Description,
                ImageUrl = dvdDto.ImageUrl
            };
            await _movieRepository.UpdateDVDAsync(dvd);
        }

        public async Task DeleteDVDAsync(Guid id)
        {
            await _movieRepository.DeleteDVDAsync(id);
        }

        public async Task<MovieResponseDTO> GetDVDByIdAsync(Guid id)
        {
            var dvd = await _movieRepository.GetDVDByIdAsync(id);
            if (dvd == null) return null;

            return new MovieResponseDTO
            {
                Id = dvd.Id,
                MovieName = dvd.MovieName,
                DirectorName = dvd.director?.DirectorName,
                GenreName = dvd.Genre?.Name,
                ReleaseDate = dvd.ReleaseDate,
                Price = dvd.Price,
                Description = dvd.Description,
                ImageUrl = dvd.ImageUrl
            };
        }

    }
}
