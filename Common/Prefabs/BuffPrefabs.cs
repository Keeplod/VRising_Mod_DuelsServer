using ProjectM;

namespace DuelsServer.Common.Prefabs
{
    public static class BuffPrefabs
    {
        public static readonly PrefabGUID AB_Interact_TombCoffinSpawn_Travel = new(722466953);

        public static readonly PrefabGUID InCombatBuff = new(697095869);

        public static readonly PrefabGUID AB_Consumable_SpellBrew_T02_AbilityGroup = new(-2008977590); // Ведьмино зелье баф
        public static readonly PrefabGUID AB_Consumable_SpellBrew_T01_AbilityGroup = new(452822121); // Заколдованный отвар баф
        public static readonly PrefabGUID AB_Consumable_PhysicalBrew_T02_AbilityGroup = new(1195333673); // Зелье ярости баф
        public static readonly PrefabGUID AB_Consumable_PhysicalBrew_T01_AbilityGroup = new(-1506728203); // Отвар неистовства баф

        public static readonly System.Collections.Generic.List<PrefabGUID> consumableBuffList = new System.Collections.Generic.List<PrefabGUID>()
        {
            AB_Consumable_SpellBrew_T02_AbilityGroup,
            AB_Consumable_SpellBrew_T01_AbilityGroup,
            AB_Consumable_PhysicalBrew_T02_AbilityGroup,
            AB_Consumable_PhysicalBrew_T01_AbilityGroup
        };
    }
}
