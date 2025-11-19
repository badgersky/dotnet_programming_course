using Domain;

namespace Services;

public class LibraryService : ILibraryService
{
    private readonly List<LibraryItem> _items = [];
    private readonly List<User> _users = [];
    private readonly List<ItemRental> _itemRentals = [];
    private int _nextU;
    private int _nextI;
    private int _nextR;

    public LibraryService()
    {
        this._nextU = _nextU = 1;
        this._nextI = _nextI = 1;
        this._nextR = _nextR = 1;
    }

    public bool AddItem(string title, string author, string isbn = "", string format = "")
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author)) return false;

        if (!string.IsNullOrWhiteSpace(isbn) && !string.IsNullOrWhiteSpace(format)) return false;

        LibraryItem? item = null;
        if (string.IsNullOrWhiteSpace(isbn))
        {
            item = new Ebook(_nextI, title, format, author);
            _nextI++;
        }

        if (string.IsNullOrWhiteSpace(format))
        {
            item = new Book(_nextI, title, author, isbn);
            _nextI++;
        }

        if (item == null) return false;
        _items.Add(item);
        return true;
    }

    public bool AddUser(string username)
    {
        if (string.IsNullOrEmpty(username)) return false;
        if (_users.Any(u => u.Username == username))
        {
            Console.WriteLine("Username already exists");
            return false;
        }
        
        var user = new User(username, _nextU);
        _users.Add(user);
        
        _nextU++;
        return true;
    }

    public bool RentItem(int itemId, int userId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            Console.WriteLine($"Item with id {itemId} not found");
            return false;
        }
        
        var user =  _users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            Console.WriteLine($"User with id {userId} not found");
            return false;
        }

        if (!item.IsA)
        {
            Console.WriteLine($"Item with id {itemId} is not available");
            return false;
        }

        if (item.GetType() == typeof(Book)) item.IsA = false;

        var newRent = new ItemRental(item, user);
        _itemRentals.Add(newRent);
        return true;
    }

    public bool ReturnItem(int itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            Console.WriteLine($"Item with id {itemId} not found");
            return false;
        }
        
        var rental = _itemRentals.FirstOrDefault(r => r.Item.Id == itemId);
        if (rental == null)
        {
            Console.WriteLine($"Rental with id {itemId} not found");
            return false;
        }
        
        rental.Returned = true;
        item.IsA = true;
        return true;
    }

    public IEnumerable<LibraryItem> GetItems()
    {
        return _items;
    }

    public IEnumerable<ItemRental> GetRentals()
    {
        return _itemRentals;
    }

    public IEnumerable<User> GetUsers()
    {
        return  _users;
    }
}