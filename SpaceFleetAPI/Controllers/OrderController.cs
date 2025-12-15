using Microsoft.AspNetCore.Mvc;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransportOrderController : ControllerBase
{
    private readonly IOrderService _s;

    public TransportOrderController(IOrderService s)
    {
        _s = s;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _s.ReadAll();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var order = await _s.ReadOne(id);
        if (order == null) 
            return NotFound();
        
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TransportOrder order)
    {
        var ok = await _s.Create(order);
        if (!ok) 
            return BadRequest("Could not create transport order");

        return CreatedAtAction(nameof(GetOne), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TransportOrder order)
    {
        var ok = await _s.Update(id, order);
        if (!ok) 
            return BadRequest("Could not update transport order");
        
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _s.Delete(id);
        if (!ok) 
            return NotFound("Could not delete transport order");
        
        return Ok("Deleted");
    }
    
    [HttpPost("{id}/complete")]
    public async Task<IActionResult> CompleteOrder(int id)
    {
        var ok = await _s.CompleteOrder(id);
        if (!ok) 
            return BadRequest("Could not complete transport order or already finished");

        var order = await _s.ReadOne(id);
        return Ok(order);
    }
}