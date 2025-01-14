using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string name)
    {
        return $"Hello, {name}";
    }
}