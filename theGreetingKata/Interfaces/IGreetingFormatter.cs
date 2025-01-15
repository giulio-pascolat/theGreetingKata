namespace theGreetingKata.Interfaces;

public interface IGreetingFormatter
{
    string Format(string[] names, bool isShouted);
}