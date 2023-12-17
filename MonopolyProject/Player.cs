using System;
using System.Collections.Generic;


public class Player
{
    public string Name { get; }
    public int Money { get; private set; }

    public int Position { get; set; }

    public Tile CurrentTile { get; private set; }


    public List<UtilityTile> playerUtilityCardList { get; set; } = new List<UtilityTile>();
    public List<TrainStation> playerTrainStationCardList { get; set; } = new List<TrainStation>();
    public List<Property> playerPropertyCardList { get; set; } = new List<Property>();

    //public int TrainStations { get; set; }
    public bool IsInJail { get; set; }
    public int TurnsInJail { get; set; }

    public int HouseCount { get; private set; }
    public int HotelCount { get; private set; }



    private readonly Board board;


    public Player(string name, Board board)
    {
        Name = name;
        Money = 20000;
        Money = 400;
        Position = 0;
        IsInJail = false;
        TurnsInJail = 0;
        HouseCount = 0;
        HotelCount = 0;
        this.board = board; // Store the reference to the Board

    }


    // Player sınıfındaki RollDice metodu
    private int RollDie()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    // Player sınıfındaki RollDice metodu
    public int RollDice()
    {
        int dice1 = RollDie();
        int dice2 = RollDie();

        Console.WriteLine($"{Name} rolled a {dice1} and {dice2}.");
        return dice1 + dice2;
    }


    public void TryToBuyTile()
    {
        if (CurrentTile is IOwnable ownableTile)
        {
            if (!ownableTile.IsOwned())


            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Do you want to buy {ownableTile.Name} for {ownableTile.Price} TL? (Y/N)");
                Console.ResetColor();

                string input = Console.ReadLine();
                if (input.Trim().ToUpper() == "Y")
                {
                    ownableTile.Purchase(this);
                    Console.WriteLine($"{Name} current balance: {Money} TL");

                    // Set the flag to indicate that the player has decided to buy
                    ownableTile.IsBuyDecisionMade = true;
                    return;
                }
                else
                {
                    Console.WriteLine($"{Name} decided not to buy {ownableTile.Name}.");
                }
            }
            else
            {
                Console.WriteLine($"{ownableTile.Name} is already owned by {ownableTile.Owner.Name}.");
            }
        }
    }



    public void Move(Board board)
    {
        int steps = RollDice();
        Position = (Position + steps) % board.Size;

        Console.WriteLine($"\n{Name} rolled a {steps} and moved to position {Position} on the board.");

        CurrentTile = board.Tiles[Position];
        Console.WriteLine($"\n{Name} is here: \n" + CurrentTile.ToString());
        DisplayAssets();
        TryToBuyTile();
        CurrentTile.LandOn(this);


        Console.WriteLine($"{Name}'s turn is complete.\n----------------------------------------");
    }

    public void DisplayAssets()

    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n\n{Name}'s Assets:");
        Console.WriteLine("------------------------------");

        // Display properties
        Console.WriteLine("Properties:");
        foreach (Property property in playerPropertyCardList)
        {
            Console.WriteLine($"- {property.Name} (Houses: {property.HouseCount}, Hotels: {property.HotelCount})");
        }

        // Display utility cards
        Console.WriteLine("\nUtility Cards:");
        foreach (UtilityTile utilityTile in playerUtilityCardList)
        {
            Console.WriteLine($"- {utilityTile.Name}");
        }

        // Display train station cards
        Console.WriteLine("\nTrain Station Cards:");
        foreach (TrainStation trainStation in playerTrainStationCardList)
        {
            Console.WriteLine($"- {trainStation.Name}");
        }

        Console.WriteLine("\n------------------------------");
        Console.WriteLine($"{Name}'s Total Money: {Money} TL");
        Console.WriteLine("------------------------------");
        Console.ResetColor();
    }



    public void BuildHouse()
    {
        // Oyuncunun bulunduğu karenin bir mülk olup olmadığını kontrol et
        if (CurrentTile is Property propertyTile)
        {
            // Mülk sahibi ise ve ev inşa edebilecek durumdaysa devam et
            if (propertyTile.Owner == this && CanBuildHouse(propertyTile))
            {
                // Evin fiyatı
                int housePrice = 50; // Bu değeri oyunun kurallarına göre ayarlayın

                // Oyuncunun ev inşa etmek için yeterli parası var mı kontrol et
                if (Money >= housePrice)
                {
                    // Ev inşa et
                    propertyTile.BuildHouse();

                    // Oyuncunun parasını azalt
                    PayToBank(housePrice);

                    Console.WriteLine($"{Name} has built a house on {propertyTile.Name}. Remaining money: {Money} TL");
                }
                else
                {
                    Console.WriteLine($"{Name} does not have enough money to build a house.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} cannot build a house on this property.");
            }
        }
        else
        {
            Console.WriteLine($"{Name} is not on a property tile. Cannot build a house.");
        }
    }
    private bool CanBuildHouse(Property propertyTile)
    {
        // Burada ev inşa etmek için gerekli diğer kontrolleri yapabilirsiniz
        // Örneğin, aynı renkteki tüm mülklerin aynı seviyede olup olmadığını kontrol etmek
        // veya başka özel durumları kontrol etmek için kullanılabilir.
        // Şu an için sadece ev sayısının bir sınıra ulaşıp ulaşmadığını kontrol ediyorum
        return propertyTile.HouseCount < 4; // Örneğin maksimum 4 ev olabilir
    }


    public void DrawCard()
    {

    }



    public void GoToJail(Board board)
    {
        Console.WriteLine($"{Name} goes to jail!");
        IsInJail = true;
        TurnsInJail = 2; // Number of turns the player should skip in jail

        // Set the player's position to the jail tile
        Position = 10;
        CurrentTile = board.Tiles[Position];
    }

    public void EndTurn()
    {
        // Decrease the TurnsInJail counter
        if (IsInJail)
        {
            TurnsInJail--;

            // Check if the player is still in jail or if their turns are up
            if (TurnsInJail == 0)
            {
                Console.WriteLine($"{Name} is released from jail!");
                IsInJail = false;
            }
            else
            {
                Console.WriteLine($"{Name} is still in jail. Turns remaining: {TurnsInJail}");
            }
        }


    }
    public void PayToOtherPlayer(Player player, int amount)
    {
        Console.WriteLine($"{Name} payed {amount}TL to {player.Name}!");
        Money = Money - amount;
        player.Money = player.Money + amount; // Methodlarla da yapulabilir 

    }

    public void EarnMoney(int amount)
    {
        Money += amount;
        Console.WriteLine($"{Name} earned {amount} money. Total money: {Money}");
    }

    public void deductMoney(int i)
    {
        Money = Money - i;
    }
    public int getUtilityCardCount()
    {
        return playerUtilityCardList.Count;
    }

    public int getTrainStationsCardCount()
    {
        return playerTrainStationCardList.Count;
    }

    internal void PayToBank(int amount)
    {

        Money -= amount;

    }
    public void goToNeartestUtiliy()
    {

        int currentPosition = Position;

        int nearestUtilityIndex = -1;
        int minDistance = int.MaxValue;

        for (int i = 0; i < board.Tiles.Count; i++)
        {
            if (board.Tiles[i] is UtilityTile utilityTile)
            {
                int distance = (i - currentPosition + board.Size) % board.Size;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestUtilityIndex = i;
                }
            }
        }

        // Move to the nearest utility tile
        Position = nearestUtilityIndex;
        CurrentTile = board.Tiles[nearestUtilityIndex];

        Console.WriteLine($"{Name} moved to the nearest utility tile: {CurrentTile.Name}");

    }
    public void SetPositionToBeginning()
    {
        Position = 0;
        CurrentTile = board.Tiles[Position];
    }


}