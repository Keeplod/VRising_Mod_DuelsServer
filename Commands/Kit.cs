using DuelsServer.Helpers;
using ProjectM;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class KitCommands
    {
        [Command("kit", usage: ".kit", description: "Набор предметов")]
        public static void KitCommand(ChatCommandContext ctx)
        {
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(488592933), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-556769032), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1634690081), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1292986377), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(82446940), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-674860200), 1);

            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-175650376), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-296161379), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1380368392), 1);

            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-2044057823), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1389040540), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-126076280), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-2053917766), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1322545846), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-774462329), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(1887724512), 1);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, new PrefabGUID(-850142339), 1);
        }
    }
}
