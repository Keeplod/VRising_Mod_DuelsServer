using DuelsServer.Helpers;
using ProjectM;
using System;
using System.Collections.Generic;
using Unity.Entities;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class KitCommands
    {
        [Command("kit", usage: ".kit", description: "Change your current kit")]
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

        public static void AddSanguineKit(Entity characterEntity)
        {
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(488592933), 1, 9);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-556769032), 1, 10);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1634690081), 1, 11);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1292986377), 1, 12);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(82446940), 1, 13);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-674860200), 1, 14);
            //
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-175650376), 1, 18);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-296161379), 1, 19);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1380368392), 1, 20);
            //
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-2044057823), 1, 0);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1389040540), 1, 1);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-126076280), 1, 2);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-2053917766), 1, 3);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1322545846), 1, 4);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-774462329), 1, 5);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(1887724512), 1, 6);
            //ItemHelpers.AddItemToInventory(characterEntity, new PrefabGUID(-850142339), 1, 8);
        }
    }
}
