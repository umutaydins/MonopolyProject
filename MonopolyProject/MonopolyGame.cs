using System;
using System.Collections.Generic;
using System.Drawing;

class MonopolyProject
{
    static void Main()
    { 


        // Determine the number of players
        Console.Write("Enter the number of players (2-4): ");
        int playerCount = int.Parse(Console.ReadLine());
        // Create player list
        List<Player> players = new List<Player>();
        Board.Instance.InitializeBoard();

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter name of player: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName,Board.Instance);
            players.Add(player);
        }

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

//player move 
do
{
  
    player.Move(Board.Instance);


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
