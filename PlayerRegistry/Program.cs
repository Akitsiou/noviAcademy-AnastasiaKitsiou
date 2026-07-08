using PlayerRegistry;
using System;
using System.Collections.Generic;
using System.Linq;

var players = new List<Player>();
int nextId = 1; 

while (true)
{
    Console.WriteLine("\n=== WorldRank Player Registry ===");
    Console.WriteLine("1. Add player");
    Console.WriteLine("2. List all players");
    Console.WriteLine("3. Find player by name");
    Console.WriteLine("0. Exit");
    Console.Write("> ");

    
    Action? action = Console.ReadLine() switch
    {
        "1" => AddPlayer,
        "2" => ListPlayers,
        "3" => FindPlayer,
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

        players.Add(player);
        Console.WriteLine("Player added successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void ListPlayers()
{
    if (players.Count == 0)
    {
        Console.WriteLine("No players registered.");
        return;
    }

    Console.WriteLine("\n--- Registered Players ---");
    foreach (var p in players)
    {
        // Επειδή γράψαμε την "public override string ToString()" στο Player.cs,
        // η C#  αυτόματα τυπώνει όμορφα τον παίκτη σκέτο με το 'p'!
        Console.WriteLine(p);
    }
}

void FindPlayer()
{
    Console.Write("Search by name: ");
    var term = Console.ReadLine() ?? string.Empty;

    var player = players
        .FirstOrDefault(p => p.Name.Equals(term, StringComparison.OrdinalIgnoreCase));

    if (player is null)
    {
        Console.WriteLine("No player found.");
        return;
    }

    
    Console.WriteLine(player);
}