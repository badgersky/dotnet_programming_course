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
}