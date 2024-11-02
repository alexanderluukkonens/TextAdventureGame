namespace TextAdventureGame;

public class Battle
{
    private void FightMonster(Monster monster)
    {
        
        while (monster.Health > 0 && player.Health > 0)
        {
            InterfaceDisplay.Battle(player, monster);
            string choice = Console.ReadLine()!;
            

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
            else
            {
                Console.WriteLine("Press 1 or 2");
                Thread.Sleep(1500);
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
                break;
            }
        }
    }
}