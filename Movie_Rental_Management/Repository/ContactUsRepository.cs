using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AppDbContext _dbContext;

        public ContactUsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactUs> AddAsync(ContactUs contact)
        {
            _dbContext.ContactUs.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }
    }
}
