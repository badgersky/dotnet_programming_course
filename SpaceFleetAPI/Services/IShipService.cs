using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public interface IShipService
{
    public Task<bool> Create(Ship ship);
    public Task<Ship?> ReadOne(int id);
    public Task<List<Ship>> ReadAll();
    public Task<bool> Delete(int id);
    public Task<bool> Update(int id, Ship uShip);
}