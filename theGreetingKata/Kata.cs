using theGreetingKata.Inserfaces;

namespace theGreetingKata;

public class Kata : IGreeter
{
    public string Greet(string? name = "")
    {
        if (string.IsNullOrWhiteSpace(name)) return "Hello, my friend"; 
        return IsUpper(name) ? $"HELLO {name.ToUpper()}!" : $"Hello, {name}";
    }
    
    
    public bool IsUpper(string name) => name.All(c => !char.IsLetter(c) || char.IsUpper(c));
}