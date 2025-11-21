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
        _db.Database.EnsureDeleted();
        _db.Dispose();
    }

    [Test]
    public async Task TestCreatePilot1()
    {
        var pilot = new Pilot { Name = "Jerry" };
        var result = await _s.Create(pilot);
        var pilots = await _s.ReadAll();

        Assert.That(pilots, Is.Not.Null);
        Assert.That(pilots.Count, Is.EqualTo(1));
        Assert.That(result, Is.True);
    }
}