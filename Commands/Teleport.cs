using DuelsServer.Helpers;
using DuelsServer.Utils;
using Newtonsoft.Json;
using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DuelsServer.Commands
{
    public static class Teleport
    {
        [Command("teleport", "tp", description: "teleport <Name|Set|Remove|List> [<Name>] Телепортирует в указанную точку.", adminOnly: false)]
        public static void tp(ChatCommandContext ctx, string Arg1 = null, string Arg2 = null)
        {
            var arg1 = Arg1?.ToLower();
            var arg2 = Arg2?.ToLower();

            if (arg1 == null)
            {
                ctx.Reply(String.Format("<color=#FF0000>Не указана точка: (<color=#37DE6A>.tp NamePoint</color>)</color>"));
                return;
            }
            if ((arg1 == "set" && arg2 == null) || (arg1 == "remove" && arg2 == null))
            {
                ctx.Reply(String.Format($"<color=#FF0000>Не указана точка:  (<color=#37DE6A>.tp {arg1} NamePoint</color>)</color>"));
                return;
            }

            if (arg1 == "set")
            {
                if (ctx.Event.User.IsAdmin)
                {
                    var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;
                    AddTeleport(pos, arg2, ctx);
                }
                return;
            }

            if (arg1 == "remove")
            {
                if (ctx.Event.User.IsAdmin)
                {
                    var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;
                    RemoveTeleport(arg2, ctx);
                }
                return;
            }

            if (arg1 == "list")
            {
                string message = $"<color=#37DE6A>Список телепортов:</color> \n";
                foreach (var item in Database.teleports)
                {
                    message += "<color=#37DE6A>.tp " + item.Key + "</color> \n";
                }
                ctx.Reply(message);
                return;
            }

            TeleportsData teleportData;
            if (Database.teleports.TryGetValue(arg1, out teleportData))
            {
                CharacterHelpers.TeleportToPos(ctx.Event.SenderUserEntity, new float3(teleportData.X, teleportData.Y, teleportData.Z));

                return;
            }
            else
            {
                ctx.Reply(String.Format($"<color=#FF0000>Точка \"{arg1}\" не найдена. Воспользуйтесь командой <color=#37DE6A>.tp list</color> для получения всех существующих точек.</color>"));
                return;
            }
        }

        public static void AddTeleport(float3 location, string name, ChatCommandContext ctx)
        {
            foreach (var teleport in Database.teleports)
            {
                if (teleport.Key == name)
                {
                    ctx.Reply(String.Format($"<color=#FF0000>Точка с таким названием уже существует.</color>"));
                    return;
                }
            }
            Database.teleports.Add(name, new TeleportsData(name, location.x, location.y, location.z));
            SaveTeleports();
            ctx.Reply(String.Format($"<color=#37DE6A>Точка \"{name}\" сохранена.</color>"));
        }

        public static void RemoveTeleport(string name, ChatCommandContext ctx)
        {
            TeleportsData teleportData;

            if (Database.teleports.TryGetValue(name, out teleportData))
            {
                Database.teleports.Remove(name);
                SaveTeleports();
                ctx.Reply(String.Format($"<color=#37DE6A>Точка \"{name}\" удалена.</color>"));
                return;
            }
            else
            {
                ctx.Reply(String.Format($"<color=#FF0000>Точка \"{name}\" не найдена. Воспользуйтесь командой <color=#37DE6A>.tp list</color> для получения всех существующих точек.</color>"));
                return;
            }
        }

        public static void LoadTeleports()
        {
            string directoryPath = "BepInEx/config/DuelsServer/Saves/";
            string filePath = Path.Combine(directoryPath, "teleports.json");
            string fileContent = "{}"; 

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
            }

            string json = File.ReadAllText("BepInEx/config/DuelsServer/Saves/teleports.json");

            Database.teleports = JsonSerializer.Deserialize<Dictionary<string, TeleportsData>>(json);
        }
        public static void SaveTeleports()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/teleports.json", JsonSerializer.Serialize(Database.teleports, Database.JSON_options));
        }
    }
}
