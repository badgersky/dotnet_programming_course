using Microsoft.AspNetCore.Mvc;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationController : ControllerBase
{
    private readonly IDestinationService _s;

    public DestinationController(IDestinationService s)
    {
        _s = s;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var destinations = await _s.ReadAll();
        return Ok(destinations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var dest = await _s.ReadOne(id);
        if (dest == null) 
            return NotFound();
        
        return Ok(dest);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Destination dest)
    {
        var ok = await _s.Create(dest);
        if (!ok) 
            return BadRequest("Could not create destination");

        return CreatedAtAction(nameof(GetOne), new { id = dest.Id }, dest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Destination dest)
    {
        var ok = await _s.Update(id, dest);
        if (!ok) 
            return BadRequest("Could not update destination");
        
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _s.Delete(id);
        if (!ok) return NotFound("Could not delete destination");
        
        return Ok("Deleted");
    }
}