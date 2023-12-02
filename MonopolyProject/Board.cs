class Board
{
    private static Board instance;
    private List<string> tiles;

    private Board()
    {
        // Initialize the board with tiles
        Size = 40; // Assuming a standard Monopoly board size
        InitializeBoard();
    }

    public static Board Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Board();
            }
            return instance;
        }
    }

    public int Size { get; }

    public List<string> Tiles
    {
        get { return tiles; }
    }

    public void InitializeBoard()
{
    tiles = new List<string>
    {
        "Go", "Property 1", "Community Chest", "Property 2", "Income Tax",
        "Property 3", "Chance", "Property 4", "Property 5", "Jail",
        "Property 6", "Community Chest", "Property 7", "Property 8", "Free Parking",
        "Property 9", "Chance", "Property 10", "Property 11", "Go to Jail",
        "Property 12", "Community Chest", "Property 13", "Property 14", "Income Tax",
        "Property 15", "Chance", "Property 16", "Property 17", "Free Parking",
        "Property 18", "Community Chest", "Property 19", "Property 20", "Go",
        "Property 21", "Chance", "Property 22", "Property 23", "Jail",
        "Property 24", "Community Chest", "Property 25", "Property 26", "Free Parking",
        "Property 27", "Chance", "Property 28", "Property 29", "Go to Jail",
        "Property 30", "Community Chest", "Property 31", "Property 32", "Income Tax",
        "Property 33", "Chance", "Property 34", "Property 35", "Free Parking",
        "Property 36", "Community Chest", "Property 37", "Property 38", "Go",
        "Chance", "Property 39", "Property 40", "Jail", "Free Parking"
    };
}

        public string GetTile(int position)
    {
        // Assuming that the position is zero-based
        if (position >= 0 && position < Size)
        {
            return tiles[position];
        }
        return "Invalid Position";
    }

    public bool CheckGameStatus(List<Player> players)
    {
        // Check if the game is over
        // In this example, the game ends when there is only one player remaining
        return players.Count == 1;
    }

    // public void PerformAction(Player player)
    // {
    //     string tile = Tiles[player.Position];
    //     Console.WriteLine($"{player.Name} landed on {tile}.");

    //     // Perform actions based on the type of til1e (you can customize this part)
    //     switch (tile)
    //     {
    //         case "Go":
    //             player.EarnMoney(200);
    //             break;
    //         case "Property 1":
    //             // Action for landing on Property 1
    //             break;
    //         case "Community Chest":
    //             // Action for landing on Community Chest
    //             break;
    //         // ... Add more cases for other tiles ...
    //         default:
    //             break;
    //     }
    // }
}