using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string? name = "")
    {
        return string.IsNullOrWhiteSpace(name) ? "Hello, my friend" : $"Hello, {name}";
    }
}