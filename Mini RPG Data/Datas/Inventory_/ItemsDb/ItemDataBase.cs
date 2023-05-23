namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public abstract class ItemDataBase
    {
        public string PictureName { get; set; } = null!;
        public int Cost { get; set; }
        public string Id { get; set; } = null!;
        public ItemType Type { get; set; }
        public int Rating { get; set; }
        public float Weight { get; set; } = 0.1f;
        public bool IsStackable { get; set; }
        public int StackSize { get; set; } = 100;
    }
}
