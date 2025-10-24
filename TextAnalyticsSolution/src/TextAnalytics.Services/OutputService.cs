using Newtonsoft.Json;
using TextAnalytics.Core;

namespace TextAnalytics.Services;

public interface IOutputService
{
    public void WriteResult(AnalysisRecord record);
}

public class OutputService : IOutputService
{
    public void WriteResult(AnalysisRecord record)
    {
        WriteToConsole(record);
        WriteToFile(record);
    }

    private void WriteToConsole(AnalysisRecord record)
    {
        Console.WriteLine("=== Text Analysis Result ===");
        Console.WriteLine($"Character Count: {record.CharacterCount}");
        Console.WriteLine($"Character Count (No Spaces): {record.CharacterCountNoSpaces}");
        Console.WriteLine($"Letter Count: {record.LetterCount}");
        Console.WriteLine($"Digit Count: {record.DigitCount}");
        Console.WriteLine($"Punctuation Count: {record.PunctuationCount}");
        Console.WriteLine($"Word Count: {record.WordCount}");
        Console.WriteLine($"Unique Word Count: {record.UniqueWordCount}");
        Console.WriteLine($"Most Common Word: {record.MostCommonWord}");
        Console.WriteLine($"Average Word Length: {record.AvgWordLength:F2}");
        Console.WriteLine($"Longest Word: {record.LongestWord}");
        Console.WriteLine($"Shortest Word: {record.ShortestWord}");
        Console.WriteLine($"Sentence Count: {record.SentenceCount}");
        Console.WriteLine($"Average Words per Sentence: {record.AvgWordsPerSentence:F2}");
        Console.WriteLine($"Longest Sentence: {record.LongestSentence}");
        Console.WriteLine("============================");
    }

    private void WriteToFile(AnalysisRecord record)
    {
        string json = JsonConvert.SerializeObject(record, Formatting.Indented);
        File.WriteAllText("result.json", json);
    }
}