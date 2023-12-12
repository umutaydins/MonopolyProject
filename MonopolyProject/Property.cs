using System.Drawing;

public class Property : Tile, IOwnable
{


    public int Price { get; set; }
    public Player Owner { get; set; }
    private Color Color { get; set; }
    public int HouseCount { get; private set; } // New property to track the number of houses





    public override void LandOn(Player player)
    {
        // renklere göre implement edilecek
        throw new NotImplementedException();
    }

  public Property(int id, string name, string description, int price, Player owner, Color color)
        : base(id, name, description)
    {
        this.Price = price;
        this.Owner = owner;
        this.Color = color;
        this.HouseCount = 0; // Initialize the house count
    }


    public bool IsOwned() { return Owner != null; }
   
    public void BuildHouse()
    {
        if (CanBuildHouse())
        {
            HouseCount++;
            Console.WriteLine($"A house is built on {Name}. Total houses: {HouseCount}");
        }
        else
        {
            Console.WriteLine($"Cannot build more houses on {Name}. Maximum limit reached.");
        }
    }

    private bool CanBuildHouse()
    {
        return HouseCount < 4; // Example: Maximum of 4 houses allowed
    }



    public override string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";


        string result = base.ToString(); // Use the common part from the base class

                result += $"\n| House Count: {HouseCount, 9} |";



        result += $"\n{verticalLine,2} Price: {Price,13}{verticalLine,5}\n" +
                  $"{verticalLine,2} Owner: {(Owner != null ? Owner.ToString() : "None"),11}{verticalLine,5}\n" +
                  $"{verticalLine,2} Color: {Color,12}{verticalLine,5}\n" +
                  $"{verticalLine}{horizontalLine}{verticalLine,5}";


        return result;
    }

    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);
    }
}