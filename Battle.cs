namespace TextAdventureGame;

public class Battle
{
    public static void FightMonster(Monster monster, Player player, World world)
    {
        while (true)
        {
            InterfaceDisplay.Battle(player, monster);
            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                int damage = player.GetRandomDamage();
                monster.Health -= damage;
                Console.WriteLine($"\nYou did {damage} damage!");
                Thread.Sleep(3000);
            }
            else if (choice == "2")
            {
                player.Heal();
                Console.WriteLine("\nYou healed 20 HP!");
                Thread.Sleep(3000);
                continue;
            }
            else if (choice == "3")
            {
                Console.WriteLine("\nYou ran like a coward!");
                Thread.Sleep(3000);
                return;
            }
            else if (choice == "4")
            {
                Console.WriteLine(
                    """

                    Help:

                    Attack - Attack the enemy and deal random damage.
                    Heal   - Heal for 20 health. Does not end your turn.
                    Flee   - Escape combat.
                    """
                );
                Thread.Sleep(3000);
                continue;
            }
            else
            {
                Console.WriteLine("Press 1 - 4");
                Thread.Sleep(3000);
                continue;
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
                return;
            }

            else if (monster.Health <= 0)
            {
                world.MonsterDefeated = true;
                player.CompletedWorlds++;
                Console.Clear();
                Console.WriteLine($"\nCongratulations! You have defeated {world.Monster.Name}!");
                Thread.Sleep(1500);
                Console.WriteLine($"\nYou gained: {world.Item.Name} to your inventory!");
                player.CollectItem(world.Item);
                Thread.Sleep(1500);
                return;
            }
        }
    }
}
