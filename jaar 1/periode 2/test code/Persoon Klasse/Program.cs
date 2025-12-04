public class Person{
    public string Name {get; set; }
    public DateTime BirthDay {get; set; }

    public Person(string name, DateTime birthDay)
    {
        Name = name;
        BirthDay = birthDay;
    }

    public string GetDescription()
    {
        return $"{Name} is geboren op {BirthDay}";
    }
    public static Person Oldest(Person person1, Person person2)
    {
        if (person1.BirthDay < person2.BirthDay)
        {
            return person1;
        }
        else
        {
            return person2;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Person persoon1 = new Person("Bas", DateTime.Now);
        Person persoon2 = new Person("Erik", DateTime.Now.AddDays(-3));
        Console.WriteLine(persoon1.GetDescription());
        Console.WriteLine(persoon2.GetDescription());
        Person oldest = Person.Oldest(persoon1, persoon2);
        Console.WriteLine($"The oldest is: {oldest.Name}");
    }
}