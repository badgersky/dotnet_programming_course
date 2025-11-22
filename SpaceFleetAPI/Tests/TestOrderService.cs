using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Models;
using SpaceFleetAPI.Services;

namespace SpaceFleetAPI.Tests
{
    public class OrderServiceTests
    {
        private SpaceFleetDbContext? _db;
        private OrderService? _s;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SpaceFleetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _db = new SpaceFleetDbContext(options);
            _s = new OrderService(_db);
            
            var pilots = new List<Pilot>
            {
                new Pilot { Id = 1, Name = "Mietek" },
                new Pilot { Id = 2, Name = "Magda" },
                new Pilot { Id = 3, Name = "Maria" },
                new Pilot { Id = 4, Name = "Maciej" }
            };
            _db.Pilots.AddRange(pilots);
            
            var ships = new List<Ship>
            {
                new LocalSystemShip { Id = 1, Model = "M - 2455", Capacity = 10, CrewCount = 2, LocalSpeed = 4, Maneuverability = 6},
                new LocalSystemShip { Id = 2, Model = "KED - 2137", Capacity = 20, CrewCount = 4, LocalSpeed = 3, Maneuverability = 7},
                new RemoteSystemShip { Id = 3, Model = "TQ - 2555", Capacity = 100, CrewCount = 8, RemoteSpeed = 200, HibernationChamber = false}
            };
            _db.Ships.AddRange(ships);
            
            var destinations = new List<Destination>
            {
                new Destination { Id = 1, Name = "Jupiter" },
                new Destination { Id = 2, Name = "Mars" },
                new Destination { Id = 3, Name = "Kepler 245b" }
            };
            _db.Destinations.AddRange(destinations);
            _db.SaveChangesAsync();
        }

        [TearDown]
        public void TearDown()
        {
            _db?.Database.EnsureDeleted();
            _db?.Dispose();
        }

        [Test]
        public async Task TestCreateOrder1()
        {
            var order = new TransportOrder { ShipId = 1, PilotId = 2, DestinationId = 1 };
            var result = await _s?.Create(order)!;
            var orders = await _s.ReadAll();
            
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task TestCreateOrder2()
        {
            var order = new TransportOrder { ShipId = 1, PilotId = 2, DestinationId = 1 };
            var result = await _s?.Create(order)!;
            var orders = await _s.ReadAll();
            
            var order2 = new TransportOrder { ShipId = 1, PilotId = 4, DestinationId = 2 };
            var result2 = await _s?.Create(order2)!;
            var orders2 = await _s.ReadAll();
            
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.That(result, Is.True);
            Assert.That(orders2, Is.Not.Null);
            Assert.That(orders2.Count, Is.EqualTo(1));
            Assert.That(result2, Is.False);
        }
        
        [Test]
        public async Task TestCreateOrder3()
        {
            var order = new TransportOrder { ShipId = 1, PilotId = 2, DestinationId = 1 };
            var result = await _s?.Create(order)!;
            var orders = await _s.ReadAll();
            
            var order2 = new TransportOrder { ShipId = 2, PilotId = 2, DestinationId = 2 };
            var result2 = await _s?.Create(order2)!;
            var orders2 = await _s.ReadAll();
            
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.That(result, Is.True);
            Assert.That(orders2, Is.Not.Null);
            Assert.That(orders2.Count, Is.EqualTo(1));
            Assert.That(result2, Is.False);
        }
        
        [Test]
        public async Task TestCreateOrder4()
        {
            var order = new TransportOrder { ShipId = 10, PilotId = 10, DestinationId = 10 };
            var result = await _s?.Create(order)!;
            var orders = await _s.ReadAll();
            
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(0));
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task TestReadOneOrder()
        {
            var order = new TransportOrder { ShipId = 1, PilotId = 2, DestinationId = 1 };
            var result = await _s?.Create(order)!;
            var order2 = await _s?.ReadOne(1)!;
            
            
            Assert.That(order, Is.Not.Null);
            Assert.That(result, Is.True);
            Assert.That(order2, Is.Not.Null);
            Assert.That(order2?.Destination?.Name, Is.EqualTo("Jupiter"));
        }

        [Test]
        public async Task TestReadAllOrders()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1 },
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2 },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3 }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();
            
            var orders2 = await _s?.ReadAll()!;
            
            Assert.That(orders2, Is.Not.Null);
            Assert.That(orders2.Count, Is.EqualTo(3));
        }
        
        [Test]
        public async Task TestUpdateOrder1()
        {
            var order1 = new TransportOrder { ShipId = 1, PilotId = 2, DestinationId = 1 };
            var result1 = await _s?.Create(order1)!;
            
            var order2 = new TransportOrder { ShipId = 1, PilotId = 3, DestinationId = 1 };
            var result2 = await _s?.Update(1, order2)!;
        
            var order3 = await _s?.ReadOne(1)!;
            
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(order3, Is.Not.Null);
            Assert.That(order3?.Pilot?.Name, Is.EqualTo("Maria"));
        }

        [Test]
        public async Task TestUpdateOrder2()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1, Finished = false},
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2, Finished = false },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3, Finished = false }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();
            
            var order1 = new TransportOrder { ShipId = 1, PilotId = 4, DestinationId = 1 };
            var result1 = await _s?.Update(1, order1)!;
        
            var order2 = await _s?.ReadOne(1)!;
            
            Assert.That(order2, Is.Not.Null);
            Assert.That(order2?.Pilot?.Name, Is.EqualTo("Magda"));
        }
        
        [Test]
        public async Task TestUpdateOrder3()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1, Finished = false},
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2, Finished = true },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3, Finished = false }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();
            
            var order1 = new TransportOrder { ShipId = 1, PilotId = 4, DestinationId = 1 };
            var result1 = await _s?.Update(1, order1)!;
        
            var order2 = await _s?.ReadOne(1)!;
            
            Assert.That(result1, Is.True);
            Assert.That(order2, Is.Not.Null);
            Assert.That(order2?.Pilot?.Name, Is.EqualTo("Maciej"));
        }
        
        [Test]
        public async Task TestDeleteOrder()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1, Finished = false},
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2, Finished = true },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3, Finished = false }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();

            var result = await _s?.Delete(1)!;
            orders = await _s.ReadAll();
            
            Assert.That(result, Is.True);
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestCompleteOrder1()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1, Finished = false},
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2, Finished = false },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3, Finished = false }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();

            var result = await _s?.CompleteOrder(1)!;
            var order = await _s?.ReadOne(1)!;
            
            Assert.That(order, Is.Not.Null);
            Assert.That(result, Is.True);
            Assert.That(order?.Finished, Is.True);
        }
        
        [Test]
        public async Task TestCompleteOrder2()
        {
            var orders = new List<TransportOrder>
            {
                new TransportOrder { Id = 1, ShipId = 1, PilotId = 2, DestinationId = 1, Finished = true},
                new TransportOrder { Id = 2, ShipId = 2, PilotId = 4, DestinationId = 2, Finished = false },
                new TransportOrder { Id = 3, ShipId = 3, PilotId = 1, DestinationId = 3, Finished = false }
            };
            await _db?.TransportOrders.AddRangeAsync(orders)!;
            await _db.SaveChangesAsync();

            var result = await _s?.CompleteOrder(1)!;
            var order = await _s?.ReadOne(1)!;
            
            Assert.That(order, Is.Not.Null);
            Assert.That(result, Is.False);
            Assert.That(order?.Finished, Is.True);
        }
    }
}