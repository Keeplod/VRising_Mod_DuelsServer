using DuelsServer.Commands;
using DuelsServer.Helpers;
using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

namespace DuelsServer.Hooks;
[HarmonyPatch]
public class DeathEventListenerSystem_Patch
{
    [HarmonyPatch(typeof(DeathEventListenerSystem), "OnUpdate")]
    [HarmonyPostfix]
    public static void Postfix(DeathEventListenerSystem __instance)
    {
        NativeArray<DeathEvent> deathEvents = __instance._DeathEventQuery.ToComponentDataArray<DeathEvent>(Allocator.Temp);
        
        foreach (DeathEvent ev in deathEvents)
        {
            if (__instance.EntityManager.HasComponent<PlayerCharacter>(ev.Died))
            {
                PlayerCharacter player = __instance.EntityManager.GetComponentData<PlayerCharacter>(ev.Died);
                Entity userEntity = player.UserEntity;
                User user = __instance.EntityManager.GetComponentData<User>(userEntity);

                CharacterHelpers.RespawnCharacter(ev.Died, userEntity);
                CharacterHelpers.ResetSkillsCooldown(user.LocalCharacter._Entity);
            }
        }
    }

    [HarmonyPatch(typeof(VampireDownedServerEventSystem), nameof(VampireDownedServerEventSystem.OnUpdate))]
    public class VampireDownedServerEventSystem_Patch
    {
        public static void Postfix(VampireDownedServerEventSystem __instance)
        {
            var entities = __instance.__OnUpdate_LambdaJob0_entityQuery.ToEntityArray(Allocator.Temp);
            EntityManager em = __instance.EntityManager;

            foreach (var entity in entities)
            {
                var Owner = __instance.EntityManager.GetComponentData<EntityOwner>(entity).Owner;
                if (!__instance.EntityManager.HasComponent<PlayerCharacter>(Owner)) return;

                VampireDownedServerEventSystem.TryFindRootOwner(entity, 1, em, out var Victim);
                PlayerCharacter player = __instance.EntityManager.GetComponentData<PlayerCharacter>(Victim);
                var userEntity = __instance.EntityManager.GetComponentData<PlayerCharacter>(Owner).UserEntity;
                var user = __instance.EntityManager.GetComponentData<User>(userEntity);

                if (user.IsConnected)
                {
                    int index = Plugin.onlineArenas.FindIndex(t => t.Player1.Name.Equals(player.Name) || t.Player2.Name.Equals(player.Name));
                    if (index != -1)
                    {
                        if (Plugin.onlineArenas[index].Player1.Name.Equals(player.Name))
                        {
                            CharacterHelpers.TeleportToPos(Plugin.onlineArenas[index].Player1.senderUserEntity, Common.Position.ServerPositions.Pos_Spawn);
                            CharacterHelpers.TeleportToPos(Plugin.onlineArenas[index].Player2.senderUserEntity, Common.Position.ServerPositions.Pos_Spawn);

                            int rating = Rating.EditRating(Plugin.onlineArenas[index].Player2.Name.ToString(), Plugin.onlineArenas[index].Player1.Name.ToString());

                            ServerChatUtils.SendSystemMessageToClient(Plugin.EntityManager, Plugin.onlineArenas[index].Player1.User, $"<color=#FF0000>Вы проиграли в схаватке с {Plugin.onlineArenas[index].Player2.Name} и получили -{rating}ммр</color>");
                            ServerChatUtils.SendSystemMessageToClient(Plugin.EntityManager, Plugin.onlineArenas[index].Player2.User, $"<color=#37DE6A>Вы победили в схаватке с {Plugin.onlineArenas[index].Player1.Name} и получили +{rating}ммр</color>");

                            Plugin.onlineArenas.RemoveAt(index);
                        }
                        else
                        {
                            CharacterHelpers.TeleportToPos(Plugin.onlineArenas[index].Player1.senderUserEntity, Common.Position.ServerPositions.Pos_Spawn);
                            CharacterHelpers.TeleportToPos(Plugin.onlineArenas[index].Player2.senderUserEntity, Common.Position.ServerPositions.Pos_Spawn);

                            int rating = Rating.EditRating(Plugin.onlineArenas[index].Player1.Name.ToString(), Plugin.onlineArenas[index].Player2.Name.ToString());

                            ServerChatUtils.SendSystemMessageToClient(Plugin.EntityManager, Plugin.onlineArenas[index].Player1.User, $"<color=#37DE6A>Вы победили в схаватке с {Plugin.onlineArenas[index].Player2.Name} и получили +{rating}ммр</color>");
                            ServerChatUtils.SendSystemMessageToClient(Plugin.EntityManager, Plugin.onlineArenas[index].Player2.User, $"<color=#FF0000>Вы проиграли в схаватке с {Plugin.onlineArenas[index].Player1.Name} и получили -{rating}ммр</color>");

                            Plugin.onlineArenas.RemoveAt(index);
                        }

                        Rating.SaveRating();
                        Rating.CreateOnlineArena();
                    }
                }
            }
        }
    }
}