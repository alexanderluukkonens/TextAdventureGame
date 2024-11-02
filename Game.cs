namespace TextAdventureGame;

public class Game
{
    Player player = new Player();
    
    bool isRunning = true;

    public void Run()
    {
        InterfaceDisplay.MenuBox();
        Thread.Sleep(7000);
        while (isRunning)
        {
            InterfaceDisplay.ShowMainMenu();
            string choice = Console.ReadLine()!;
            isRunning = Menu.HandleMenuChoice(choice, player);
        }
    }
}
