using Domain;

namespace Services;

public interface ILibraryService
{
    bool AddItem(string title, string author, string isbn = "", string format = "");
    bool AddUser(string username);
    bool RentItem(int itemId, int userId);
    bool ReturnItem(int itemId);
    IEnumerable<LibraryItem> GetItems();
    IEnumerable<ItemRental> GetRentals();
    IEnumerable<User> GetUsers();
}