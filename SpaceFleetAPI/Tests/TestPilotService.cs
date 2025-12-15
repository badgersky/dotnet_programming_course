using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Tests;

public class PilotServiceTests
{
    private SpaceFleetDbContext? _db;
    private PilotService? _s;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<SpaceFleetDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _db = new SpaceFleetDbContext(options);
        _s = new PilotService(_db);
    }

    [TearDown]
    public void TearDown()
    {
        _db?.Database.EnsureDeleted();
        _db?.Dispose();
    }

    [Test]
    public async Task TestCreatePilot1()
    {
        var pilot = new Pilot { Name = "Jerry" };
        var result = await _s?.Create(pilot)!;
        var pilots = await _s.ReadAll();

        Assert.That(pilots, Is.Not.Null);
        Assert.That(pilots.Count, Is.EqualTo(1));
        Assert.That(result, Is.True);
    }
    
    [Test]
    public async Task TestCreatePilot2()
    {
        var pilot = new Pilot { Name = "" };
        var result = await _s?.Create(pilot)!;
        var pilots = await _s.ReadAll();
        
        Assert.That(pilots.Count, Is.EqualTo(0));
        Assert.That(result, Is.False);
    }
    
    [Test]
    public async Task TestCreatePilot3()
    {
        var pilot =  new Pilot { Id = 1, Name = "Jerry" };
        await _s.Create(pilot);
        
        pilot = new Pilot { Id = 1, Name = "Jane" };
        var result = await _s?.Create(pilot)!;
        var pilots = await _s.ReadAll();
        
        Assert.That(pilots.Count, Is.EqualTo(1));
        Assert.That(result, Is.False);
    }
    
    [Test]
    public async Task TestDeletePilot()
    {
        var pilot = new Pilot { Name = "Jerry" };
        var result1 = await _s?.Create(pilot)!;
        var pilots1 = await _s.ReadAll();

        var result2 = await _s.Delete(pilot.Id);
        var pilots2 = await _s.ReadAll();
        
        Assert.That(pilots1, Is.Not.Null);
        Assert.That(pilots1.Count, Is.EqualTo(1));
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
        Assert.That(pilots2, Is.Not.Null);
        Assert.That(pilots2.Count, Is.EqualTo(0));
    }
    
    [Test]
    public async Task TestReadOnePilot()
    {
        var pilot = new Pilot { Name = "Jerry" };
        var result1 = await _s?.Create(pilot)!;
        
        pilot = new Pilot { Name = "Jane" };
        var result2 =  await _s.Create(pilot);
        
        var pilot2 = await _s.ReadOne(pilot.Id);
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
        Assert.That(pilot2, Is.Not.Null);
        Assert.That(pilot2?.Name, Is.EqualTo("Jane"));
    }
    
    [Test]
    public async Task TestUpdatePilot()
    {
        var pilot = new Pilot { Name = "Jerry" };
        var result1 = await _s?.Create(pilot)!;
        
        var uPilot = new Pilot { Name = "Jane" };
        var result2 =  await _s.Update(pilot.Id, uPilot);
        
        var pilot2 = await _s.ReadOne(pilot.Id);
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.True);
        Assert.That(pilot2, Is.Not.Null);
        Assert.That(pilot2?.Name, Is.EqualTo("Jane"));
    }
}