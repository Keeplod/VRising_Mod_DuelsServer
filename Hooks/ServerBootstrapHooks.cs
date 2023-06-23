using HarmonyLib;
using DuelsServer.Helpers;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using DuelsServer.Common.Position;
using ProjectM.Gameplay.Systems;

namespace DuelsServer.Hooks;

[HarmonyPatch]
public class ServerBootstrapHooks
{
    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserConnected))]
    public static class OnUserConnected_Patch
    {
        public static void Postfix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
        {
            try
            {
                var em = __instance.EntityManager;
                var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
                var serverClient = __instance._ApprovedUsersLookup[userIndex];
                var userEntity = serverClient.UserEntity;
                var userData = __instance.EntityManager.GetComponentData<User>(userEntity);
                bool isNewVampire = userData.CharacterName.IsEmpty;

                if (!isNewVampire)
                {
                    CharacterHelpers.TeleportToPos(serverClient.UserEntity, ServerPositions.Pos_Spawn);
                }
            }
            catch { }
        }
    }

    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserDisconnected))]
    public static class OnUserDisconnected_Patch
    {
        private static void Prefix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId, ConnectionStatusChangeReason connectionStatusReason, string extraData)
        {
            try
            {
                var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
                var serverClient = __instance._ApprovedUsersLookup[userIndex];
                var userData = __instance.EntityManager.GetComponentData<User>(serverClient.UserEntity);
                bool isNewVampire = userData.CharacterName.IsEmpty;

                if (!isNewVampire)
                {
                    CharacterHelpers.TeleportToPos(serverClient.UserEntity, ServerPositions.Pos_Dissconect);
                }
            }
            catch { };
        }
    }
}