using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IService
{

    public interface IReservationService
    {
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<List<Reservation>> GetReservationsByUserAsync(Guid userId);
        Task<bool> DeleteReservationAsync(Guid id);
    }

}

