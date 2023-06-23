using Unity.Collections;
using Unity.Entities;

namespace DuelsServer.Common.Structs
{
    public struct PlayerCTX
    {
        public Entity Player;
        public FixedString64 Name;
        public PlayerCTX(Entity player, FixedString64 name)
        {
            Player = player;
            Name = name;
        }
    }
}
