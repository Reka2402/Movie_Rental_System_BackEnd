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

            public UserController(IUserservice userService)
            {
                _userService = userService;
            }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpRequestDTO request)
        {
            try
            {
                var data = await _userService.SignUp(request);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    }
