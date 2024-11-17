using Movie_Rental_Management.Entities;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.IRepository
{
    public interface IUserRepository
    {
        Task<Customer> SignUp(Customer customer);
        Task<Role> GetRoleById(Guid Id);
        Task<User> GetUserByEmail(string email);
        Task<Customer> GetCustomerByNIC(string nic);
        Task<UserRole> AddUserRole(UserRole userRole);
        Task<Role> GetRoleByName(string name);
        Task<User> AddUser(User user);

    }
}
