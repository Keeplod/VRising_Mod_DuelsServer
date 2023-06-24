namespace DuelsServer.Common.Structs
{
    public class PlayerRating
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public PlayerRating(string name, int rating)
        {
            Name = name; 
            Rating = rating;
        }
    }
}
