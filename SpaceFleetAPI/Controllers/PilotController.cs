using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PilotController : ControllerBase
{
    private readonly IPilotService _s;

    public PilotController(IPilotService s)
    {
        _s = s;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pilots = await _s.ReadAll();
        return Ok(pilots);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var pilot = await _s.ReadOne(id);
        if  (pilot == null)
            return NotFound();
        
        return Ok(pilot);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pilot pilot)
    {
        var ok = await _s.Create(pilot);
        if (!ok)
            return BadRequest("Could not create pilot");
        
        return CreatedAtAction(nameof(GetOne), new { id = pilot.Id }, pilot);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Pilot pilot)
    {
        var ok = await _s.Update(id, pilot);
        if (!ok)
            return NotFound("Could not update pilot");
        
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _s.Delete(id);
        if (!ok)
            return NotFound("Could not delete pilot");
        
        return Ok("Deleted");
    }
}