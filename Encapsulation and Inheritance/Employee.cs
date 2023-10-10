namespace Encapsulation_and_Inheritance;

internal class Employee : Person
{
    // fields of the parent class are inherited, except ?

    // a public field that's not a parent field
    public int mitarbeiterID;


    // look this up
    public Employee() : base()
    {
    }

    // if the parent class has an empty constructor, this is a valid way to make a constructor

    /*
    public Employee(string name, string vorname, string geburtstag, string anschrift, string plz, string ort, int mitarbeiterID)
    {
        this.Name = name;
        this.Vorname = vorname;
        this.Geburtstag = geburtstag;
        this.Anschrift = anschrift;
        this.Plz = plz;
        this.Ort = ort;
        this.mitarbeiterID = mitarbeiterID;
    }
    */

    // else
    public Employee(string name, string vorname, string geburtstag, string anschrift, string plz, string ort, int mitarbeiterID) : base(name, vorname, geburtstag, anschrift, plz, ort)
    {
        this.mitarbeiterID = mitarbeiterID;
    }
}