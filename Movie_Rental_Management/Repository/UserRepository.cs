using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;

namespace Movie_Rental_Management.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dBContext;

        public UserRepository(AppDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Customer> SignUp(Customer customer)
        {
            var customerData = await _dBContext.Customers.AddAsync(customer);
            await _dBContext.SaveChangesAsync();
            return customerData.Entity;
        }
        public async Task<User> AddUser(User user)
        {
            var userData = await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return userData.Entity;
        }
        public async Task<Role> GetRoleByName(string name)
        {
           var roleData = await _dBContext.Roles.SingleOrDefaultAsync(r => r.Name == name);
            return roleData!;
        }
        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            var userRoleData = await _dBContext.UserRoles.AddAsync(userRole);
            await _dBContext.SaveChangesAsync();
            return userRoleData.Entity;
        }
        public async Task<Customer>GetCustomerByNIC(string nic)
        {
            var customerData = await _dBContext.Customers.SingleOrDefaultAsync(c => c.NIC.ToLower() == nic.ToLower());
            return customerData!;   
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var userData = await _dBContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            return userData!;
        }
        public async Task<Role> GetRoleById (Guid Id)
        {
            var roleData = await _dBContext.Roles.SingleOrDefaultAsync(r => r.Id == Id);
            return roleData!;
        }


    }
}
