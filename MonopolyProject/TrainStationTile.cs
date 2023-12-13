using System;
using System.Drawing;
public class TrainStation : Tile, IOwnable
{
    public int Rent { get; set; }
    public int Price { get; set; }
    public Player Owner { get; set; }
    public int StationsOwned { get; set; }
    public bool IsBuyDecisionMade { get; set; }

    public TrainStation(int id, string name, string description, int price)
        : base(id, name, description)
    {
        this.Rent = 50;
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
        if (Owner != player)
        {
            int totalRent = CalculateRent();
            Console.WriteLine($"Player {player.Name} pays ${totalRent} rent to {Owner.Name}.");
            player.PayToOtherPlayer(Owner, totalRent);
        }
    }

    public bool IsOwned() { return Owner != null; }

    private int CalculateRent()
    {

        return Rent * Owner.TrainStations; // sonradan düzenlenecek
    }
    public override string ToString()
    {
        return base.ToString();
    }

    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);
        buyer.TrainStations++;
    }
}
