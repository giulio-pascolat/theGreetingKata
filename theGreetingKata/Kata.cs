using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string[]? names = null)
    {
        names ??= [""];

        if (names.Length == 0 || string.IsNullOrWhiteSpace(names[0]))
            return "Hello, my friend.";

        var (normalNames, shoutedNames) = SplitNamesByCase(names);
  
        var normalGreeting = CreateGreeting(normalNames, false);

        var shoutedGreeting = CreateGreeting(shoutedNames, true);
        
        if (normalNames.Length > 0)
        {
            return shoutedNames.Length > 0 ? $"{normalGreeting} AND {shoutedGreeting}" : normalGreeting;
        }
        return shoutedGreeting;
    }


    private static bool IsUpper(string name) => name.All(c => !char.IsLetter(c) || char.IsUpper(c));
    
    private static (string[] normal, string[] shouted) SplitNamesByCase(string[] names)
    {
        var splitNames = SplitAndPreserveQuotedNames(names);
    
        return (splitNames.Where(name => !IsUpper(name)).ToArray(), splitNames.Where(IsUpper).ToArray());
    }
    
    
    private static string[] SplitAndPreserveQuotedNames(string[] input)
    {
        var result = new List<string>();

        foreach (var name in input)
        {
            if (name.StartsWith($"\"") && name.EndsWith($"\""))
            {
                result.Add(name.Trim('\"'));
            }
            else
            {
                result.AddRange(name.Split(", ", StringSplitOptions.RemoveEmptyEntries));
            }
        }

        return result.ToArray();
    }


    private static string CreateGreeting(string[] names, bool isShouted)
    {
        return names.Length switch
        {
            0 => "",
            1 => isShouted ? $"HELLO {names[0]}!" : $"Hello, {names[0]}.",
            2 => isShouted ? $"HELLO {string.Join(" AND ", names)}!" : $"Hello, {names[0]} and {names[1]}.",
            _ => isShouted ? $"HELLO {string.Join(", ", names[..^1])} AND {names[^1]}!" : $"Hello, {string.Join(", ", names[..^1])}, and {names[^1]}."
        };

    }
}