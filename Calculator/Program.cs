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

string GetOperation()
{
    string operation = "emptyLater", input;
    do 
    {
        Console.WriteLine("What would you like to do with these numbers? Add, subtract, multiply or divide?");
        input = Console.ReadLine();


    } while (false);

    return operation;
}

Console.WriteLine("Willkommen im Taschenrechner Potato-Instruments PI-30DE");


int num1 = GetNumber();
int num2 = GetNumber();

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