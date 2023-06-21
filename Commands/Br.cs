using DuelsServer.Helpers;
using ProjectM;
using ProjectM.Network;
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