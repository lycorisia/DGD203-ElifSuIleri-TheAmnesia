using System;
using System.Collections.Generic;

namespace TheAmnesiaGame
{
    public class Map
    {
        private Dictionary<(int X, int Y), string> locations;
        public string CurrentLocation { get; set; }

        public Map((int X, int Y) startLocation)
        {
            locations = new Dictionary<(int X, int Y), string>
            {
                { (0, 0), "forest" },
                { (0, 1), "village" },
                { (0, -1), "cliff" },
                { (0, 2), "cave" }
            };
            CurrentLocation = GetLocation(startLocation);
        }

        public string GetLocation((int X, int Y) position)
        {
            return locations.ContainsKey(position) ? locations[position] : "There is nothing here.";
        }

        public void MovePlayer(Player player, string direction)
        {
            var (x, y) = player.Position;

            switch (direction.ToLower())
            {
                case "north":
                    y++;
                    break;
                case "south":
                    y--;
                    break;
                case "east":
                    x++;
                    break;
                case "west":
                    x--;
                    break;
            }

            if (locations.ContainsKey((x, y)))
            {
                player.Position = (x, y);
                CurrentLocation = locations[(x, y)];
            }
            else
            {
                Console.WriteLine("The path is a dead end");
            }
            
        }
    }
}