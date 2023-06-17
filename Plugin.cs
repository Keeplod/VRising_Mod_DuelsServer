using BepInEx;
using BepInEx.Unity.IL2CPP;
using DuelsServer.Commands;
using HarmonyLib;
using System.Reflection;
using VampireCommandFramework;

namespace DuelsServer
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("gg.deca.VampireCommandFramework")]
    public class Plugin : BasePlugin
    {
        private Harmony _harmony;

        public override void Load()
        {
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            CommandRegistry.RegisterAll();
            Teleport.LoadTeleports();

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
