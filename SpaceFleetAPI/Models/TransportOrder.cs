using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceFleetAPI.Models;

public class TransportOrder
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required int ShipId { get; set; }
    [ForeignKey("ShipId")]
    public Ship? Ship { get; set; }
    [Required]
    public required int PilotId { get; set; }
    [ForeignKey("PilotId")]
    public Pilot? Pilot { get; set; }
    [Required]
    public required int DestinationId { get; set; }
    [ForeignKey("DestinationId")]
    public Destination? Destination { get; set; }
    [Required]
    public bool Finished { get; set; }
}