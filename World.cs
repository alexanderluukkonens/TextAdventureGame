namespace TextAdventureGame;

public class World
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Monster Monster { get; private set; }
    public Item Item { get; private set; }
    public bool MonsterDefeated { get; set; }
    public bool ItemCollected { get; set; }

    public World(string name, string description, Monster monster, Item item)
    {
        Name = name;
        Description = description;
        Monster = monster;
        Item = item;
        MonsterDefeated = false;
        ItemCollected = false;
    }
}
