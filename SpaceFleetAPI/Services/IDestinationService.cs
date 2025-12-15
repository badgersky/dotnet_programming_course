using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public interface IDestinationService
{
    public Task<bool> Create(Destination dest);
    public Task<Destination?> ReadOne(int id);
    public Task<List<Destination>> ReadAll();
    public Task<bool> Delete(int id);
    public Task<bool> Update(int id, Destination uDest);
}