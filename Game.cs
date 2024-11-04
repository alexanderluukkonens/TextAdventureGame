namespace TextAdventureGame;

public class Game
{
    Player player = new Player();
    
    public static bool isRunning = true;

    public void Run()
    {
        InterfaceDisplay.MenuBox();
        Thread.Sleep(3000);
        while (isRunning)
        {
            InterfaceDisplay.ShowMainMenu();
            string choice = Console.ReadLine()!;
            isRunning = Menu.MainMenu(choice, player);
        }
    }
}
