using System;
using System.Collections.Generic;
using System.Drawing;

public class Board
{
    private static Board instance;
    public int cash { get; set; }// Current cash available on the board
    public List<Tile> Tiles { get; set; }
    public int Size { get; }
    private Board()
    {
        // Initialize the board with tiles
        cash = 0;
        Size = 40; // Assuming a standard Monopoly board size
        InitializeBoard();
    }

    public static Board Instance
    {
        get
        {
            // Singleton pattern to ensure only one instance of Board exists
            if (instance == null)
            {
                instance = new Board();
            }
            return instance;
        }
    }





    Tile BeginningTile = new DefaultTiles(0, "Beginning Tile", "You will earn 200TL."); // Start of the board
    Tile kasimpasa = new Property(1, "Kasimpasa", "Property", 60, null, "Brown");// Property tile example
    Tile communityChestCardTile = new CommunityChestCardTile(2, "Community Chest Card", "Draw a card");
    Tile dolapdere = new Property(3, "Dolapdere", "Property", 60, null, "Brown");
    Tile incomeTaxTile = new DefaultTiles(4, "Income Tax Tile", "Pay 200TL to board ");

    Tile haydarPasaStation = new TrainStation(5, "Haydarpasa Station", "Train Station", 100);
    Tile sultanahmet = new Property(6, "Sultanahmet", "Property", 120, null, "Blue");
    Tile chanceCardTile = new ChanceCardTile(7, "Chance CardTile ", "Draw a card");
    Tile karakoy = new Property(8, "Karakoy", "Property", 120, null, "Blue");

    Tile sirkeci = new Property(9, "Sirkeci", "Property", 120, null, "Blue");

    Tile prison = new DefaultTiles(10, "Prison", "Welcome to prison!");

    Tile beyoglu = new Property(11, "Beyoglu", "Property", 160, null, "Pink");
    Tile electricCompany = new UtilityTile(12, "Electric Company", "Description", 150);
    Tile taksim = new Property(13, "Taksim", "Property", 160, null, "Pink");
    Tile besiktas = new Property(14, "Besiktas", "Property", 160, null, "Pink");
    Tile taksimStation = new TrainStation(15, "Taksim Train Station", "Train Station", 100);

    Tile harbiye = new Property(16, "Harbiye", "Property", 200, null, "Orange");

    Tile sisli = new Property(18, "Sisli", "Property", 200, null, "Orange");
    Tile mecidiyekoy = new Property(19, "Mecidiyekoy", "Property", 200, null, "Orange");
    Tile freeParkingTile = new DefaultTiles(20, "Free Parking Tile", "Collect all the money board.");
    Tile erenkoy = new Property(21, "Erenkoy", "Property", 240, null, "Red");
    Tile bostanci = new Property(23, "Bostanci", "Property", 240, null, "Red");
    Tile caddebostan = new Property(24, "Caddebostan", "Property", 240, null, "Red");
    Tile erenkoyTrainStation = new TrainStation(25, "Erenkoy Station", "Train Station", 100);
    Tile nisantasi = new Property(26, "Nisantasi", "Property", 280, null, "Yellow");
    Tile macka = new Property(27, "Macka", "Property", 280, null, "Yellow");
    Tile waterWorks = new UtilityTile(28, " Water Works", "Description", 50);
    Tile tesvikiye = new Property(29, "Tesvikiye", "description", 280, null, "Yellow");
    Tile goToPrison = new JailTile(30, "Prison Tile", "Go to prison!");
    Tile levent = new Property(31, "Levent", "Property", 320, null, "Green");
    Tile etiler = new Property(32, "Etiler", "Property", 320, null, "Green");
    // (33) Chance card tile, no need to create again

    Tile bebek = new Property(34, "Bebek", "Property", 320, null, "Green");
    Tile sirkeciStation = new TrainStation(35, "Sirkeci Istasyonu", "Description", 150);
    // (36) Chance card tile, no need to create again
    Tile tarabya = new Property(37, "Tarabya", "Property", 400, null, "DarkBlue");
    Tile luxuryTaxTile = new DefaultTiles(38, "Luxury Tax Tile", "Pay 150TL to board.");
    Tile yenikoy = new Property(39, "Yenikoy", "Property", 400, null, "DarkBlue");

    public void InitializeBoard()
    {
        // Initialize the list of tiles
        Tiles = new List<Tile>
        {
            //Add all the tiles to the board in the desired order
            BeginningTile,kasimpasa, communityChestCardTile, dolapdere, incomeTaxTile,haydarPasaStation,sultanahmet, chanceCardTile, karakoy,  sirkeci,prison, beyoglu,electricCompany, taksim, besiktas, taksimStation, harbiye,communityChestCardTile, sisli,
            mecidiyekoy,freeParkingTile, erenkoy,chanceCardTile, bostanci, caddebostan,erenkoyTrainStation, nisantasi, macka, waterWorks,tesvikiye,goToPrison,levent,etiler, communityChestCardTile,bebek, sirkeciStation,chanceCardTile,tarabya, luxuryTaxTile,yenikoy
        };


    }

    public void DisplayBoard(List<Player> players)
    {
        ConsoleColor[] playerColors = { ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Magenta };
        int counter = 0;
        Console.WriteLine();

        // Display the board and players' positions on it
        for (int i = 0; i < Tiles.Count; i++)
        {
            List<Player> playersAtPosition = players.Where(player => player.Position == i).ToList();

            if (playersAtPosition.Count > 0)
            {
                // Display the players at this position with their respective colors
                foreach (Player player in playersAtPosition)
                {
                    int colorIndex = players.IndexOf(player) % playerColors.Length;
                    Console.ForegroundColor = playerColors[colorIndex];
                    Console.Write(player.Name + " ");
                }
            }
            else
            {
                Console.Write(" ");
            }
            if(i == 10 || i == 20|| i == 30 || i == 39)
            {
                Tiles[i].Display("\n",i);
            }
            else
            {
                Tiles[i].Display("-->",i);
            }
            Console.ResetColor();
        }
    }

    




    public bool CheckGameStatus(List<Player> players)
    {
        // Check if only one player is left, indicating the end of the game
        return players.Count == 1;
    }

}













