using System;
using System.Runtime.CompilerServices;

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

ConsoleKeyInfo GetOperation()
{
    ConsoleKeyInfo returnKey;
    bool checkParse;
    do 
    {
        Console.WriteLine("What would you like to do with these numbers? Add +, subtract -, multiply * or divide /?");
        returnKey = Console.ReadKey(true);
        checkParse = (returnKey.KeyChar == '+' || returnKey.KeyChar == '-' || returnKey.KeyChar == '*' || returnKey.KeyChar == '/' || returnKey.KeyChar == '%' || returnKey.KeyChar == '\\' );
        
        
    } while (!checkParse);

    return returnKey;
}

Console.WriteLine("Willkommen im Taschenrechner Potato-Instruments PI-30DE");

float Calculate(int firstNumber, int secondNumber, ConsoleKeyInfo operation)
{
    float num1 = (float)firstNumber, num2 = (float)secondNumber, result;
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
                Console.WriteLine("!!!Division by zero does not work... I guess!!");
                result = float.PositiveInfinity;

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
            result = (float)resultInt;
            break;
        default:
            result = float.MaxValue;
            break;
    }
    Console.WriteLine("{0} {1} {2} = {3}", num1, pressedKeyNumber , num2, result);
    return result;
}


while (true)
{
int num1 = GetNumber();
int num2 = GetNumber();
ConsoleKeyInfo pressedKey = GetOperation();
double result = Calculate( num1, num2, pressedKey);
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