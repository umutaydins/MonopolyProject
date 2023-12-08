using System;
using System.Collections.Generic;
using System.Drawing;

class MonopolyProject
{
    static void Main()


    {

        Property kasimpasa = new Property(1,"kasimpasa",60,null,Color.Brown);
        Property dolapdere = new Property(3,"dolapder",60,null,Color.Brown);
        Property karakoy = new Property(8,"karakoy",60,null,Color.Blue);
        Property sultanahmet = new Property(6,"sultanahmet",60,null,Color.Blue);
        Property sirkeci = new Property(9,"sirkeci",60,null,Color.Blue);
        Property besiktas = new Property(14,"besiktas",60,null,Color.Pink);
        Property taksim = new Property(13,"taksim",60,null,Color.Pink);
        Property beyoglu = new Property(11,"beyoglu",60,null,Color.Pink);
        Property harbiye = new Property(16,"harbiye",60,null,Color.Orange);
        Property sisli = new Property(18,"sisli",60,null,Color.Orange);
        Property mecidiyekoy = new Property(19,"mecidiyekoy",60,null,Color.Orange);
        Property erenkoy = new Property(21,"erenkoy",60,null,Color.Red);
        Property bostanci = new Property(22,"bostanci",60,null,Color.Red);
        Property caddebostan = new Property(23,"caddebostan",60,null,Color.Red);
        Property nisantasi = new Property(26,"nisantasi",60,null,Color.Yellow);
        Property macka = new Property(27,"macka",60,null,Color.Yellow);
        Property tesvikiye = new Property(29,"tesvikiye",60,null,Color.Yellow);
        Property etiler = new Property(32,"etiler",60,null,Color.Green);
        Property levent = new Property(31,"levent",60,null,Color.Green);
        Property bebek = new Property(34,"bebek",60,null,Color.Green);
        Property tarabya = new Property(37,"tarabya",60,null,Color.DarkBlue);
        Property yenikoy = new Property(39,"yenikoy",60,null,Color.DarkBlue);

        Console.WriteLine(kasimpasa.ToString());
        Console.WriteLine(macka.ToString());
        




        // Determine the number of players
        Console.Write("Enter the number of players (2-4): ");
        int playerCount = int.Parse(Console.ReadLine());
        // Create player list
        List<Player> players = new List<Player>();

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter name of player: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            players.Add(player);
        }
Console.WriteLine("kkkkkkkkk");
        // Oyun tahtasını oluştur
        Board.Instance.InitializeBoard();

        while (players.Count > 1)
        {
            // Her bir oyuncunun sırası
            foreach (Player player in players.ToList()) // ToList kullanarak döngü içinde listenin değişmesini önle
            {
                Console.WriteLine($"Şu anda sıra {player.Name}'de.");

                // Oyuncuya zar atması için Enter tuşuna basması istenir
                Console.WriteLine("Enter tuşuna basarak zar atın.");
                Console.ReadLine();

                bool isDouble = false;

// Örnek bir oyuncu hareketi
do
{
    int rollResult = player.RollDice();
    Console.WriteLine($"{player.Name} rolled a {rollResult}.");

    // Zar çifti gelmişse tekrar zar at
    isDouble = (rollResult == -1);

    if (isDouble)
    {
        Console.WriteLine($"{player.Name}, zar çifti attı! Tekrar zar atılıyor.");
        Console.WriteLine("Enter tuşuna basarak zar atın.");
        Console.ReadLine();
    }

    // Move the player on the board
    player.Move(Board.Instance);

    // Oyuncunun bulunduğu karenin bilgisini al
    string currentTile = Board.Instance.GetTile(player.Position);
    Console.WriteLine($"{player.Name} şu anda {currentTile} karesinde.");

    // Eğer Community Chest karesine gelinmişse kartı çek
    if (currentTile.Contains("Community Chest"))
    {
        CommunityChestCard communityChestCard = new CommunityChestCard();
        communityChestCard.DrawCard();
    }

} while (isDouble);

              
                // Diğer oyuncuların iflas edip etmediğini kontrol et
                CheckBankruptcy(players);

                // Oyun durumunu kontrol et, bir oyuncu kazandı mı?
                if (Board.Instance.CheckGameStatus(players))
                {
                    Console.WriteLine($"{player.Name} oyunu kazandı!");
                    return;
                    Console.WriteLine($"denem yaz");
                }
            }
        }

        // Oyun bittiğinde kalan oyuncuyu ekrana yazdır
        Console.WriteLine($"{players[0].Name} oyunu kazandı!");
    }

    static void CheckBankruptcy(List<Player> players)
    {
        // İflas eden oyuncuları listeden çıkart
        players.RemoveAll(player => player.Money <= 0);
    }
}
