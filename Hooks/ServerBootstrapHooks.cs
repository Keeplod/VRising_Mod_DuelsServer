using DuelsServer.Commands;
using DuelsServer.Common.Position;
using DuelsServer.Helpers;
using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;

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

                string message = "<color=#447BD4>Дискорд: https://discord.gg/EXKGV52csa</color> \n";
                message += "<color=#FFD300>Используй <color=#FF0000>.kit</color> для получения экипировки\n</color>";
                message += "<size=150%><color=#FFD300>Вы тут впервые? Используй <color=#FF0000>.help</color>!</color></size>";
                ServerChatUtils.SendSystemMessageToClient(Plugin.EntityManager, userData, message);


                SetDebugSettingEvent setDebugSettingEvent = new()
                {
                    SettingType = DebugSettingType.DropsDisabled,
                    Value = true,
                };
                VWorld.Server.GetExistingSystem<DebugEventsSystem>().SetDebugSetting(userIndex, ref setDebugSettingEvent);

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