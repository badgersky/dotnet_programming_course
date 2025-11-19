namespace Domain;

public abstract class LibraryItem
{
    public int Id { get; set; }
    public string Title { get; protected set; }
    public bool IsA { get; protected set; } = true;

    protected LibraryItem(int id, string title)
    {
        Id = id;
        Title = title.Trim();
    }
    
    public abstract void DisplayInfo();
}