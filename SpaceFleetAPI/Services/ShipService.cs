using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public class ShipService : IShipService
{
    private readonly SpaceFleetDbContext _db;

    public ShipService(SpaceFleetDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Ship ship)
    {
        if (ship.Capacity < 0) return false;
        if (ship.CrewCount < 0) return false;
        
        if (ship is LocalSystemShip localShip)
        {
            if (localShip.LocalSpeed < 1) return false;
            if (localShip.Maneuverability is < 0 or > 10) return false;
        }

        if (ship is RemoteSystemShip remoteShip)
        {
            if (remoteShip.RemoteSpeed < 10)  return false;
            if (!remoteShip.HibernationChamber && remoteShip.RemoteSpeed < 1000) return false;
        }
        
        _db.Ships.Add(ship);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Ship?> ReadOne(int id)
    {
        return await _db.Ships.FindAsync(id);
    }

    public async Task<List<Ship>> ReadAll()
    {
        return await _db.Ships.ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var ship = await _db.Ships.FindAsync(id);
        if (ship == null)
            return false;
        
        _db.Ships.Remove(ship);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, Ship uShip)
    {
        var ship = await _db.Ships.FindAsync(id);
        if (ship == null)
            return false;
        
        ship.Model = uShip.Model;
        ship.Capacity = uShip.Capacity;
        ship.CrewCount = uShip.CrewCount;
        
        if (ship is LocalSystemShip localShip && uShip is LocalSystemShip usLocal)
        {
            if (usLocal.LocalSpeed < 1) return false;
            if (usLocal.Maneuverability < 1 || usLocal.Maneuverability > 10) return false;

            localShip.LocalSpeed = usLocal.LocalSpeed;
            localShip.Maneuverability = usLocal.Maneuverability;
        }
        else if (ship is RemoteSystemShip remoteShip && uShip is RemoteSystemShip usRemote)
        {
            if (usRemote.RemoteSpeed < 20) return false;
            if (!usRemote.HibernationChamber && remoteShip.RemoteSpeed < 1000)  return false; 

            remoteShip.RemoteSpeed = usRemote.RemoteSpeed;
            remoteShip.HibernationChamber = usRemote.HibernationChamber;
        }
        else
        {
            throw new InvalidOperationException("Type mismatch between existing ship and update object");
        }

        await _db.SaveChangesAsync();
        return true;
    }
}