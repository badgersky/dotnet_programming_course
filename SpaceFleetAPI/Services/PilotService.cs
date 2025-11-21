using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public class PilotService : IPilotService
{
    private readonly SpaceFleetDbContext _db;

    public PilotService(SpaceFleetDbContext db)
    {
        _db = db;
    }


    public async Task<bool> Create(Pilot pilot)
    {
        _db.Add(pilot);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Pilot?> ReadOne(int id)
    {
        return await _db.Pilots.FindAsync(id);;
    }

    public async Task<List<Pilot>> ReadAll()
    {
        return await _db.Pilots.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var pilot = await _db.Pilots.FindAsync(id);
        if (pilot == null)
            return false;
        
        _db.Remove(pilot);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, Pilot uPilot)
    {
        var pilot = await _db.Pilots.FindAsync(id);
        if (pilot == null)
            return false;
        
        pilot.Name = uPilot.Name;
        await _db.SaveChangesAsync();
        return true;
    }
}