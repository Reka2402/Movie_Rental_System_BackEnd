using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.Service
{
    public class UserService : IUserservice
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> SignUp(SignUpRequestDTO request)
        {
            var nicCheck = await _userRepository.GetCustomerByNIC(request.NIC);
            var emailCheck = await _userRepository.GetUserByEmail(request.Email);
            if (nicCheck == null)
            {
                if (emailCheck == null)
                {
                    var user = new User()
                    {
                        Email = request.Email,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
                    };
                    var userData = await _userRepository.AddUser(user);
                    var roleData = await _userRepository.GetRoleByName("Customer");
                    if(roleData == null)
                    {
                        throw new Exception("Role Not found");
                    }
                    var userRole = new UserRole()
                    {
                        UserId = userData.Id,
                        RoleId = roleData.Id
                    };
                    var userRoleData = await _userRepository.AddUserRole(userRole);
                    var customer = new Customer()
                    {
                        Id = userData.Id,
                        NIC = request.NIC,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        MobileNumber = request.MobileNumber,
                        JoinDate = DateTime.Now,
                        IsActive =true,

                    };
                    var customerData = await _userRepository.SignUp(customer);
                    return "SignUp Successfully";
                }
                else
                {
                    throw new Exception("Email already used");
                }
            }
            else
            {
                throw new Exception("NIC already used");
            }
        }

    }
}
