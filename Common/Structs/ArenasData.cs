namespace DuelsServer.Common.Structs
{
    public class ArenasData
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
}
