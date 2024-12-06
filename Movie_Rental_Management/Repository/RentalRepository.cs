using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rent> AddRental(Rent rent)
        {
            var data = await _context.Rents.AddAsync(rent);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<Rent>> GetAllRentals()
        {
            var data = await _context.Rents.ToListAsync();
            return data;
        }

        public async Task<Rent> GetById(Guid Id)
        {
            var data = await _context.Rents.FirstOrDefaultAsync(rent => rent.Id == Id);
            return data;
        }
        public async Task<Rent> GetByUserID(Guid UserId)
        {
            var data = await _context.Rents.FirstOrDefaultAsync(a => a.userId == UserId);
            return data;
        }

        public async Task<Rent> UpdateRent(Rent rent)
        {
            var data = await GetById(rent.Id);
            if (data == null) return null;
            
            data.Status = rent.Status;
            _context.Rents.Update(rent);
            await _context.SaveChangesAsync();
            return data;


        }
        
      

    }
}
