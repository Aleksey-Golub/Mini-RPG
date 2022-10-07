namespace Mini_RPG_Data.Character_;

[Serializable]
public class LevelData
{
    public int Value;
    public int CurrentExperience;

    internal LevelData Copy()
    {
        return (LevelData)MemberwiseClone();
    }
}
