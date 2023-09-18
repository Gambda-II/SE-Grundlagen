Console.WriteLine("Wie viele Zufallszahlen möchtest du?");

var inputAmount = Console.ReadLine();
var randomAmount = int.Parse(inputAmount);
var rand = new Random();

int[] randomNumbers = new int[randomAmount];

for (int k = 0; k < randomAmount; k++)
{
    randomNumbers[k] = rand.Next(0,10);
}

foreach(int x in randomNumbers)
{
Console.WriteLine(x);
}
