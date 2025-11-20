using Services;

namespace LibraryAppTests;

public class UserInputServiceTests
{
    private UserInputService _s;
    private TextWriter _originalOut;
    private TextReader _originalIn;
    private StringWriter _fakeOutput;
    private StringReader? _fakeInput;

    [SetUp]
    public void Setup()
    {
        _s = new UserInputService();
        _originalOut = Console.Out;
        _originalIn  = Console.In;
        _fakeOutput  = new StringWriter();
        _fakeInput = null;
        Console.SetOut(_fakeOutput);
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_originalOut);
        Console.SetIn(_originalIn);
        _fakeOutput.Dispose();
        _fakeInput?.Dispose();
    }
    
    private void SetInput(params string[] lines)
    {
        _fakeInput = new StringReader(string.Join(Environment.NewLine, lines));
        Console.SetIn(_fakeInput);
    }

    [Test]
    public void TestReadString1()
    {
        SetInput("  ", "", "username");
        var res = _s.ReadString("Username: ");
        Assert.That(res, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestReadString2()
    {
        SetInput("  ", "", "  username  ");
        var res = _s.ReadString("Username: ");
        Assert.That(res, Is.EqualTo("username"));
    }
    
    [Test]
    public void TestReadInt1()
    {
        SetInput(" ", "  ", "", "  12  ");
        var res = _s.ReadInt("Id: ");
        Assert.That(res, Is.EqualTo(12));
    }
    
    [Test]
    public void TestReadInt2()
    {
        SetInput("  ", "", " -12 ", " 2   ");
        var res = _s.ReadInt("Id: ");
        Assert.That(res, Is.EqualTo(2));
    }
    
    [Test]
    public void TestReadFormat1()
    {
        SetInput("  ", "", "  username  ", "pdf");
        var res = _s.ReadFormat("Format: ");
        Assert.That(res, Is.EqualTo("pdf"));
    }
    
    [Test]
    public void TestReadFormat2()
    {
        SetInput("  ", "", "  username  ", " exe ", "jpg", "EPUB");
        var res = _s.ReadFormat("Format: ");
        Assert.That(res, Is.EqualTo("epub"));
    }
    
    [Test]
    public void TestReadIsbn10()
    {
        SetInput("  0131872508  ");
        var res = _s.ReadIsbn("ISBN: ");
        Assert.That(res, Is.EqualTo("0131872508"));
    }
    
    [Test]
    public void TestReadIsbn13()
    {
        SetInput("  9780201616224  ");
        var res = _s.ReadIsbn("ISBN: ");
        Assert.That(res, Is.EqualTo("9780201616224"));
    }
}