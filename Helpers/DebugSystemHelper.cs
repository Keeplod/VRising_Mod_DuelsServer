using ProjectM.Network;
using ProjectM;

namespace DuelsServer.Helpers
{
    public static class DebugSystemHelper
    {
        public static void SetDebugSetting(DebugSettingType debugSettingType, bool enabled, int fromUserIndex = 0)
        {
            SetDebugSettingEvent setDebugSettingEvent = new()
            {
                SettingType = debugSettingType,
                Value = enabled,
            };

            VWorld.Server.GetExistingSystem<DebugEventsSystem>().SetDebugSetting(fromUserIndex, ref setDebugSettingEvent);
        }
    }
}
