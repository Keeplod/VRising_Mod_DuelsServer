using DuelsServer.Common.Prefabs;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using Il2CppSystem;
using ProjectM;
using ProjectM.Network;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Unity.Entities;
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

            //Регистрация на арену
            if (arg1 == null)
            {

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
                Database.arenas.Add(arg2, new ArenasData(arg2));
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

                ArenasData arenasData;
                if (Database.arenas.TryGetValue(arg2, out arenasData))
                {
                    Database.arenas.Remove(arg2);
                    SaveArenas();
                    ctx.Reply(System.String.Format($"<color=#37DE6A>Арена \"{arg2}\" удалена.</color>"));
                    return;
                }
                else
                {
                    ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                    return;
                }
            }

            // Создание 1 точки телепорта на арену
            if (arg1 == "setpoint1")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }

                ArenasData arenasData;
                if (Database.arenas.TryGetValue(arg2, out arenasData))
                {
                    var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;
                    arenasData.XPoint1 = pos.x;
                    arenasData.YPoint1 = pos.y;
                    arenasData.ZPoint1 = pos.z;
                    Database.arenas[arg2] = arenasData;
                    SaveArenas();

                    ctx.Reply(System.String.Format($"<color=#37DE6A>Установлен 1й поинт для арены \"{arg2}\"</color>"));
                    return;
                }
                else
                {
                    ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                    return;
                }
            }

            // Создание 2 точки телепорта на арену
            if (arg1 == "setpoint2")
            {
                if (arg2 == null)
                {
                    ctx.Reply($"<color=#FF0000>Укажите название арены.</color>");
                    return;
                }

                ArenasData arenasData;
                if (Database.arenas.TryGetValue(arg2, out arenasData))
                {
                    var pos = VWorld.Server.EntityManager.GetComponentData<LocalToWorld>(ctx.Event.SenderCharacterEntity).Position;
                    arenasData.XPoint2 = pos.x;
                    arenasData.YPoint2 = pos.y;
                    arenasData.ZPoint2 = pos.z;
                    Database.arenas[arg2] = arenasData;
                    SaveArenas();

                    ctx.Reply(System.String.Format($"<color=#37DE6A>Установлен 2й поинт для арены \"{arg2}\"</color>"));
                    return;
                }
                else
                {
                    ctx.Reply(System.String.Format($"<color=#FF0000>Арена \"{arg2}\" не найдена.</color>"));
                    return;
                }
            }
        }

        public static void LoadArenas()
        {
            string directoryPath = "BepInEx/config/DuelsServer/Saves/";
            string filePath = Path.Combine(directoryPath, "arenas.json");
            string fileContent = "{}";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
            }

            string json = File.ReadAllText("BepInEx/config/DuelsServer/Saves/arenas.json");

            Database.arenas = JsonSerializer.Deserialize<Dictionary<string, ArenasData>>(json);
        }
        public static void SaveArenas()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/arenas.json", JsonSerializer.Serialize(Database.arenas, Database.JSON_options));
        }

        public static void LoadRating()
        {
            string directoryPath = "BepInEx/config/DuelsServer/Saves/";
            string filePath = Path.Combine(directoryPath, "rating.json");
            string fileContent = "{}";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
            }

            string json = File.ReadAllText("BepInEx/config/DuelsServer/Saves/rating.json");

            Database.rating = JsonSerializer.Deserialize<Dictionary<string, PlayerRatingData>>(json);
        }
        public static void SaveRating()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/rating.json", JsonSerializer.Serialize(Database.rating, Database.JSON_options));
        }
    }
}