using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class Effect
    {
        public EffectType EffectType { get; set; }
        public int Value { get; set; }
    }
}
