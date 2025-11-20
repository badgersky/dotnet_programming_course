using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Models;

namespace SpaceFleetAPI.Data;

public class SpaceFleetDbContext : DbContext
{
    public SpaceFleetDbContext(DbContextOptions<SpaceFleetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ship> Ships { get; set; }
    public DbSet<LocalSystemShip> LocalSystemShips { get; set; }
    public DbSet<RemoteSystemShip> RemoteSystemShips { get; set; }
    public DbSet<Pilot> Pilots { get; set; }
    public DbSet<TransportOrder> TransportOrders { get; set; }
    public DbSet<Destination> Destinations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocalSystemShip>();
        modelBuilder.Entity<RemoteSystemShip>();
        
        base.OnModelCreating(modelBuilder);
    }
}