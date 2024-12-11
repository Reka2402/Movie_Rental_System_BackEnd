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
          
            var data = await _context.Rents.Include(d => d.user).Include(d => d.Movie).ToListAsync();
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




        //public async Task<IEnumerable<Rent>> GetAllRentals()
        //{
        //    return await _context.Rents.Include(r => r.Movie).Include(r => r.Customer).ToListAsync();
        //}

        //public async Task<Rent> GetRentalById(Guid id)
        //{
        //    return await _context.Rents.Include(r => r.Movie).Include(r => r.Customer).FirstOrDefaultAsync(r => r.Id == id);
        //}

        //public async Task CreateRental(Rent rental)
        //{
        //    _context.Rents.Add(rental);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateRental(Rent rental)
        //{
        //    _context.Rents.Update(rental);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteRental(Guid id)
        //{
        //    var rental = await _context.Rents.FindAsync(id);
        //    if (rental != null)
        //    {
        //        _context.Rents.Remove(rental);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<IEnumerable<Rent>> GetRentalsByCustomerId(Guid customerId)
        //{
        //    return await _context.Rents
        //                         .Where(r => r.CustomerId == customerId)
        //                         .Include(r => r.DVD)
        //                         .Include(r => r.Customer)
        //                         .ToListAsync();
        //}



    }
}
