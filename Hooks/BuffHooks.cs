using DuelsServer.Common.Position;
using DuelsServer.Common.Prefabs;
using DuelsServer.Helpers;
using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;

namespace DuelsServer.Hooks
{
    [HarmonyPatch(typeof(Destroy_TravelBuffSystem), nameof(Destroy_TravelBuffSystem.OnUpdate))]
    public class Destroy_TravelBuffSystem_Patch
    {
        private static void Postfix(Destroy_TravelBuffSystem __instance)
        {
            var entities = __instance.__OnUpdate_LambdaJob0_entityQuery.ToEntityArray(Allocator.Temp);
            foreach (var entity in entities)
            {
                PrefabGUID GUID = __instance.EntityManager.GetComponentData<PrefabGUID>(entity);
                if (GUID.Equals(BuffPrefabs.AB_Interact_TombCoffinSpawn_Travel))
                {
                    var Owner = __instance.EntityManager.GetComponentData<EntityOwner>(entity).Owner;
                    if (!__instance.EntityManager.HasComponent<PlayerCharacter>(Owner)) return;

                    var userEntity = __instance.EntityManager.GetComponentData<PlayerCharacter>(Owner).UserEntity;
                    var user = __instance.EntityManager.GetComponentData<User>(userEntity);

                    //KitCommands.AddSanguineKit(user.LocalCharacter._Entity);
                    CharacterHelpers.TeleportToPos(userEntity, ServerPositions.Pos_Spawn);
                }
            }
        }
    }
}
