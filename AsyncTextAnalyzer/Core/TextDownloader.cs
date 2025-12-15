namespace Core;

public class TextDownloader : ITextDownloader
{
    private readonly HttpClient _client;

    public TextDownloader()
    {
        _client = new HttpClient();
    }

    public async Task<string> Download(string url)
    {
        var resp = await _client.GetAsync(url);

        if (!resp.IsSuccessStatusCode)
        {
            Console.WriteLine($"Failed to download content from {url}");
            return string.Empty;
        }
        
        return await resp.Content.ReadAsStringAsync();
    }

    public async Task<Dictionary<string, string>> DownloadMany(IEnumerable<string> urls)
    {
        var results = new Dictionary<string, string>();
        var tasks = new List<Task>();

        foreach (var url in urls)
        {
            var task = Task.Run(async () =>
            {
                var content = await Download(url);
                if (!string.IsNullOrEmpty(content))
                {
                    lock (results)
                    {
                        results.Add(url, content);
                    }
                }
            });
            
            tasks.Add(task);
        }
        
        await Task.WhenAll(tasks);
        return results;
    }
}