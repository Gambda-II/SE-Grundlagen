//Collections / Sammlungen
#region Arrays
// initialize an array with length 8
using Microsoft.VisualBasic;

int[] ints = new int[2*4];


for (int i = 0; i <ints.Length; i++)
{
    ints[i] = i++;
    Console.WriteLine(string.Join(',',ints));
}

var innts = ints.Append<int>(20);
Console.WriteLine("Old Array after Append()" + string.Join(',', ints));
Console.WriteLine("New Array after Append()" + string.Join(',', innts));
#endregion

#region Lists
List<int> intsList= new List<int>();
List<int[]> intsListArray= new List<int[]>();
List<int[][]> intsListArrayJagged = new List<int[][]>();
List<int[][][]> intsListArrayMatrixReloaded = new List<int[][][]>();
List<List<int>> intsListList = new List<List<int>>();
List<List<int[][]>> intsListListArray = new List<List<int[][]>>();



List<string> namen = new ();
//Add some values / names to the list via .Add()
namen.Add("John Dorian");
namen.Add("Jane Dorian");
namen.Add("John Johnson");
namen.Add("Meister Schief");
Console.WriteLine("Added some names.");
Console.WriteLine(string.Join('\n', namen));
Console.Write('\n');

//Find a value / name in the list 
//Predicate = hwhat geht nicht
//Predicate<string> findJohn = (string s) => { return s == "John"; };
//Console.WriteLine("I've been looking for ...");
//Console.WriteLine((string)namen.Find(findJohn));
//Console.Write('\n');

//Remove a value / name from the list, needs to be exact
namen.Remove("John");
namen.Remove("John Johnson");
Console.WriteLine("Removed a name");
Console.WriteLine(string.Join('\n', namen));
Console.Write('\n');

//Sort a list
Console.WriteLine("Before .Sort()\n" + string.Join(',', namen));
namen.Sort();

Console.WriteLine("After .Sort()\n" + string.Join(',', namen));
Console.Write('\n');

List<double> usefulConstants = new();
usefulConstants.Add(Double.Pi);
usefulConstants.Add(Double.E);
usefulConstants.Add(Double.Epsilon);

#endregion