using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class UtilityTile : Tile, IOwnable
{


    public int Charge { get; private set; }

    public int Price { get; private set; }

    public Player Owner { get; set; }
    public bool IsBuyDecisionMade { get; set; }



    public UtilityTile(int id, string name, string description, int price)
        : base(id, name, description)
    {
        Price = price;
        this.Owner = null;
    }


    public bool IsOwned() { return Owner != null; }






    public override void LandOn(Player player)

    {
        if (!IsBuyDecisionMade)
        {


            if (IsOwned() && Owner != player)
            {
                int dice = player.RollDice();
                if (Owner.getUtilityCardCount() == 1)
                {


                    Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice * 5} to {Owner.Name}");
                    player.PayToOtherPlayer(Owner, dice * 5);

                }
                else if (Owner.getUtilityCardCount() == 2)
                {
                    Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice * 10} to {Owner.Name}");
                    player.PayToOtherPlayer(Owner, dice * 10);

                }

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
            Owner.playerUtilityCardList.Add(this);
        }
    }
}
