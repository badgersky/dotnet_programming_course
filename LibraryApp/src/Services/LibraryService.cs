using Domain;

namespace Services;

public class LibraryService : ILibraryService
{
    
    
    public void AddItem(LibraryItem item)
    {
        throw new NotImplementedException();
    }

    public void AddUser(User u)
    {
        throw new NotImplementedException();
    }

    public void RentItem(int itemId, int uId)
    {
        throw new NotImplementedException();
    }

    public void ReturnItem(int itemId, int uId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LibraryItem> GetItems()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ItemRental> GetRentals()
    {
        throw new NotImplementedException();
    }
}