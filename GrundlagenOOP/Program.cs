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
    }
}