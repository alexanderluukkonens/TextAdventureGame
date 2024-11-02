namespace TextAdventureGame;

public class Player
{
    public int Health { get; set; }
    public List<Item> Inventory { get; private set; }
    public int CompletedWorlds { get; set; }
    private Random random;

    public Player()
    {
        Health = 100;
        Inventory = new List<Item>();
        CompletedWorlds = 0;
        random = new Random();
    }

    public void CollectItem(Item item)
    {
        Inventory.Add(item);
    }

    public int GetRandomDamage()
    {
        int baseDamage = 1;
        foreach (Item item in Inventory)
        {
            baseDamage += item.Damage;
        }
        return random.Next(baseDamage - 2, baseDamage + 15);
    }

    public void Heal()
    {
        if (Health > 100)
        {
            Health = 100;
        }
    }

    public void ShowInventory()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("INVENTORY");

        if (Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty!");
            return;
        }

        foreach (Item item in Inventory)
        {
            Console.WriteLine($"{item.Name} (Damage: {item.Damage})");
        }
    }

    public void ShowStatus()
    {
        Console.Clear();
        ConsoleHelper.DrawBox("PLAYERSTATUS");
        Console.WriteLine($"Health: {Health}/100");
        Console.WriteLine($"Completed worlds: {CompletedWorlds}");
    }
}
