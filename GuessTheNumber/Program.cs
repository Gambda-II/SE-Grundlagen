using System;

bool isPlaying = true;
while(isPlaying)
{ 
bool checkForCorrectInput = true;
int minValue = 0;
int maxValue = 10;
int numberOfTries = 5;
string outputMessage;
bool isWinning = false;

string messageSmaller = "Meine Zahl ist kleiner!", messageBigger = "Meine Zahl ist größer!", messageNotANumber = "Du hast keine Zahl eingegeben!", messageNotInDomain = "Die Zahl ist nicht im gewählten Bereich.", messageWinning = "Treffer!";

while(checkForCorrectInput)
    {
        Console.WriteLine("Bitte den Bereich eingeben. \nKleinste Zahl: ");
        while (checkForCorrectInput)
        {
            checkForCorrectInput = !int.TryParse(Console.ReadLine(), out minValue);
            Console.WriteLine(checkForCorrectInput ? "Das ist keine Zahl wtf??? Neue Zahl eingeben." : "");
        }

        checkForCorrectInput = true;

        Console.WriteLine("Größte Zahl:");
        while (checkForCorrectInput)
        {
            checkForCorrectInput = !int.TryParse(Console.ReadLine(), out maxValue);
            Console.WriteLine(checkForCorrectInput ? "Das ist keine Zahl wtf??? Neue Zahl eingeben." : "");
        }
        checkForCorrectInput = true;

        if (minValue > maxValue)
        {
            Console.WriteLine("Deine kleinste Zahl ist größer als die größte Zahl... Bitte neue Werte eingeben.");
            checkForCorrectInput = true;
        }
        else
        {
            checkForCorrectInput = false;
        }
    }


Random randomNumber = new Random(); 
int myValue = randomNumber.Next(minValue, maxValue + 1);


Console.WriteLine("Ich suche mir jetzt eine Zahl zwischen {0} und {1}. Du hast {2} Versuche meine Zahl zu erraten.", minValue, maxValue, numberOfTries);
Console.WriteLine("An welche Zahl denke ich?");

while (!isWinning && numberOfTries > 0)
{
    Console.WriteLine("Du hast noch {0} Versuche.", numberOfTries);
    numberOfTries--;

    int inputValue;
    checkForCorrectInput = int.TryParse(Console.ReadLine(), out inputValue);

    if (checkForCorrectInput)
    {
        if (inputValue == myValue)
        {
            outputMessage = messageWinning;
            isWinning = true;
        }
        else if (inputValue >= minValue && inputValue <= maxValue)
        {
            outputMessage = inputValue < myValue ? messageBigger : messageSmaller;
        }
        else
        {
            outputMessage = messageNotInDomain;
        }

    }
    else 
    {
        outputMessage = messageNotANumber;
    }
    Console.WriteLine(outputMessage);
}
Console.WriteLine(isWinning ? "Gewonnen" : "Schade");

    bool checkAtEnd = true;
    while (checkAtEnd)
    {
    Console.WriteLine("Wieder spielen [SPACE] oder Aufhören [Esc]?");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Spacebar:
            isPlaying = true;
            checkAtEnd = false;
            break;
            case ConsoleKey.Escape:
            isPlaying = false;
            checkAtEnd = false;
            break;
        default:
            break;
            
    }

    }
}

Console.WriteLine();