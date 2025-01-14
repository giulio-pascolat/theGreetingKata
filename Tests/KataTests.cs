using theGreetingKata;

namespace TestProject1;

public class KataTests
{
    private readonly Kata _kata = new();
    [Fact]
    public void Should_return_correct_name()
    {
        Assert.Equal("Hello, Bob", _kata.Greet("Bob"));
    }

    [Fact]
    public void Should_handle_null()
    {
        Assert.Equal("Hello, my friend", _kata.Greet());
    }
}