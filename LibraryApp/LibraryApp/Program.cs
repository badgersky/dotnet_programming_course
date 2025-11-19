using Microsoft.Extensions.DependencyInjection;
using Services;

namespace LibraryApp;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider =  services.BuildServiceProvider();

        var inputS = serviceProvider.GetService<IUserInputService>();
        var libraryS = serviceProvider.GetService<ILibraryService>();

        if (inputS == null || libraryS == null)
        {
            return;
        }

        Console.WriteLine("------------------------------------");
        Console.WriteLine("           L I B R A R Y");
        Console.WriteLine("------------------------------------");
        
        while (true)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add E-Book");
            Console.WriteLine("3. Add user");
            Console.WriteLine("4. Rent item");
            Console.WriteLine("5. Return item");
            Console.WriteLine("6. List of items");
            Console.WriteLine("7. List of active rentals");
            Console.WriteLine("8. List of users");
            Console.WriteLine("0. Quit");
            Console.WriteLine("-----------------------------------------");
            Console.Write("\nChose: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": ABook(libraryS, inputS); break;
                case "2": AeBook(libraryS, inputS); break;
                case "3": AUser(libraryS, inputS); break;
                case "4": RentI(libraryS, inputS); break;
                case "5": ReturnI(libraryS, inputS); break;
                case "6": ShowI(libraryS); break;
                case "7": ShowR(libraryS); break;
                case "8": ShowU(libraryS); break;
                case "0":
                    Console.WriteLine("See ya later alligator!");
                    return;
                default:
                    Console.WriteLine("Wrong option");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    private static void AeBook(ILibraryService library, IUserInputService input)
    {
        var title = input.ReadString("Title: ");
        var author = input.ReadString("Author: ");
        var format = input.ReadFormat("Format: ");
        
        library.AddItem(title, author, "", format);
        Console.WriteLine("E-Book added");
    }

    private static void ShowU(ILibraryService library)
    {
        var users = library.GetUsers();
        var enumerable = users.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("No users");
        }

        foreach (var user in enumerable)
        {
            user.DisplayInfo();
        }
    }

    private static void ShowR(ILibraryService library)
    {
        var rentals =  library.GetRentals();
        var enumerable = rentals.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("No rentals");
        }

        foreach (var rental in enumerable)
        {
            if (!rental.Returned)
            {
                Console.WriteLine(rental);
            }
        }

    }

    private static void ShowI(ILibraryService library)
    {
        var items = library.GetItems();
        var enumerable = items.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("No items");
        }

        foreach (var item in enumerable)
        {
            item.DisplayInfo();
        }
    }

    private static void ReturnI(ILibraryService library, IUserInputService input)
    {
        int itemId = input.ReadInt("ItemId: ");
        
        library.ReturnItem(itemId);
    }

    private static void RentI(ILibraryService library, IUserInputService input)
    {
        int itemId = input.ReadInt("ItemId: ");
        int userId = input.ReadInt("UserId: ");
        
        library.RentItem(itemId, userId);
    }

    private static void AUser(ILibraryService library, IUserInputService input)
    {
        string username = input.ReadString("Username: ");

        library.AddUser(username);
    }

    private static void ABook(ILibraryService library, IUserInputService input)
    {
        var title =  input.ReadString("Title: ");
        var author = input.ReadString("Author: ");
        var isbn  = input.ReadIsbn("Isbn: ");
        
        library.AddItem(title, author, isbn);
        Console.WriteLine("Book added");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ILibraryService, LibraryService>();
        services.AddSingleton<IUserInputService, UserInputService>();
    }
}