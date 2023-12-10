using System;

public class JailTile : Tile
{
    public JailTile(int id, string name, string description)
        : base(id, name, description)
    {
        // Additional initialization for JailTile if needed
    }

      public override void LandOn(Player player)
    {
        Console.WriteLine($"Player {player.Name} landed on the Jail tile.");

        // Implement specific behavior for the JailTile
        player.GoToJail(Board.Instance); // Assuming you have a GoToJail method in the Player class
    }

}
