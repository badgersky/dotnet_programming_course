namespace Core;

public interface IAnalyzeService
{
    string NormalizeText(string text);
    Dictionary<string, int> CountWords(string text);
}