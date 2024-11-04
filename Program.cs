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
            ConsoleHelper.WaitForKey();
        }
    }
}

/* TODOS

** = Done

Must.

**1. Fix descriptions for worlds and print it with Thread.Sleep. Andreas 
**2. Fix healing mechanic. ( Limit uses and maybe add a random value to heal. )
**3. Add help to MainMenu.
**4. Fix up victory screen. Should this be a separate method.
**5. Add check inventory in Battle Menu.
**6. Add character inspection. ( Show equipped weapon/gear, max health, min damage - max damage, other possible stats ex. level? )
**7. Fix up Final victory screen. 
**8. Check encapsulation abstraction for all variables and check for unused variables and methods.
**9. Do we need more error/exception handling? Test breaking the game.

Optional.

1. Add more content to worlds. ( More enemies, more events, )
**2. Add inventory features ( Equip/Un-equip ).
3. Add coloring to damage(Red), critical damage (Orange), healing(Green) and 
other Console.WriteLine() (Where it is reasonable.).
4. Check if help fits in for Worlds Menu.
5. Should the player be able to level up?
6. Add map?
**7. Fix up victory screen content.
8. Fix ressurection ? (if dead)
*/
