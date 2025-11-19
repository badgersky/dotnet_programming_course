using Domain;

namespace Services;

public interface ILibraryService
{
    void AddItem(LibraryItem item);
    void AddUser(User u);
    void RentItem(int itemId, int uId);
    void ReturnItem(int itemId, int uId);
    IEnumerable<LibraryItem> GetItems();
    IEnumerable<ItemRental> GetRentals();
}