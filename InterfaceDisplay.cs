namespace TextAdventureGame;

public class InterfaceDisplay
{
    public static void Battle(Player player, Monster monster)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("BATTLE");
        Console.WriteLine($"Your health: {player.Health}");
        Console.WriteLine($"{monster.Name}s health: {monster.Health}");
        Console.WriteLine("\n1. - Attack");
        Console.WriteLine("2. - Heal");
        Console.WriteLine("3. - Flee");
        Console.WriteLine("\n4. 'Help'");
    }

    public static void ShowInventory(List<Item> inventory)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("INVENTORY");

        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty!");
            return;
        }

        foreach (Item item in inventory)
        {
            Console.WriteLine($"{item.Name} (Damage: {item.Damage})");
        }
    }

    public static void ShowStatus(int health, int completedWorlds)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("PLAYERSTATUS");
        Console.WriteLine($"Health: {health}/100");
        Console.WriteLine($"Completed worlds: {completedWorlds}");
    }

    public static void Instructions()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("INSTRUCTIONS");
        Console.WriteLine(
            "You are a player who has entered a galaxy where you have to make your way through different worlds and defeat their enemy to be able to move on to the next world! "
        );
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
    public static void ShowMainMenu()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("ADVENTUREGAME");
        Console.WriteLine("1. About");
        Console.WriteLine("2. Explore worlds");
        Console.WriteLine("3. Show inventory");
        Console.WriteLine("4. Show Playerstatus");
        Console.WriteLine("5. End game");
        Console.WriteLine("\nChoose an option (1-5):");
    }
}
