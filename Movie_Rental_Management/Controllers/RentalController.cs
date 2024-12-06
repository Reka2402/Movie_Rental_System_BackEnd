using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
         
        private readonly IRentalService _rentService;

        public RentalController(IRentalService rentService)
        {
            _rentService = rentService;
        }
        [HttpPost("Add_Rendal")]        
        
       public async Task <IActionResult> AddRental(Guid CustomerId,Guid MovieId, RentalrequestModel rentalrequestModel)
        {
            var data = await _rentService.AddRental(CustomerId,MovieId, rentalrequestModel);
            return Ok(data);
        }

        [HttpGet("Get_All_Rentals")]
        public async Task<IActionResult> GetAllRentals()
        {
            var data = await _rentService.GetAllRentals();
            return Ok(data);
        }

        [HttpGet("Get_By_Id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var data = await _rentService.GetById(Id);
            return Ok(data);
        }

        [HttpGet("Get_By_UserId")]
        public async Task<IActionResult> GetByUserID(Guid UserId)
        {
            var data = await _rentService.GetByUserID(UserId);
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRent(Guid Id, RentalrequestModel rentalrequestModel)
        {
            var data = await _rentService.UpdateRent(Id, rentalrequestModel);
            return Ok(data);
        }
    }
}

