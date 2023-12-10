using System;
using System.Collections.Generic;
using System.Drawing;

public class Board
{
    private static Board instance;
    public List<Tile> tiles { get; set; }


    // SİMDİLİK property yaptım şans kartları ve diğer kartlar girince ortak bir şey yaparız
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



    // Define the list of tiles
    Tile deneme1 = new UtilityTile(0, "Baslangıc", "Description",50); // Baslangıc tile'ı yapılacak
    Tile kasimpasa = new Property(1, "kasimpasa", "Description", 60, null, Color.Brown);
    Tile communityChestCardTile = new CommunityChestCardTile(2, "Community Chest Card", "Description");
    Tile dolapdere = new Property(3, "dolapdere", "description", 60, null, Color.Brown);
    Tile incomeTaxTile = new TaxAndParkingTile(4, "Income Tax Tile", "Description", 200);

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
    Tile bPasaStation = new TrainStation(5, "b Istasyonu", "Description", 50);

    Tile harbiye = new Property(16, "harbiye", "description", 60, null, Color.Orange);
    Tile sisli = new Property(18, "sisli", "description", 60, null, Color.Orange);
    Tile mecidiyekoy = new Property(19, "mecidiyekoy", "description", 60, null, Color.Orange);
    Tile freeParkingTile = new TaxAndParkingTile(20, "Free Parking Tile", "Description", 200); //Simdilik 200 yazdım fee yerine bankadaki para yazılacak 
    Tile erenkoy = new Property(21, "erenkoy", "description", 60, null, Color.Red);
    Tile bostanci = new Property(23, "bostanci", "description", 60, null, Color.Red);
    Tile caddebostan = new Property(24, "caddebostan", "description", 60, null, Color.Red);
    Tile aStation = new TrainStation(25, "a Istasyonu", "Description", 50);
    Tile nisantasi = new Property(26, "nisantasi", "description", 60, null, Color.Yellow);
    Tile macka = new Property(27, "macka", "description", 60, null, Color.Yellow);
    Tile waterWorks = new UtilityTile(28, " Water Works", "Description",50);
    Tile tesvikiye = new Property(29, "tesvikiye", "description", 60, null, Color.Yellow);
    Tile levent = new Property(31, "levent", "description", 60, null, Color.Green);
    Tile etiler = new Property(32, "etiler", "description", 60, null, Color.Green);

    Tile bebek = new Property(34, "bebek", "description", 60, null, Color.Green);
    Tile sirkeciStation = new TrainStation(35, "Sirkeci Istasyonu", "Description", 50);
    Tile tarabya = new Property(37, "tarabya", "description", 60, null, Color.DarkBlue);
    Tile luxuryTaxTile = new TaxAndParkingTile(38, "Luxury Tax Tile", "Description", 150);
    Tile yenikoy = new Property(39, "yenikoy", "description", 60, null, Color.DarkBlue);

    public void InitializeBoard()
    {
        // Initialize the list of tiles
        tiles = new List<Tile>
        {
            deneme1,kasimpasa, communityChestCardTile, dolapdere, incomeTaxTile,haydarPasaStation,sultanahmet, chanceCardTile, karakoy,  sirkeci,deneme2, beyoglu,electricCompany, taksim, besiktas, bPasaStation, harbiye, sisli,
            mecidiyekoy,freeParkingTile, erenkoy,chanceCardTile, bostanci, caddebostan, nisantasi, macka, waterWorks,tesvikiye,  levent,etiler, communityChestCardTile,bebek, sirkeciStation,tarabya, luxuryTaxTile,yenikoy
        };


    }

    // The following method is commented out since it's incomplete and seems to be
    // a placeholder for future functionality.

    // public string GetTile(int position)
    // {
    //     if (position >= 0 && position < Size)
    //     {
    //         return tiles[position].ToString(); // Assuming tiles is a list of Property
    //     }
    //     return "Invalid Position";
    // }

    // The following method is commented out as well, as it's not fully implemented.

    public bool CheckGameStatus(List<Player> players)
    {
        return players.Count == 1;
    }

    // The following method is commented out, as it's a placeholder for future functionality.

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













