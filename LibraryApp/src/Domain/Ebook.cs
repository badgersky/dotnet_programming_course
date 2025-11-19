namespace Domain;

public class Ebook : LibraryItem
{
    public string Author { get;  set; }
    public string Format { get;  set; }
    
    
    public Ebook(int id, string title, string format, string author) : base(id, title)
    {
        Author = author.Trim();
        Format = format.Trim();
        
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("  TYPE: E-BOOK");
        Console.WriteLine($"    ID: {Id}");
        Console.WriteLine($" Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Format: {Format}");
        Console.WriteLine($"Status: {(IsA  ? "AVAILABLE" : "RENTED")}");
        Console.WriteLine("-----------------------------------------");
    }
}