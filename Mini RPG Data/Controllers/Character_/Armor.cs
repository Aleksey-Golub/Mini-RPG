using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Controllers.Character_;

[Serializable]
public class Armor
{
    public Armor(int value, ArmorType type)
    {
        Value = value;
        Type = type;
    }

    public int Value { get; set; }
    public ArmorType Type { get; set; }
}
