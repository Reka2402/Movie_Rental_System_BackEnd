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

        public async Task<Rent> GetRentalById(Guid id)
        {
            return await _context.Rents.Include(r => r.Movie).Include(r => r.user).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateRental(Rent rental)
        {
            _context.Rents.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRental(Rent rental)
        {
            _context.Rents.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRental(Guid id)
        {
            var rental = await _context.Rents.FindAsync(id);
            if (rental != null)
            {
                _context.Rents.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rent>> GetRentalsByCustomerId(Guid customerId)
        {
            return await _context.Rents
                                 .Where(r => r.userId == customerId)
                                 .Include(r => r.Movie)
                                 .Include(r => r.user)
                                 .ToListAsync();
        }
       


















        //public async Task<Rent> RentalAccept(Guid rentalId)
        //{
        //    // Fetch the rental record
        //    var rental = await GetRentalById(rentalId);
        //    if (rental == null) throw new Exception("Rental not found");

        //    // Update rental status
        //    rental.Status = "Rent";
        //    rental.Isoverdue = false;

        //    // Fetch the related DVD and update copies available
        //    var dvd = await _context.Movies.FirstOrDefaultAsync(d => d.Id == rental.MovieId);
        //    if (dvd == null) throw new Exception("DVD not found");

        //    if (dvd.TotalCopies > 0)
        //    {
        //        dvd.TotalCopies--; // Decrement copies available
        //    }
        //    else
        //    {
        //        throw new Exception("No copies available for the selected DVD");
        //    }

        //    // Save changes to database
        //    await _context.SaveChangesAsync();

        //    return rental;
        //}
        ////public async Task<Rent> UpdateRental(Rent rental)
        ////{
        ////    _context.Rents.Update(rental);
        ////    await _context.SaveChangesAsync();
        ////    return rental;
        ////}
        //public async Task<int> GetAcceptedRentalsCount()
        //{
        //    return await _context.Rents.CountAsync(r => r.Status == "Rent");
        //}
        //public async Task<Rent> RejectRental(Rent rental)
        //{
        //    rental.Status = "Rejected"; // Only update rental status
        //    await _context.SaveChangesAsync(); // Save changes to the database
        //    return rental;
        //}
        //public async Task<List<Rent>> CheckAndUpdateOverdueRentals()
        //{

        //    var overdue = await _context.Rents.Where(r => r.Isoverdue == true).ToListAsync();
        //    //foreach (var rent in overdue)
        //    //{
        //    //    rent.Isoverdue = true;

        //    //}

        //    //await _dbContext.SaveChangesAsync();
        //    return overdue;


        //}

        //public async Task<int> GetReturnedRentalsCount()
        //{
        //    return await _context.Rents.CountAsync(r => r.Status == "Returned");
        //}

        //public async Task<int> GetRejectedRentalsCount()
        //{
        //    return await _context.Rents.CountAsync(r => r.Status == "Rejected");
        //}
        //public async Task IncrementDVDQuantity(int dvdId)
        //{
        //    var dvd = await _context.Movies.FindAsync(dvdId);
        //    if (dvd != null)
        //    {
        //        dvd.TotalCopies += 1;
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<IEnumerable<Rent>> GetAllRentals()
        //{
        //    return await _context.Rents.Include(r => r.Movie).Include(r => r.user).ToListAsync();
        //}



    }
}
