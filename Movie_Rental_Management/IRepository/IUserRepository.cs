using Movie_Rental_Management.Entities;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.IRepository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> Login(LoginRequestModel request);
    }
}
