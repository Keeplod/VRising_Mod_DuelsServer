namespace DuelsServer.Common.Structs
{
    public struct OnlineArena
    {
        public ArenasData Data;
        public PlayerCTX Player1;
        public PlayerCTX Player2;

        public OnlineArena(ArenasData arenasData, PlayerCTX player1, PlayerCTX player2) 
        {
            Data = arenasData;
            Player1 = player1;
            Player2 = player2;
        }
    }
}
