using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class WeaponItemData : ItemDataBase
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public DamageType DamageType { get; set; }
        public Grip Grip { get; set; }
        public WeaponType WeaponType { get; set; }
    }
}
