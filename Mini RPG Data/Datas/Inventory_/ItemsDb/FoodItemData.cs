namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class FoodItemData : ItemDataBase
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
}
