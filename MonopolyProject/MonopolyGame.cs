using System;
using System.Collections.Generic;
using System.Drawing;

class MonopolyProject
{
    static void Main()
    {
        int playerCount = 0;

        while (true)
        {
            try
            {
                // Determine the number of players
                Console.Write("Enter the number of players (2-4): ");
                playerCount = int.Parse(Console.ReadLine());

                // Check if the entered number of players is within the valid range
                if (playerCount < 2 || playerCount > 4)
                {
                    throw new ArgumentException("Number of players must be between 2 and 4.");
                }

                break; // Exit the loop if a valid number of players is entered
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Create player list
        List<Player> players = new List<Player>();
        Board.Instance.InitializeBoard();

        for (int i = 1; i <= playerCount; i++)
        {
            string playerName = GetPlayerName(players, i);
            Player player = new Player(playerName, Board.Instance);
            players.Add(player);
        }

        while (players.Count > 1)
        {
            // Inside the while loop where players take turns
            foreach (Player player in players.ToList())
            {
                Console.WriteLine($"\nIt's {player.Name}'s turn.");

                // Check if the player is in jail
                if (player.IsInJail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} is in jail and cannot play this turn.");
                    Console.ResetColor();
                    player.TurnsInJail++;
                    continue; // Skip the rest of the turn for players in jail
                }

                Console.WriteLine("Press Enter to roll the dice.");
                Console.ReadLine();
                Board.Instance.DisplayBoard(players);
                player.Move(Board.Instance);
                Console.Clear();
                CheckBankruptcy(players);

                if (Board.Instance.CheckGameStatus(players))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{players[0].Name} wins the game!");
                    Console.ResetColor();
                    return;
                }
            }

        }


        Console.WriteLine($"{players[0].Name} wins the game!");
    }

    static string GetPlayerName(List<Player> existingPlayers, int playerNumber)
    {
        while (true)
        {
            try
            {
                Console.Write($"Enter name of player {playerNumber}: ");
                string playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName))
                {
                    throw new ArgumentException("Player name cannot be empty or whitespace.");
                }

                if (existingPlayers.Any(player => player.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("Player name must be unique.");
                }

                return playerName;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void CheckBankruptcy(List<Player> players)
    {
        List<Player> bankruptPlayers = players.FindAll(player => player.Money <= 0);

        foreach (Player player in bankruptPlayers)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{player.Name} has gone bankrupt and lost the game!");
            Console.ResetColor();
            players.Remove(player);
        }
    }

}
