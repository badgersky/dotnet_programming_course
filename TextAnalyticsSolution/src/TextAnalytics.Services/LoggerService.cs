using Serilog;

namespace TextAnalytics.Services;

public interface ILoggerService
{
    public void Info(string message);
    public void Error(string message);
    public void Warning(string message);
}

public class LoggerService : ILoggerService
{
    static LoggerService()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }
    
    public void Info(string message)
    {
        Log.Information(message);
    }

    public void Error(string message)
    {
        Log.Error(message);
    }

    public void Warning(string message)
    {
        Log.Warning(message);
    }
}