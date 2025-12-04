class Warrior
{
    public string? Naam {get; set;}
    public int Health {get; set;}
    public int Power {get; set;}
    private Random rnd = new Random();

    public Warrior(string naam, int health, int power)
    {
        Naam = naam;
        Health = health;
        Power = power;
    }

    public void Attack()
    {
        Console.WriteLine(rnd.Next(1, Power).ToString());
    }

    public void TakeDamage(int dmg)
    {
        int newHealth = Math.Max(0, Health - dmg);
        Health = newHealth;
    }

    public void Heal(int amount)
    {
        int newHealth = Math.Min(100, Health + amount);
        Health = newHealth;
    }

    public bool IsAlive()
    {
        if (Health > 0){
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Status()
    {
        return $"Naam: {Naam} | Health: {Health} | Power: {Power}";
    }
}

class Program
{
    public static void Main()
    {
        Warrior test = new Warrior("Bas", 100, 0);
        Console.WriteLine(test.Status());
        test.TakeDamage(50);
        Console.WriteLine(test.IsAlive());
        Console.WriteLine(test.Status());
        test.Heal(20);
        Console.WriteLine(test.Status());
        test.Heal(100);
        Console.WriteLine(test.Status());

    }
}
