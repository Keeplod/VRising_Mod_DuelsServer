using HarmonyLib;
using DuelsServer.Helpers;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Unity.Entities;
using Unity.Mathematics;

namespace DuelsServer.Hooks;

[HarmonyPatch]
public class DisconnectTeleportToMainSpawn
{
    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserDisconnected))]
    [HarmonyPrefix]
    public static void Prefix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
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
            Position = new float3((float)-1403.53, (float)7.5, (float)-399.08),
            Target = PlayerTeleportDebugEvent.TeleportTarget.Self
        });
    }
}


