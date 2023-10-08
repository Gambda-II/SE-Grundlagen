namespace GrundlagenOOP;

public class Dog

{

    //property  shortcut prop + TAB or prop + ENTER
    
    // standard, shortened
    public float Speed { get; set; }

    // standard, expanded
    private int _amount;
    public int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }

    // prop with no set, can't set Nickname
    public string Nickname { get; }

    //prop with no get, can't set EyeColor, does not work with auto complete -> needs get
    //public string EyeColor { set; }

    // customized prop
    private string color;
    public string Color 
    { 
        get 
        { 
            return color; 
        } 
        set 
        {
            if (value == "black" || value == "white")
            {
                color = value;
            }
        }  
    }


    public int ID { get; }

    //field
    public string name;


    public Dog(int id, string name, string color)
    {
        this.ID = id;
        this.name = name;
        this.Color = color;
    }

    public void Bark()
    {

        Console.WriteLine("Wuff");
    }

}