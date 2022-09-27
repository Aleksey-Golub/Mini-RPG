namespace Mini_RPG_Data.Datas.Inventory_;

[Serializable]
public class InventoryData
{
    public List<ItemSaveData> Items = new List<ItemSaveData>();
    /// <summary>
    /// 0 - Head, 1 - Hands, 2 - Body, 3 - Legs, 4 - MainHand, 5 - OffHand
    /// </summary>
    public ItemSaveData[] EquippedItems = new ItemSaveData[6];
}
