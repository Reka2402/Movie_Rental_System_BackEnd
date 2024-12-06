using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IRentalRepository
    {

        Task<Rent> AddRental(Rent rent);
        Task<List<Rent>> GetAllRentals();
        Task<Rent> GetById(Guid Id);
        Task<Rent> GetByUserID(Guid UserId);
        Task<Rent> UpdateRent(Rent rent);

    }
}
