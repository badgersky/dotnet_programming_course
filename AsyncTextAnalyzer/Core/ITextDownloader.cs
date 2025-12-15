namespace Core;

public interface ITextDownloader
{
    Task<string> Download(string url);
    Task<Dictionary<string, string>> DownloadMany(IEnumerable<string> urls);
}