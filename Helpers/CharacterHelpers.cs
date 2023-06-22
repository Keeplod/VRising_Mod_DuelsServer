using DuelsServer.Common.Prefabs;
using Il2CppSystem;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DuelsServer.Helpers
{
    public static class CharacterHelpers
    {
        public static void TeleportToPos(Entity userEntity, float3 pos)
        {
            var entity = Plugin.EntityManager.CreateEntity(
                    ComponentType.ReadWrite<FromCharacter>(),
                    ComponentType.ReadWrite<PlayerTeleportDebugEvent>());

            Plugin.EntityManager.SetComponentData<FromCharacter>(entity, new()
            {
                User = userEntity
            });

            Plugin.EntityManager.SetComponentData<PlayerTeleportDebugEvent>(entity, new()
            {
                Position = new float3(pos.x, pos.y, pos.z),
                Target = PlayerTeleportDebugEvent.TeleportTarget.Self
            });
        }

        public static void RespawnCharacter(Entity VictimEntity, PlayerCharacter player, Entity userEntity)
        {
            var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(VictimEntity).Position;
            var bufferSystem = VWorld.Server.GetExistingSystem<EntityCommandBufferSystem>();
            var commandBufferSafe = bufferSystem.CreateCommandBuffer();

            Nullable_Unboxed<float3> spawnLoc = new();
            spawnLoc.value = new(pos.x, pos.y, pos.z);
            spawnLoc.has_value = true;

            var server = VWorld.Server.GetOrCreateSystem<ServerBootstrapSystem>();

            server.RespawnCharacter(commandBufferSafe, userEntity, customSpawnLocation: spawnLoc, previousCharacter: VictimEntity, fadeOutEntity: userEntity);
        }

        public static void ClearInventory(Entity characterEntity, bool isDeleteArmor = true)
        {
            if (!InventoryUtilities.TryGetInventoryEntity(Plugin.EntityManager, characterEntity, out Entity playerInventory) || playerInventory == Entity.Null)
                return;

            if (isDeleteArmor)
            {
                InventoryUtilitiesServer.ClearInventory(Plugin.EntityManager, playerInventory);
            }
            else
            {
                var inventoryBuffer = Plugin.EntityManager.GetBuffer<InventoryBuffer>(playerInventory);

                foreach (var inventoryItem in inventoryBuffer)
                {

                    bool isDelete = true;
                    foreach (var item in IItemPrefabs.allArmors)
                    {
                        if (inventoryItem.ItemType == item)
                        {
                            isDelete = false;
                        }
                    }
                    if (isDelete)
                    {
                        InventoryUtilitiesServer.TryRemoveItem(Plugin.EntityManager, playerInventory, inventoryItem.ItemType, inventoryItem.Amount);
                    }
                }
            }
        }

        public static void ResetSkillsCooldown(Entity characterEntity)
        {
            var AbilityBuffer = Plugin.EntityManager.GetBuffer<AbilityGroupSlotBuffer>(characterEntity);
            foreach (var ability in AbilityBuffer)
            {
                var AbilitySlot = ability.GroupSlotEntity._Entity;
                var ActiveAbility = Plugin.EntityManager.GetComponentData<AbilityGroupSlot>(AbilitySlot);
                var ActiveAbility_Entity = ActiveAbility.StateEntity._Entity;

                var b = PrefabHelpers.GetPrefabGUID(ActiveAbility_Entity);
                if (b.GuidHash == 0) continue;

                var AbilityStateBuffer = Plugin.EntityManager.GetBuffer<AbilityStateBuffer>(ActiveAbility_Entity);
                foreach (var state in AbilityStateBuffer)
                {
                    var abilityState = state.StateEntity._Entity;
                    var abilityCooldownState = Plugin.EntityManager.GetComponentData<AbilityCooldownState>(abilityState);
                    abilityCooldownState.CooldownEndTime = 0;
                    Plugin.EntityManager.SetComponentData(abilityState, abilityCooldownState);
                }
            }
        }

        public static void ChangeSpeed(Entity characterEntity, float speed)
        {
            var component = Plugin.EntityManager.GetComponentData<Movement>(characterEntity);
            component.Speed = ModifiableFloat.Create(characterEntity, Plugin.EntityManager, speed);
            Plugin.EntityManager.SetComponentData(characterEntity, component);
        }
    }
}
