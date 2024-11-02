namespace TextAdventureGame;

public class Player 
{
    public int Health { get; set; }
    public List<Item> Inventory { get; private set; }
    public int CompletedWorlds { get; set; }
    private Random random = new Random();

    public Player()
    {
        Health = 100;
        Inventory = new List<Item>();
        CompletedWorlds = 0;
    }

    public void CollectItem(Item item)
    {
        Inventory.Add(item);
    }

    public int GetRandomDamage()
    {
        int baseDamage = 3;
        foreach (Item item in Inventory)
        {
            baseDamage += item.Damage;
        }
        return random.Next(baseDamage - 2, baseDamage + 15);
    }

    public void Heal()
    {
        Health += 20;
        if (Health > 100)
        {
            Health = 100;
        }
    }
}
