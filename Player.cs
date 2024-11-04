namespace TextAdventureGame;

public class Player
{
    public int Health { get; set; }
    public List<Item> Inventory { get; private set; }
    public int CompletedWorlds { get; set; }
    public int BaseDamage {get; private set;}
    public int HealingUses { get; private set; }
    public Item EquippedItem { get; private set; } 
    private Random random = new Random();

    public Player()
    {
        Health = 100;
        Inventory = new List<Item>();
        CompletedWorlds = 0;
        HealingUses = 0;
        Inventory.Add(new Item("Stick", 3, 1));
        EquippedItem = Inventory[0];
        BaseDamage = 3 + EquippedItem.Damage;
    }

    public void CollectItem(Item item)
    {
        Inventory.Add(item);
    }
    public void CollectPotion()
    {
        HealingUses = 3;
        return;
    }

    public int GetRandomDamage()
    {
        return random.Next(BaseDamage, BaseDamage + 15);
    }

    public void Heal()
    {
        if (Health == 100)
        {
            InterfaceDisplay.PlayerInfoFullHealth();
            return;
        }
        if (HealingUses > 0)
        {
            HealingUses--;
            int healing = random.Next(10, 26);
            Health += healing;
            InterfaceDisplay.PlayerInfoHealing(healing);
            InterfaceDisplay.PlayerInfoHealingUses(HealingUses);
        }
        else
        {
            InterfaceDisplay.PlayerInfoHealingUses(HealingUses);
        }

        if (Health > 100)
        {
            Health = 100;
        }
    }
    public void EquipItem(int choice)
    {
        foreach (Item item in Inventory)
        {
            if (item.ItemID.Equals(choice))
            {
                EquippedItem = item;
                BaseDamage = item.Damage + 3;
                Console.WriteLine($"\nYou equipped your {item.Name}.\n");
                return;
            }
        } 
    }
}
