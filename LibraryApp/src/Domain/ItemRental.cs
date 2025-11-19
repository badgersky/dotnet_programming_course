namespace Domain;

public class ItemRental
{
    public int UserId { get; }
    public int ItemId { get; }
    public DateTime RTimestamp { get; }

    public ItemRental(int userId, int itemId)
    {
        UserId = userId;
        ItemId = itemId;
        RTimestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Item ID: {ItemId}, User ID: {UserId}";
    }
}