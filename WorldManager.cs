namespace TextAdventureGame;

public class WorldManager
{
    public static List<World> worlds = new List<World>
    {
        new World(
            "Forest",
            "A dark and mysterious forest",
            new Monster("Forest Giant", 30, 5),
            new Item("Wooden Sword", 5, 2)
        ),
        new World(
            "Cave",
            "A deep and cold cave",
            new Monster("Cave Troll", 50, 8),
            new Item("Stone Club", 8, 3)
        ),
        new World(
            "Mountain",
            "A high and dangerous mountain",
            new Monster("Drake", 80, 12),
            new Item("NaN", 0, 4)
        ),
    };

    private static void ExploreWorld(World world, Player player)
    {
        InterfaceDisplay.WorldInfo(world);

        if (!world.MonsterDefeated)
        {
            Menu.BattleMenu(player, world);
            if (!Game.isRunning)
            {
                return;
            }
        }
        else
        {
            Console.WriteLine("\nYou have already explored this world.");
        }

        ConsoleHelper.WaitForKey();
    }

    public static void ChooseWorld(Player player)
    {
        bool exploring = true;
        while (exploring)
        {
            if (!Game.isRunning)
            {
                break;
            }
            WorldAvailable(player);

            string choice = Console.ReadLine()!;
            if (choice == "4")
            {
                exploring = false;
            }
            else if (
                int.TryParse(choice, out int worldIndex)
                && worldIndex >= 1
                && worldIndex <= worlds.Count
            )
            {
                if (worldIndex - 1 <= player.CompletedWorlds)
                {
                    ExploreWorld(worlds[worldIndex - 1], player);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nYou must clear the previous worlds first!");
                    ConsoleHelper.WaitForKey();
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
                ConsoleHelper.WaitForKey();
                continue;
            }
        }
    }

    private static void WorldAvailable(Player player)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("WORLDS");

        for (int i = 0; i < worlds.Count; i++)
        {
            string availability = i <= player.CompletedWorlds ? "Available" : "Locked";
            Console.WriteLine($"[{i + 1}] {worlds[i].Name} - {availability}");
        }
        Console.WriteLine("[4] Return to the main menu");
        Console.WriteLine("\nChoose a world from the list.");
        Console.Write("\nChoice: ");
    }
}
