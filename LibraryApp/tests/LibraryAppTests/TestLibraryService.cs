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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
        Assert.That(enumerable[1].Id, Is.EqualTo(1));
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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
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
        Assert.That(enumerable.First().Id, Is.EqualTo(0));
        Assert.That(enumerable[1].Id, Is.EqualTo(1));
    }
}