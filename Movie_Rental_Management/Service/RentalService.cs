using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;
using System.Threading.Tasks;

namespace Movie_Rental_Management.Service
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentRepository;
        private readonly IMovieRepository _movieRepository;
      

        public RentalService(IRentalRepository rentRepository, IMovieRepository movieRepository)
        {
            _rentRepository = rentRepository;
            _movieRepository = movieRepository;
         
        }

        public async Task<RentalResponseModel> AddRental(Guid userId,Guid MovieId, RentalrequestModel rentalrequestModel)
        {
           
            var movie = await _movieRepository.GetDvdByIdAsync(MovieId);

            var rental = new Rent
            {
                Id = Guid.NewGuid(),
               userId= userId,
                initialPrice = movie.Price,
                MovieId = MovieId,
                RequestedDate = DateTime.UtcNow,
                ApporovedDate = rentalrequestModel.ApporovedDate,
                RentalDate = rentalrequestModel.RentalDate,
                ReturnDate = rentalrequestModel.ReturnDate,
                RentalDays = (rentalrequestModel.ReturnDate - rentalrequestModel.RentalDate).Days,  
                TotalAmount = rentalrequestModel.TotalAmount,
                Isoverdue = rentalrequestModel.Isoverdue,
                Status = rentalrequestModel.Status
            };

            var data = await _rentRepository.AddRental(rental);

            var response = new RentalResponseModel
            {
                Id = data.Id,
               userId = data.userId, 
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"), 
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;
        }

        public async Task<List<RentalResponseModel>> GetAllRentals()
        {
            var data = await _rentRepository.GetAllRentals();

            var responce = data.Select(a => new RentalResponseModel
            {
                Id = a.Id,
                userId = a.userId,
                initialPrice = a.initialPrice,
                MovieId = a.MovieId,
                RequestedDate = a.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = a.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = a.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = a.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = a.RentalDays,
                TotalAmount = a.TotalAmount,
                Isoverdue = a.Isoverdue,
                Status = a.Status.ToString()

            }).ToList();
            return responce;
        }

        public async Task<RentalResponseModel> GetById(Guid Id)
        {
            var data = await _rentRepository.GetById(Id);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;
        }

        public async Task<RentalResponseModel> GetByUserID(Guid UserId)
        {
            var data = await _rentRepository.GetByUserID(UserId);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;
        }

        public async Task<RentalResponseModel> UpdateRent(Guid Id ,RentalrequestModel rentalrequestModel)
        {
            var rental = await _rentRepository.GetById(Id);
            if (rental == null) return null;

            rental.ApporovedDate = DateTime.Now;
            rental.Status = RentStatus.Approved;

            var data = await _rentRepository.UpdateRent(rental);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;

        }


    }
}
