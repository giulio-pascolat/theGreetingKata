using theGreetingKata.Inserfaces;
using theGreetingKata.Interfaces;

namespace theGreetingKata.Services;

public class GreetingFormatter: IGreetingFormatter
{
    public string Format(string[] names, bool isShouted)
    {
        return names.Length switch
        {
            0 => "",
            1 => isShouted ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.",
            2 => isShouted ? $"HELLO {string.Join(" AND ", names)}!" : $"Hello, {names[0]} and {names[1]}.",
            _ => isShouted
                ? $"HELLO {string.Join(", ", names[..^1])} AND {names[^1]}!"
                : $"Hello, {string.Join(", ", names[..^1])}, and {names[^1]}."
        };
    }
}