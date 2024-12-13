using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;

namespace Movie_Rental_Management.Service
{

    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            return await _repository.AddReservationAsync(reservation);
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _repository.GetAllReservationsAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            var reservation = await _repository.GetReservationByIdAsync(id);
            if (reservation == null)
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");

            return reservation;
        }

        public async Task<List<Reservation>> GetReservationsByUserAsync(Guid userId)
        {
            return await _repository.GetReservationsByUserAsync(userId);
        }

        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            return await _repository.DeleteReservationAsync(id);
        }
    }

}

