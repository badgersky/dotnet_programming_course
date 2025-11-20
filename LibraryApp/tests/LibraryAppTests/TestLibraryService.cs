using Services;

namespace LibraryAppTests;

public class TestLibraryService
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAddUser1()
    {
        var s = new LibraryService();

        s.AddUser("username");
        var users = s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable.First().Username, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestAddUser2()
    {
        var s = new LibraryService();

        s.AddUser("username");
        s.AddUser("username");
        var users = s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable.First().Username, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestAddUser3()
    {
        var s = new LibraryService();

        s.AddUser("username1");
        s.AddUser("username2");
        var users = s.GetUsers();

        var enumerable = users.ToList();
        Assert.That(enumerable.Count(), Is.EqualTo(2));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable[1].Id, Is.EqualTo(2));
        Assert.That(enumerable.First().Username, Is.EqualTo("username1"));
    }
    
    [Test]
    public void TestAddItem1()
    {
        var s = new LibraryService();

        s.AddItem("title", "author", "123");
        var items =  s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddItem2()
    {
        var s = new LibraryService();

        s.AddItem("title", "author", "", "pdf");
        s.AddItem("title", "author", "123", "pdf");
        var items =  s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(1));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddItem3()
    {
        var s = new LibraryService();

        s.AddItem("title", "author", "", "pdf");
        s.AddItem("title", "author", "123");
        s.AddItem("title", "author", "321");
        var items =  s.GetItems();
        var enumerable = items.ToList();
        
        Assert.That(enumerable.Count(), Is.EqualTo(3));
        Assert.That(enumerable.First().Id, Is.EqualTo(1));
        Assert.That(enumerable[1].Id, Is.EqualTo(2));
    }
    
    [Test]
    public void TestAddRental1()
    {
        var s = new LibraryService();

        s.AddItem("title", "author", "", "pdf");
        s.AddUser("username");
        s.RentItem(1, 1);
        var rentals = s.GetRentals();
        var items =  s.GetItems();
        var enumerable1 = items.ToList();
        var enumerable2 = rentals.ToList();
        
        Assert.That(enumerable1.First().IsA, Is.EqualTo(true));
        Assert.That(enumerable2.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddRental2()
    {
        var s = new LibraryService();

        s.AddItem("title", "author", "12323");
        s.AddUser("username");
        s.RentItem(1, 1);
        var rentals = s.GetRentals();
        var items =  s.GetItems();
        var enumerable1 = items.ToList();
        var enumerable2 = rentals.ToList();
        
        Assert.That(enumerable1.First().IsA, Is.EqualTo(false));
        Assert.That(enumerable2.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAddRental3()
    {
        var s = new LibraryService();
        
        s.AddUser("username");
        s.RentItem(1, 1);
        var rentals = s.GetRentals();
        var enumerable1 = rentals.ToList();
        
        Assert.That(enumerable1.Count(), Is.EqualTo(0));
    }
    
    [Test]
    public void TestReturnItem()
    {
        var s = new LibraryService();
        
        s.AddItem("title", "author", "12323");
        s.AddUser("username");
        s.RentItem(1, 1);
        s.ReturnItem(1);
        var items = s.GetItems();
        var rentals = s.GetRentals();
        var enumerable1 = rentals.ToList();
        var enumerable2 = items.ToList();
        
        Assert.That(enumerable1.First().Returned, Is.EqualTo(true));
        Assert.That(enumerable2.First().IsA, Is.EqualTo(true));
    }
}