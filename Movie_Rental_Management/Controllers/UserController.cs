using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserservice _userService;
        public UserController(IUserservice authService)
        {
            _userService = authService;
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
        [HttpGet]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var result = await _userService.Login(email, password);
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


    }
}
