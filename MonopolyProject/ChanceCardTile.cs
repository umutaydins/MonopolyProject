using System;
using System.Drawing;
public class ChanceCardTile : Tile
{
    public static List<Player> players= MonopolyProject.players;
    List<string> chanceCardActions;

    public ChanceCardTile(int id, string name, string description) : base(id, name, description)
    {
        chanceCardActions = new List<string>();
        Suffle();
    }

    public override void LandOn(Player player)
    {
        Console.WriteLine($"{player.Name} landed on {Name}.");
        DrawRandomChanceCard(player,players);}

    private void Suffle()
    {
        chanceCardActions.Add("Collect 150Ꝟ.");
        chanceCardActions.Add("Collect 50Ꝟ.");
        chanceCardActions.Add("Place 150Ꝟ on the board.");
        chanceCardActions.Add("Place on the board 25Ꝟ for each owned house, and 100Ꝟ for each owned hotel.");
        chanceCardActions.Add("Travel to the nearest train station. Collect 200Ꝟ if youpass through the beginning tile.");
        chanceCardActions.Add("Go back 3 tiles.");
        chanceCardActions.Add("Get out of jail immediately, if in jail.");
        chanceCardActions.Add("Pay each player 50Ꝟ.");
    }

    private void DrawRandomChanceCard(Player player, List<Player> players)
    {
        if (chanceCardActions.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Suffling Card...");
            Console.ResetColor();
            Suffle();
        }
        // list of chance card actions

        // Randomly selectn
        Random random = new Random();
        int randomIndex = random.Next(chanceCardActions.Count);
        string selectedAction = chanceCardActions[randomIndex];

        PerformChanceCardAction(player, selectedAction,players);
        chanceCardActions.Remove(selectedAction);
        
    }

    private void PerformChanceCardAction(Player player, string action, List<Player> players)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Description:\n--------------------------------------");
        Console.WriteLine(action);   
        Console.WriteLine("--------------------------------------");
        Console.ResetColor();
        switch (action)
        {
            case "Collect 150Ꝟ.":
                player.EarnMoney(150);
                Console.WriteLine($"{player.Name} collected 150Ꝟ.");
                break;
            case "Collect 50Ꝟ.":
                player.EarnMoney(50);
                Console.WriteLine($"{player.Name} collected 50Ꝟ.");
                break;
            case "Place 150Ꝟ on the board.":
                player.PayToBank(150);
                Board.Instance.cash += 150;
                Console.WriteLine($"Board has: {Board.Instance.cash}TL");
                break;

            case "Place on the board 25Ꝟ for each owned house, and 100Ꝟ for each owned hotel.":

                if(player.HouseCount>0){
                    Console.WriteLine($"{player.Name} has {player.HouseCount} House{(player.HouseCount > 1 ? "'s": "")}");
                    player.PayToBank(player.HouseCount * 25);
                    Board.Instance.cash += player.HouseCount * 25;

                    if(player.HotelCount > 0)
                    {
                        Console.WriteLine($"{player.Name} has {player.HotelCount} Hotel{(player.HotelCount > 1 ? "'s" : "")}");
                        player.PayToBank(player.HotelCount * 100);
                        Board.Instance.cash += player.HotelCount * 100;
                    }
                }
                else
                {
                    Console.WriteLine($"{player.Name} has no property.");
                }
                break;   
                
            case "Travel to the nearest train station. Collect 200Ꝟ if youpass through the beginning tile.":


                player.goToNeartestStation();

                int difference =  player.Position-Id;

               // Check if the new position is negative
                if (difference < 0)
                {
                player.EarnMoney(200); // Give the player $200
                           Console.WriteLine($"{player.Name} traveled to the nearest train station and collected 200Ꝟ.");
                           player.TryToBuyTile();

                }
                else{
                           Console.WriteLine($"{player.Name} traveled to the nearest train station.");
                            player.TryToBuyTile();
                }

                break;


            case "Go back 3 tiles.":
                player.Position-=3;
                player.TryToBuyTile();
                break;

            case "Get out of jail immediately, if in jail.":
                player.TurnsInJail=0;
                player.IsInJail=false;
                break; 


            case "Pay each player 50Ꝟ.":

             foreach (Player otherPlayer in players)
             {        

                if (otherPlayer != player)
                {
                    player.PayToOtherPlayer(otherPlayer, 50);
                    Console.WriteLine($"{otherPlayer.Name} collected 50Ꝟ from {player.Name}.");
                }
             }

               break;       
            default:
                Console.WriteLine($"Unhandled chance card action: {action}");
                break;
        }
    }
}
