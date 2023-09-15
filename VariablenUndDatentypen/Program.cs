using System.Net; //brauch ich für IP-Adressen
using System.Numerics; //brauch ich für Vektoren

#region Variablen
// // // // // //
// Variablen Deklaration
// Datentyp Variablenname;


bool isItMeYoureLookingFor;

string name;
char symbol;

int age;
float speed;
double measure;
decimal distance;

object something;

Vector2 twoDirections;
Vector3 threeDirections;

IPAddress address;

// var irgendwas; geht nicht, muss initialisiert werden

// // // // // //
// Variablen Initialisierung / Assignment
// Variablenname = Wert;

isItMeYoureLookingFor = false;

name = "Alexhander";
symbol = '?';

age = 69;
speed = 1.23f;
measure = 1.2345;
distance = 1.25M;

something = new object();

twoDirections = new Vector2(1.0f,2.7f);
threeDirections = new Vector3(0.1f, 1.2f, 12.3f);

address = new IPAddress(123456); // 123456 => 64.226.1.0 ???
Console.WriteLine("This is an ip adress: " + address);

var irgendwas = new Random();

// // // // // //
// Variablen deklarieren und initialisieren
// Datentyp Variablenname = Wert;

int firstInteger = 1;
int firstPrime = 2, secondPrime = 3, thirdPrime = 5;
var chesseCake = "is the best cake";

// // // // // //
//lokale Variablen in einem Statement sind äh lokal

int i = 0;
while(i < 5)
{
    var xyz = 10;
    i++;
}
// Wenn ein Codeblock geschlossen wird, sind alle Variablen, die innerhalb des Blocks deklariert wurden nicht mehr gültig => Können danach nicht mehr verwendet werden.
// xyz => Geht hier nicht mehr, da xyz sich in einem anderem SCOPE befindet
// var xyz = 20; => Variable kann dafür aber neu deklariert werden
#endregion

#region Datentypen
//Primitive Datentypen
//

bool boolean = false || true;
int integer = 420;
float floatingNumber = 1.0f; //needs f or M
double doubleNumber = 1.0; //
decimal dezimalNumber = 1.0m; //needs m or M
char sign = '+';

/* float: bitstring to decimal conversion
 * 
 * 01000001001011000000000000000000 -> 32 bits
 * 0 10000010 01011000000000000000000 -> first bit = sign bit, next 8 bits = exponent bit, next 23 bits = mantissa, bias = -127
 * note: mantissa has a leading hidden bit, when exponent is nonzero
 * sign * mantissa * 2^(exponent + bias)
 * 0 => sign = +
 * 1000 0010 => exponent = 130
 * (1)010 1100 0000 0000 0000 0000 => mantissa = 2 883 584
 * (1.0) + 0 + .25 + 0 + .0625 + 0.03125 + 0 + 0 + 0 + ... = 1.34375 !!OR!! 2 883 584 / 2^(23) = 0.34375 + hidden 1.0 => 1.34375
 * 
 * 0 10000010 01011000000000000000000 => + 1.34375 * 2^(130-127) = + 1.34375 * 2^3 => + 1.34375 * 8 = + 10.75
 * 
 * float: decimal to bitstring conversion
 * 
 * - 15.8 
 * ----> 15 / 2 = 7 R 1 => 1        ----> .8 * 2 = 1.6 => 1
 * ----> 7 / 2  = 3 R 1 => 1        ----> .6 * 2 = 1.2 => 1
 * ----> 3 / 2  = 1 R 1 => 1        ----> .2 * 2 = 0.4 => 0
 * ----> 1 / 2  = 0 R 1 => 1        ----> .4 * 2 = 0.8 => 0 repeated ==> 1100 1100 1100 [1100...] mantissa bits
 * ----> 0 / 2  = 0 R 0 => 0 ==> 01111 exponent bits ==> 00001111
 * ==> full bitstring 00001111.110011001100...
 * decimalpoint shift 3 to the left to hidden bit ==> 00001.111110011001100... 
 * exponent = shift + bias = 3 + 127 = 130 => 10000010
 * mantissa = 1111100110011001100... truncated to 23 bits => 1111 1001 1001 1001 1001 100
 * sign bit = 1
 * full bitstring => 1 10000010 11111001100110011001100...
 * 11000001011111001100110011001100...
 * my bit string:               11000001011111001100110011001100
 * actual stored bit string:    11000001011111001100110011001101
 * last bit should be rounded up because the next bit was 1
 * 
 */

//Komplexe Datentypen
object myObject = new object();
string myString = "Hello Morld!";
dynamic myDynamic;
List<int> listOfIntegers = new List<int> { 1,2,3,4,5};
int[] arrayOfIntegers = {1,2,3,4};
int[,] matrixOfIntegers = { {1,2,3 },{4,5,6 } };
double[] arrayOfDoubles = new double[5];
    arrayOfDoubles[3] = Math.PI;
    arrayOfDoubles[1] = double.Epsilon;
double[][] jaggedArray = new double[2][];
    jaggedArray[0] = new double[3] { 1.0, 3.0, 5.0 };
    jaggedArray[1] = new double[3] { 2.0, 4.0, 6.0 };
//  jaggedArray[2] = new double[3] { 3.0, 6.0, 9.0 }; geht nicht weil die Dimension bis 2 geht

#endregion

#region Werte & Referenzen, value types and reference types
int mamboNumber = 5;
int[] mamboArray = { 1, 2, 3 };

Console.WriteLine("Before Modify() ran.");
Console.WriteLine("This is Mambo Number " + mamboNumber);
Console.WriteLine("This is Mambo Array " + string.Join(',', mamboArray));

Modify(mamboNumber,mamboArray);

Console.WriteLine("After Modify() ran.");
Console.WriteLine("This is Mambo Number " + mamboNumber);
Console.WriteLine("This is Mambo Array " + string.Join(',', mamboArray));

#endregion

void Modify(int num, int[] array)
{
    num = 4;
    array[0] = 500;
}