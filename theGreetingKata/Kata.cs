using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string[]? names = null)
    {
        names ??= [""];

        if (names.Length == 0 || string.IsNullOrWhiteSpace(names[0]))
            return "Hello, my friend.";

        var normalNames = names.Where(name => !IsUpper(name)).ToArray();
        var shoutedNames = names.Where(IsUpper).ToArray();

        var normalGreeting = normalNames.Length switch
        {
            0 => "",
            1 => $"Hello, {normalNames[0]}.",
            2 => $"Hello, {normalNames[0]} and {normalNames[1]}.",
            _ => $"Hello, {string.Join(", ", normalNames[..^1])}, and {normalNames[^1]}."
        };

        var shoutedGreeting = shoutedNames.Length switch
        {
            0 => "",
            1 => $"HELLO {shoutedNames[0]}!",
            _ => $"HELLO {string.Join(" AND ", shoutedNames)}!"
        };
        
        if (normalNames.Length > 0)
        {
            return shoutedNames.Length > 0 ? $"{normalGreeting} AND {shoutedGreeting}" : normalGreeting;
        }
        return shoutedGreeting;
    }


    private static bool IsUpper(string name) => name.All(c => !char.IsLetter(c) || char.IsUpper(c));
}