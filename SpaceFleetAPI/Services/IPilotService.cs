using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public interface IPilotService
{
    public Task<bool> Create(Pilot pilot);
    public Task<Pilot?> ReadOne(int id);
    public Task<List<Pilot>> ReadAll();
    public Task<bool> Delete(int id);
    public Task<bool> Update(int id, Pilot uPilot);
}