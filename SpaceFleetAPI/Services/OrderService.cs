using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public class OrderService : IOrderService
{
    private readonly SpaceFleetDbContext _db;

    public OrderService(SpaceFleetDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(TransportOrder order)
    {
        if (await _db.TransportOrders.AnyAsync(p => p.Id == order.Id))
            return false;
        
        if (!await _db.Ships.AnyAsync(p => p.Id == order.ShipId))
            return false;
        
        if (!await _db.Pilots.AnyAsync(p => p.Id == order.PilotId))
            return false;
        
        if (!await _db.Destinations.AnyAsync(p => p.Id == order.DestinationId))
            return false;
        
        if (await _db.TransportOrders.AnyAsync(p => p.PilotId == order.PilotId && !p.Finished))
            return false;
        
        if (await _db.TransportOrders.AnyAsync(p => p.ShipId == order.ShipId && !p.Finished))
            return false;
        
        _db.TransportOrders.Add(order);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }

    public async Task<TransportOrder?> ReadOne(int id)
    {
        return await _db.TransportOrders.FindAsync(id);
    }

    public async Task<List<TransportOrder>> ReadAll()
    {
        return await _db.TransportOrders.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var order  = await _db.TransportOrders.FindAsync(id);
        if (order == null)
            return false;
        
        _db.TransportOrders.Remove(order);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }

    public async Task<bool> Update(int id, TransportOrder uOrder)
    {
        var order = await _db.TransportOrders.FindAsync(id);
        if (order == null)
            return false;
        
        if (!await _db.TransportOrders.AnyAsync(p => p.Id == order.Id))
            return false;
        
        if (!await _db.Ships.AnyAsync(p => p.Id == order.ShipId))
            return false;
        
        if (!await _db.Pilots.AnyAsync(p => p.Id == order.PilotId))
            return false;
        
        if (!await _db.Destinations.AnyAsync(p => p.Id == order.DestinationId))
            return false;

        if (await _db.TransportOrders.AnyAsync(p => p.PilotId == order.PilotId && !p.Finished && p.Id != id))
            return false;
        
        if (await _db.TransportOrders.AnyAsync(p => p.ShipId == order.ShipId && !p.Finished &&  p.Id != id))
            return false;
        
        order.DestinationId = uOrder.DestinationId;
        order.PilotId = uOrder.PilotId;
        order.ShipId = uOrder.ShipId;
                
        order.Finished = uOrder.Finished;
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }
    
    public async Task<bool> CompleteOrder(int id)
    {
        var order = await _db.TransportOrders.FindAsync(id);
        if (order == null) 
            return false;

        if (order.Finished) 
            return false;

        order.Finished = true;
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }
}