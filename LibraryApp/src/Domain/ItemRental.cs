namespace Domain;

public class ItemRental
{
    public LibraryItem Item { get; }
    public User User { get; }
    public DateTime RTimestamp { get; }
    public bool Returned;

    public ItemRental(LibraryItem item, User user)
    {
        Item = item;
        User = user;
        Returned = false;
        RTimestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Item ID: {Item.Id}, User ID: {User.Id}";
    }
}