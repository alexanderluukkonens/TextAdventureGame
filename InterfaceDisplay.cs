namespace TextAdventureGame;

public class InterfaceDisplay
{
    
    // Battle
    public static void BattleMenuDisplay(Player player, World world)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("BATTLE - " + world.Name);
        Console.WriteLine($"Your health: {player.Health}");
        Console.WriteLine($"{world.Monster.Name}s health: {world.Monster.Health}");
        Console.WriteLine("\n[1] - Attack");
        Console.WriteLine("[2] - Heal");
        Console.WriteLine("[3] - Show Inventory");
        Console.WriteLine("[4] - Show Character");
        Console.WriteLine("[5] - Flee");
        Console.WriteLine("\n[6] 'Help'");
        Console.Write("\nChoice: ");
    }

    public static void BattleInfoHelp()
    {
        Console.WriteLine(
            """

            Help:

            Attack - Attack the enemy and deal random damage.
            Heal   - Heal for 20 health. Does not end your turn.
            Show Inventory - Opens inventory and lets you equip items.
            Show Character - Display player stats.
            Flee   - Escape combat.
            """
        );
    }

    public static void BattleVictoryScreen(World world, Player player)
    {
        Console.Clear();
        Console.WriteLine($"\nCongratulations! You have defeated {world.Monster.Name}!");
        Thread.Sleep(1500);
        Console.WriteLine($"\nYou found: a {world.Item.Name}! It was added to your inventory.");
        Thread.Sleep(1500);
        if (world.Name.Equals("Forest"))
        {
            Console.WriteLine("\nYou found: 3 healing potions! They were added to your inventory.");
        }
    }

    // Player
    public static void PlayerInfoFullHealth()
    {
        Console.WriteLine("You already have full health!");
        Thread.Sleep(2000);
        ConsoleHelper.WaitForKey();
    }

    public static void PlayerInfoHealingUses(int healingUses)
    {
        Console.WriteLine($"\nYou have: {healingUses} healing potions left!");
        Thread.Sleep(3000);
        ConsoleHelper.WaitForKey();
    }

    public static void PlayerInfoHealing(int healing)
    {
        Console.WriteLine($"\nYou healed: {healing} health points!");
    }

    public static void PlayerInfoShowInventory(Player player)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("INVENTORY");

        if (player.CompletedWorlds > 0)
        {
            Console.WriteLine("Consumables:\n");
            Console.WriteLine($"You have: {player.HealingUses} healing potions.");
            Console.WriteLine("_______________________________________________\n");
        }
        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty!");
            return;
        }
        Console.WriteLine("Items:\n");
        foreach (Item item in player.Inventory)
        {
            Console.WriteLine($"{item.ItemID}. {item.Name}. Damage: {item.Damage}");
        }
        Console.WriteLine("_______________________________________________\n");
        Console.WriteLine($"\n[{player.Inventory.Count + 1}]. - Close Inventory");
        Console.WriteLine("\nChoose an item from the list to equip. ");
        Console.Write("\nChoice: ");
        Menu.InventoryMenu(player);
    }

    public static void PlayerInfoShowCharacter(Player player)
    {
        Console.Clear();
        ConsoleHelper.DrawBox("PLAYERSTATUS");
        Console.WriteLine($"Health: {player.Health}/100.");
        Console.WriteLine($"Damage: {player.BaseDamage} - {player.BaseDamage + 14}.");
        Console.WriteLine($"Weapon: {player.EquippedItem.Name}.");
        Console.WriteLine($"Completed worlds: {player.CompletedWorlds}.");
    }

    // Menu
    public static void AboutGame()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("ABOUT");
        Console.WriteLine(
            """
            You find yourself in a galaxy far far away,
            where you have to make your way through thrilling
            and exciting worlds. Defeat each guardian to 
            unlock new worlds and find the treasure! 
            """
        );
    }

    public static void MenuBox()
    {
        Console.WriteLine("");
        Console.WriteLine($"            YOU ENTERED ROOM 2 !");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"     WELCOME TO A PLACE FAR FROM EARTH!");
        Console.WriteLine("");
    }

    public static void ShowMainMenu()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("ADVENTUREGAME");
        Console.WriteLine("[1] Explore Worlds");
        Console.WriteLine("[2] Show Inventory");
        Console.WriteLine("[3] Show Character");
        Console.WriteLine("[4] About");
        Console.WriteLine("\n[5] Help");
        Console.WriteLine("[6] End Game");
        Console.Write("\nChoice: ");
    }

    public static void MainMenuHelp()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("HELP");
        Console.WriteLine(
            """
            Explore worlds - Enter the game and explore different worlds.
            Show inventory - Shows inventory content of player.
            Show Playerstatus - Shows health and completed worlds of player.
            About - Game description.

            End game - Exit game.
            """
        );
    }

    // World
    public static void WorldInfo(World world)
    {
        Console.Clear();
        ConsoleHelper.DrawBox(world.Name);

        foreach (
            char c in world.Description
                + $"\n\nA monster approaches: {world.Monster.Name}! Prepare for combat!"
        )
        {
            if (!Console.KeyAvailable)
            {
                Console.Write(c);
                Thread.Sleep(140);
            }
            else
            {
                Thread.Sleep(200);
                Console.Clear();
                ConsoleHelper.DrawBox(world.Name);
                Console.WriteLine(
                    world.Description
                        + $"\n\nA monster approaches: {world.Monster.Name}!"
                        + " Prepare for combat!"
                );
                Console.WriteLine();
                Console.ReadKey();
                ConsoleHelper.WaitForKey();
                return;
            }
        }
        Thread.Sleep(500);
        Console.Clear();
        ConsoleHelper.DrawBox(world.Name);
        Console.WriteLine(
            world.Description
                + $"\n\nA monster approaches: {world.Monster.Name}!"
                + " Prepare for combat!"
        );
        ConsoleHelper.WaitForKey();
        return;
    }

    // Game Over
    public static void GameOverScreen()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine($"       You have been defeated by the guardians   ");
        Console.WriteLine("");
        Console.WriteLine("         and will never find the treasure!  ");
        Console.WriteLine("");
        Console.WriteLine("                   ***GAME OVER***");
    }

    public static void GameVictoryScreen()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine($"        You have defeated the final guardian    ");
        Console.WriteLine("");
        Console.WriteLine("          and found riches beyond all your");
        Console.WriteLine($"     ");
        Console.WriteLine("      dreams and now starts the long journey home");
        Console.WriteLine("");
        Console.WriteLine("                   ***GAME OVER***");
    }
}
