using Microsoft.Extensions.Logging;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Loggers;

public class OrderEventLogger
{
    private readonly ILogger<OrderEventLogger> _logger;

    public OrderEventLogger(OrderService service, ILogger<OrderEventLogger> logger)
    {
        _logger = logger;

        service.OrderCreated += OnOrderCreated;
        service.OrderUpdated += OnOrderUpdated;
        service.OrderDeleted += OnOrderDeleted;
        service.OrderCompleted += OnOrderCompleted;
    }

    private void OnOrderCreated(object? sender, TransportOrder order)
    {
        _logger.LogInformation($"Order created: {order.Id}, Ship: {order.ShipId}, Pilot: {order.PilotId}, Destination: {order.DestinationId}, Finished: {order.Finished}");
    }

    private void OnOrderUpdated(object? sender, TransportOrder order)
    {
        _logger.LogInformation($"Order updated: {order.Id}, Ship: {order.ShipId}, Pilot: {order.PilotId}, Destination: {order.DestinationId}, Finished: {order.Finished}");
    }

    private void OnOrderDeleted(object? sender, TransportOrder order)
    {
        _logger.LogInformation($"Order deleted: {order.Id}, Ship: {order.ShipId}, Pilot: {order.PilotId}, Destination: {order.DestinationId}");
    }

    private void OnOrderCompleted(object? sender, TransportOrder order)
    {
        _logger.LogInformation($"Order completed: {order.Id}, Ship: {order.ShipId}, Pilot: {order.PilotId}, Destination: {order.DestinationId}");
    }
}