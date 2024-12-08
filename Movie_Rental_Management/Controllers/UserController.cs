using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserservice _userService;
        public UserController(IUserservice authService , AppDbContext context)
        {
            _userService = authService;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRequestDTO user)
        {
            try
            {
                var result = await _userService.Register(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var result = await _userService.Login(loginRequest.Email, loginRequest.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("check")]
        public async Task<IActionResult> CheckAPI()
        {
            try
            {
                var role = User.FindFirst("Role").Value;
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,               
                    u.Nic,
                    u.Phone,
                    u.Role,
                    u.PasswordHash,

                })
                .ToListAsync();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetUser(Guid id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email,              
                    u.Nic,
                    u.Phone,
                    u.Role,
                    u.PasswordHash,

                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }





    }
}
