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
}
