using System;
using System.Drawing;
public class TrainStation : Tile
{
    private int rent;
    private Player ownedBy;
    private int stationsOwned;

    public TrainStation(int id, string name, string description, int rent)
        : base(id, name, description)
    {
        this.rent = rent;
        this.ownedBy = null;
        this.stationsOwned = 0;
    }

    public int Rent
    {
        get { return rent; }
    }

    public Player OwnedBy
    {
        get { return ownedBy; }
        set { ownedBy = value; }
    }

    public int StationsOwned
    {
        get { return stationsOwned; }
    }

    public void IncrementStationsOwned()
    {
        stationsOwned++;
    }

    public override void LandOn(Player player)
    {
        Console.WriteLine($"Player {player.Name} landed on the Train Station tile.");
        if (ownedBy != null)
        {
            int totalRent = CalculateRent();
            Console.WriteLine($"Player {player.Name} pays ${totalRent} rent to {ownedBy.Name}.");
            // Implement logic to transfer money from player to ownedBy
        }
        else
        {
            Console.WriteLine($"This Train Station is unowned. Would you like to buy it?");
            // Implement logic for player to buy the Train Station
        }
    }

    private int CalculateRent()
    {
        
        return rent * (int)Math.Pow(2, stationsOwned - 1); // sonradan düzenlenecek
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
