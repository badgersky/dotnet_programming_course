using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Extensions;

public static class OrderServiceExtensions
{
    public static async Task<List<TransportOrder>> GetOrdersByPilotId(
        this IOrderService service, SpaceFleetDbContext db, int pilotId)
    {
        return await db.TransportOrders
            .Where(o => o.PilotId == pilotId)
            .ToListAsync();
    }

    public static async Task<List<TransportOrder>> GetOrdersByShipId(
        this IOrderService service, SpaceFleetDbContext db, int shipId)
    {
        return await db.TransportOrders
            .Where(o => o.ShipId == shipId)
            .ToListAsync();
    }

    public static async Task<List<TransportOrder>> GetOrdersByDestinationId(
        this IOrderService service, SpaceFleetDbContext db, int destinationId)
    {
        return await db.TransportOrders
            .Where(o => o.DestinationId == destinationId)
            .ToListAsync();
    }
}