using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Tests;

public class ShipServiceTests
{
    private SpaceFleetDbContext? _db;
    private ShipService? _s;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<SpaceFleetDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _db = new SpaceFleetDbContext(options);
        _s = new ShipService(_db);
    }

    [TearDown]
    public void TearDown()
    {
        _db?.Database.EnsureDeleted();
        _db?.Dispose();
    }
    
    [Test]
    public async Task TestCreateShip1()
    {
        var ship = new LocalSystemShip
            { Id = 1, Model = "JEQ - 2379", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };

        var result = await _s?.Create(ship)!;
        var ships = await _s.ReadAll();

        Assert.That(ships, Is.Not.Null);
        Assert.That(ships.Count, Is.EqualTo(1));
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task TestCreateShip2()
    {
        var ship = new LocalSystemShip
            { Id = 1, Model = "", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };

        var result = await _s?.Create(ship)!;
        var ships = await _s.ReadAll();

        Assert.That(ships, Is.Not.Null);
        Assert.That(ships.Count, Is.EqualTo(0));
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task TestCreateShip3()
    {
        var ship = new LocalSystemShip
            { Id = 1, Model = "JEQ - 2379", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };
        var result1 = await _s?.Create(ship)!;

        ship = new LocalSystemShip() 
            {Id = 1, Model = "JAKE - 2", Capacity = 5, CrewCount = 2, LocalSpeed = 4, Maneuverability = 8 };
        var result2 = await _s?.Create(ship)!;
        var ships = await _s.ReadAll();
        
        Assert.That(ships, Is.Not.Null);
        Assert.That(ships.Count, Is.EqualTo(1));
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.False);
    }
    
    [Test]
    public async Task TestDeleteShip1()
    {
        var ship = new LocalSystemShip
            { Id = 1, Model = "FIN - 10000", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };
        
        var result1 = await _s?.Create(ship)!;
        var ships1 = await _s.ReadAll();
        var result2 = await _s?.Delete(1)!;
        var ships2 = await _s.ReadAll();
        
        Assert.That(ships1, Is.Not.Null);
        Assert.That(ships1.Count, Is.EqualTo(1));
        Assert.That(ships2.Count, Is.EqualTo(0));
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
    }
    
    [Test]
    public async Task TestDeleteShip2()
    {
        var result = await _s?.Delete(1)!;
        var ships = await _s.ReadAll();

        Assert.That(ships.Count, Is.EqualTo(0));
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task TestUpdateShip1()
    {
        var ship1 = new LocalSystemShip
            { Id = 1, Model = "FIN - 10000", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };
        var result1 = await _s?.Create(ship1)!;

        var ship2 = new RemoteSystemShip() 
        { Id = 1, Model = "LE - 2789", Capacity = 120, CrewCount = 10, RemoteSpeed = 400, HibernationChamber = false };
        var result2 = await _s?.Update(1, ship2)!;

        var ship = await _s?.ReadOne(1)!;
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.False);
        Assert.That(ship, Is.Not.Null);
        Assert.That(ship?.Model, Is.EqualTo("FIN - 10000"));
    }
    
    [Test]
    public async Task TestUpdateShip2()
    {
        var ship1 = new LocalSystemShip
            { Id = 1, Model = "FIN - 10000", Capacity = 13, CrewCount = 2, LocalSpeed = 2, Maneuverability = 9 };
        var result1 = await _s?.Create(ship1)!;

        var ship2 = new LocalSystemShip() 
            { Id = 1, Model = "LE - 2789", Capacity = 10, CrewCount = 3, LocalSpeed = 3, Maneuverability = 8 };
        var result2 = await _s?.Update(1, ship2)!;

        var ship = await _s?.ReadOne(1)!;
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
        Assert.That(ship, Is.Not.Null);
        Assert.That(ship?.Model, Is.EqualTo("LE - 2789"));
    }
}