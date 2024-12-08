using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;
using Movie_Rental_Management.Service;

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
        [HttpPost("Add_Rental")]        
        
       public async Task <IActionResult> AddRental( RentalrequestModel rentalrequestModel)
        {
            var data = await _rentService.AddRental(rentalrequestModel);
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

        //[HttpGet]
        //public async Task<IActionResult> GetAllRentals()
        //{
        //    var rentals = await _rentalService.GetAllRentals();
        //    return Ok(rentals);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRentalById(Guid id)
        //{
        //    var rental = await _rentalService.GetRentalById(id);
        //    if (rental == null) return NotFound();
        //    return Ok(rental);
        //}

        //[HttpPost("request")]
        //public async Task<IActionResult> RequestRental([FromBody] CreateRentalDto rental)
        //{
        //    try
        //    {
        //        await _rentalService.RequestRental(rental);
        //        return Ok(new { message = "Rental request submitted successfully." });
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        // Return 404 Not Found if the customer is not found
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        // General error handling
        //        return StatusCode(500, new { message = "An error occurred while processing the request.", details = ex.Message });
        //    }
        //}


        //[HttpPut("approve/{id}")]
        //public async Task<IActionResult> ApproveRental(Guid id)
        //{
        //    await _rentalService.ApproveRental(id);
        //    return Ok();
        //}

        //[HttpPut("collect/{id}")]
        //public async Task<IActionResult> CollectRental(Guid id)
        //{
        //    await _rentalService.CollectRental(id);
        //    return Ok();
        //}

        //[HttpPut("return/{id}")]
        //public async Task<IActionResult> ReturnRental(Guid id)
        //{
        //    await _rentalService.ReturnRental(id);
        //    return Ok();
        //}

        //[HttpPut("reject/{id}")]
        //public async Task<IActionResult> RejectRental(Guid id)
        //{
        //    await _rentalService.RejectRental(id);
        //    return Ok();
        //}

        //[HttpGet("customer/{customerId}")]
        //public async Task<IActionResult> GetRentalsByCustomerId(Guid customerId)
        //{
        //    var rentals = await _rentalService.GetRentalsByCustomerId(customerId);
        //    if (rentals == null || rentals.Count == 0)
        //    {
        //        return NotFound(new { message = "No rentals found for this customer." });
        //    }
        //    return Ok(rentals);
        //}
    }
}


