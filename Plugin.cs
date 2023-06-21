using BepInEx;
using BepInEx.Unity.IL2CPP;
using DuelsServer.Commands;
using DuelsServer.Helpers;
using DuelsServer.Utils;
using HarmonyLib;
using ProjectM;
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

        public override void Load()
        {
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            CommandRegistry.RegisterAll();
            Teleport.LoadTeleports();
            Rating.LoadRating();
            Rating.LoadArenas();
            //OnGameInitialized();

            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        public override bool Unload()
        {
            CommandRegistry.UnregisterAssembly();
            _harmony.UnpatchSelf();

            return true;
        }

        //public void OnGameInitialized()
        //{
        //    Initialize();
        //}
        //
        //public static void Initialize()
        //{
        //    DebugSystemHelper.SetDebugSetting(DebugSettingType.DropsDisabled, true);
        //    DebugSystemHelper.SetDebugSetting(DebugSettingType.DayNightCycleDisabled, true);
        //}
    }
}
