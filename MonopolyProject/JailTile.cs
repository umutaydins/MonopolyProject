using System;

public class JailTile : Tile
{
    public JailTile(int id, string name, string description)
        : base(id, name, description)
    {

    }

      public override void LandOn(Player player)
    {
        Console.WriteLine($"Player {player.Name} landed on the Jail tile.");
        player.GoToJail(Board.Instance); 
    }

}
