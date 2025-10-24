namespace TextAnalytics.Services;

public class InputService
{
    private string ReadFromConsole()
    {
        string? ans;
        string result = "";
        string? line;
        while (true)
        {   
            Console.WriteLine("Do you want to load text from file? y/n");
            ans = Console.ReadLine();
            if (ans != "y" || ans != "n")
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