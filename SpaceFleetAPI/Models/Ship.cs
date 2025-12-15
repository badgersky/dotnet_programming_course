using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public abstract class Ship
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)] 
    public required string Model { get; set; } = "";
    [Required]
    public int Capacity { get; set; }
    [Required]
    public int CrewCount { get; set; }
    public List<TransportOrder>? TransportOrders { get; set; }
}