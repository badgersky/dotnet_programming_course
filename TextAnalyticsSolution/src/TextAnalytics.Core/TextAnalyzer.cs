namespace TextAnalytics.Core;

public interface ITextAnalyzer
{
    public int CountCharacters(string text);
    public int CountCharactersNoSpaces(string text);
    public int CountLetters(string text);
    public int CountDigits(string text);
    public int CountPunctuation(string text);
    public int CountWords(string text);
    public int CountUniqueWords(string text);
    public string MostCommonWord(string text);
    public float AvgWordLength(string text);
    public string LongestWord(string text);
    public string ShortestWord(string text);
    public int CountSentences(string text);
    public float AvgWordsPerSentence(string text);
    public string LongestSentence(string text);
}

public class TextAnalyzer
{
    
}