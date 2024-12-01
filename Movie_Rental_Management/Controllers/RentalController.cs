using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;

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

        // Send a rental request
        [HttpPost("request")]
        public IActionResult SendRentalRequest([FromBody] Rent rent)
        {
            _rentService.SendRentalRequest(rent);
            return Ok("Rental request sent successfully.");
        }

        // Approve a rental request
        [HttpPut("approve/{id}")]
        public IActionResult ApproveRental(Guid id)
        {
            var rent = _rentService.GetRentById(id);
            if (rent == null)
                return NotFound("Rental request not found.");

            _rentService.ApproveRental(id);
            return Ok("Rental request approved.");
        }

        // Mark as returned
        [HttpPut("return/{id}")]
        public IActionResult MarkAsReturned(Guid id)
        {
            var rent = _rentService.GetRentById(id);
            if (rent == null)
                return NotFound("Rental not found.");

            _rentService.MarkAsReturned(id);
            return Ok("Rental marked as returned.");
        }

        // Get all rentals
        [HttpGet]
        public IActionResult GetAllRents()
        {
            return Ok(_rentService.GetAllRents());
        }

        // Get manager dashboard data
        [HttpGet("dashboard")]
        public IActionResult GetManagerDashboardData()
        {
            return Ok(_rentService.GetManagerDashboardData());
        }
    }
}

