using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IReservationRepository
    {
        
        Task<List<Reservation>> GetReservationsByUserAsync(Guid userId);
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(Guid id);
        Task<Reservation> GetReservationByIdAsync(Guid id);
    }
}
