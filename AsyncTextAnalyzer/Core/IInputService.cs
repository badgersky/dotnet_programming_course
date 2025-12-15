namespace Core;

public interface IInputService
{
    string ReadPath();
    Task<IEnumerable<string>> ReadUrls(string path);
    bool IsValidUrl(string url);
}