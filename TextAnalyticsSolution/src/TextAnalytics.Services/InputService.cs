namespace TextAnalytics.Services;

public interface IInputService
{
    string ReadText(string? filePath);
}

public class InputService : IInputService
{
    public string ReadText(string? filePath = null)
    {
        return filePath == null ? ReadFromConsole() : ReadFromFile(filePath);
    }

    private static string ReadFromFile(string filePath)
    {
        if (File.Exists(filePath)) return File.ReadAllText(filePath);
            
        Console.WriteLine("File does not exist");
        Environment.Exit(1);
        return string.Empty;
    }

    private static string ReadFromConsole()
    {
        string? ans;
        var result = "";
        while (true)
        {   
            Console.WriteLine("Do you want to load text from file? y/n");
            ans = Console.ReadLine();
            if (ans != "y" && ans != "n")
            {
                Console.WriteLine("Enter y or n");
            }
            else
            {
                break;
            }
        }

        if (ans == "y")
        {
            string? filePath = null;
            while (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Enter valid path to a file:");
                filePath = Console.ReadLine();
            }

            filePath = filePath.Trim();
            return ReadFromFile(filePath);
        }

        Console.WriteLine("Enter text to analyze:");
        Console.WriteLine("Double press enter when finished");
        while (true)
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            result += line + Environment.NewLine;
        }

        return result;
    }
}