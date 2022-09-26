using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class ArmorItemData : ItemDataBase
    {
        public int ArmorValue { get; set; }
        public int DodgePenalty { get; set; }
        public ArmorType ArmorType { get; set; }
        public EquipmentSlot EquipmentSlot { get; set; }
    }
}
