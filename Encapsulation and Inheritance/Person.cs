namespace Encapsulation_and_Inheritance
{
    internal class Person
    {
        // in general, fields _identifier and properties Identifier

        string name;
        string vorname;
        string geburtstag;
        string anschrift;
        string plz;
        string ort;

        public Person()
        {
            
        }

        public Person(string name, string vorname, string geburtstag, string anschrift, string plz, string ort)
        {
            Name = name;
            Vorname = vorname;
            Geburtstag = geburtstag;
            Anschrift = anschrift;
            Plz = plz;
            Ort = ort;
        }

        public string Name { get => name; set => name = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Geburtstag { get => geburtstag; set => geburtstag = value; }
        public string Anschrift { get => anschrift; set => anschrift = value; }
        public string Plz { get => plz; set => plz = value; }
        public string Ort { get => ort; set => ort = value; }
    }
}
