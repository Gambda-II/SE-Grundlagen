using System.Text;

namespace GrundlagenOOP;

internal class Program
{
    static void Main(string[] args)
    {
        // Statische Klasse Console
        // Console.WriteLine("Hello, World!");

        // Instanziierbare Klasse
        // Random rnd = new Random();

        // static method by namespace.class.method
        GrundlagenOOP.Cat.Meow();

        // static method by class.method
        Cat.Meow();

        // instantiate new object
        Cat cat = new Cat("", 0, "");

        cat.Meow();
        cat.Name = "Katze";
        cat.Age = 99;
        cat.Color = "transparent";

        Console.WriteLine(cat);
        Cat kat = new Cat("Katzer", 100, "blau");
        Console.WriteLine(kat);


        // fields vs properties
        Dog snoop = new Dog(0,"Calvin Cordozar Broadus Jr.", "black");
        var snoopy = new Dog(1, "Snoopy", "blacker");
        Dog scooby = new(2,"Doo","slightly gray");

        Person snopdog = new("snop", "dog");
        Console.WriteLine(snopdog.FullName());
        Console.WriteLine(snopdog.FullNameLambda);
        snopdog.Platzhalter(snopdog.FirstName);
        Console.WriteLine(snopdog.FirstName.Contains("s"));
    }
}