using System.Collections.Concurrent;
using System.Diagnostics;
using Core;
using Microsoft.Extensions.DependencyInjection;

namespace App;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        var inputService = serviceProvider.GetService<IInputService>();
        var downloadService = serviceProvider.GetService<ITextDownloader>();
        var analyzeService = serviceProvider.GetService<IAnalyzeService>();
        
        if (inputService == null || downloadService == null || analyzeService == null)
        {
            Console.WriteLine("Services not created properly, closing the program...");
            return;
        }
        
        var path = inputService.ReadPath();
        var urls = await inputService.ReadUrls(path);
        
        var swDownload = Stopwatch.StartNew();
        var books = await downloadService.DownloadMany(urls);
        swDownload.Stop();
        
        var swAnalyze = Stopwatch.StartNew();
        var globalCounts = new ConcurrentDictionary<string, int>();
        Parallel.ForEach(books.Values, text =>
            {
                var normalized = analyzeService.NormalizeText(text);
                var localCounts = analyzeService.CountWords(normalized);

                foreach (var kv in localCounts)
                {
                    globalCounts.AddOrUpdate(kv.Key, kv.Value, (_, v) => v + kv.Value);
                }
            });
        swAnalyze.Stop();
        
        Console.WriteLine("\n10 most frequently used words:");
        foreach (var kv in globalCounts.OrderByDescending(kv => kv.Value).Take(10))
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        }
        
        Console.WriteLine($"Download time: {swDownload.Elapsed.TotalSeconds:F2}s");
        Console.WriteLine($"Analyze time: {swAnalyze.Elapsed.TotalSeconds:F2}s");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IInputService, InputService>();
        services.AddSingleton<ITextDownloader, TextDownloader>();
        services.AddSingleton<IAnalyzeService, AnalyzeService>();
    }
}