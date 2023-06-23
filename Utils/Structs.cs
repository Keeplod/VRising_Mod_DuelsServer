namespace DuelsServer.Utils
{
    public struct TeleportsData
    {
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public TeleportsData(string name, float x, float y, float z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct PlayerRatingData
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public PlayerRatingData(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
    }

    public struct FakeNull
    {
        public int value;
        public bool has_value;
    }
}
