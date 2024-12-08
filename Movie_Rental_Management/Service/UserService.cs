using Microsoft.IdentityModel.Tokens;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movie_Rental_Management.Service
{
    public class UserService : IUserservice
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<string> Register(UserRequestDTO userRequest)
        {
            var req = new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Role = userRequest.Role,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                Nic = userRequest.Nic,
                Phone = userRequest.Phone,
            };
            var user = await _userRepository.AddUser(req);
            var token = CreateToken(user);
            return token;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Wrong password.");
            }
            return CreateToken(user);
        }


        private string CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("Id", user.Id.ToString()));
            claimsList.Add(new Claim("Name", user.Name));
            claimsList.Add(new Claim("Email", user.Email));
            claimsList.Add(new Claim("Nic", user.Nic));
            claimsList.Add(new Claim("Phone", user.Phone));
            claimsList.Add(new Claim("Role", user.Role.ToString()));


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        //public async Task<string> SignUp(SignUpRequestDTO request)
        //{
        //    var nicCheck = await _userRepository.GetCustomerByNIC(request.NIC);
        //    var emailCheck = await _userRepository.GetUserByEmail(request.Email);
        //    if (nicCheck == null)
        //    {
        //        if (emailCheck == null)
        //        {
        //            var user = new User()
        //            {
        //                Email = request.Email,
        //                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        //            };
        //            var userData = await _userRepository.AddUser(user);
        //            var roleData = await _userRepository.GetRoleByName("Customer");
        //            if(roleData == null)
        //            {
        //                throw new Exception("Role Not found");
        //            }
        //            var userRole = new UserRole()
        //            {
        //                UserId = userData.Id,
        //                RoleId = roleData.Id
        //            };
        //            var userRoleData = await _userRepository.AddUserRole(userRole);
        //            var customer = new Customer()
        //            {
        //                Id = userData.Id,
        //                NIC = request.NIC,
        //                Email = request.Email,
        //                FirstName = request.FirstName,
        //                LastName = request.LastName,
        //                MobileNumber = request.MobileNumber,
        //                JoinDate = DateTime.Now,
        //                IsActive =true,

        //            };
        //            var customerData = await _userRepository.SignUp(customer);
        //            return "SignUp Successfully";
        //        }
        //        else
        //        {
        //            throw new Exception("Email already used");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("NIC already used");
        //    }
        //}

    }
}
