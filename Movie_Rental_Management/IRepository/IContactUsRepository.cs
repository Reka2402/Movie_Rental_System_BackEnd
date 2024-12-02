using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IContactUsRepository
    {
        Task<ContactUs> AddAsync(ContactUs contact);
    }
}
