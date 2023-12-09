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
        // Implement specific behavior for the JailTile, e.g., skip a turn or pay a fine
    }
}
