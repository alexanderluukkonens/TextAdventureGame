namespace TextAdventureGame;

public class Menu
{
    public static bool HandleMenuChoice(string choice, Player player)
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
                    WorldManager.ChooseWorld(player);
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
        return true;
    }
}