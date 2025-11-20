using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class Pilot
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public List<TransportOrder>? TransportOrders { get; set; }
}