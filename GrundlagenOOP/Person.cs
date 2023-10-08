namespace GrundlagenOOP;

internal class Person
{
    private string firstName;
    public string FirstName { get => firstName; set => firstName = value; }

    private string lastName;
    public string LastName { get => lastName; set => lastName = value; }


    public Person(string firstName, string lastName)
    {

        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }

    public string FullNameLambda => FirstName + " " + LastName;

    public Action<string> Platzhalter = (string name) => Console.WriteLine($"Hello {name}");
}