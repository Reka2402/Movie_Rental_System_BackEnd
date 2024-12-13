using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Movie)
                .ToListAsync();
        }
        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            return await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<List<Reservation>> GetReservationsByUserAsync(Guid userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Movie)
                .ToListAsync();
        }
        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
