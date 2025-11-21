using Microsoft.AspNetCore.Mvc;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController : ControllerBase
{
    private readonly IShipService _s;

    public ShipController(IShipService s)
    {
        _s = s;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ships = await _s.ReadAll();
        return Ok(ships);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var ship = await _s.ReadOne(id);
        if (ship == null)
            return NotFound();
        
        return Ok(ship);
    }

    [HttpPost("local")]
    public async Task<IActionResult> PostLocal([FromBody] LocalSystemShip ship)
    {
        var ok = await _s.Create(ship);
        if (!ok) 
            return BadRequest("Could not create local ship");

        return CreatedAtAction(nameof(GetOne), new { id = ship.Id }, ship);
    }

    [HttpPost("remote")]
    public async Task<IActionResult> PostRemote([FromBody] RemoteSystemShip ship)
    {
        var ok = await _s.Create(ship);
        if (!ok) 
            return BadRequest("Could not create remote ship");

        return CreatedAtAction(nameof(GetOne), new { id = ship.Id }, ship);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Ship ship)
    {
        var ok = await _s.Update(id, ship);
        if (!ok)
            return BadRequest("Could not update ship");
        
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _s.Delete(id);
        if (!ok)
            return NotFound("Could not delete ship");
        
        return Ok("Deleted");
    }
}