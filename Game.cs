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
        ConsoleHelper.MenuBox();
        Thread.Sleep(7000);
        while (isRunning)
        {
            ShowMainMenu();
            string choice = Console.ReadLine()!;
            HandleMenuChoice(choice);
        }
    }

    private void ShowMainMenu()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("ADVENTUREGAME");
        Console.WriteLine("1. Instructions");
        Console.WriteLine("2. Explore worlds");
        Console.WriteLine("3. Show inventory");
        Console.WriteLine("4. Show Playerstatus");
        Console.WriteLine("5. End game");
        Console.WriteLine("\nChoose an option (1-5):");
    }

    private void HandleMenuChoice(string choice)
    {
        try
        {
            switch (choice)
            {
                case "1":
                    ConsoleHelper.Instructions();
                    ConsoleHelper.WaitForKey();
                    break;
                case "2":
                    ExploreWorlds();
                    break;
                case "3":
                    player.ShowInventory();
                    ConsoleHelper.WaitForKey();
                    break;
                case "4":
                    player.ShowStatus();
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

    private void FightMonster(Monster monster)
    {
        while (monster.Health > 0 && player.Health > 0)
        {
            Console.Clear();
            ConsoleHelper.DrawBox("BATTLE");
            Console.WriteLine($"Your health: {player.Health}");
            Console.WriteLine($"{monster.Name}s health: {monster.Health}");
            Console.WriteLine("\n1. Attack");
            Console.WriteLine("2. Heal");

            string choice = Console.ReadLine()!;
            Console.Clear();

            if (choice == "1")
            {
                int damage = player.GetRandomDamage();
                monster.Health -= damage;
                Console.WriteLine($"\nYou did {damage} damage!");
                Thread.Sleep(1500);
            }
            else if (choice == "2")
            {
                player.Heal();
                Console.WriteLine("\nYou healed 20 HP!");
                Thread.Sleep(1500);
            }

            if (monster.Health > 0)
            {
                int monsterDamage = monster.GetDamage();
                player.Health -= monsterDamage;
                Console.WriteLine($"{monster.Name} did {monsterDamage} damage on you!");
                Thread.Sleep(1500);
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("\nYou lost the battle!");
                player.Health = 100;
                Thread.Sleep(1500);
                break;
            }
        }
    }
}
