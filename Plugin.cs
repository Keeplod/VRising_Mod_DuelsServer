using BepInEx;
using BepInEx.Unity.IL2CPP;
using DuelsServer.Commands;
using DuelsServer.Common.Structs;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using HarmonyLib;
using ProjectM;
using System.Collections.Generic;
using System.Reflection;
using Unity.Entities;
using VampireCommandFramework;

namespace DuelsServer
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("gg.deca.VampireCommandFramework")]
    public class Plugin : BasePlugin
    {
        private Harmony _harmony;
        public static EntityManager EntityManager => VWorld.Server.EntityManager;

        public static List<TeleportsData> teleports = new List<TeleportsData>();
        public static List<ArenasData> arenas = new List<ArenasData>();
        public static List<PlayerRatingData> tableRatingPlayers = new List<PlayerRatingData>();

        public static List<PlayerCTX> onlineQueueArena = new List<PlayerCTX>();
        public static List<OnlineArena> onlineArenas = new List<OnlineArena>();



        public override void Load()
        {
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            CommandRegistry.RegisterAll();
            Teleport.LoadTeleports();
            Rating.LoadRating();
            Rating.LoadArenas();

            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        public override bool Unload()
        {
            CommandRegistry.UnregisterAssembly();
            _harmony.UnpatchSelf();

            return true;
        }
    }
}
