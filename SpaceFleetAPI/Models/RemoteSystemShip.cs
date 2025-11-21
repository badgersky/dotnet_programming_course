using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class RemoteSystemShip : Ship
{
    public bool HibernationChamber { get; set; }
    public double RemoteSpeed { get; set; }
}