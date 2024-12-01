using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.IService
{
    public interface IRentalService
    {
        Rent GetRentById(Guid id);
        IEnumerable<Rent> GetAllRents();
        IEnumerable<Rent> GetManagerDashboardData();
        void SendRentalRequest(Rent rent);
        void ApproveRental(Guid rentId);
        void MarkAsReturned(Guid rentId);
    }
}
