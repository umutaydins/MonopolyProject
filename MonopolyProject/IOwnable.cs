// Interface representing an ownable item, such as a property or tile
public interface IOwnable
{
    int Id { get; }
    string Name { get; }
    int Price { get; }
    Player Owner { get; set; }
    bool IsOwned();
    void Purchase(Player buyer);
    // Property to track whether the buy decision is made for the item
    public bool IsBuyDecisionMade { get; set; }
}

// Manager class to handle the purchase of ownable items
public class TileOwnershipManager
{
    // Method to handle the purchase of an ownable item by a player
    public void PurchaseTile(IOwnable tile, Player buyer)
    {
        if (!tile.IsOwned())
        {
            int price = tile.Price;
            if (buyer.Money >= price)
            {
                buyer.PayToBank(price);
                tile.Owner = buyer;
                Console.WriteLine($"{buyer.Name} has purchased {tile.GetType().Name} '{tile.Name}' for {price} TL.");
                
            }
            else
            {
                Console.WriteLine($"{buyer.Name} does not have enough money to purchase {tile.GetType().Name} '{tile.Name}'.");
            }
        }
        else
        {
            Console.WriteLine($"{tile.GetType().Name} '{tile.Name}' is already owned by {tile.Owner.Name}.");
        }
    }
}