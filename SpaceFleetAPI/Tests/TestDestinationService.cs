using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Tests;

public class DestinationServiceTests
{
    private SpaceFleetDbContext? _db;
    private DestinationService? _s;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<SpaceFleetDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _db = new SpaceFleetDbContext(options);
        _s = new DestinationService(_db);
    }

    [TearDown]
    public void TearDown()
    {
        _db?.Database.EnsureDeleted();
        _db?.Dispose();
    }

    [Test]
    public async Task TestCreateDestination1()
    {
        var destination = new Destination() { Name = "Titan Station 2b" };
        var result = await _s?.Create(destination)!;
        destination = await _s?.ReadOne(1)!;
        
        Assert.That(result, Is.True);
        Assert.That(destination, Is.Not.Null);
        Assert.That(destination?.Name, Is.EqualTo("Titan Station 2b"));
    }

    [Test]
    public async Task TestCreateDestination2()
    {
        var destination = new Destination() { Id = 1, Name = "Titan Station 2b" };
        var result1 = await _s?.Create(destination)!;
        
        destination = new Destination() { Id = 1, Name = "Titan Station 1b" };
        var result2 = await _s?.Create(destination)!;

        destination = await _s?.ReadOne(1)!;
        
        Assert.That(result1, Is.True);
        Assert.That(result2, Is.False);
        Assert.That(destination, Is.Not.Null);
        Assert.That(destination?.Name, Is.EqualTo("Titan Station 2b"));
    }

    [Test]
    public async Task TestCreateDestination3()
    {
        var destination = new Destination() { Name = "" };
        var result = await _s?.Create(destination)!;
        destination = await _s?.ReadOne(1)!;
        
        Assert.That(result, Is.False);
        Assert.That(destination, Is.Null);
    }

    [Test]
    public async Task TestDeleteDestination()
    {
    }

    [Test]
    public async Task TestReadOneDestination()
    {
    }

    [Test]
    public async Task TestUpdateDestination()
    {
    }
}