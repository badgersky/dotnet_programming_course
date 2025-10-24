namespace TextAnalytics.Services;

public interface IInputService
{
    string ReadFromConsole();
    string ReadFromFile(string? filePath = null);
}

public class InputService : IInputService
{
    public string ReadFromFile(string? filePath = null)
    {
        if (filePath == null)
        {
            Console.WriteLine("Enter valid path to a file:");
            filePath = Console.ReadLine();
        }

        if (File.Exists(filePath)) return File.ReadAllText(filePath);
            
        Console.WriteLine("File does not exist");
        Environment.Exit(1);
        return string.Empty;
    }

    public string ReadFromConsole()
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
            return ReadFromFile();
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