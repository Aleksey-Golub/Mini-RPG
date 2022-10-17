using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Datas.Character_.Abilities_;
using Mini_RPG_Data.Datas.Inventory_;

namespace Mini_RPG_Data.Character_;

[Serializable]
public class CharacterData
{
    public int Id { get; set; }
    public Race Race = Race.Human;
    public string Name = null!;
    public string AvatarPath = null!;
    public LevelData LevelData;
    public HealthData HealthData;
    public SatiationData SatiationData;
    public AbilitiesDatas AbilitiesDatas;
    public InventoryData InventoryData;

    public CharacterData()
    {
        LevelData = new LevelData();
        HealthData = new HealthData();
        SatiationData = new SatiationData();
        AbilitiesDatas = Abilities.GetFor(Race);
        InventoryData = new InventoryData();
    }

    internal CharacterData Copy()
    {
        CharacterData copy = (CharacterData)MemberwiseClone();
        copy.LevelData = LevelData.Copy();
        copy.HealthData = HealthData.Copy();
        copy.SatiationData = SatiationData.Copy();
        copy.AbilitiesDatas = AbilitiesDatas.Copy();
        copy.InventoryData = InventoryData.Copy();

        return copy;
    }
}