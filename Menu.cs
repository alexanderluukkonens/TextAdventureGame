namespace TextAdventureGame;

public class Menu
{
    static bool battleActive = true;
    public static bool MainMenu(string choice, Player player)
    {   
        
        try
        {
            switch (choice)
            {
                case "1":
                    WorldManager.ChooseWorld(player);
                    break;
                case "2":
                    InterfaceDisplay.PlayerInfoShowInventory(player);
                    ConsoleHelper.WaitForKey();
                    break;

                case "3":
                    InterfaceDisplay.PlayerInfoShowCharacter(player);
                    ConsoleHelper.WaitForKey();
                    break;

                case "4":
                    InterfaceDisplay.AboutGame();
                    ConsoleHelper.WaitForKey();
                    break;

                case "5":
                    InterfaceDisplay.MainMenuHelp();
                    ConsoleHelper.WaitForKey();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("\nThanks for playing!");
                    return false;

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
        if (!Game.isRunning)
        {
            return false;
        }
        return true;
    }
    public static void BattleMenu(Player player, World world)
    {
        battleActive = true;
        while (battleActive)
        {
            InterfaceDisplay.BattleMenuDisplay(player, world);
            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                battleActive = Battle.BattleMonster(player, world);
                Thread.Sleep(3000);
            }
            else if (choice == "2")
            {
                player.Heal();
                continue;
            }
            else if (choice == "3")
            {
                InterfaceDisplay.PlayerInfoShowInventory(player);
                ConsoleHelper.WaitForKey();
                continue;
            }
            else if (choice == "4")
            {
                InterfaceDisplay.PlayerInfoShowCharacter(player);
                ConsoleHelper.WaitForKey();
                continue;
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nYou ran like a coward!");
                Thread.Sleep(3000);
                return;
            }
            else if (choice == "6")
            {
                InterfaceDisplay.BattleInfoHelp();
                ConsoleHelper.WaitForKey();
                continue;
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
                ConsoleHelper.WaitForKey();
                continue;
            }
            
        }
    }

    public static void InventoryMenu(Player player)
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
        {

            if (choice == player.Inventory.Count + 1)
            {
                Console.WriteLine("\nClosing inventory.");
                return;
            }

            if (choice > player.Inventory.Count || choice < 1)
            {
                Console.WriteLine("Invalid selection. Try again.");
                return;
            }

            player.EquipItem(choice);
            
        }
        else
        {
            Console.WriteLine("Invalid selection. Try again.");
            return;
        }
    }
}
