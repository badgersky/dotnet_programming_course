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
    protected string[] GetWords(string text);
    protected string[] GetSentences(string text);
}

public class TextAnalyzer : ITextAnalyzer
{
    private const string Punctuation = "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";

    public AnalysisRecord Analyze(string text)
    {
        return new AnalysisRecord(
            CharacterCount: CountCharacters(text),
            CharacterCountNoSpaces: CountCharactersNoSpaces(text),
            LetterCount: CountLetters(text),
            DigitCount: CountDigits(text),
            PunctuationCount: CountPunctuation(text),
            WordCount: CountWords(text),
            UniqueWordCount: CountUniqueWords(text),
            MostCommonWord: MostCommonWord(text),
            AvgWordLength: AvgWordLength(text),
            LongestWord: LongestWord(text),
            ShortestWord: ShortestWord(text),
            SentenceCount: CountSentences(text),
            AvgWordsPerSentence: AvgWordsPerSentence(text),
            LongestSentence: LongestSentence(text)
        );
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
        var words = GetWords(text);
        
        return words.Length;
    }

    public int CountUniqueWords(string text)
    {
        var words = GetWords(text);
        
        var hashWords = new HashSet<string>(words);
        return hashWords.Count;
    }

    public string MostCommonWord(string text)
    {
        var words = GetWords(text);

        var wordCounts = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }
        
        return wordCounts.OrderByDescending(x => x.Value).First().Key;
    }

    public float AvgWordLength(string text)
    {
        int wordNum = CountWords(text);
        int letterNum = CountLetters(text);
        
        if (wordNum == 0) return 0f;
        
        return letterNum / (float)wordNum;
    }

    public string LongestWord(string text)
    {
        var words = GetWords(text);
        var longestWord = "";
        int longestLength = 0;
        
        foreach (var word in words)
        {
            if (word.Length > longestLength)
            {
                longestLength = word.Length;
                longestWord = word;
            }    
        }

        return longestWord;
    }

    public string ShortestWord(string text)
    {
        var words = GetWords(text);
        var shortestWord = "";
        int shortestLength = words[0].Length;

        foreach (var word in words)
        {
            if (word.Length < shortestLength)
            {
                shortestWord = word;
                shortestLength = word.Length;
            }
        }
        
        return shortestWord;
    }

    public int CountSentences(string text)
    {
        var sentences = GetSentences(text);
        return sentences.Length;
    }

    public float AvgWordsPerSentence(string text)
    {
        int sNum = CountSentences(text);
        int wordNum = CountWords(text);
        
        if (sNum == 0) return 0f;
        
        return wordNum / (float)sNum;
    }

    public string LongestSentence(string text)
    {
        var sentences = GetSentences(text);
        int longestSentenceWordCount = 0;
        string longestSentence = "";
        
        foreach (var sentence in sentences)
        {
            if (CountWords(sentence) > longestSentenceWordCount)
            {
                longestSentence = sentence;
                longestSentenceWordCount = CountWords(sentence);
            }
        }
        
        return longestSentence;
    }

    public string[] GetSentences(string text)
    {
        string[] notSentence = { "dr.", "prof.", "mgr.", "np.", "itd.", "itp.", "tj.", "tzn." };

        foreach (var s in notSentence)
        {
            text = text.Replace(s, s.Replace(".", "[DOT]"));
        }
        
        var sentences = text.Split(new[] {'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = sentences[i].Replace("[DOT]", ".");
        }
        
        return sentences;
    }
    
    public string[] GetWords(string text)
    {
        foreach (var c in Punctuation)
        {
            text = text.Replace(c.ToString(), "");
        }
        
        char[] whiteSpace = [' ', '\t', '\n'];
        string[] words  = text.ToLower().Split(whiteSpace,  StringSplitOptions.RemoveEmptyEntries);
        
        return words;
    }
}