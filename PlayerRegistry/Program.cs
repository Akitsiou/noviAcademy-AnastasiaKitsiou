using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        List<Player> players = new List<Player>();
        int nextId = 1;

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. List Players");
            Console.WriteLine("3. Find by Name");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter player name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter player score: ");
                    if (int.TryParse(Console.ReadLine(), out int score))
                    {
                        players.Add(new Player(nextId++, name, score));
                        Console.WriteLine("Player added successfully!");
                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- Registered Players ---");
                    if (players.Count == 0) Console.WriteLine("No players found.");
                    foreach (var p in players)
                    {
                        Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Score: {p.Score}");
                    }
                    break;

                case "3":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();

                    var foundPlayer = players.FirstOrDefault(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

                    if (foundPlayer != null)
                    {
                        Console.WriteLine($"Found! ID: {foundPlayer.Id} | Name: {foundPlayer.Name} | Score: {foundPlayer.Score}");
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting application...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        }


    }

}