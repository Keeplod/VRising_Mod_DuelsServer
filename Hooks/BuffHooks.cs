using DuelsServer.Commands;
using DuelsServer.Common.Position;
using DuelsServer.Common.Prefabs;
using DuelsServer.Helpers;
using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

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

                    KitCommands.kitStarted(user.LocalCharacter);
                    CharacterHelpers.TeleportToPos(userEntity, ServerPositions.Pos_Spawn);
                }
            }
        }
    }

    // Происходит утечка при дистрои бафа

    //[HarmonyPatch(typeof(ModifyUnitStatBuffSystem_Spawn), nameof(ModifyUnitStatBuffSystem_Spawn.OnUpdate))]
    //public class ModifyUnitStatBuffSystem_Spawn_Patch
    //{
    //    private static void Prefix(ModifyUnitStatBuffSystem_Spawn __instance)
    //    {
    //        NativeArray<Entity> entities = __instance.__OnUpdate_LambdaJob0_entityQuery.ToEntityArray(Allocator.Temp);
    //        foreach (var entity in entities)
    //        {
    //            PrefabGUID GUID = __instance.EntityManager.GetComponentData<PrefabGUID>(entity);
    //
    //            Entity Owner = Plugin.EntityManager.GetComponentData<EntityOwner>(entity).Owner;
    //            if (!Plugin.EntityManager.HasComponent<PlayerCharacter>(Owner))
    //                continue;
    //
    //            PlayerCharacter playerCharacter = Plugin.EntityManager.GetComponentData<PlayerCharacter>(Owner);
    //            Entity User = playerCharacter.UserEntity;
    //            User Data = Plugin.EntityManager.GetComponentData<User>(User);
    //
    //            if (GUID == BuffPrefabs.WolfNormal || GUID == BuffPrefabs.WolfStygian)
    //            {
    //                CharacterHelpers.ChangeSpeed(Data.LocalCharacter._Entity, 15.00f);
    //            }
    //        }
    //    }
    //}
    //
    //[HarmonyPatch(typeof(ModifyUnitStatBuffSystem_Destroy), nameof(ModifyUnitStatBuffSystem_Destroy.OnUpdate))]
    //public class ModifyUnitStatBuffSystem_Destroy_Patch
    //{
    //    private static void Prefix(ModifyUnitStatBuffSystem_Destroy __instance)
    //    {
    //        NativeArray<Entity> entities = __instance.__OnUpdate_LambdaJob0_entityQuery.ToEntityArray(Allocator.Temp);
    //        foreach (var entity in entities)
    //        {
    //            try
    //            {
    //                PrefabGUID GUID = __instance.EntityManager.GetComponentData<PrefabGUID>(entity);
    //
    //                Entity Owner = Plugin.EntityManager.GetComponentData<EntityOwner>(entity).Owner;
    //                if (!Plugin.EntityManager.HasComponent<PlayerCharacter>(Owner))
    //                    continue;
    //
    //                PlayerCharacter playerCharacter = Plugin.EntityManager.GetComponentData<PlayerCharacter>(Owner);
    //                Entity User = playerCharacter.UserEntity;
    //                User Data = Plugin.EntityManager.GetComponentData<User>(User);
    //
    //                if (GUID == BuffPrefabs.WolfNormal || GUID == BuffPrefabs.WolfStygian)
    //                {
    //                    CharacterHelpers.ChangeSpeed(Data.LocalCharacter._Entity, 4.4f);
    //                }
    //            }
    //            catch
    //            {
    //
    //            }
    //        }
    //    }
    //}
}
