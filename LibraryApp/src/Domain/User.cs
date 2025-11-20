namespace Domain;

public class User
{
    public int Id { get; }
    public string Username { get; }

    public User(string username, int id)
    {
        Id = id;
        Username = username.Trim();
    }

    public void DisplayInfo()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"User ID: {Id}");
        Console.WriteLine($"Username: {Username}");
        Console.WriteLine("-----------------------------------------");
    }
}