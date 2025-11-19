namespace Domain;

public class Book : LibraryItem
{
    public string Author { get; set; }
    public string Isbn { get; set; }
    
    public Book(int id, string title, string author, string isbn) : base(id, title)
    {   
        Author = author;
        Isbn = isbn;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("────────────────────────────────────────");
        Console.WriteLine("  TYPE: BOOK");
        Console.WriteLine($"    ID: {Id}");
        Console.WriteLine($" Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"  ISBN: {Isbn}");
        Console.WriteLine($"Status: {(IsA ? "RESERVED" : "AVAILABLE")}");
        Console.WriteLine("────────────────────────────────────────");
    }
}