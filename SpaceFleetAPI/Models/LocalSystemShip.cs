using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class LocalSystemShip : Ship
{
    [Required]
    public int MaxSpeed { get; set; }
    [Required, Range(1, 10)]
    public int Maneuverability { get; set; }
}