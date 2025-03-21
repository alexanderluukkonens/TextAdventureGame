namespace TextAdventureGame;

public class Monster
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int BaseDamage { get; private set; }
    private Random random;

    public Monster(string name, int health, int baseDamage)
    {
        Name = name;
        Health = health;
        BaseDamage = baseDamage;
        random = new Random();
    }

    public int GetDamage()
    {
        return random.Next(BaseDamage - 2, BaseDamage + 14);
    }
}
