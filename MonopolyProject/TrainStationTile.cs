using System;
using System.Drawing;
public class TrainStation : Tile, IOwnable
{
    public int Rent { get; set; }
    public int Price { get; set; }
    public Player Owner { get; set; }
    public int StationsOwned { get; set; }

    public TrainStation(int id, string name, string description, int price)
        : base(id, name, description)
    {
        this.Price = price;
        this.Owner = null;
        this.StationsOwned = 0;
    }

    public void IncrementStationsOwned()
    {
        StationsOwned++;
    }

    public override void LandOn(Player player)
    {
        Console.WriteLine($"Player {player.Name} landed on the Train Station tile.");
        if (Owner != null)
        {
            int totalRent = CalculateRent();
            Console.WriteLine($"Player {player.Name} pays ${totalRent} rent to {Owner.Name}.");
            // Implement logic to transfer money from player to ownedBy
        }
        else
        {
            Console.WriteLine($"This Train Station is unowned. Would you like to buy it?");
            // Implement logic for player to buy the Train Station
            //asdasdasdasdsadsadasd
        }
    }

    public bool IsOwned() { return Owner != null; }

    private int CalculateRent()
    {

        return Rent * (int)Math.Pow(2, StationsOwned - 1); // sonradan düzenlenecek
    }
    public override string ToString()
    {
        return base.ToString();
    }

    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);
    }
}
