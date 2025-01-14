using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string[]? names = null)
    {
        names ??= [""];

        if (names.Length == 0 || string.IsNullOrWhiteSpace(names[0]))
            return "Hello, my friend";

        if (names.Length == 1)
            return IsUpper(names[0]) ? $"HELLO {names[0].ToUpper()}!" : $"Hello, {names[0]}";

        if (names.Length == 2)
            return $"Hello, {names[0]} and {names[1]}.";

        var allButLast = string.Join(", ", names[..^1]);
        var last = names[^1];
        return $"Hello, {allButLast}, and {last}.";

    }

    private static bool IsUpper(string name) => name.All(c => !char.IsLetter(c) || char.IsUpper(c));
}