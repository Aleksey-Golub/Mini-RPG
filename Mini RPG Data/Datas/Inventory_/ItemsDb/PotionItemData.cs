namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class PotionItemData : ItemDataBase
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
}
