using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Services;

public interface IOrderService
{
    public Task<bool> Create(TransportOrder order);
    public Task<TransportOrder?> ReadOne(int id);
    public Task<List<TransportOrder>> ReadAll();
    public Task<bool> Delete(int id);
    public Task<bool> Update(int id, TransportOrder uOrder);
}