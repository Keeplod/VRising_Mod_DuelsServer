using HarmonyLib;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Unity.Entities;
using Unity.Mathematics;

namespace DuelsServer.Hooks;

[HarmonyPatch]
public class ConnectTeleportToMainSpawn
{
    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserConnected))]
    [HarmonyPostfix]
    public static void Postfix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
    {
        var entityManager = VWorld.Server.EntityManager;
        var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
        var serverClient = __instance._ApprovedUsersLookup[userIndex];
        var userEntity = serverClient.UserEntity;

        var entity = entityManager.CreateEntity(
            ComponentType.ReadWrite<FromCharacter>(),
            ComponentType.ReadWrite<PlayerTeleportDebugEvent>()
        );
        
        entityManager.SetComponentData<FromCharacter>(entity, new()
        {
            User = userEntity
        });
        
        entityManager.SetComponentData<PlayerTeleportDebugEvent>(entity, new()
        {
            Position = new float3((float)-1997.500, 5, (float)-2797.5000),
            Target = PlayerTeleportDebugEvent.TeleportTarget.Self
        });

        ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChat.Green($"Вы телепортированы на спавн!"));
    }
}


