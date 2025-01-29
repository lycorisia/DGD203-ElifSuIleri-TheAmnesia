using System;
using System.IO;
using System.Text.Json;

namespace TheAmnesiaGame
{
    public class SaveManager
    {
        private const string SaveFilePath = "savegame.json";

        public void SaveGame(Player player)
        {
            try
            {
                // Serialize the player object to a JSON string
                string jsonString = JsonSerializer.Serialize(player);

                // Write the JSON string to the file
                File.WriteAllText(SaveFilePath, jsonString);

                Console.WriteLine("Game saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving: {ex.Message}");
            }
        }

        public bool LoadGame(out Player player)
        {
            player = null;

            if (!File.Exists(SaveFilePath))
                return false;

            try
            {
                // Read the JSON string from the file
                string jsonString = File.ReadAllText(SaveFilePath);

                // Deserialize the JSON string to a Player object
                player = JsonSerializer.Deserialize<Player>(jsonString);

                Console.WriteLine("Game loaded successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading: {ex.Message}");
                return false;
            }
        }
    }
}