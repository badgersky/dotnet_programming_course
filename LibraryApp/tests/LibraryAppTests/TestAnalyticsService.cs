using Services;

namespace LibraryAppTests;

public class TestAnalyticsService
{
    private IAnalyticService  _as;
    private ILibraryService _lb;
    [SetUp]
    public void Setup()
    {
        _lb = new LibraryService();
        for (var i = 0; i < 10; i++)
        {
            _lb.AddUser($"user{i}");
            _lb.AddItem($"title{i}", $"author{i}", "12345678910");
            _lb.AddItem($"ebook{i}", $"author{i}", "", "pdf");
        }

        _as = new AnalyticsService(_lb);
    }

    [Test]
    public void TestAllItemsCount1()
    {
        var ic = _as.AllItemsCount();
        
        Assert.That(ic, Is.EqualTo(20));
    }
    
    [Test]
    public void TestAllItemsCount2()
    {
        _lb.AddItem("asdd", "asds", "", "pdf");
        var ic = _as.AllItemsCount();
        
        Assert.That(ic, Is.EqualTo(21));
    }

    [Test]
    public void TestAllUsersCount1()
    {
        var uc = _as.AllUsersCount();
        
        Assert.That(uc, Is.EqualTo(10));
    }

    [Test]
    public void TestAllUsersCount2()
    {
        _lb.AddUser("JOJO");
        var uc = _as.AllUsersCount();
        
        Assert.That(uc, Is.EqualTo(11));
    }

    [Test]
    public void TestAllRentalsCount1()
    {
        var rc = _as.AllRentalsCount();
        
        Assert.That(rc, Is.EqualTo(0));
    }

    [Test]
    public void TestAllRentalsCount2()
    {
        for (var i = 1; i < 6; i++)
        {
            _lb.RentItem(12, i);
            _lb.RentItem(i, 10);
        }

        var rc = _as.AllRentalsCount();
        
        Assert.That(rc, Is.EqualTo(10));
    }
    
    [Test]
    public void TestActiveRentalsCount1()
    {
        var rc = _as.AllActiveRentalsCount();
        
        Assert.That(rc, Is.EqualTo(0));
    }

    [Test]
    public void TestActiveRentalsCount2()
    {
        for (var i = 1; i < 6; i++)
        {
            _lb.RentItem(12, i);
            _lb.RentItem(i, 10);
        }
        for (var i = 1; i < 4; i++)
        {
            _lb.ReturnItem(i);
        }

        var rc = _as.AllActiveRentalsCount();
        
        Assert.That(rc, Is.EqualTo(7));
    }
    
    [Test]
    public void TestMostActiveUser1()
    {
        for (var i = 1; i < 6; i++)
        {
            _lb.RentItem(12, i);
            _lb.RentItem(i, 10);
        }
        
        var user = _as.MostActiveUser();
        
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Username, Is.EqualTo("user9"));
    }

    [Test]
    public void TestMostCommonRental1()
    {
        for (var i = 1; i < 6; i++)
        {
            _lb.RentItem(12, i);
            _lb.RentItem(i, 10);
        }
        
        var rental = _as.MostCommonRental();
        
        Assert.That(rental, Is.Not.Null);
        Assert.That(rental.Title, Is.EqualTo("ebook5"));
    }
}