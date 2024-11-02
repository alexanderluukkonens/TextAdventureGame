namespace TextAdventureGame;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Game game = new Game();
            game.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
