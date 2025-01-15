using theGreetingKata.Inserfaces;
using theGreetingKata.Interfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    private readonly INameSplitter _nameSplitter;
    private readonly IGreetingFormatter _greetingFormatter;

    public Kata(INameSplitter nameSplitter, IGreetingFormatter greetingFormatter)
    {
        _nameSplitter = nameSplitter;
        _greetingFormatter = greetingFormatter;
    }

    public string Greet(string[]? names = null)
    {
        names ??= new[] { "" };

        if (names.Length == 0 || string.IsNullOrWhiteSpace(names[0]))
            return "Hello, my friend.";

        var (normalNames, shoutedNames) = _nameSplitter.SplitNamesByCase(names);

        var normalGreeting = _greetingFormatter.Format(normalNames, false);
        var shoutedGreeting = _greetingFormatter.Format(shoutedNames, true);

        if (normalNames.Length > 0)
        {
            return shoutedNames.Length > 0
                ? $"{normalGreeting} AND {shoutedGreeting}"
                : normalGreeting;
        }
        return shoutedGreeting;
    }
}