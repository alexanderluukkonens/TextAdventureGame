namespace TextAdventureGame;

public static class ConsoleHelper
{
    public static void DrawBox(string title)
    {
        Console.WriteLine("====================");
        Console.WriteLine($"     {title}");
        Console.WriteLine("====================");
    }

    public static void MenuBox()
    {
        Console.WriteLine("");
        Console.WriteLine($"            YOU ENTERED ROOM 5 !");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"     WELCOME TO A PLACE FAR FROM EARTH!");
        Console.WriteLine("");
    }

    public static void WaitForKey()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static void Instructions()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("INSTRUCTIONS");
        Console.WriteLine(
            "You are a player who has entered a galaxy where you have to make your way through different worlds and defeat their enemy to be able to move on to the next world! "
        );
    }
}
