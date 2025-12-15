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

        if (inputService == null)
        {
            return;
        }

        var path = inputService.ReadPath();
        var urls = await inputService.ReadUrls(path);
        foreach (var url in urls)
        {
            Console.WriteLine(url);
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IInputService, InputService>();
    }
}