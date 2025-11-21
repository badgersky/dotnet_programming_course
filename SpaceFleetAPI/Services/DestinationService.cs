using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public class DestinationService : IDestinationService
{
    private readonly SpaceFleetDbContext _db;

    public DestinationService(SpaceFleetDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Destination dest)
    {
        _db.Destinations.Add(dest);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }

    public async Task<Destination?> ReadOne(int id)
    {
        return await _db.Destinations.FindAsync(id);
    }

    public async Task<List<Destination>> ReadAll()
    {
        return await _db.Destinations.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var ship = await _db.Ships.FindAsync(id);
        if (ship == null) 
            return false;
        
        _db.Ships.Remove(ship);
        var i = await _db.SaveChangesAsync();
        return i > 0;    
    }

    public async Task<bool> Update(int id, Destination uDest)
    {
        var dest = await _db.Destinations.FindAsync(id);
        if (dest == null)
            return false;
        
        dest.Name = uDest.Name;
        _db.Destinations.Update(dest);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }
}