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
}