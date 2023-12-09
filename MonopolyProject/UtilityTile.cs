using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class UtilityTile : Tile
{

    private int price;
    private int charge;
    private Player owner;


    public UtilityTile(int id, string name, string description)
        : base(id, name, description)
    {
        
    }

    public int GetPrice()
    {
        return price;
    }

    public void SetPrice(int newPrice)
    {
        price = newPrice;
    }

    public int GetCharge()
    {
        return charge;
    }

    public void SetCharge(int newCharge)
    {
        charge = newCharge;
    }

    public Player GetOwner()
    {
        return owner;
    }

    public void SetOwner(Player newOwner)
    {
        owner = newOwner;
    }
    

    

    public override void LandOn(Player player)

    {
      if (GetOwner() != null){
        int dice = player.RollDice();
        if (owner.getUtilityCardCount()==1){

            
            Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice*5} to {owner.Name}");
            player.PayToOtherPlayer(owner,dice*5);
            
        }
        else if (owner.getUtilityCardCount()==2){
            Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice*10} to {owner.Name}");
            player.PayToOtherPlayer(owner,dice*10);

        }

      }

      else{

        //Satın alıp almak istemedigi sorulacak
      }

        
       
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
