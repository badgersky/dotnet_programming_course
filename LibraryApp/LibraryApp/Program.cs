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

        Console.WriteLine("════════════════════════════════════");
        Console.WriteLine("           L I B R A R Y");
        Console.WriteLine("════════════════════════════════════");
        
        while (true)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add E-Book");
            Console.WriteLine("3. Add user");
            Console.WriteLine("4. Rent item");
            Console.WriteLine("5. Return item");
            Console.WriteLine("6. List of items");
            Console.WriteLine("7. List of active rentals");
            Console.WriteLine("8. List of users");
            Console.WriteLine("0. Quit");
            Console.Write("\nChose: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": ABook(libraryS, inputS); break;
                case "2": AEBook(libraryS, inputS); break;
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

    private static void AEBook(ILibraryService libraryS, IUserInputService inputS)
    {
        throw new NotImplementedException();
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
            Console.WriteLine(user.Username);
        }
    }

    private static void ShowR(ILibraryService library)
    {
        throw new NotImplementedException();
    }

    private static void ShowI(ILibraryService library)
    {
        throw new NotImplementedException();
    }

    private static void ReturnI(ILibraryService library, IUserInputService input)
    {
        throw new NotImplementedException();
    }

    private static void RentI(ILibraryService library, IUserInputService input)
    {
        throw new NotImplementedException();
    }

    private static void AUser(ILibraryService library, IUserInputService input)
    {
        throw new NotImplementedException();
    }

    private static void ABook(ILibraryService library, IUserInputService input)
    {
        throw new NotImplementedException();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ILibraryService, LibraryService>();
        services.AddSingleton<IUserInputService, UserInputService>();
    }
}