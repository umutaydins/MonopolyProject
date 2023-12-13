using System;
using System.Collections.Generic;
using System.Drawing;

public class Board
{
    private static Board instance;
    public List<Tile> Tiles { get; set; }
    public int CurrentMoney;


    // SİMDİLİK property yaptım şans kartları ve diğer kartlar girince ortak bir şey yaparız
    private Board()
    {
        // Initialize the board with tiles
        CurrentMoney = 0;
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
    Tile BeginningTile = new DefaultTiles(0, "Beginning Tile", "You will earn 200TL."); // Baslangıc tile'ı yapılacak
    Tile kasimpasa = new Property(1, "kasimpasa", "Description", 60, null, "Brown");
    Tile communityChestCardTile = new CommunityChestCardTile(2, "Community Chest Card", "Description");
    Tile dolapdere = new Property(3, "dolapdere", "description", 60, null, "Brown");
    Tile incomeTaxTile = new DefaultTiles(4, "Income Tax Tile", "Pay 200TL to board ");

    Tile haydarPasaStation = new TrainStation(5, "Haydarpasa Istasyonu", "Description", 50);// simdilik 50 yazdım kullanıcının istasyon sayısına göre ayaralanacak

    Tile sultanahmet = new Property(6, "sultanahmet", "description", 60, null, "Blue");
    Tile chanceCardTile = new ChanceCardTile(7, "ChanceCardTile", "none");
    Tile karakoy = new Property(8, "karakoy", "description", 60, null, "Blue");

    Tile sirkeci = new Property(9, "sirkeci", "description", 60, null, "Blue");

    // PRISON VISITOR TİLE

    Tile prison = new DefaultTiles(10,"Prison","Welcome to prison!");

    Tile beyoglu = new Property(11, "beyoglu", "description", 60, null, "Pink");
    Tile electricCompany = new UtilityTile(12, "Electric Company", "Description", 50);
    Tile taksim = new Property(13, "taksim", "description", 60, null, "Pink");
    Tile besiktas = new Property(14, "besiktas", "description", 60, null, "Pink");
    Tile bPasaStation = new TrainStation(15, "b Istasyonu", "Description", 50);

    Tile harbiye = new Property(16, "harbiye", "description", 60, null, "Orange");

    Tile sisli = new Property(18, "sisli", "description", 60, null, "Orange");
    Tile mecidiyekoy = new Property(19, "mecidiyekoy", "description", 60, null, "Orange");
    Tile freeParkingTile = new DefaultTiles(20, "Free Parking Tile", "Collect all the money board.");
    Tile erenkoy = new Property(21, "erenkoy", "description", 60, null, "Red");
    Tile bostanci = new Property(23, "bostanci", "description", 60, null, "Red");
    Tile caddebostan = new Property(24, "caddebostan", "description", 60, null, "Red");
    Tile aStation = new TrainStation(25, "a Istasyonu", "Description", 50);
    Tile nisantasi = new Property(26, "nisantasi", "description", 60, null, "Yellow");
    Tile macka = new Property(27, "macka", "description", 60, null, "Yellow");
    Tile waterWorks = new UtilityTile(28, " Water Works", "Description", 50);
    Tile tesvikiye = new Property(29, "tesvikiye", "description", 60, null, "Yellow");
    Tile goToPrison = new JailTile(30,"Prison Tile","Go to prison!");
    Tile levent = new Property(31, "levent", "description", 60, null, "Green");
    Tile etiler = new Property(32, "etiler", "description", 60, null, "Green");
    // (33) Chance card tile, no need to create again

    Tile bebek = new Property(34, "bebek", "description", 60, null, "Green");
    Tile sirkeciStation = new TrainStation(35, "Sirkeci Istasyonu", "Description", 50);
    // (36) Chance card tile, no need to create again
    Tile tarabya = new Property(37, "tarabya", "description", 60, null, "DarkBlue");
    Tile luxuryTaxTile = new DefaultTiles(38, "Luxury Tax Tile", "Pay 150TL to board.");
    Tile yenikoy = new Property(39, "yenikoy", "description", 60, null, "DarkBlue");

    public void InitializeBoard()
    {
        // Initialize the list of tiles
        Tiles = new List<Tile>
        {
            BeginningTile,kasimpasa, communityChestCardTile, dolapdere, incomeTaxTile,haydarPasaStation,sultanahmet, chanceCardTile, karakoy,  sirkeci,prison, beyoglu,electricCompany, taksim, besiktas, bPasaStation, harbiye,communityChestCardTile, sisli,
            mecidiyekoy,freeParkingTile, erenkoy,chanceCardTile, bostanci, caddebostan,aStation, nisantasi, macka, waterWorks,tesvikiye,goToPrison,levent,etiler, communityChestCardTile,bebek, sirkeciStation,chanceCardTile,tarabya, luxuryTaxTile,yenikoy
        };


    }





    public bool CheckGameStatus(List<Player> players)
    {
        return players.Count == 1;
    }

}













