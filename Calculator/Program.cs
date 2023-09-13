Console.WriteLine("Willkommen im Taschenrechner Potato-Calc v1");

bool checkParseFirstNumber = false, checkParseSecondNumber = false;
int num1 = 0, num2 = 0;

while (!(checkParseFirstNumber && checkParseSecondNumber))
{

    Console.WriteLine("Erste Zahl eingeben");
    var firstNumber = Console.ReadLine();

    Console.WriteLine("Zweite Zahl eingeben");
    var secondNumber = Console.ReadLine();

    //Console.WriteLine($"{firstNumber} + {secondNumber} = {System.Convert.ToInt32(firstNumber) + System.Convert.ToInt32(secondNumber)}" );

    checkParseFirstNumber = int.TryParse(firstNumber, out num1);
    checkParseSecondNumber = int.TryParse(secondNumber, out num2);

}

int result = num1 + num2;
Console.WriteLine("{0} + {1} = {2}", num1, num2, result);


/*
var funcNumber = Console.ReadLine;
Console.WriteLine(funcNumber);
Console.WriteLine(funcNumber());
*/

/*
 * String in Integer umwandlen bspw.
 * string numberAsString = "123";
 * int numberAsInt = int.Parse(numberAsString);
 */