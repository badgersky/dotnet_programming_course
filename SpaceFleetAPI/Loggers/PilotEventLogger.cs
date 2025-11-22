using Microsoft.Extensions.Logging;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Loggers;

public class PilotEventLogger
{
    private readonly ILogger<PilotEventLogger> _logger;

    public PilotEventLogger(PilotService service, ILogger<PilotEventLogger> logger)
    {
        _logger = logger;

        service.PilotCreated += OnPilotCreated;
        service.PilotUpdated += OnPilotUpdated;
        service.PilotDeleted += OnPilotDeleted;
    }

    private void OnPilotCreated(object? sender, Pilot pilot)
    {
        _logger.LogInformation($"Pilot created: {pilot.Id}, Name: {pilot.Name}");
    }

    private void OnPilotUpdated(object? sender, Pilot pilot)
    {
        _logger.LogInformation($"Pilot updated: {pilot.Id}, Name: {pilot.Name}");
    }

    private void OnPilotDeleted(object? sender, Pilot pilot)
    {
        _logger.LogInformation($"Pilot deleted: {pilot.Id}, Name: {pilot.Name}");
    }
}