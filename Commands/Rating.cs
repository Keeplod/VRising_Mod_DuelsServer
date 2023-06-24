using DuelsServer.Common.Structs;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using Il2CppSystem;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Unity.Mathematics;
using Unity.Transforms;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class Rating
    {
        [Command("r", description: "[info|createArena|removeArena|setPoint1|setPoint2] [<name>] Рейтинговая арена.", adminOnly: false)]
        public static void rating(ChatCommandContext ctx, string Arg1 = null, string Arg2 = null)
        {
            int index = Plugin.onlineArenas.FindIndex(t => t.Player1.Name.Equals(ctx.Event.User.CharacterName) || t.Player2.Name.Equals(ctx.Event.User.CharacterName));
            if (index == -1)
            {
                var arg1 = Arg1?.ToLower();
                var arg2 = Arg2?.ToLower();

                //Регистрация в очередь
                if (arg1 == null)
                {
                    bool isUserPlayed = Plugin.tableRatingPlayers.Exists(player => player.Name == ctx.User.CharacterName.ToString());

                    if (!isUserPlayed)
                    {
                        Plugin.tableRatingPlayers.Add(new PlayerRating(ctx.User.CharacterName.ToString(), 1000));
                    }

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
                        senderCharacterEntity = ctx.Event.SenderCharacterEntity,
                        senderUserEntity = ctx.Event.SenderUserEntity,
                        User = ctx.Event.User,
                        Name = ctx.Event.User.CharacterName
                    };
                    Plugin.onlineQueueArena.Add(player);
                    ctx.Reply($"<color=#37DE6A>Вы встали в очередь на арену...</color>");

                    CreateOnlineArena();
                }

                // Информация о рейтинге игрока
                if (arg1 == "info")
                {
                    bool isUserPlayed = Plugin.tableRatingPlayers.Exists(player => player.Name == ctx.User.CharacterName.ToString());

                    if (!isUserPlayed)
                    {
                        Plugin.tableRatingPlayers.Add(new PlayerRating(ctx.User.CharacterName.ToString(), 1000));
                    }

                    Plugin.tableRatingPlayers = Plugin.tableRatingPlayers.OrderByDescending(player => player.Rating).ToList();

                    string message = "<color=#ff0>Рейтинг игроков: \n";
                    bool isViewsPlayerRequest = false;

                    for (int i = 0; i < Plugin.tableRatingPlayers.Count; i++)
                    {
                        if (i < 5)
                        {
                            if (Plugin.tableRatingPlayers[i].Name == ctx.User.CharacterName.ToString())
                            {
                                isViewsPlayerRequest = true;
                                message += $"<color=#37DE6A>{i + 1}. {Plugin.tableRatingPlayers[i].Name} ({Plugin.tableRatingPlayers[i].Rating}) - (Вы) </color>\n";
                            }
                            else
                            {
                                message += $"<color=#ff0>{i + 1}. {Plugin.tableRatingPlayers[i].Name} ({Plugin.tableRatingPlayers[i].Rating})</color>\n";
                            }
                        }
                        else
                        {
                            if (i == 5)
                            {
                                if (Plugin.tableRatingPlayers[i].Name == ctx.User.CharacterName.ToString())
                                {
                                    message += $"<color=#37DE6A>{i + 1}. {Plugin.tableRatingPlayers[i].Name} ({Plugin.tableRatingPlayers[i].Rating}) - (Вы) </color>\n";
                                }
                                else
                                {
                                    if (!isViewsPlayerRequest)
                                    {
                                        message += $"<color=#ff0>...\n</color>";
                                    }
                                }
                            }
                            else
                            {
                                if (!isViewsPlayerRequest)
                                {
                                    if (Plugin.tableRatingPlayers[i].Name == ctx.User.CharacterName.ToString())
                                    {
                                        isViewsPlayerRequest = true;
                                        message += $"<color=#37DE6A>{i + 1}. {Plugin.tableRatingPlayers[i].Name} ({Plugin.tableRatingPlayers[i].Rating}) - (Вы) </color>\n";
                                    }
                                }
                            }
                        }
                    }

                    ctx.Reply(message);
                }

                // Создание арены
                if (arg1 == "createarena")
                {
                    if (ctx.Event.User.IsAdmin)
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
                    return;
                }

                // Удаление арены
                if (arg1 == "removearena")
                {
                    if (ctx.Event.User.IsAdmin)
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
                    return;

                }

                // Создание 1 точки телепорта на арену
                if (arg1 == "setpoint1")
                {
                    if (ctx.Event.User.IsAdmin)
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
                    return;
                }

                // Создание 2 точки телепорта на арену
                if (arg1 == "setpoint2")
                {
                    if (ctx.Event.User.IsAdmin)
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
                    return;
                }
            }
            else
            {
                ctx.Reply($"<color=#FF0000>Вы не можите использовать данную команду на арене!</color>");
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

                Console.WriteLine("arenas.Count: " + arenas.Count);

                if (arenas.Count > 0)
                {

                    System.Random random = new System.Random();
                    int randomIndex = random.Next(0, arenas.Count);

                    var newArena = new OnlineArena(arenas[randomIndex], Plugin.onlineQueueArena[0], Plugin.onlineQueueArena[1]);
                    Plugin.onlineQueueArena.RemoveAt(1);
                    Plugin.onlineQueueArena.RemoveAt(0);
                    Plugin.onlineArenas.Add(newArena);
                    CharacterHelpers.TeleportToPos(newArena.Player1.senderUserEntity, new float3(newArena.Data.XPoint1, newArena.Data.YPoint1, newArena.Data.ZPoint1));
                    CharacterHelpers.TeleportToPos(newArena.Player2.senderUserEntity, new float3(newArena.Data.XPoint2, newArena.Data.YPoint2, newArena.Data.ZPoint2));

                    Br.CommandBr(newArena.Player1.User.Index, newArena.Player1.senderCharacterEntity);
                    Br.CommandBr(newArena.Player2.User.Index, newArena.Player2.senderCharacterEntity);
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

            Plugin.tableRatingPlayers = JsonSerializer.Deserialize<List<PlayerRating>>(json);
        }
        public static void SaveRating()
        {
            File.WriteAllText("BepInEx/config/DuelsServer/Saves/rating.json", JsonSerializer.Serialize(Plugin.tableRatingPlayers, Database.JSON_options));
        }

        public static int EditRating(string WinPlayerName, string LostPlayerName)
        {
            int indexPlayerWin = Plugin.tableRatingPlayers.FindIndex(p => p.Name == WinPlayerName);
            int indexPlayerLost = Plugin.tableRatingPlayers.FindIndex(p => p.Name == LostPlayerName);

            if (Plugin.tableRatingPlayers[indexPlayerWin].Rating - Plugin.tableRatingPlayers[indexPlayerLost].Rating >= 250)
            {
                Plugin.tableRatingPlayers[indexPlayerWin].Rating += 2;
                Plugin.tableRatingPlayers[indexPlayerLost].Rating -= 2;
                return 2;
            }
            else
            {
                Plugin.tableRatingPlayers[indexPlayerWin].Rating += 25;
                Plugin.tableRatingPlayers[indexPlayerLost].Rating -= 25;
                return 25;
            }
        }
    }
}