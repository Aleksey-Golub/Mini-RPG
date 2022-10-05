using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Datas.Enemy_.EnemiesDB;

[Serializable]
public class BeastEnemyDataBase
{
    public BeastEnemyDataBase()
    {
        CharacterData = new CharacterData();
        HeadArmor = new Armor(0, ArmorType.Light);
        HandsArmor = new Armor(0, ArmorType.Light);
        BodyArmor = new Armor(0, ArmorType.Light);
        LegsArmor = new Armor(0, ArmorType.Light);
    }

    public CharacterData CharacterData { get; set; }
    public int MaxHealth { get; set; }
    public int FieldOfView { get; set; }
    public int Experience { get; set; }
    public int AttackModifier { get; set; }
    public int DefenseModifier { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public DamageType DamageType { get; set; }
    public Armor HeadArmor { get; set; }
    public Armor HandsArmor { get; set; }
    public Armor BodyArmor { get; set; }
    public Armor LegsArmor { get; set; }
}
