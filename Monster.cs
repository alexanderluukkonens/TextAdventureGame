namespace TextAdventureGame;

public class Monster
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int BaseDamage { get; private set; }
    private Random random = new Random();

    public Monster(string name, int health, int baseDamage)
    {
        Name = name;
        Health = health;
        BaseDamage = baseDamage;
    }

    public int GetRandomDamage()
    {
        return random.Next(BaseDamage - 2, BaseDamage + 14);
    }
}
