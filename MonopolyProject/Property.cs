using System.Drawing;

public class Property: Tile{

    public int id;
    private string name;
    private int price;
    private Player owner;
    private Color color;
    

    // Getter method for 'name' attribute
    public string GetName()
    {
        return name;
    }

    // Setter method for 'name' attribute
    public void SetName(string newName)
    {
        name = newName;
    }

    // Getter method for 'price' attribute
    public int GetPrice()
    {
        return price;
    }

    // Setter method for 'price' attribute
    public void SetPrice(int newPrice)
    {
        price = newPrice;
    }

    // Getter method for 'owner' attribute
    public Player GetOwner()
    {
        return owner;
    }

    // Setter method for 'owner' attribute
    public void SetOwner(Player newOwner)
    {
        owner = newOwner;
    }


    public Color GetColor()
    {
        return color;
    }

    // Setter method for 'color' attribute
    public void SetColor(Color newColor)
    {
        color = newColor;
    }

    public bool IsOwned(){
        return owner != null;

    }

    public int GetId()
    {
        return id;
    }
    

    public override void LandOn(Player player)
    {
        // renklere göre implement edilecek
        throw new NotImplementedException();
    }

    public Property(int id, string name, string description, int price, Player owner, Color color)
        : base(id, name, description)
    {
        this.price = price;
        this.owner = owner;
        this.color = color;
    }

    public override string ToString()
    {
        string horizontalLine = new string('-', 30); 
        string verticalLine = "|"; 

    
string result = base.ToString(); // Use the common part from the base class

        // Add property-specific details if needed
        result += $"\n{verticalLine,2} Price: {price, 13}{verticalLine, 5}\n" +
                  $"{verticalLine,2} Owner: {(owner != null ? owner.ToString() : "None"), 11}{verticalLine, 5}\n" +
                  $"{verticalLine,2} Color: {color, 12}{verticalLine, 5}\n" +
                  $"{verticalLine}{horizontalLine}{verticalLine, 5}";


        return result;
    }

}