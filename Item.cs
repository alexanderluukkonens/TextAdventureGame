namespace TextAdventureGame;

public class Item
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int ItemID { get; private set; }

    public Item(string name, int damage, int itemID)
    {
        Name = name;
        Damage = damage;
        ItemID = itemID;
    }
}
