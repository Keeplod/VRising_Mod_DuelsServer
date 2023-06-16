using DuelsServer.Helpers;
using HarmonyLib;
using Il2CppSystem;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using Unity.Mathematics;

namespace DuelsServer.Hooks;

[HarmonyPatch]
public class RespawnTeleportToMainSpawn
{
    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.SpawnCharacter))]
    [HarmonyPostfix]
    public static void Postfix(ServerBootstrapSystem __instance, EntityCommandBuffer commandBuffer, Entity prefab, Entity user, Nullable_Unboxed<float3> customSpawnPosition)
    {
        var entityManager = VWorld.Server.EntityManager;
    
        var entity = entityManager.CreateEntity(
            ComponentType.ReadWrite<FromCharacter>(),
            ComponentType.ReadWrite<PlayerTeleportDebugEvent>()
        );
    
        entityManager.SetComponentData<FromCharacter>(entity, new()
        {
            User = user
        });
    
        entityManager.SetComponentData<PlayerTeleportDebugEvent>(entity, new()
        {
            Position = new float3((float)-1997.500, 5, (float)-2797.5000),
            Target = PlayerTeleportDebugEvent.TeleportTarget.Self
        });
    }
}


