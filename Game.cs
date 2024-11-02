namespace TextAdventureGame;

public class Game
{
    private Player player;
    private List<World> worlds;
    private bool isRunning;
    private Random random;

    public Game()
    {
        player = new Player();
        worlds = new List<World>();
        InitializeWorlds();
        isRunning = true;
        random = new Random();
    }

    private void InitializeWorlds()
    {
        worlds.Add(
            new World(
                "Forest",
                "A dark and mysterious forest",
                new Monster("Forestgiant", 30, 5),
                new Item("Woodsword", 5)
            )
        );
        worlds.Add(
            new World(
                "The Cave",
                "A deep and cold cave",
                new Monster("Cave-troll", 50, 8),
                new Item("Stoneclub", 8)
            )
        );
        worlds.Add(
            new World(
                "The mountain",
                "A high and dangerous mountin",
                new Monster("Drake", 80, 12),
                new Item("Magic sword", 12)
            )
        );
    }

    public void Run()
    {
        InterfaceDisplay.MenuBox();
        Thread.Sleep(7000);
        while (isRunning)
        {
            InterfaceDisplay.ShowMainMenu();
            string choice = Console.ReadLine()!;
            HandleMenuChoice(choice);
        }
    }

  

    private void HandleMenuChoice(string choice)
    {
        try
        {
            switch (choice)
            {
                case "1":
                    InterfaceDisplay.Instructions();
                    ConsoleHelper.WaitForKey();
                    break;
                case "2":
                    ExploreWorlds();
                    break;
                case "3":
                    InterfaceDisplay.ShowInventory(player.Inventory);
                    ConsoleHelper.WaitForKey();
                    break;
                case "4":
                    InterfaceDisplay.ShowStatus(player.Health, player.CompletedWorlds);
                    ConsoleHelper.WaitForKey();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nThanks for playing!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            ConsoleHelper.WaitForKey();
        }
    }

    private void ExploreWorlds()
    {
        bool exploring = true;
        while (exploring)
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
                    ExploreWorld(worlds[worldIndex - 1]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nYou must clear the previous worlds first!");
                    ConsoleHelper.WaitForKey();
                }
            }
        }
    }

    private void ExploreWorld(World world)
    {
        Console.Clear();
        ConsoleHelper.DrawBox(world.Name);
        Console.WriteLine(world.Description);

        if (!world.MonsterDefeated)
        {
            Console.WriteLine($"\nA monster approaches: {world.Monster.Name}!");
            FightMonster(world.Monster);
            if (world.Monster.Health <= 0)
            {
                world.MonsterDefeated = true;
                player.CompletedWorlds++;
                Console.Clear();
                Console.WriteLine($"\nCongratulations! You have defeated {world.Monster.Name}!");
                Thread.Sleep(1500);
                Console.WriteLine($"\nYou gained: {world.Item.Name} to your inventory!");
                player.CollectItem(world.Item);
                Thread.Sleep(1500);
            }
        }
        else
        {
            Console.WriteLine("\nYou have already explored this world.");
        }

        ConsoleHelper.WaitForKey();
    }

    
}
