using System;
using System.Drawing;

public class CommunityChestCardTile: Tile

{
        public static List<Player> players= MonopolyProject.players;
    List<string> communityCardAction;


    public CommunityChestCardTile(int id, string name, string description) : base(id, name, description)
    {

        communityCardAction = new List<string>();
        Suffle();
    }

    public override void LandOn(Player player)
    { 
        Console.WriteLine($"{player.Name} landed on {Name}.");
        DrawRandomCommunitycard(player,players);
    }
    private void Suffle()
    {
        communityCardAction.Add("Collect 200Ꝟ");
        communityCardAction.Add("Collect 100Ꝟ");
        communityCardAction.Add("Place 100 on the board");
        communityCardAction.Add("Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel");
        communityCardAction.Add("Travel to the nearest utility (electric company or water works). Collect 200Ꝟ if you pass through the beginning tile");
        communityCardAction.Add("Advance to the beginning tile");
        communityCardAction.Add("Travel to jail immediately. Do not collect 200Ꝟ if you pass through the beginning tile");
        communityCardAction.Add("Collect 100Ꝟ from each player");
    }

    private void DrawRandomCommunitycard(Player player, List<Player> players)
    {
        if (communityCardAction.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Suffling Cards...");
            Console.ResetColor();
            Suffle();
        }

        // Randomly select
        Random random = new Random();
        int randomIndex = random.Next(communityCardAction.Count);
        string selectedAction = communityCardAction[randomIndex];

        PerformCommChanceCardAction(player, selectedAction, players);
        communityCardAction.Remove(selectedAction);
    }
    
    private void PerformCommChanceCardAction(Player player, string action, List<Player> players)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Description:\n--------------------------------------");
        Console.WriteLine(action);
        Console.WriteLine("--------------------------------------");
        Console.ResetColor();
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
                player.PayToBank(100);
                Board.Instance.cash += 100;
                Console.WriteLine($"Board has: {Board.Instance.cash}TL");
                break;

            case "Place on the board 40Ꝟ for each owned house, and 115Ꝟ for each owned hotel":
                if (player.HouseCount > 0)
                {
                    Console.WriteLine($"{player.Name} has {player.HouseCount} House{(player.HouseCount > 1 ? "'s" : "")}");
                    player.PayToBank(player.HouseCount * 40);
                    Board.Instance.cash += player.HouseCount * 40;

                    if (player.HotelCount > 0)
                    {
                        Console.WriteLine($"{player.Name} has {player.HotelCount} Hotel{(player.HotelCount > 1 ? "'s" : "")}");
                        player.PayToBank(player.HotelCount * 115);
                        Board.Instance.cash += player.HotelCount * 115;
                    }
                }
                else
                {
                    Console.WriteLine($"{player.Name} has no property.");
                }
                break;


            case "Travel to the nearest utility (electric company or water works). Collect 200Ꝟ if you pass through the beginning tile":
                player.goToNeartestUtiliy();
                player.TryToBuyTile();
                break; 

            case "Advance to the beginning tile":
            player.SetPositionToBeginning();
            player.EarnMoney(200);

                break;

            case "Travel to jail immediately. Do not collect 200Ꝟ if you pass through the beginning tile":
              player.GoToJail(Board.Instance);
                break; 


            case "Collect 100Ꝟ from each player":
             foreach (Player otherPlayer in players)
             {
                if (otherPlayer != player)
                {
                    otherPlayer.PayToOtherPlayer(player, 100);
                    Console.WriteLine($"{player.Name} collected 100Ꝟ from {otherPlayer.Name}.");
                }
             }

             
            break;
            
              

            default:
            Console.WriteLine($"Unhandled chance card action: {action}");
             break;
            }
    }
}
