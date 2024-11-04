namespace TextAdventureGame;

public static class ConsoleHelper
{
    public static void DrawBox(string title)
    {
        const int boxWidth = 20;
        const string border = "====================";

        int padding = (boxWidth - title.Length) / 2;

        if (title.Length > boxWidth - 2)
        {
            title = title.Substring(0, boxWidth - 2);
        }

        Console.WriteLine(border);
        Console.WriteLine($"{new string(' ', padding)}{title}");
        Console.WriteLine(border + "\n");
    }

    public static void WaitForKey()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
}
