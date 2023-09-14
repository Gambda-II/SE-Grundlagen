using System;

int GetNumber()
{
    int num;
    bool checkParse;
    string input;
    do
    {
        Console.WriteLine("Please enter an integer:");
        input = Console.ReadLine();
        checkParse = int.TryParse(input, out num);

        if (checkParse == false)
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
        }

    } while (checkParse == false);

    return num;
}

ConsoleKey GetOperation()
{
    ConsoleKey returnKey;
    bool checkParse;
    do 
    {
        Console.WriteLine("What would you like to do with these numbers? Add +, subtract -, multiply * or divide /?");
        returnKey = Console.ReadKey(true).Key;
        checkParse = (returnKey == ConsoleKey.Add || returnKey == ConsoleKey.Subtract || returnKey == ConsoleKey.Multiply || returnKey == ConsoleKey.Divide || returnKey == ConsoleKey.OemPlus || returnKey == ConsoleKey.OemMinus);

    } while (!checkParse);

    return returnKey;
}

Console.WriteLine("Willkommen im Taschenrechner Potato-Instruments PI-30DE");

int Calculate(int num1, int num2, ConsoleKey operation)
{
    int result;
    int pressedKeyNumber = (int)operation;
    switch (pressedKeyNumber)
    {
        case 187: // +
            result = num1 + num2;
            break;
        case 189: // -
            result = num1 - num2;
            break;
        case 107: // +
            result = num1 + num2;
            break;
        case 109: // -
            result = num1 - num2;
            break;
        case 106: // *
            result = num1 * num2;
            break;
        case 111: // /
            result = num1 / num2;
            break;
        default:
            result = int.MaxValue;
            break;
    }

    return result;
}


//int num1 = GetNumber();
//int num2 = GetNumber();

int result = Calculate(GetNumber(), GetNumber(), GetOperation());
Console.WriteLine(result);


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