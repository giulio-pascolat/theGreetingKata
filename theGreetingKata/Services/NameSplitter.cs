using theGreetingKata.Interfaces;

namespace theGreetingKata.Services;

public class NameSplitter : INameSplitter
{
    public (string[] normal, string[] shouted) SplitNamesByCase(string[] names)
    {
        var splitNames = SplitAndPreserveQuotedNames(names);
        return (
            splitNames.Where(name => !IsUpper(name)).ToArray(),
            splitNames.Where(IsUpper).ToArray()
        );
    }

    private static bool IsUpper(string name) =>
        name.All(c => !char.IsLetter(c) || char.IsUpper(c));

    private static string[] SplitAndPreserveQuotedNames(string[] input)
    {
        var result = new List<string>();

        foreach (var name in input)
        {
            if (name.StartsWith("\"") && name.EndsWith("\""))
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
}