using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Loggers;

public class ShipEventLogger
{
    private readonly ILogger<ShipEventLogger> _logger;

    public ShipEventLogger(ShipService service, ILogger<ShipEventLogger> logger)
    {
        _logger = logger;

        service.ShipCreated += OnShipCreated;
        service.ShipUpdated += OnShipUpdated;
        service.ShipDeleted += OnShipDeleted;
    }

    private void OnShipCreated(object? sender, Ship ship)
    {
        if (ship is LocalSystemShip localShip)
        {
            _logger.LogInformation($"LSS created: {localShip.Id}, Model: {localShip.Model}, Speed: {localShip.LocalSpeed} AU/h");
        }
        else if (ship is RemoteSystemShip remoteShip)
        {
            _logger.LogInformation($"RSS created: {remoteShip.Id}, Model: {remoteShip.Model}, Speed: {remoteShip.RemoteSpeed} ly/h");
        }
    }

    private void OnShipUpdated(object? sender, Ship ship)
    {
        if (ship is LocalSystemShip localShip)
        {
            _logger.LogInformation($"LSS updated: {localShip.Id}, Model: {localShip.Model}, Speed: {localShip.LocalSpeed} AU/h");
        }
        else if (ship is RemoteSystemShip remoteShip)
        {
            _logger.LogInformation($"RSS updated: {remoteShip.Id}, Model: {remoteShip.Model}, Speed: {remoteShip.RemoteSpeed} ly/h");
        }
    }

    private void OnShipDeleted(object? sender, Ship ship)
    {
        if (ship is LocalSystemShip localShip)
        {
            _logger.LogInformation($"LSS deleted: {localShip.Id}, Model: {localShip.Model}, Speed: {localShip.LocalSpeed} AU/h");
        }
        else if (ship is RemoteSystemShip remoteShip)
        {
            _logger.LogInformation($"RSS deleted: {remoteShip.Id}, Model: {remoteShip.Model}, Speed: {remoteShip.RemoteSpeed} ly/h");
        }
    }
}