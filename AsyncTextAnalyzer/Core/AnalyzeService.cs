using System.Text.RegularExpressions;

namespace Core;

public class AnalyzeService : IAnalyzeService
{
    public string NormalizeText(string text)
    {
        text = text.ToLower();
        text = Regex.Replace(text, @"[^\p{L}\s]", " ");
        return text;
    }

    public Dictionary<string, int> CountWords(string text)
    {
        var result = new Dictionary<string, int>();
        var words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (result.ContainsKey(word))
            {
                result[word]++;
            }
            else
            {
                result.Add(word, 1);
            }
        }
        
        return result;
    }
}