using Microsoft.AspNetCore.Mvc;
using zadanko.DTO;
using zadanko.Models;
using zadanko.Services;

namespace zadanko.Controllers;

[Route("api/reservation/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _service;

    public ReservationController(IReservationService service)
    {
        _service = service;
    }

    public async Task<IActionResult> AddReservation(ReservationDTO reservation)
    {
        try
        {
            _service.AddReservation(reservation);
        }
        catch (NullReferenceException e)
        {
            return (NotFound(e));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Created();
    } 
}