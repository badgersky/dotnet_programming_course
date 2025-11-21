using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public class ShipService : IShipService
{
    public Task<bool> Create(Ship ship)
    {
        throw new NotImplementedException();
    }

    public Task<Ship> ReadOne(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ship>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Ship uShip)
    {
        throw new NotImplementedException();
    }
}