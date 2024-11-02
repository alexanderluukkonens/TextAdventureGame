namespace TextAdventureGame;

public static class ConsoleHelper
{
    public static void DrawBox(string title)
    {
        Console.WriteLine("====================");
        Console.WriteLine($"     {title}");
        Console.WriteLine("====================");
    }
    
    public static void WaitForKey()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
