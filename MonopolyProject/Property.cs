using System.Drawing;

public class Property : Tile, IOwnable
{


    public int Price { get; set; }
    public Player Owner { get; set; }
    private Color Color { get; set; }




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
    }


    public bool IsOwned() { return Owner != null; }


    public override string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";


        string result = base.ToString(); // Use the common part from the base class

        // Add property-specific details if needed
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