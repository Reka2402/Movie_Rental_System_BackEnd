using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Repository;
using static Movie_Rental_Management.Entities.Rent;

namespace Movie_Rental_Management.Service
{
    public class RentalService: IRentalService
    {

        private readonly IRentalRepository _rentRepository;
        private readonly IMovieRepository _movieRepository;

        public RentalService(IRentalRepository rentRepository, IMovieRepository movieRepository)
        {
            _rentRepository = rentRepository;
            _movieRepository = movieRepository;
        }
        public Rent GetRentById(Guid id)
        {
            return _rentRepository.GetById(id);
        }

        public IEnumerable<Rent> GetAllRents()
        {
            return _rentRepository.GetAll();
        }

        public IEnumerable<Rent> GetManagerDashboardData()
        {
            return _rentRepository.GetAllForManagerDashboard();
        }

        public void SendRentalRequest(Rent rent)
        {
            
            var movie = _rentRepository.GetById(rent.MovieId);

            if (movie == null)
                throw new Exception("Movie not found.");

          
            rent.TotalAmount = movie.initialPrice * rent.RentalDays;  

            rent.Id = Guid.NewGuid();
            rent.RequestedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            rent.Status = RentStatus.Pending;

            _rentRepository.Add(rent);
        }

        public void ApproveRental(Guid rentId)
        {
            var rent = _rentRepository.GetById(rentId);
            if (rent != null && rent.Status == RentStatus.Pending)
            {
                rent.ApporovedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                rent.Rentaldate = DateOnly.FromDateTime(DateTime.UtcNow);
                rent.Status = RentStatus.Rented;

                _rentRepository.Update(rent);
            }
        }

        public void MarkAsReturned(Guid rentId)
        {
            var rent = _rentRepository.GetById(rentId);
            if (rent != null && rent.Status == RentStatus.Rented)
            {
                rent.ReturnDate = DateOnly.FromDateTime(DateTime.UtcNow);
                rent.Status = RentStatus.Returned;

                _rentRepository.Update(rent);
            }
        }
    }
}
