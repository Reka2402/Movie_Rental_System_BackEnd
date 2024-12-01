using Microsoft.EntityFrameworkCore;
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
        public Rent GetById(Guid id)
        {
            return _context.Rents
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Rent> GetAll()
        {
            return _context.Rents
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .ToList();
        }

        public IEnumerable<Rent> GetAllForManagerDashboard()
        {
            return _context.Rents
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Where(r => r.Status != Rent.RentStatus.Pending)
                .ToList();
        }

        public void Add(Rent rent)
        {
            _context.Rents.Add(rent);
            _context.SaveChanges();
        }

        public void Update(Rent rent)
        {
            _context.Rents.Update(rent);
            _context.SaveChanges();
        }


    }
}
