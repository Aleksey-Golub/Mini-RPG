using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Datas.Character_.Abilities_;

namespace Mini_RPG_Data.Character_;

[Serializable]
public class CharacterData
{
    public CharacterRace Race = CharacterRace.Human;
    public string Name;
    public string AvatarPath = null!;
    public LevelData LevelData;
    public HealthData HealthData;
    public AbilitiesDatas AbilitiesDatas;

    public CharacterData()
    {
        LevelData = new LevelData();
        HealthData = new HealthData();
        AbilitiesDatas = Abilities.GetFor(Race);
    }
}