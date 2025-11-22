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
        var exists = await _db.Destinations.AnyAsync(p => p.Id == dest.Id);
        if (exists)
            return false;
        
        if (string.IsNullOrEmpty(dest.Name))
            return false;
        
        if (dest.Name.Length > 50)
            return false;
        
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
        var dest = await _db.Destinations.FindAsync(id);
        if (dest == null) 
            return false;
        
        _db.Destinations.Remove(dest);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }

    public async Task<bool> Update(int id, Destination uDest)
    {
        if (string.IsNullOrEmpty(uDest.Name))
            return false;
        
        if (uDest.Name.Length > 50)
            return false;
        
        var dest = await _db.Destinations.FindAsync(id);
        if (dest == null)
            return false;
        
        dest.Name = uDest.Name;
        _db.Destinations.Update(dest);
        var i = await _db.SaveChangesAsync();
        return i > 0;
    }
}