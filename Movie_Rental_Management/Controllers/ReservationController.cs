using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IService;

namespace Movie_Rental_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
            private readonly IReservationService _service;

            public ReservationController(IReservationService service)
            {
                _service = service;
            }

            [HttpPost("add")]
            public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdReservation = await _service.AddReservationAsync(reservation);
                return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllReservations()
            {
                var reservations = await _service.GetAllReservationsAsync();
                return Ok(reservations);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetReservationById(Guid id)
            {
                var reservation = await _service.GetReservationByIdAsync(id);
                if (reservation == null)
                    return NotFound($"Reservation with ID {id} not found.");

                return Ok(reservation);
            }

            [HttpGet("user/{userId}")]
            public async Task<IActionResult> GetReservationsByUser(Guid userId)
            {
                var reservations = await _service.GetReservationsByUserAsync(userId);
                return Ok(reservations);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReservation(Guid id)
            {
                try
                {
                    var result = await _service.DeleteReservationAsync(id);
                    return result ? Ok() : NotFound($"Reservation with ID {id} not found.");
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
        }

    }

