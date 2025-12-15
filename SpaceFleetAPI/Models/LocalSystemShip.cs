using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class LocalSystemShip : Ship
{
    public int LocalSpeed { get; set; }
    [System.ComponentModel.DataAnnotations.Range(1, 10)]
    public int Maneuverability { get; set; }
}