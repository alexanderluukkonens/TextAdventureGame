namespace TextAdventureGame;

public class Item
{
    public string Name { get; private set; }
    public int Damage { get; private set; }

    public Item(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}
