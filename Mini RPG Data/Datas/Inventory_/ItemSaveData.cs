namespace Mini_RPG_Data.Datas.Inventory_;

[Serializable]
public class ItemSaveData
{
    public ItemSaveData(ItemType type, int id)
    {
        ItemType = type;
        Id = id;
    }

    public ItemType ItemType { get; set; }
    /// <summary>
    /// id in Type group
    /// </summary>
    public int Id { get; set; }
}
