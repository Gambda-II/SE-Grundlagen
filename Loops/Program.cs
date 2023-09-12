Console.WriteLine("Demo loops");

//while loop
// while (condition){statment}
Console.WriteLine("\nWHILE LOOPS");
int iterCount = 0;
while (iterCount < 10)      //10 loops --> 0,1,2,3,4,5,6,7,8,9 < 10
{

    iterCount++;
    Console.WriteLine("WHILE " + iterCount);

}

//do while loop
//do{statement}while(condition)
Console.WriteLine("\nDO-WHILE LOOPS");
iterCount = 10;
do
{

    Console.WriteLine("DO WHILE " + iterCount);
    iterCount--;

} while (iterCount > 0);   //10 loops --> 10,9,8,7,6,5,4,3,2,1 > 0

//for loop
//for(index;condition;increment)
Console.WriteLine("\nFOR LOOPS");
int maxIter = 11;
for (int i = 1; i < maxIter; i++) //10 loops --> 1,2,3,4,5,6,7,8,9,10
{

    Console.WriteLine("FOR " + i);

}

//for multiple expressions
Console.WriteLine("\nFOR LOOPS with multiple expressions");
for (int i = 0, j = 0; i + j < 5; i++, j++)
{

    Console.WriteLine("Value of i: {0}, j: {1} ", i, j);

}

//foreach loop
//foreach(type variableName in arrayName)
string[] cars = { "Audi", "BMW", "VW", "Porsche" };
Console.WriteLine("\nFOREACH LOOPS");
foreach (string car in cars)
{

    Console.WriteLine("FOREACH {0}", car);

}

