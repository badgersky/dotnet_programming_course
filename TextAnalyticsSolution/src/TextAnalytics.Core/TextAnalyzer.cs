namespace TextAnalytics.Core;

public interface ITextAnalyzer
{
    public AnalysisRecord Analyze(string text);
    protected int CountCharacters(string text);
    protected int CountCharactersNoSpaces(string text);
    protected int CountLetters(string text);
    protected int CountDigits(string text);
    protected int CountPunctuation(string text);
    protected int CountWords(string text);
    protected int CountUniqueWords(string text);
    protected string MostCommonWord(string text);
    protected float AvgWordLength(string text);
    protected string LongestWord(string text);
    protected string ShortestWord(string text);
    protected int CountSentences(string text);
    protected float AvgWordsPerSentence(string text);
    protected string LongestSentence(string text);
}

public class TextAnalyzer : ITextAnalyzer
{
    public AnalysisRecord Analyze(string text)
    {
        throw new NotImplementedException();
    }

    public int CountCharacters(string text)
    {
        return text.Length;
    }

    public int CountCharactersNoSpaces(string text)
    {
        return text.Replace(" ", "").Length;
    }

    public int CountLetters(string text)
    {
        return text.Count(char.IsLetter);
    }

    public int CountDigits(string text)
    {
        return text.Count(char.IsDigit);
    }

    public int CountPunctuation(string text)
    {
        return text.Count(char.IsPunctuation);
    }

    public int CountWords(string text)
    {
        throw new NotImplementedException();
    }

    public int CountUniqueWords(string text)
    {
        throw new NotImplementedException();
    }

    public string MostCommonWord(string text)
    {
        throw new NotImplementedException();
    }

    public float AvgWordLength(string text)
    {
        throw new NotImplementedException();
    }

    public string LongestWord(string text)
    {
        throw new NotImplementedException();
    }

    public string ShortestWord(string text)
    {
        throw new NotImplementedException();
    }

    public int CountSentences(string text)
    {
        throw new NotImplementedException();
    }

    public float AvgWordsPerSentence(string text)
    {
        throw new NotImplementedException();
    }

    public string LongestSentence(string text)
    {
        throw new NotImplementedException();
    }
}