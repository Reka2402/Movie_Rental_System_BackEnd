using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IRepository
{
    public interface IRentalRepository
    {
        Rent GetById(Guid id);
        IEnumerable<Rent> GetAll();
        IEnumerable<Rent> GetAllForManagerDashboard();
        void Add(Rent rent);
        void Update(Rent rent);

    }
}
