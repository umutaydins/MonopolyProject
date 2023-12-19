using System;
using System.Drawing;
public class TrainStation : Tile, IOwnable
{
    public int Rent { get; set; }
    public int Price { get; set; }
    public Player Owner { get; set; }
    public bool IsBuyDecisionMade { get; set; }

    public TrainStation(int id, string name, string description, int price)
        : base(id, name, description)
    {
        this.Rent = 50;
        this.Price = price;
        this.Owner = null;

    }



    public override void LandOn(Player player)

    {
        if (!IsBuyDecisionMade)
        {


            if (IsOwned() && Owner != player)
            {
                int totalRent = CalculateRent();
                Console.WriteLine($"Player {player.Name} pays ${totalRent} rent to {Owner.Name}.");
                player.PayToOtherPlayer(Owner, totalRent);

            }
            else if (IsOwned() && Owner == player)
            {
                Console.WriteLine("This property is yours!");
            }
        }

        else
        {
            IsBuyDecisionMade = false;

        }



    }




    public bool IsOwned() { return Owner != null; }

    private int CalculateRent()
    {
        int TrainStationCount = Owner.getTrainStationsCardCount();

        return Rent * TrainStationCount;
    }

    public override void Display(string route,int position)
    {
        if (IsOwned())
        {
            Console.Write($"|{position}-{Name} Owner: {Owner.Name}|" + route);
        }
        else
        {
            base.Display(route,position);
        }
    }

    public override string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";


        string result = base.ToString(); // Use the common part from the base class



        result += $"\n{verticalLine,2} Price: {Price,13}\n" +
                  $"{verticalLine,2} Owner: {(Owner != null ? Owner.Name : "Does not have owner"),11}\n" +
                  $"{verticalLine}{horizontalLine}";


        return result;
    }

    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);
        if (this.Owner == buyer)
        {
            Owner.playerTrainStationCardList.Add(this);
        }
    }
}
