using System;

string inputAge = "";
int age = 0;
bool checkInputFormat = true;
while (checkInputFormat)
{
    Console.WriteLine("Bitte Alter eingeben.");
    inputAge = Console.ReadLine();
    checkInputFormat = !(int.TryParse(inputAge, out age));
}


if (age < 18)
{
    Console.WriteLine("Zugriff verwehrt!");
}
else
{
    Console.WriteLine("Zugriff vermehrt!");
}

/*
enum Wochentag
{
    Montag = 1,
    Dienstag = 2,
    Mittwoch = 3,
    Donnerstag = 4,
    Freitag = 5
};
*/
Console.WriteLine("Bitte einen Wochentag 1 bis 5 eingeben!");
int inputWochentag = int.Parse(Console.ReadLine());
var wochentag = inputWochentag;

switch (wochentag)
{
    case 1: 
        Console.WriteLine("Heute ist Montag");
        break;
    case 2:
        Console.WriteLine("Heute ist Dienstag");
        break;
    case 3:
        Console.WriteLine("Heute ist Mittwoch");
        break;
    case 4:
        Console.WriteLine("Heute ist Donnerstag");
        break;
    case 5:
        Console.WriteLine("Heute ist Freitag");
        break;
    default:
        Console.WriteLine("Heute ist kein Wochentag");
        break;
}