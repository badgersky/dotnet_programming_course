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
        var books = await downloadService.DownloadMany(urls);

        
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IInputService, InputService>();
        services.AddSingleton<ITextDownloader, TextDownloader>();
        services.AddSingleton<IAnalyzeService, AnalyzeService>();
    }
}