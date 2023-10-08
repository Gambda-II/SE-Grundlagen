namespace GrundlagenOOP;
public class Cat
{
    // Variables inside a class -> Properties oder Fields
    public string Name;
    public int Age;
    public string Color;

    //Constructor
    public Cat(string name, int age, string color)
    {
        Name = name;
        Age = age;
        Color = color;
    }

    public Cat(int Age, string Name, string Color)
    {
        this.Age = Age;
        this.Name = Name;
        this.Color = Color;
    }


    // Functions inside a class -> Methods
    public static void Meow()
    {
        Console.WriteLine("Meow!");
    }

    public void Meow(string s = "")
    {
        Console.WriteLine("Meow!");
    }

    public override string ToString()
    {

        return $"Name: {this.Name}\nAge: {this.Age}\nColor: {this.Color}";
    }
}

// static class --> kann keine Instanzen erstellen, kann nicht als Typelement verwendet werden --> statische Methoden werden über die Klasse 

// non static class --> kann Instanzen erstellen, kann als Typelement verwendet werden, Methoden können static oder non static sein
