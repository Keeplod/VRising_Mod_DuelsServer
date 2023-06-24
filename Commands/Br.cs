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
            int index = Plugin.onlineArenas.FindIndex(t => t.Player1.Name.Equals(ctx.Event.User.CharacterName) || t.Player2.Name.Equals(ctx.Event.User.CharacterName));
            if (index == -1)
            {
                // Health up
                var HealthEvent = new ChangeHealthDebugEvent()
                {
                    Amount = 1000,
                };

                VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeHealthEvent(ctx.Event.User.Index, ref HealthEvent);

                // Ability recover
                CharacterHelpers.ResetSkillsCooldown(ctx.Event.SenderCharacterEntity);

                // Blood up
                var clientEvent = new ChangeBloodDebugEvent()
                {
                    Amount = 100,
                };

                VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeBloodEvent(ctx.Event.User.Index, ref clientEvent);
            }
            else
            {
                ctx.Reply($"<color=#FF0000>Вы не можите использовать данную команду на арене!</color>");
            }
        }

        public static void CommandBr(int index, Entity senderCharacterEntity)
        {
            // Health up
            var HealthEvent = new ChangeHealthDebugEvent()
            {
                Amount = 1000,
            };

            VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeHealthEvent(index, ref HealthEvent);

            // Ability recover
            CharacterHelpers.ResetSkillsCooldown(senderCharacterEntity);

            // Blood up
            var clientEvent = new ChangeBloodDebugEvent()
            {
                Amount = 100,
            };

            VWorld.Server.GetExistingSystem<DebugEventsSystem>().ChangeBloodEvent(index, ref clientEvent);
        }
    }
}