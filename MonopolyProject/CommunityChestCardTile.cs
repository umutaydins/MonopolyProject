using System;
using System.Drawing;
public class CommunityChestCardTile: Tile
{
  
    public CommunityChestCardTile(int id, string name, string description) : base(id, name, description)
    {

    }

    public override void LandOn(Player player)
    {
        Console.WriteLine($"{player.Name} landed on {Name}.");
        DrawRandomCommunitycard(player);
    }

    private void DrawRandomCommunitycard(Player player)
    {
        // list of chance card actions
        List<string> communityCardAction = new List<string>
        {
            "Collect 200Ꝟ",
            "Collect 100Ꝟ",
            "Place 100 on the board",
            "Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel",
            "Travel to the nearest utility (electric company or water works). Collect 200Ꝟ if you pass through the beginning tile",
            "Advance to the beginning tile",
            "Travel to jail immediately. Do not collect 200Ꝟ if you pass through the beginning tile",
            "Collect 100Ꝟ from each player"
        };

        // Randomly selectn
        Random random = new Random();
        int randomIndex = random.Next(communityCardAction.Count);
        string selectedAction = communityCardAction[randomIndex];

       
        PerformChanceCardAction(player, selectedAction);
    }

    private void PerformChanceCardAction(Player player, string action)
    {
        switch (action)
        {
            case "Collect 200Ꝟ":
                player.EarnMoney(200);
                Console.WriteLine($"{player.Name} collected 200Ꝟ.");
                break;
            case "Collect 100Ꝟ":
                player.EarnMoney(100);
                Console.WriteLine($"{player.Name} collected 100Ꝟ.");
                break;
            case "Place 100 on the board":

            
                break;

            case "Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel":
             if(player.HotelCount>0){
                player.PayToBank(player.HotelCount*115);
             }    
              else{
                player.PayToBank(player.HouseCount*40);
             }        
                break;   

                 
            case "Travel to the nearest utility (electric company or water works). Collect 200Ꝟ if you pass through the beginning tile":
             player.goToNeartestUtiliy();
             
            
                break; 

            case "Advance to the beginning tile":
            player.SetPositionToBeginning();
                break;

            case "Travel to jail immediately. Do not collect 200Ꝟ if you pass through the beginning tile":
              player.GoToJail(Board.Instance);
                break; 


            case "Collect 100Ꝟ from each player":
               break;       
            default:
                Console.WriteLine($"Unhandled chance card action: {action}");
                break;
        }
    }
}
