using Core;

namespace Tests;

public class InputServiceTests
{
    private InputService _inputService;
    
    [SetUp]
    public void Setup()
    {
        _inputService = new InputService();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}