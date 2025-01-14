using theGreetingKata;
using theGreetingKata.Inserfaces;

namespace TestProject1;

public class KataTests
{
    private readonly IGreeter _kata = new Kata();

    [Fact]
    public void ShouldReturnCorrectName()
    {
        Assert.Equal("Hello, Bob", _kata.Greet(["Bob"]));
    }

    [Fact]
    public void ShouldHandleNull()
    {
        Assert.Equal("Hello, my friend", _kata.Greet([]));
    }

    [Fact]
    public void ShouldBeUpper()
    {
        Assert.Equal("HELLO JERRY!", _kata.Greet(["JERRY"]));
    }

    [Fact]
    public void ShouldHandleTwoNames()
    {
        Assert.Equal("Hello, Jill and Jane.", _kata.Greet(["Jill", "Jane"]));
    }
}