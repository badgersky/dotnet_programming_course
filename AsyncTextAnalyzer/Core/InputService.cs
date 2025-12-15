namespace Core;

public class InputService : IInputService
{
    public string ReadPath()
    {
        while (true)
        {
            Console.WriteLine("Enter valid path to file with urls: ");
            var path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Path cannot be empty");
                continue;
            }
            
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
            }
            else
            {
                return path.Trim();
            }
        }
    }

    public async Task<IEnumerable<string>> ReadUrls(string path)
    {
        var lines = await File.ReadAllLinesAsync(path); 
        
        return lines.Select(l => l.Trim()).Where(l => !string.IsNullOrWhiteSpace(l)).Where(IsValidUrl);
    }

    public bool IsValidUrl(string url)
    {
        if (!url.StartsWith("https://www.gutenberg.org/"))
        {
            return false;
        }
        
        return true;
    }
}