namespace TextAdventureGame;

public class Battle
{
    public static bool BattleMonster(Player player, World world)
    {
        int damage = player.GetRandomDamage();
        world.Monster.Health -= damage;
        Console.WriteLine($"\nYou did {damage} damage!");

        if (world.Monster.Health > 0)
        {
            int monsterDamage = world.Monster.GetRandomDamage();
            player.Health -= monsterDamage;
            Console.WriteLine($"\n{world.Monster.Name} dealt {monsterDamage} damage to you!");
            Thread.Sleep(1500);
        }

        if (player.Health <= 0)
        {
            InterfaceDisplay.GameOverScreen();
            Game.isRunning = false;
            Thread.Sleep(1500);
            return false;
        }
        else if (world.Monster.Health <= 0)
        {
            world.MonsterDefeated = true;
            player.CompletedWorlds++;

            if (player.CompletedWorlds == 1)
            {
                player.CollectPotion();
            }

            if (player.CompletedWorlds == 3)
            {
                InterfaceDisplay.GameVictoryScreen();
                Thread.Sleep(1000);
                Game.isRunning = false;
                return false;
            }

            player.CollectItem(world.Item);

            InterfaceDisplay.BattleVictoryScreen(world, player);

            return false;
        }

        return true;
    }
}
