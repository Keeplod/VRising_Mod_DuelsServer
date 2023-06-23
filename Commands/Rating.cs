using DuelsServer.Common.Prefabs;
using DuelsServer.Common.Structs;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using Il2CppSystem;
using MS.Internal.Xml.XPath;
using ProjectM;
using ProjectM.Network;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    struct NullableFloat
    {
        public float3 value;
        public bool has_value;
    }

    public static class Rating
    {
        [Command("r", description: "[info|createArena|removeArena|setPoint1|setPoint2] [<name>] Рейтинговая арена.", adminOnly: false)]
        public static void rating(ChatCommandContext ctx, string Arg1 = null, string Arg2 = null)
        {
            var arg1 = Arg1?.ToLower();
            var arg2 = Arg2?.ToLower();

            //Регистрация в очередь
            if (arg1 == null)
            {
                for (int i = Plugin.onlineQueueArena.Count - 1; i >= 0; i--)
                {
                    if (Plugin.onlineQueueArena[i].Name.Equals(ctx.Event.User.CharacterName))
                    {
                        Plugin.onlineQueueArena.RemoveAt(i);
                        ctx.Reply($"<color=#ff0>Вы вышли из очереди на арену.</color>");
                        return;
                    }
                }
                PlayerCTX player = new PlayerCTX()
                {
                    Player = ctx.Event.SenderCharacterEntity,
                    Name = ctx.Event.User.CharacterName
                };
                Plugin.onlineQueueArena.Add(player);
                ctx.Reply($"<color=#37DE6A>Вы встали в очередь на арену...</color>");
            }

            // Информация о рейтинге игрока
            if (arg1 == "info")
            {
                ctx.Reply($"<color=#ff0>Информация об игроке {ctx.Event.User.CharacterName}</color>");
            }

            // Создание арены
            if (arg1 == "createarena")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }
                Plugin.arenas.Add(new ArenasData(arg2));
                SaveArenas();

                ctx.Reply($"<color=#37DE6A>Создана арена \"{arg2}\", установите поинты.</color>");
            }

            // Удаление арены
            if (arg1 == "removearena")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }

                for (int i = Plugin.arenas.Count - 1; i >= 0; i--)
                {
                    if (Plugin.arenas[i].Name == arg2)
                    {
                        Plugin.arenas.RemoveAt(i);
                        SaveArenas();
                        ctx.Reply(System.String.Format($"<color=#37DE6A>Арена \"{arg2}\" удалена.</color>"));
                        return;
                    }
                }
                ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                return;
            }

            // Создание 1 точки телепорта на арену
            if (arg1 == "setpoint1")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }

                foreach (var arena in Plugin.arenas)
                {
                    if (arena.Name == arg2)
                    {
                        var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

                        arena.XPoint1 = pos.x;
                        arena.YPoint1 = pos.y;
                        arena.ZPoint1 = pos.z;

                        SaveArenas();

                        ctx.Reply($"<color=#37DE6A>Установлен 1й поинт для арены \"{arg2}\"</color>");
                        return;
                    }
                }
                ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                return;
            }

            // Создание 2 точки телепорта на арену
            if (arg1 == "setpoint2")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }

                foreach (var arena in Plugin.arenas)
                {
                    if (arena.Name == arg2)
                    {
                        var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;

                        arena.XPoint2 = pos.x;
                        arena.YPoint2 = pos.y;
                        arena.ZPoint2 = pos.z;

                        SaveArenas();

                        ctx.Reply($"<color=#37DE6A>Установлен 2й поинт для арены \"{arg2}\"</color>");
                        return;
                    }
                }
                ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                return;
            }
        }

        public static void CreateOnlineArena()
        {
            if (Plugin.onlineQueueArena.Count >= 2)
            {
                var arenas = Plugin.arenas;

                for (int i = arenas.Count - 1; i >= 0; i--)
                {
                    foreach (var gameArena in Plugin.onlineArenas)
                    {
                        if (gameArena.Data.Name == arenas[i].Name)
                        {
                            arenas.RemoveAt(i);
                        }
                    }
                }

                if (arenas.Count > 0)
                {
                    var newArena = new OnlineArena(arenas.First(), Plugin.onlineQueueArena[0], Plugin.onlineQueueArena[1]);
                    Plugin.onlineArenas.RemoveAt(1);
                    Plugin.onlineArenas.RemoveAt(0);
                    Plugin.onlineArenas.Add(newArena);
                    CharacterHelpers.TeleportToPos(newArena.Player1.Player, new float3(newArena.Data.XPoint1, newArena.Data.YPoint1, newArena.Data.ZPoint1));
                    CharacterHelpers.TeleportToPos(newArena.Player2.Player, new float3(newArena.Data.XPoint2, newArena.Data.YPoint2, newArena.Data.ZPoint2));
                }
            }
        }

        public static void LoadArenas()
        {
            string directoryPath = "BepInEx/config/DuelsServer/Saves/";
            string filePath = Path.Combine(directoryPath, "arenas.json");
            string fileContent = "[]";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
            }

            string json = File.ReadAllText("BepInEx/config/DuelsServer/Saves/arenas.json");

            Console.WriteLine("JSON: " + json);

            Plugin.arenas = JsonSerializer.Deserialize<List<ArenasData>>(json);
        }
        public static void SaveArenas()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/arenas.json", JsonSerializer.Serialize(Plugin.arenas, Database.JSON_options));
        }

        public static void LoadRating()
        {
            string directoryPath = "BepInEx/config/DuelsServer/Saves/";
            string filePath = Path.Combine(directoryPath, "rating.json");
            string fileContent = "[]";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
            }

            string json = File.ReadAllText("BepInEx/config/DuelsServer/Saves/rating.json");

            Plugin.tableRatingPlayers = JsonSerializer.Deserialize<List<PlayerRatingData>>(json);
        }
        public static void SaveRating()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/rating.json", JsonSerializer.Serialize(Plugin.tableRatingPlayers, Database.JSON_options));
        }
    }
}