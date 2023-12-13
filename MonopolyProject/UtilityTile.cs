using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class UtilityTile : Tile,IOwnable
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


    public bool IsOwned() {return Owner != null;}


    

    

    public override void LandOn(Player player)

    {
      if (Owner != null){
        int dice = player.RollDice();
        if (Owner.getUtilityCardCount()==1){

            
            Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice*5} to {Owner.Name}");
            player.PayToOtherPlayer(Owner,dice*5);
            
        }
        else if (Owner.getUtilityCardCount()==2){
            Console.WriteLine($"{player.Name} rolled a {dice}. {player.Name} will pay {dice*10} to {Owner.Name}");
            player.PayToOtherPlayer(Owner,dice*10);

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

    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);
    }
}
