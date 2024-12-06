using Movie_Rental_Management.Entities;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.IService
{
    public interface IRentalService
    {
        Task<RentalResponseModel> AddRental(Guid CustomerId,Guid MovieId, RentalrequestModel rentalrequestModel);
        Task<List<RentalResponseModel>> GetAllRentals();
        Task<RentalResponseModel> GetById(Guid Id);
        Task<RentalResponseModel> GetByUserID(Guid UserId);
        Task<RentalResponseModel> UpdateRent(Guid Id, RentalrequestModel rentalrequestModel);
    }
}
