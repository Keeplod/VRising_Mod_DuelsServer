using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

namespace DuelsServer.Common.Structs
{
    public struct PlayerCTX
    {
        public Entity senderCharacterEntity;
        public Entity senderUserEntity;
        public User User;
        public FixedString64 Name;

        public PlayerCTX(Entity player, FixedString64 name)
        {
            senderCharacterEntity = player;
            Name = name;
        }
    }
}
