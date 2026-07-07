using PlayerRegistry;
using System;
using System.Collections.Generic;
using System.Linq;

IPlayerRepository playerRepo = new InMemoryPlayerRepository();
IWalletRepository walletRepo = new InMemoryWalletRepository();

while (true)
{
    Console.WriteLine("\n=== WorldRank Player Registry ===");
    Console.WriteLine("1. Add player");
    Console.WriteLine("2. List all players");
    Console.WriteLine("3. Find player by name");
    Console.WriteLine("4. Add wallet to player"); 
    Console.WriteLine("0. Exit");
    Console.Write("> ");

    Action? action = Console.ReadLine() switch
    {
        "1" => AddPlayer,
        "2" => ListPlayers,
        "3" => FindPlayer,
        "4" => AddWalletToPlayer, 
        "0" => null,
        _ => () => Console.WriteLine("Unknown option.")
    };

    if (action is null)
        return;

    action();
}

void AddPlayer()
{
    Console.Write("Name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Name cannot be empty.");
        return;
    }

    Console.Write("Score: ");
    var scoreInput = Console.ReadLine();
    if (!int.TryParse(scoreInput, out var score))
    {
        Console.WriteLine("Score must be a whole number.");
        return;
    }

    try
    {
        var player = new Player(name);
        player.UpdateScore(score);

        playerRepo.AddPlayer(player);
        Console.WriteLine("Player added successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void ListPlayers()
{
    var allPlayers = playerRepo.GetAllPlayers().ToList();

    if (allPlayers.Count == 0)
    {
        Console.WriteLine("No players registered.");
        return;
    }

    Console.WriteLine("\n--- Registered Players ---");
    foreach (var p in allPlayers)
    {
        
        Console.WriteLine(p);

        var wallets = walletRepo.GetByPlayer(p.Id).ToList();
        if (wallets.Any())
        {
            foreach (var w in wallets)
            {
                Console.WriteLine($"   └── {w}");
            }
        }
        else
        {
            Console.WriteLine("   └── No wallets linked to this player.");
        }
    }
}

void FindPlayer()
{
    Console.Write("Search by name: ");
    var term = Console.ReadLine() ?? string.Empty;

    var player = playerRepo.GetAllPlayers()
        .FirstOrDefault(p => p.Name.Equals(term, StringComparison.OrdinalIgnoreCase));

    if (player is null)
    {
        Console.WriteLine("No player found.");
        return;
    }

    Console.WriteLine(player);

    var wallets = walletRepo.GetByPlayer(player.Id).ToList();
    foreach (var w in wallets)
    {
        Console.WriteLine($"   └── {w}");
    }
}

void AddWalletToPlayer()
{
    Console.Write("Enter player name to give a wallet: ");
    var term = (Console.ReadLine() ?? string.Empty).Trim(); // Το .Trim() καθαρίζει τα κενά

    // Ψάχνουμε τον παίκτη καλώντας το playerRepo
    var player = playerRepo.GetAllPlayers()
        .FirstOrDefault(p => p.Name.Trim().Equals(term, StringComparison.OrdinalIgnoreCase));

    if (player is null)
    {
        Console.WriteLine("No player found. Create the player first.");
        return;
    }

    Console.WriteLine("Select Currency: 0 = EUR, 1 = USD, 2 = GBP");
    Console.Write("> ");
    if (!int.TryParse(Console.ReadLine(), out int currencyChoice) || currencyChoice < 0 || currencyChoice > 2)
    {
        Console.WriteLine("Invalid currency selection.");
        return;
    }

    Console.Write("Enter initial balance: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance) || initialBalance < 0)
    {
        Console.WriteLine("Invalid balance. Must be a positive number.");
        return;
    }

    Currency selectedCurrency = (Currency)currencyChoice;

    try
    {
        var newWallet = new Wallet(player.Id, selectedCurrency, initialBalance);
        walletRepo.Add(newWallet, player.Id);
        Console.WriteLine($"Wallet ({selectedCurrency}) added successfully to player {player.Name}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
