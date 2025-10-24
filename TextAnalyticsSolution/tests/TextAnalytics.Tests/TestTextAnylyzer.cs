using TextAnalytics.Core;

namespace TextAnalytics.Tests;

public class TextAnalyzerTests
{
    private TextAnalyzer _analyzer;

    [SetUp]
    public void Setup()
    {
        _analyzer = new TextAnalyzer();
    }

    [Test]
    public void TestCountCharacters1()
    {
        Assert.That(_analyzer.CountCharacters("abc"), Is.EqualTo(3));
    }
    
    [Test]
    public void TestCountCharacters2()
    {
        Assert.That(_analyzer.CountCharacters("abc\"\n\n..."), Is.EqualTo(9));
    }
    
    [Test]
    public void TestCountCharacters3()
    {
        Assert.That(_analyzer.CountCharacters(""), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountCharacters4()
    {
        Assert.That(_analyzer.CountCharacters("a b c"), Is.EqualTo(5));
    }
    
    [Test]
    public void TestCountCharacters5()
    {
        Assert.That(_analyzer.CountCharacters("\t\t\t "), Is.EqualTo(4));
    }
    
    [Test]
    public void TestCountCharactersNoSpaces1()
    {
        Assert.That(_analyzer.CountCharactersNoSpaces("a b c"), Is.EqualTo(3));
    }
    
    [Test]
    public void TestCountCharactersNoSpaces2()
    {
        Assert.That(_analyzer.CountCharactersNoSpaces("abc"), Is.EqualTo(3));
    }
    
    
    [Test]
    public void TestCountCharactersNoSpaces3()
    {
        Assert.That(_analyzer.CountCharactersNoSpaces("   "), Is.EqualTo(0));
    }
    
    
    [Test]
    public void TestCountCharactersNoSpaces4()
    {
        Assert.That(_analyzer.CountCharactersNoSpaces("\t\t\t"), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountCharactersNoSpaces5()
    {
        Assert.That(_analyzer.CountCharactersNoSpaces("\ta\tb\tc."), Is.EqualTo(4));
    }
    
    [Test]
    public void TestCountLetters1()
    {
        Assert.That(_analyzer.CountLetters("123abc345"), Is.EqualTo(3));
    }
    
    [Test]
    public void TestCountLetters2()
    {
        Assert.That(_analyzer.CountLetters("123"), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountLetters3()
    {
        Assert.That(_analyzer.CountLetters("123 ..."), Is.EqualTo(0));
    }

    [Test]
    public void TestCountLetters4()
    {
        Assert.That(_analyzer.CountLetters(""), Is.EqualTo(0));
    }

    [Test]
    public void TestCountDigits1()
    {
        Assert.That(_analyzer.CountDigits("1234cxc"), Is.EqualTo(4));
    }

    [Test]
    public void TestCountDigits2()
    {
        Assert.That(_analyzer.CountDigits("abc. "), Is.EqualTo(0));
    }

    [Test]
    public void TestCountDigits3()
    {
        Assert.That(_analyzer.CountDigits("1\t2"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountDigits4()
    {
        Assert.That(_analyzer.CountDigits("1abc\n\n2"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountPunctuation1()
    {
        Assert.That(_analyzer.CountPunctuation("dzien dobry. ///"), Is.EqualTo(4));
    }
    
    [Test]
    public void TestCountPunctuation2()
    {
        Assert.That(_analyzer.CountPunctuation("dzien dobry."), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountPunctuation3()
    {
        Assert.That(_analyzer.CountPunctuation("dzien-dobry."), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountPunctuation4()
    {
        Assert.That(_analyzer.CountPunctuation("!@.."), Is.EqualTo(4));
    }
    
    [Test]
    public void TestCountWords()
    {
        Assert.That(_analyzer.CountWords("siema siema. o tej porze..."), Is.EqualTo(5));
    }
    
    [Test]
    public void TestCountWords2()
    {
        Assert.That(_analyzer.CountWords(""), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountWords3()
    {
        Assert.That(_analyzer.CountWords("dzien Dobry"), Is.EqualTo(2));
    }

    [Test]
    public void TestCountWords4()
    {
        Assert.That(_analyzer.CountWords("123asd...caks 1289wadsdw;p12"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountWords5()
    {
        Assert.That(_analyzer.CountWords("jednodlugieslowo"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountUniqueWords1()
    {
        Assert.That(_analyzer.CountUniqueWords("dzien dzien dzien"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountUniqueWords2()
    {
        Assert.That(_analyzer.CountUniqueWords("dzien dobry Dzien Dobry"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountUniqueWords3()
    {
        Assert.That(_analyzer.CountUniqueWords(""), Is.EqualTo(0));
    }

    [Test]
    public void TestCountUniqueWords4()
    {
        Assert.That(_analyzer.CountUniqueWords("jednoslowo"), Is.EqualTo(1));
    }

    [Test]
    public void TestCountUniqueWords5()
    {
        Assert.That(_analyzer.CountUniqueWords("Example. Text with many words. Words WORDS words."), Is.EqualTo(5));
    }
    
    [Test]
    public void TestMostCommonWords1()
    {
        Assert.That(_analyzer.MostCommonWord("Example. Text with many words. Words WORDS words."), Is.EqualTo("words"));
    }
    
    [Test]
    public void TestMostCommonWords2()
    {
        Assert.That(_analyzer.MostCommonWord("word words"), Is.EqualTo("word"));
    }
    
    [Test]
    public void TestMostCommonWords3()
    {
        Assert.That(_analyzer.MostCommonWord("Sentence 1. Sentence 2. Sentence 3.\n"), Is.EqualTo("sentence"));
    }
    
    [Test]
    public void TestMostCommonWords4() 
    {
        Assert.That(_analyzer.MostCommonWord(""), Is.EqualTo(""));
    }
    
    [Test]
    public void TestMostCommonWords5()
    {
        Assert.That(_analyzer.MostCommonWord("      \t\t\t\n\n"), Is.EqualTo(""));
    }
    
    [Test]
    public void TestAvgWordLength1()
    {
        Assert.That(_analyzer.AvgWordLength("Zdanie zdanie zdanie zdanie zdanie."), Is.EqualTo(6));
    }
    
    [Test]
    public void TestAvgWordLength2()
    {
        Assert.That(_analyzer.AvgWordLength(""), Is.EqualTo(0));
    }
    
    [Test]
    public void TestAvgWordLength3()
    {
        Assert.That(_analyzer.AvgWordLength(".....----!!!!....?"), Is.EqualTo(0));
    }

    [Test]
    public void TestLongestWord1()
    {
        Assert.That(_analyzer.LongestWord("Couple words and one thelongestword."), Is.EqualTo("thelongestword"));
    }

    [Test]
    public void TestLongestWord2()
    {
        Assert.That(_analyzer.LongestWord(".....---??!"), Is.EqualTo(""));
    }
    
    [Test]
    public void TestLongestWord3()
    {
        Assert.That(_analyzer.LongestWord("..word...---??!"), Is.EqualTo("word"));
    }

    [Test]
    public void TestLongestWord4()
    {
        Assert.That(_analyzer.LongestWord("word"), Is.EqualTo("word"));
    }

    [Test]
    public void TestLongestWord5()
    {
        Assert.That(_analyzer.LongestWord(""), Is.EqualTo(""));
    }

    [Test]
    public void TestShortestWord1()
    {
        Assert.That(_analyzer.ShortestWord(""), Is.EqualTo(""));
    }
    
    [Test]
    public void TestShortestWord2()
    {
        Assert.That(_analyzer.ShortestWord("lol couple words."), Is.EqualTo("lol"));
    }

    [Test]
    public void TestShortestWord3()
    {
        Assert.That(_analyzer.ShortestWord(".....word ---- ???longer"), Is.EqualTo("word"));
    }

    [Test]
    public void TestShortestWord4()
    {
        Assert.That(_analyzer.ShortestWord("Siema siema o tej porze..."), Is.EqualTo("o"));
    }
    
    [Test]
    public void TestShortestWord5()
    {
        Assert.That(_analyzer.ShortestWord("1 2 3 4 5 6"), Is.EqualTo("1"));
    }
    
    [Test]
    public void TestCountSentences1()
    {
        Assert.That(_analyzer.CountSentences("Siema siema o tej porze..."), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountSentences2()
    {
        Assert.That(_analyzer.CountSentences("Siema siema o tej porze."), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountSentences3()
    {
        Assert.That(_analyzer.CountSentences("Siema siema o tej porze.\n\n"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestCountSentences4()
    {
        Assert.That(_analyzer.CountSentences("Siema siema o tej porze. Kazdy wypic moze!"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestCountSentences5()
    {
        Assert.That(_analyzer.CountSentences("Siema. Siema! O. Tej. Porze? Kazdy?\n\n"), Is.EqualTo(6));
    }
    
    [Test]
    public void TestCountSentences6()
    {
        Assert.That(_analyzer.CountSentences(""), Is.EqualTo(0));
    }
    
    [Test]
    public void TestCountSentences7()
    {
        Assert.That(_analyzer.CountSentences("Jedno zdanie bez kropki"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAvgWordsPerSentence1()
    {
        Assert.That(_analyzer.AvgWordsPerSentence("Siema. Siema! O. Tej. Porze? Kazdy?\n\n"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestAvgWordsPerSentence2()
    {
        Assert.That(_analyzer.AvgWordsPerSentence(""), Is.EqualTo(0));
    }

    [Test]
    public void TestAvgWordsPerSentence3()
    {
        Assert.That(_analyzer.AvgWordsPerSentence("Jedno zdanie"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestAvgWordsPerSentence4()
    {
        Assert.That(_analyzer.AvgWordsPerSentence("Sentence 1. Sentence 2! Sentence 3"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestLongestSentence1()
    {
        Assert.That(_analyzer.LongestSentence("Sentence 1. Sentence 2! Sentence 3"), Is.EqualTo("Sentence 1"));
    }
    
    [Test]
    public void TestLongestSentence2()
    {
        Assert.That(_analyzer.LongestSentence("Sentence 1. Sentence 2 and 3."), Is.EqualTo("Sentence 2 and 3"));
    }
    
    [Test]
    public void TestLongestSentence3()
    {
        Assert.That(_analyzer.LongestSentence("One sentence"), Is.EqualTo("One sentence"));
    }
    
    [Test]
    public void TestLongestSentence4()
    {
        Assert.That(_analyzer.LongestSentence(""), Is.EqualTo(""));
    }
    
    [Test]
    public void TestLongestSentence5()
    {
        Assert.That(_analyzer.LongestSentence("Sentence 1\n\nsentence2."), Is.EqualTo("Sentence 1\n\nsentence2"));
    }
    
    [Test]
    public void TestLongestSentence6()
    {
        Assert.That(_analyzer.LongestSentence("Siema - stary."), Is.EqualTo("Siema - stary"));
    }
}