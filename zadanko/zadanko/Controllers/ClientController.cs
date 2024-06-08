using Microsoft.AspNetCore.Mvc;
using zadanko.DTO;
using zadanko.Services;

namespace zadanko.Controllers;

[Route("api/client/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetClient(int id)
    {
        try
        {
            ClientDTO client = await _service.GetClient(id);
            return Ok(client);
        }
        catch (NullReferenceException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}