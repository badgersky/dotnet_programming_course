using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class RemoteSystemShip : Ship
{
    [Required]
    public bool HibernationChamber { get; set; }
    [Required]
    public double MaxJump { get; set; }
}