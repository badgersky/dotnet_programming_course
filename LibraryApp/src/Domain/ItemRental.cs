namespace Domain;

public class ItemRental
{
    public int UserId { get; }
    public int ItemId { get; }

    public ItemRental(int userId, int itemId)
    {
        UserId = userId;
        ItemId = itemId;
    }

    public override string ToString()
    {
        return $"Item ID: {ItemId}, User ID: {UserId}";
    }
}