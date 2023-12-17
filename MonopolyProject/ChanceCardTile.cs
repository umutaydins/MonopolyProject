using System;
using System.Drawing;
public class ChanceCardTile : Tile
{
        public static List<Player> players;

    public ChanceCardTile(int id, string name, string description) : base(id, name, description)
    {

    }

    public override void LandOn(Player player)
    {
        Console.WriteLine($"{player.Name} landed on {Name}.");
        DrawRandomChanceCard(player,players);}

    private void DrawRandomChanceCard(Player player, List<Player> players)
    {
        // list of chance card actions
        List<string> chanceCardActions = new List<string>
        {
            "Collect 150Ꝟ.",
            "Collect 50Ꝟ.",
            "Place 150Ꝟ on the board",
            "Place on the board 25 for each owned house, and 100Ꝟ for each owned hotel",
            "Travel to the nearest train station. Collect 200Ꝟ if youpass through the beginning tile.",
            "Go back 3 tiles.",
            "Get out of jail immediately, if in jail.",
            "Pay each player 50Ꝟ."
        };

        // Randomly selectn
        Random random = new Random();
        int randomIndex = random.Next(chanceCardActions.Count);
        string selectedAction = chanceCardActions[randomIndex];

       
        PerformChanceCardAction(player, selectedAction,players);
    }

    private void PerformChanceCardAction(Player player, string action, List<Player> players)
    {
        switch (action)
        {
            case "Collect 150Ꝟ":
                player.EarnMoney(150);
                Console.WriteLine($"{player.Name} collected 200Ꝟ.");
                break;
            case "Collect 50Ꝟ":
                player.EarnMoney(50);
                Console.WriteLine($"{player.Name} collected 100Ꝟ.");
                break;
            case "Place 150 on the board":
                            player.PayToBank(150);


            
                break;

            case "Place on the board 25 for each owned house, and 100Ꝟ for each owned hotel":
             if(player.HotelCount>0){
                player.PayToBank(player.HotelCount*100);
             }    
              else{
                player.PayToBank(player.HouseCount*25);
             }        
                break;   

                 
            case "Travel to the nearest train station. Collect 200Ꝟ if youpass through the beginning tile.":
             player.goToNeartestUtiliy();
            
                break; 

            case "Go back 3 tiles.":
            player.Position-=3;
                break;

            case "Get out of jail immediately, if in jail.":
              player.GoToJail(Board.Instance);
                break; 


            case "Pay each player 50Ꝟ.":
             foreach (Player otherPlayer in players)
             {
                if (otherPlayer != player)
                {
                    player.PayToOtherPlayer(otherPlayer, 50);
                    Console.WriteLine($"{otherPlayer.Name} collected 100Ꝟ from {player.Name}.");
                }
             }

               break;       
            default:
                Console.WriteLine($"Unhandled chance card action: {action}");
                break;
        }
    }
}
