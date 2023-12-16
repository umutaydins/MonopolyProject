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
       // this.fee = fee;
       // fee kısmını bizim vermemize gerek yok 
    }

    

    public override void LandOn(Player player)

    {
        if(base.Name=="Income Tax Tile"){

            player.deductMoney(200);
            Board.Instance.cash +=200; 

            Console.WriteLine($"Board has: {Board.Instance.cash}TL");

        }

        else if(base.Name=="Luxury Tax Tile"){
            
            
            player.deductMoney(150);
            Board.Instance.cash +=150; 
            Console.WriteLine($"Board has: {Board.Instance.cash}TL");
        }

        else if(base.Name=="Free Parking Tile"){
            
            player.EarnMoney(Board.Instance.cash);
            Board.Instance.cash = 0;
            Console.WriteLine($"Board has: {Board.Instance.cash}TL");
        }
        else if (Name=="Beginning Tile"){
            
            player.EarnMoney(200);

        }

    }
    public override string ToString()
    {
        return base.ToString();
    }
}
