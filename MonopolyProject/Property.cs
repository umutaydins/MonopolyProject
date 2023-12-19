using System.Drawing;

public class Property : Tile, IOwnable
{


    public int Price { get; set; }
    public Player Owner { get; set; }
    private string Color { get; set; }
    public int HouseCount { get; private set; }
    public int HotelCount { get; private set; }
    public bool IsBuyDecisionMade { get; set; }
    public bool HasHotel { get; private set; }




    public Property(int id, string name, string description, int price, Player owner, string color)
        : base(id, name, description)
    {
        this.Price = price;
        this.Owner = owner;
        this.Color = color;
        this.HouseCount = 0;
        this.HotelCount = 0;
    }



    public override void LandOn(Player player)
    {
        if (!IsBuyDecisionMade)
        {
            if (IsOwned() && Owner != player)
            {
                // Calculate and charge rent to the player
                int rent = CalculateRent();
                player.PayToOtherPlayer(Owner, rent);
            }
            else if (IsOwned() && Owner == player)
            {
                // Check if the player wants to build a house or hotel
                if (HasHotel)
                {
                    Console.WriteLine("This property has a hotel. You cannot build houses or hotels.");
                }
                else
                {
                    // Display options for building a house or hotel
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("This property is yours. Do you want to build a house or hotel?\n !You can build hotel only after you build 4 house!");
                    int housePrice = CalculateMoneyForBuildingHouse();
                    int hotelPrice = CalculateMoneyForBuildingHotel();
                    Console.WriteLine($"House price : {housePrice}TL\nHotel price: {hotelPrice}TL");
                    Console.ResetColor();
                    string input = Console.ReadLine();
                    if (input.Trim().ToUpper() == "Y")
                    {
                        BuildHouseOrHotel();
                    }
                }
            }
            else
            {
                // when the property is not owned
            }
        }
        else
        {
            // Reset the flag for the next time the player lands on this tile
            IsBuyDecisionMade = false;

            Console.WriteLine($"{player.Name} has decided to buy {Name}.");
        }
    }


    private int CalculateRent()
    {
        switch (Color)
        {
            case "Brown": return HouseCount switch { 0 => 4, 1 => 20, 2 => 60, 3 => 180, 4 => 320, _ => 0 };
            case "Blue": return HouseCount switch { 0 => 8, 1 => 40, 2 => 100, 3 => 300, 4 => 450, _ => 0 };
            case "Pink": return HouseCount switch { 0 => 12, 1 => 60, 2 => 180, 3 => 500, 4 => 700, _ => 0 };
            case "Orange": return HouseCount switch { 0 => 16, 1 => 80, 2 => 220, 3 => 600, 4 => 800, _ => 0 };
            case "Red": return HouseCount switch { 0 => 20, 1 => 100, 2 => 300, 3 => 750, 4 => 925, _ => 0 };
            case "Yellow": return HouseCount switch { 0 => 24, 1 => 120, 2 => 360, 3 => 850, 4 => 1025, _ => 0 };
            case "Green": return HouseCount switch { 0 => 28, 1 => 150, 2 => 450, 3 => 1000, 4 => 1200, _ => 0 };
            case "DarkBlue": return HouseCount switch { 0 => 50, 1 => 200, 2 => 600, 3 => 1400, 4 => 1700, _ => 0 };
            default: return 0;
        }
    }

    // Check if the property is owned by a player
    public bool IsOwned() { return Owner != null; }

    public void BuildHouse()
    {
        if (CanBuildHouse())
        {
            HouseCount++;
            int houseMoney = CalculateMoneyForBuildingHouse();
            Owner.deductMoney(houseMoney);

            Console.WriteLine($"A house is built on {Name} and {Owner.Name} payed {houseMoney}TL. Total houses on {Name}: {HouseCount}");
        }
        else
        {
            Console.WriteLine($"Cannot build more houses on {Name}. Maximum limit reached.");
        }
    }

    // Build a house or hotel based on player input
    public void BuildHouseOrHotel()
    {
        if (CanBuildHouse())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"A house is being built....");
            Console.ResetColor();
            BuildHouse();

        }
        else if (CanBuildHotel())

        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"A hotel is being built....");
            Console.ResetColor();
            BuildHotel();

        }

    }

    // Check if a house can be built on the property
    private bool CanBuildHouse()
    {
        return HouseCount < 4; // Example: Maximum of 4 houses allowed
    }

    private bool CanBuildHotel()
    {
        return HouseCount == 4 && !HasHotel; // Example: Build hotel if there are 4 houses and no hotel
    }


    private void BuildHotel()
    {
        int hotelMoney = CalculateMoneyForBuildingHotel();
        Owner.deductMoney(hotelMoney);

        Console.WriteLine($"A hotel is built on {Name} and {Owner.Name} paid {hotelMoney}TL. Total hotels on {Name}: 1");

        // Reset house count
        HouseCount = 0;
        HotelCount++;
        HasHotel = true;
    }



    private int CalculateMoneyForBuildingHouse()
    {
        switch (Color)
        {
            case "Brown": return 50;
            case "Blue": return 50;
            case "Pink": return 100;
            case "Orange": return 100;
            case "Red": return 150;
            case "Yellow": return 150;
            case "Green": return 200;
            case "DarkBlue": return 200;
            default: return 0;
        }
    }

    private int CalculateMoneyForBuildingHotel()
    {
        switch (Color)
        {
            case "Brown": return 5 * 50; // 5 times the house cost for a hotel
            case "Blue": return 5 * 50;
            case "Pink": return 5 * 100;
            case "Orange": return 5 * 100;
            case "Red": return 5 * 150;
            case "Yellow": return 5 * 150;
            case "Green": return 5 * 200;
            case "DarkBlue": return 5 * 200;
            default: return 0;
        }
    }

    public override void Display(string route,int position)
    {
        if (IsOwned())
        {
            Console.Write($"|{position}-{Name} Owner: {Owner.Name} Houses: {HouseCount} Hotels: {HotelCount}|" + route);
        }
        else
        {
            base.Display(route,position);
        }
    }

    public override string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";


        string result = base.ToString(); // Use the common part from the base class
        
        result += $"\n{verticalLine,2} House Count: {HouseCount,9} |";
        result += $"\n{verticalLine,2} Hotel Count: {HouseCount,9} |";



        result += $"\n{verticalLine,2} Price: {Price,13}{verticalLine,5}\n" +
                  $"{verticalLine,2} Owner: {(Owner != null ? Owner.Name : "None"),11}{verticalLine,5}\n" +
                  $"{verticalLine,2} Color: {Color,12}{verticalLine,5}\n" +
                  $"{verticalLine}{horizontalLine}{verticalLine,5}";

        Console.ForegroundColor = Color.Equals("Brown") ? ConsoleColor.DarkRed : (Color.Equals("Blue") ? ConsoleColor.Blue : (Color.Equals("Pink") ? ConsoleColor.Magenta : (Color.Equals("Orange") ? ConsoleColor.DarkYellow : (Color.Equals("Red") ? ConsoleColor.Red : (Color.Equals("Yellow") ? ConsoleColor.Yellow : (Color.Equals("Green") ? ConsoleColor.Green : (Color.Equals("DarkBlue") ? ConsoleColor.DarkBlue : ConsoleColor.White)))))));

        return result;
    }
    // Method to handle the purchase of the property by a player
    public void Purchase(Player buyer)
    {
        TileOwnershipManager ownershipManager = new TileOwnershipManager();
        ownershipManager.PurchaseTile(this, buyer);

        if (this.Owner == buyer)
        {
            Owner.playerPropertyCardList.Add(this);
        }
    }
}