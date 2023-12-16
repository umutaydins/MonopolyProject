using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
public enum Condition
{
    CollectBoard,
    PlaceBoard,
    Collect,
}
public class DefaultTile : Tile
{
    private int fee;
    private Player player1;
    private Condition condition { get; set; }

    public DefaultTile(int id, string name, string description, int fee,Condition condition)
        : base(id, name, description)
    {
        this.fee = fee;
        this.condition = condition;
    }

    public int Fee
    {
        get { return fee; }
    }

    public override void LandOn(Player player)

    {

        Console.WriteLine($"Player {player.Name} landed on the {base.Name} Tile.");
        Console.WriteLine(Description);
        int con = (int)condition;
        if (con == 0)
        {
            player.EarnMoney(player.Money + Board.Instance.cash);
            Board.Instance.cash = 0;
        }
        else if (con == 1)
        {
            player.deductMoney(fee);
            Board.Instance.cash += fee;
            // income tax tile
        }
        else if (con == 2)
        {
            player.EarnMoney(fee);
            // start tile
        }

        // Implement logic to transfer money from player to the bank
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
