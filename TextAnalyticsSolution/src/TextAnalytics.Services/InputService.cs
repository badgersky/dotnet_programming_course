namespace TextAnalytics.Services;

public interface IInputService
{
    string ReadFromConsole();
}

public class InputService : IInputService
{
    public string ReadFromConsole()
    {
        string? ans;
        var result = "";
        string? line;
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
            // reading from file
            return "FILE CONTENT";
        }

        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            result += line + Environment.NewLine;
        }

        return result;
    }
}