using System.ComponentModel.DataAnnotations;

namespace SpaceFleetAPI.Models;

public class Destination
{
    [Key]
    public int Id { get; set; }
    [Required,  MaxLength(50)]
    public required string Name { get; set; }
    public List<TransportOrder>? TransportOrders { get; set; }
}