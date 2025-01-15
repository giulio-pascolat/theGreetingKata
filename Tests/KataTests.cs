using theGreetingKata;
using theGreetingKata.Inserfaces;

namespace TestProject1;

public class KataTests
{
    private readonly Kata _kata = new();

    [Fact]
    public void ShouldReturnCorrectName()
    {
        Assert.Equal("Hello, Bob.", _kata.Greet(["Bob"]));
    }

    [Fact]
    public void ShouldHandleNull()
    {
        Assert.Equal("Hello, my friend.", _kata.Greet());
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


    [Theory]
    [InlineData(new[] { "Amy", "Brian", "Charlotte" }, "Hello, Amy, Brian, and Charlotte.")]
    [InlineData(new[] { "Amy", "Brian", "Charlotte", "Dave" }, "Hello, Amy, Brian, Charlotte, and Dave.")]
    public void ShouldHandleThreeOrMoreNames(string[] names, string expected)
    {
        Assert.Equal(expected, _kata.Greet(names));
    }



    [Theory]
    [InlineData(new[] { "Amy", "BRIAN", "Charlotte" }, "Hello, Amy and Charlotte. AND HELLO BRIAN!")]
    [InlineData(new[] { "John", "TOM" }, "Hello, John. AND HELLO TOM!")]
    [InlineData(new[] { "John", "Tina" }, "Hello, John and Tina.")]
    [InlineData(new[] { "Alice", "Charlie" }, "Hello, Alice and Charlie.")]
    [InlineData(new[] { "Mia", "JACK", "Oliver", "SARA" }, "Hello, Mia and Oliver. AND HELLO JACK AND SARA!")]
    [InlineData(new[] { "JILL", "STEVE", "KATE" }, "HELLO JILL, STEVE AND KATE!")]
    public void ShouldHandleMixedNames(string[] names, string expected)
    {
        Assert.Equal(expected, _kata.Greet(names));
    }


    [Theory]
    [InlineData(new[] { "Bob", "Charlie, Dianne" }, "Hello, Bob, Charlie, and Dianne.")]
public void ShouldHandleCommaSeparatedNames(string[] names, string expected)
    {
        Assert.Equal(expected, _kata.Greet(names));
    }


    [Theory]
    [InlineData(new[] { "Bob", "\"Charlie, Dianne\"" }, "Hello, Bob and Charlie, Dianne.")]
public void ShouldHandleDoubleQuotesdNames(string[] names, string expected)
    {
        Assert.Equal(expected, _kata.Greet(names));
    }
}