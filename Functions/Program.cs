class Functions
{
    static void Main(string[] args)
    {
        Console.WriteLine("BITTE AUTHENTIFIZIERUNGSNAME EINGEBEN:");
        string inputName = Console.ReadLine();
        printGreeting(inputName, 2);

        Console.WriteLine("23.7!");
        double inputNumber = 23.7;
        int einNeuerWert = printGreeting(inputName,inputNumber);

        printGreeting(maxRepeats: 2, name: "Ich teste hier einen Namen und die Parameter in einer anderen Reihenfolge.");
        Console.WriteLine(value: "und hier was anderes.");
        
    }
    void printHello()
    {
        Console.WriteLine("Hello");
    }

    string getHello()
    {
        return "Hello";
    }

    public static void printGreeting(string name, int maxRepeats)
    {
        int i = 0;
        while (i < maxRepeats)
        {
            Console.WriteLine($"Hello {name}");
            i++;
        }
    }
    public static int printGreeting(string name, double doubleValue)
    {
        int newValue = (int)Math.Round(doubleValue, 1);
        Console.WriteLine("{0} ist eine {1} und etwa {2}",name, doubleValue, newValue);
        return newValue;
    }
}