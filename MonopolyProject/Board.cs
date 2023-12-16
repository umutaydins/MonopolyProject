using System;
using System.Collections.Generic;
using System.Drawing;

public class Board
{
    private static Board instance;
    public int  cash{ get; set; }
    public List<Tile> tiles { get; set; }


    // SİMDİLİK property yaptım şans kartları ve diğer kartlar girince ortak bir şey yaparız
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
            if (instance == null)
            {
                instance = new Board();
            }
            return instance;
        }
    }

    public int Size { get; }



    // Define the list of tiles
    Tile start = new DefaultTile(0, "Baslangıc", "Description",200,Condition.Collect); // Baslangıc tile'ı yapılacak
    Tile kasimpasa = new Property(1, "kasimpasa", "Description", 60, null, Color.Brown);
    Tile communityChestCardTile = new CommunityChestCardTile(2, "Community Chest Card", "Description");
    Tile dolapdere = new Property(3, "dolapdere", "description", 60, null, Color.Brown);
    Tile incomeTaxTile = new DefaultTile(4, "Income Tax Tile", "Description", 200,Condition.PlaceBoard);

    Tile haydarPasaStation = new TrainStation(5, "Haydarpasa Istasyonu", "Description",50);// simdilik 50 yazdım kullanıcının istasyon sayısına göre ayaralanacak

    Tile sultanahmet = new Property(6, "sultanahmet", "description", 60, null, Color.Blue);
    Tile chanceCardTile = new ChanceCardTile(7, "deneme", "Description");
    Tile karakoy = new Property(8, "karakoy", "description", 60, null, Color.Blue);

    Tile sirkeci = new Property(9, "sirkeci", "description", 60, null, Color.Blue);
    Tile deneme2 = new Property(10, "deneme2", "Description", 60, null, Color.Brown);
    Tile beyoglu = new Property(11, "beyoglu", "description", 60, null, Color.Pink);
    Tile electricCompany = new UtilityTile(12, "Electric Company", "Description",50);
    Tile taksim = new Property(13, "taksim", "description", 60, null, Color.Pink);
    Tile besiktas = new Property(14, "besiktas", "description", 60, null, Color.Pink);
    Tile bPasaStation = new TrainStation(15, "b Istasyonu", "Description", 50);

    Tile harbiye = new Property(16, "harbiye", "description", 60, null, Color.Orange);

    Tile sisli = new Property(18, "sisli", "description", 60, null, Color.Orange);
    Tile mecidiyekoy = new Property(19, "mecidiyekoy", "description", 60, null, Color.Orange);
    Tile freeParkingTile = new DefaultTile(20, "Free Parking Tile", "Description", 0,Condition.CollectBoard); //Simdilik 200 yazdım fee yerine bankadaki para yazılacak 
    Tile erenkoy = new Property(21, "erenkoy", "description", 60, null, Color.Red);
    Tile bostanci = new Property(23, "bostanci", "description", 60, null, Color.Red);
    Tile caddebostan = new Property(24, "caddebostan", "description", 60, null, Color.Red);
    Tile aStation = new TrainStation(25, "a Istasyonu", "Description", 50);
    Tile nisantasi = new Property(26, "nisantasi", "description", 60, null, Color.Yellow);
    Tile macka = new Property(27, "macka", "description", 60, null, Color.Yellow);
    Tile waterWorks = new UtilityTile(28, " Water Works", "Description",50);
    Tile tesvikiye = new Property(29, "tesvikiye", "description", 60, null, Color.Yellow);
    Tile kodes= new Property(30,"kodes","sdsds",60,null,Color.Black);
    Tile levent = new Property(31, "levent", "description", 60, null, Color.Green);
    Tile etiler = new Property(32, "etiler", "description", 60, null, Color.Green);

    Tile bebek = new Property(34, "bebek", "description", 60, null, Color.Green);
    Tile sirkeciStation = new TrainStation(35, "Sirkeci Istasyonu", "Description", 50);
    Tile  chanceCard = new ChanceCardTile(36,"Chance Card","sdsdds");
    Tile tarabya = new Property(37, "tarabya", "description", 60, null, Color.DarkBlue);
    Tile luxuryTaxTile = new DefaultTile(38, "Luxury Tax Tile", "Description", 150,Condition.PlaceBoard);
    Tile yenikoy = new Property(39, "yenikoy", "description", 60, null, Color.DarkBlue);

    public void InitializeBoard()
    {
        // Initialize the list of tiles
        tiles = new List<Tile>
        {
            start,luxuryTaxTile,incomeTaxTile,freeParkingTile
        };


    }

    // a placeholder

    // public string GetTile(int position)
    // {
    //     if (position >= 0 && position < Size)
    //     {
    //         return tiles[position].ToString(); // Assuming tiles is a list of Property
    //     }
    //     return "Invalid Position";
    // }


    public bool CheckGameStatus(List<Player> players)
    {
        return players.Count == 1;
    }


    // public void PerformAction(Player player)
    // {
    //     string tile = Tiles[player.Position];
    //     Console.WriteLine($"{player.Name} landed on {tile}.");

    //     // Perform actions based on the type of tile (you can customize this part)
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













