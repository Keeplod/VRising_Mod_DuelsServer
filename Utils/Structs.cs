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

    public struct ArenasData
    {
        public string Name { get; set; }
        public float XPoint1 { get; set; }
        public float YPoint1 { get; set; }
        public float ZPoint1 { get; set; }
        public float XPoint2 { get; set; }
        public float YPoint2 { get; set; }
        public float ZPoint2 { get; set; }
        public ArenasData(string name)
        {
            Name = name;
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
}
