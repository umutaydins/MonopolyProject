using System;
using System.Collections.Generic;


public class Player
{
    public string Name { get; }
    public int Money { get; private set; }
    public int Position { get; set; }
    public Tile CurrentTile { get; private set; }
    public bool IsInJail { get; set; }
    public int TurnsInJail { get; set; }
    public int LastDiceValue { get; private set; }
    public int HouseCount { get; private set; }
    public int HotelCount { get; private set; }
    // Lists to store different types of cards owned by the player
    public List<UtilityTile> playerUtilityCardList { get; set; } = new List<UtilityTile>();
    public List<TrainStation> playerTrainStationCardList { get; set; } = new List<TrainStation>();
    public List<Property> playerPropertyCardList { get; set; } = new List<Property>();



    // Reference to the game board
    private readonly Board board;


    public Player(string name, Board board)
    {
        Name = name;
        Money = 200;
        Position = 0;
        IsInJail = false;
        TurnsInJail = 2;
        HouseCount = 0;
        HotelCount = 0;
        this.board = board; // Store the reference to the Board

    }


    // Roll a single die
    private int RollDie()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    // Roll two dice and return the total
    public int RollDice()
    {
        int dice1 = RollDie();
        int dice2 = RollDie();

        Console.WriteLine($"\n{Name} rolled a {dice1} and {dice2}.");
        return dice1 + dice2;
    }

    // Attempt to buy the current tile if it is ownable
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


    // Move the player on the board
    public void Move(Board board)
    {
        // Check if the player is in jail; if so, they can't move
        if (!IsInJail)
        {
            Console.Clear();
            int steps = RollDice();
            if (Position + steps > board.Size - 1 && Position + steps != 40) { board.Tiles[0].LandOn(this); } // check player is pass starting tile if so player get 200
            Position = (Position + steps) % board.Size;

            Console.WriteLine($"\n{Name} rolled a {steps} and moved to position {Position} on the board.");

            CurrentTile = board.Tiles[Position];
            board.DisplayBoard(MonopolyProject.players);
            Console.WriteLine($"\n{Name} is here: \n" + CurrentTile.ToString());

            DisplayAssets();
            TryToBuyTile();
            CurrentTile.LandOn(this);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} is in jail and cannot move.");
            Console.ResetColor();
            this.EndTurn();
            Console.ReadLine();
        }

        Console.WriteLine($"{Name}'s turn is complete.\n----------------------------------------");
        Console.WriteLine($"\n\n{Name}'s Final Total Money: {Money} TL");
        Console.WriteLine($"Total Money on Board: {Board.Instance.cash} TL");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press 'Enter' to continue...");
        Console.ResetColor();
        Console.ReadLine();
        Console.Clear();
    }

    // Display player's assets, including properties, utility cards, and train station cards
    public void DisplayAssets()

    {
        Console.ForegroundColor = ConsoleColor.Cyan;
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


    // Build a house on the current property
    public void BuildHouse()
    {
        // Check if the current tile is a property
        if (CurrentTile is Property propertyTile)
        {
            // Check if the player is the owner of the property and can build a house
            if (propertyTile.Owner == this && CanBuildHouse(propertyTile))
            {
                int housePrice = 50;

                // Check if the player has enough money to build a house
                if (Money >= housePrice)
                {
                    propertyTile.BuildHouse();
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
    // Check if the player can build a house on the given property
    private bool CanBuildHouse(Property propertyTile)
    {
        return propertyTile.HouseCount < 4;
    }
    // Roll a die for determining player order
    public int RollDiceForOrder()
    {
        LastDiceValue = RollDie();
        Console.WriteLine($"{Name} rolled a {LastDiceValue}.");
        return LastDiceValue;
    }
    // Send the player to jail
    public void GoToJail(Board board)
    {
        Console.WriteLine($"{Name} goes to jail!");
        IsInJail = true;
        TurnsInJail = 3; // Number of turns the player should skip in jail

        // Set the player's position to the jail tile
        Position = 10;
        CurrentTile = board.Tiles[Position];
    }

    public void EndTurn()
    {
        // Decrease the TurnsInJail counter
        if (IsInJail)
        {

            // Check if the player is still in jail or if their turns are up
            if (TurnsInJail == 0)
            {
                Console.WriteLine($"{Name} is released from jail!");
                IsInJail = false;
            }
            else
            {
                TurnsInJail--;
                Console.WriteLine($"{Name} is still in jail. Turns remaining: {TurnsInJail}");

            }

        }


    }
    public void PayToOtherPlayer(Player player, int amount)
    {
        Console.WriteLine($"{Name} payed {amount}TL to {player.Name}!");
        Money = Money - amount;
        player.Money = player.Money + amount; 

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
    // Move to the nearest utility tile
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

        Position = nearestUtilityIndex;
        CurrentTile = board.Tiles[nearestUtilityIndex];

        Console.WriteLine($"{Name} moved to the nearest utility tile: {CurrentTile.Name}");

    }

      public void goToNeartestStation()
    {

        int currentPosition = Position;

        int nearestStationIndex = -1;
        int minDistance = int.MaxValue;

        for (int i = 0; i < board.Tiles.Count; i++)
        {
            if (board.Tiles[i] is TrainStation trainStationTile)
            {
                int distance = (i - currentPosition + board.Size) % board.Size;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestStationIndex = i;
                    
                }
            }
        }

        Position = nearestStationIndex;
        CurrentTile = board.Tiles[nearestStationIndex];

        Console.WriteLine($"{Name} moved to the nearest train station tile: {CurrentTile.Name}");

    }
    public void SetPositionToBeginning()
    {
        Position = 0;
        CurrentTile = board.Tiles[Position];
    }


}