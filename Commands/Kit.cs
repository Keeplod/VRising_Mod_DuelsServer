using DuelsServer.Common.Prefabs;
using DuelsServer.Helpers;
using ProjectM;
using System;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class KitCommands
    {
        [Command("kit", usage: ".kit", description: "Набор предметов")]
        public static void KitCommand(ChatCommandContext ctx)
        {
            CharacterHelpers.ClearInventory(ctx.Event.SenderCharacterEntity, true);

            Random random = new Random();

            foreach (var prefab in IItemPrefabs.weaponList)
            {
                ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            }

            foreach (var prefab in IItemPrefabs.equipmentList)
            {
                ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            }

            foreach (var prefab in IItemPrefabs.magicSourceList)
            {
                ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, prefab, 1);
            }

            // шапки оставляют инвентарь на трупе, что может мешать... как отключить выпадение дропа пока не ясно
            //int randomIndex = random.Next(IItemPrefabs.headgearList.Count);
            //ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, IItemPrefabs.headgearList[randomIndex], 1);

            int randomIndex = random.Next(IItemPrefabs.cloakList.Count);
            ItemHelper.AddItemToInventory(ctx.Event.SenderCharacterEntity, IItemPrefabs.cloakList[randomIndex], 1);
        }
        public static void kitStarted(NetworkedEntity ne)
        {
            CharacterHelpers.ClearInventory(ne._Entity, true);

            Random random = new Random();

            foreach (var prefab in IItemPrefabs.weaponList)
            {
                ItemHelper.AddItemToInventory(ne._Entity, prefab, 1);
            }

            foreach (var prefab in IItemPrefabs.equipmentList)
            {
                ItemHelper.AddItemToInventory(ne._Entity, prefab, 1);
            }

            foreach (var prefab in IItemPrefabs.magicSourceList)
            {
                ItemHelper.AddItemToInventory(ne._Entity, prefab, 1);
            }

            // шапки оставляют инвентарь на трупе, что может мешать... как отключить выпадение дропа пока не ясно
            //int randomIndex = random.Next(IItemPrefabs.headgearList.Count);
            //ItemHelper.AddItemToInventory(ne._Entity, IItemPrefabs.headgearList[randomIndex], 1);

            int randomIndex = random.Next(IItemPrefabs.cloakList.Count);
            ItemHelper.AddItemToInventory(ne._Entity, IItemPrefabs.cloakList[randomIndex], 1);
        }
    }
}
