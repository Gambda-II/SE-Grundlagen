using System.Runtime.InteropServices;

decimal GetNumber()
{

    

    decimal num;
    bool checkParse;
    string input;
    do
    {
        Console.WriteLine("Please enter an integer:");
        input = Console.ReadLine();
        checkParse = decimal.TryParse(input, out num);

        if (checkParse == false)
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
        }

    } while (checkParse == false);

    return num;
}

ConsoleKeyInfo GetOperation()
{
    ConsoleKeyInfo returnKey;
    bool checkParse;
    do
    {
        Console.WriteLine("What would you like to do with these numbers? Add +, subtract -, multiply * or divide /?");
        returnKey = Console.ReadKey(true);
        checkParse = (returnKey.KeyChar == '+' || returnKey.KeyChar == '-' || returnKey.KeyChar == '*' || returnKey.KeyChar == '/' || returnKey.KeyChar == '%' || returnKey.KeyChar == '\\');


    } while (!checkParse);

    return returnKey;
}

Console.WriteLine("Welcome to your calculator Potato-Instruments PI-30DE \nPress [ESC] to close this program.\nPress any key to start another calculation");

decimal Calculate(decimal firstNumber, decimal secondNumber, ConsoleKeyInfo operation)
{
    //float num1 = (float)firstNumber, num2 = (float)secondNumber, result;
    decimal num1 = firstNumber, num2 = secondNumber, result;
    char pressedKeyNumber = operation.KeyChar;
    switch (pressedKeyNumber)
    {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            if (num2 == 0)
            {
                Console.WriteLine("!!!Division by zero does not work... I guess... whatever... don't bother me...");
                result = decimal.MaxValue;
            }
            else
            {
                result = num1 / num2;
            }
            break;
        case '%':
            result = num1 % num2;
            break;
        case '\\':
            int resultInt = (int)num1 / (int)num2;
            result = (decimal)resultInt;
            break;
        default:
            result = decimal.MaxValue;
            break;
    }
    Console.WriteLine("{0} {1} {2} = {3}", num1, pressedKeyNumber, num2, result);
    return result;
}

bool isRunning = true;
int counter = 0;
while (isRunning)
{
    decimal num1 = GetNumber();
    decimal num2 = GetNumber();
    ConsoleKeyInfo pressedKey = GetOperation();
    decimal result = Calculate(num1, num2, pressedKey);
    counter++;
    Console.WriteLine("Press[ESC] to close this program or any key to start another calculation.\n");
    isRunning = !(Console.ReadKey(true).Key == ConsoleKey.Escape);
    
    if (!isRunning)
        Environment.Exit(0);
    else
        Console.WriteLine("Start calculation #{0}", counter);

    Console.Clear();
}


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