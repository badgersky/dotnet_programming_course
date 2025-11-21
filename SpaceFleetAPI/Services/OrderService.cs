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

        if (await _db.Destinations.AnyAsync(x => x.Id == uOrder.DestinationId))
            order.DestinationId = uOrder.DestinationId;
        if (await _db.Pilots.AnyAsync(x => x.Id == uOrder.PilotId))
            order.PilotId = uOrder.PilotId;
        if (await _db.Ships.AnyAsync(x => x.Id == uOrder.ShipId))
            order.ShipId = uOrder.ShipId;
                
        order.Finished = uOrder.Finished;
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }
}