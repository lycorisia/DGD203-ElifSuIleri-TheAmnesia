using System;

namespace TheAmnesiaGame
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("The Amnesia");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Credits");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartNewGame();
                        break;
                    case "2":
                        LoadSavedGame();
                        break;
                    case "3":
                        DisplayCredits();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void StartNewGame()
        {
            Console.Clear();
            GameWorld game = new GameWorld();
            game.Start();
        }

        private static void LoadSavedGame()
        {
            Console.Clear();
            SaveManager saveManager = new SaveManager();
            if (saveManager.LoadGame(out Player player))
            {
                GameWorld game = new GameWorld(player);
                game.Start();
            }
            else
            {
                Console.WriteLine("No saved game found. Press any key to return to the main menu.");
                Console.ReadKey();
            }
        }

        private static void DisplayCredits()
        {
            Console.Clear();
            Console.WriteLine("The Amnesia by Elif Su İleri");
            Console.WriteLine("Credits To:@ApexNebulae on Twitter/X,Olcay Kalyoncuoğlu on Udemy and r/csharp the C# Subreddit ");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}