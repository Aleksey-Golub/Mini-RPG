using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Player_;

namespace Mini_RPG_Data.Datas
{
    [Serializable]
    public class TownTraderData
    {
        public InventoryData InventoryData = new InventoryData();
        public WalletData WalletData = new WalletData();
    }
}