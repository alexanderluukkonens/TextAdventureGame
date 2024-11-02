namespace TextAdventureGame;

public class WorldManager
{
    public static List<World> worlds = new List<World>       
    {
        new World(
            "Forest",
            "A dark and mysterious forest",
            new Monster("Forestgiant", 30, 5),
            new Item("Woodsword", 5)
        ),

        new World(
            "The Cave",
            "A deep and cold cave",
            new Monster("Cave-troll", 50, 8),
            new Item("Stoneclub", 8)
        ),

        new World(
            "The mountain",
            "A high and dangerous mountin",
            new Monster("Drake", 80, 12),
            new Item("Magic sword", 12)
        )
    };

    private static void ExploreWorld(World world, Player player)
    {
        Console.Clear();
        ConsoleHelper.DrawBox(world.Name);
        Console.WriteLine(world.Description);

        if (!world.MonsterDefeated)
        {
            Console.WriteLine($"\nA monster approaches: {world.Monster.Name}!");
            Battle.FightMonster(world.Monster, player, world);
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
                Console.Clear();
                Console.WriteLine("Enter 1-4");
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
            Console.WriteLine($"{i + 1}. {worlds[i].Name} - {availability}");
        }
        Console.WriteLine("4. Return to the main menu");
        Console.WriteLine("\nChoose a world (1-4):");
    }
}
