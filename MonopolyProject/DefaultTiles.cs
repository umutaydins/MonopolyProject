using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class DefaultTiles : Tile
{
    private Player player1;

    public DefaultTiles(int id, string name, string description)
        : base(id, name, description)
    {

    }



    public override void LandOn(Player player)

    {
        // Check the type of the tile and perform specific actions
        if (base.Name == "Income Tax Tile")
        {
            // Deduct money from the player and add to the board's cash
            player.deductMoney(200);
            Board.Instance.cash += 200;

            Console.WriteLine($"Board has: {Board.Instance.cash}TL");

        }

        else if (base.Name == "Luxury Tax Tile")
        {
            player.deductMoney(150);
            Board.Instance.cash += 150;
            Console.WriteLine($"Board has: {Board.Instance.cash}TL");
        }

        else if (base.Name == "Free Parking Tile")
        {
            // Earn money for the player from the board's cash and reset board's cash
            player.EarnMoney(Board.Instance.cash);
            Board.Instance.cash = 0;
            Console.WriteLine($"Board has: {Board.Instance.cash}TL");
        }
        else if (Name == "Beginning Tile")
        {
            // Earn money for the player
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.Name} passed begining tile. {player.Name} Get 200.");
            Console.ResetColor();
            player.EarnMoney(200);

        }

    }
    public override string ToString()
    {
        return base.ToString();
    }
}
