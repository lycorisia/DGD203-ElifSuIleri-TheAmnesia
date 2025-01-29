using System.Text.Json.Serialization;
namespace TheAmnesiaGame
{


    [System.Serializable]
    public class Player
    {
        public string Name { get; private set; }

        [JsonIgnore]
        public (int X, int Y) Position { get; set; }

        public int PositionX
        {
            get => Position.X;
            set => Position = (value, Position.Y);
        }

        public int PositionY
        {
            get => Position.Y;
            set => Position = (Position.X, value);
        }

        [JsonInclude] // Ensures Inventory is properly loaded
        public Inventory Inventory { get; private set; }

        // Parameterless constructor required for deserialization
        public Player() { }

        public Player(string name)
        {
            Name = name;
            Position = (0, 0);
            Inventory = new Inventory();
        }
    }
}