namespace theGreetingKata.Interfaces;

public interface INameSplitter
{
    (string[] normal, string[] shouted) SplitNamesByCase(string[] names);
}