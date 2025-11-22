using Microsoft.Extensions.Logging;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Loggers;

public class DestinationEventLogger
{
    private readonly ILogger<DestinationEventLogger> _logger;

    public DestinationEventLogger(DestinationService service, ILogger<DestinationEventLogger> logger)
    {
        _logger = logger;

        service.DestinationCreated += OnDestinationCreated;
        service.DestinationUpdated += OnDestinationUpdated;
        service.DestinationDeleted += OnDestinationDeleted;
    }

    private void OnDestinationCreated(object? sender, Destination dest)
    {
        _logger.LogInformation($"Destination created: {dest.Id}, Name: {dest.Name}");
    }

    private void OnDestinationUpdated(object? sender, Destination dest)
    {
        _logger.LogInformation($"Destination updated: {dest.Id}, Name: {dest.Name}");
    }

    private void OnDestinationDeleted(object? sender, Destination dest)
    {
        _logger.LogInformation($"Destination deleted: {dest.Id}, Name: {dest.Name}");
    }
}