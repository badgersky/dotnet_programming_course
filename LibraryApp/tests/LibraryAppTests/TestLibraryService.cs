using Services;

namespace LibraryAppTests;

public class TestLibraryService
{
    private ILibraryService _s;
    
    [SetUp]
    public void Setup()
    { 
        _s = new LibraryService();
    }

    [Test]
    public void TestAddUser1()
    {
        _s.AddUser("username");
        var users = _s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable.First().Username, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestAddUser2()
    {
        _s.AddUser("username");
        _s.AddUser("username");
        var users = _s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable.First().Username, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestAddUser3()
    {
        _s.AddUser("username1");
        _s.AddUser("username2");
        var users = _s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(2));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable[1].Id, Is.EqualTo(2));
        Assert.That(enumerable.First().Username, Is.EqualTo("username1"));
    }
    
    [Test]
    public void TestAddItem1()
    {
        _s.AddItem("title", "author", "123");
        var items =  _s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddItem2()
    {
        _s.AddItem("title", "author", "", "pdf");
        _s.AddItem("title", "author", "123", "pdf");
        var items =  _s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddItem3()
    {
        _s.AddItem("title", "author", "", "pdf");
        _s.AddItem("title", "author", "123");
        _s.AddItem("title", "author", "321");
        var items =  _s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(3));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable[1].Id, Is.EqualTo(2));
    }
    
    [Test]
    public void TestAddRental1()
    {
        _s.AddItem("title", "author", "", "pdf");
        _s.AddUser("username");
        _s.RentItem(1, 1);
        var rentals = _s.GetRentals();
        var items =  _s.GetItems();
        var enumerable1 = items.ToList();
        var enumerable2 = rentals.ToList();
        
        Assert.That(enumerable1.First().IsA, Is.EqualTo(true));
        Assert.That(enumerable2.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddRental2()
    {
        _s.AddItem("title", "author", "12323");
        _s.AddUser("username");
        _s.RentItem(1, 1);
        var rentals = _s.GetRentals();
        var items =  _s.GetItems();
        var enumerable1 = items.ToList();
        var enumerable2 = rentals.ToList();
        
        Assert.That(enumerable1.First().IsA, Is.EqualTo(false));
        Assert.That(enumerable2.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddRental3()
    {
        _s.AddUser("username");
        _s.RentItem(1, 1);
        var rentals = _s.GetRentals();
        var enumerable1 = rentals.ToList();
        
        Assert.That(enumerable1.Count(), Is.EqualTo(0));
    }
    
    [Test]
    public void TestReturnItem()
    {
        _s.AddItem("title", "author", "12323");
        _s.AddUser("username");
        _s.RentItem(1, 1);
        _s.ReturnItem(1);
        var items = _s.GetItems();
        var rentals = _s.GetRentals();
        var enumerable1 = rentals.ToList();
        var enumerable2 = items.ToList();
        
        Assert.That(enumerable1.First().Returned, Is.EqualTo(true));
        Assert.That(enumerable2.First().IsA, Is.EqualTo(true));
    }
}