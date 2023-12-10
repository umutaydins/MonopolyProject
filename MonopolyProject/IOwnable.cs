public interface IOwnable
{
    int Id { get; }
    string Name { get; }
    int Price { get; }
    Player Owner { get; set; }
    bool IsOwned();
    void Purchase(Player buyer);
}


public class TileOwnershipManager
{
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