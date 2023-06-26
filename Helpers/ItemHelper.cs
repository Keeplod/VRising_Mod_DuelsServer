using ProjectM;
using Unity.Entities;


namespace DuelsServer.Helpers
{
    internal static partial class ItemHelper
    {
        public static Entity AddItemToInventory(Entity recipient, PrefabGUID guid, int amount)
        {
            try
            {
                var gameData = VWorld.Server.GetExistingSystem<GameDataSystem>();
                var itemSettings = AddItemSettings.Create(VWorld.Server.EntityManager, gameData.ItemHashLookupMap, true);
                var inventoryResponse = InventoryUtilitiesServer.TryAddItem(itemSettings, recipient, guid, amount);

                return inventoryResponse.NewEntity;
            }
            catch
            {
                
            }
            return new Entity();
        }
    }
}
