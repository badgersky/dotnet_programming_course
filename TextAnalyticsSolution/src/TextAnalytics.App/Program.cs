using Microsoft.Extensions.DependencyInjection;
using TextAnalytics.Services;

namespace TextAnalytics.App 
{
    internal abstract class Program
    {

        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var inputService = serviceProvider.GetService<IInputService>();
            
            var filePath = ReadArgs(args);
            var text = inputService?.ReadText(filePath);
            
            Console.Write(text);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IInputService, InputService>();
        }

        private static string? ReadArgs(string[] args)
        {
            string? filePath = null;
            
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "--help" || args[i] == "-h")
                    {
                        ShowHelp();
                    }

                    if (args[i] == "--file" || args[i] == "-f")
                    {
                        if (i + 1 < args.Length)
                        {
                            filePath = args[i + 1];
                        }
                        else
                        {
                            Console.WriteLine("No file specified");
                            Environment.Exit(1);
                        }

                        break;
                    }

                    if (args[i] == "--interactive" || args[i] == "-i")
                    {
                        break;
                    }

                }
            }
            
            return filePath;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("--interactive/-i - reads text or path to a file from stdin");
            Console.WriteLine("--file/-f <path> - reads text from file, path must be valid path to an existing file");
            Console.WriteLine("--help/-h - shows this help");
        }
    }
}