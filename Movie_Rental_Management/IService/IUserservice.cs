using Movie_Rental_Management.Entities;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.IService
{
    public interface IUserservice
    {
        Task<string> Register(UserRequestDTO userRequest);
        Task<string> Login(string email, string password);
    }
}
