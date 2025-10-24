namespace TextAnalytics.Core;

public record AnalysisRecord(
    int CharacterCount,
    int CharacterCountNoSpaces,
    int LetterCount,
    int DigitCount,
    int PunctuationCount,
    int WordCount,
    int UniqueWordCount,
    string MostCommonWord,
    float AvgWordLength,
    string LongestWord,
    string ShortestWord,
    int SentenceCount,
    float AvgWordsPerSentence,
    string LongestSentence
    );