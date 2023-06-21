using DuelsServer.Helpers;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class Br
    {
        [Command("br", "b", description: "Восстановление способностей и здоровья", adminOnly: false)]
        public static void br(ChatCommandContext ctx)
        {
            // Health up
            var HealthEvent = new ChangeHealthDebugEvent()
            {
                Amount = 1000,
            };

            VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeHealthEvent(ctx.Event.User.Index, ref HealthEvent);
            //ctx.Reply($"<color=#ff0>Востановлено хп</color>");

            // Ability recover
            CharacterHelpers.ResetSkillsCooldown(ctx.Event.SenderCharacterEntity);
            //Entity PlayerCharacter = ctx.Event.SenderCharacterEntity;
            //string name = ctx.Name;
            //
            //var AbilityBuffer = VWorld.Server.EntityManager.GetBuffer<AbilityGroupSlotBuffer>(PlayerCharacter);
            //foreach (var ability in AbilityBuffer)
            //{
            //    var AbilitySlot = ability.GroupSlotEntity._Entity;
            //    var ActiveAbility = VWorld.Server.EntityManager.GetComponentData<AbilityGroupSlot>(AbilitySlot);
            //    var ActiveAbility_Entity = ActiveAbility.StateEntity._Entity;
            //
            //    var b = PrefabHelpers.GetPrefabGUID(ActiveAbility_Entity);
            //    if (b.GuidHash == 0) continue;
            //
            //    var AbilityStateBuffer = VWorld.Server.EntityManager.GetBuffer<AbilityStateBuffer>(ActiveAbility_Entity);
            //    foreach (var state in AbilityStateBuffer)
            //    {
            //        var abilityState = state.StateEntity._Entity;
            //        var abilityCooldownState = VWorld.Server.EntityManager.GetComponentData<AbilityCooldownState>(abilityState);
            //        abilityCooldownState.CooldownEndTime = 0;
            //        VWorld.Server.EntityManager.SetComponentData(abilityState, abilityCooldownState);
            //    }
            //}

            //ctx.Reply($"<color=#ff0>Востановлены абилки</color>");

            // Blood up
            var clientEvent = new ChangeBloodDebugEvent()
            {
                Amount = 100,
            };

            VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeBloodEvent(ctx.Event.User.Index, ref clientEvent);

            //ctx.Reply($"<color=#ff0>Востановлена кровь</color>");
        }
    }
}