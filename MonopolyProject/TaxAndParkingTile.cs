using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class TaxAndParkingTile : Tile
{
    private int fee;
    private Player player1;

    public TaxAndParkingTile(int id, string name, string description, int fee)
        : base(id, name, description)
    {
        this.fee = fee;
    }

    public int Fee
    {
        get { return fee; }
    }

    public override void LandOn(Player player)

    {
        if(base.GetName()=="Income Tax Tile"){
            player.deductMoney(200);
        }


        Console.WriteLine($"Player {player.Name} landed on the {base.Name} Tile.");
        Console.WriteLine($"Player {player.Name} pays ${fee} to the bank.");

        
        // Implement logic to transfer money from player to the bank
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
