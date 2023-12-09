using System;
using System.Drawing;
public class CommunityChestCardTile: Tile
{
    public CommunityChestCardTile(int id, string name, string description) : base(id, name, description)
    {
    }

    public void DrawCard()
    {
        // Community Chest kartı özel davranışları burada tanımlanır.
    }

    public override void LandOn(Player player)
    {
        throw new NotImplementedException();
    }
}
