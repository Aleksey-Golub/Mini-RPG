namespace Mini_RPG_Data.Character_;

[Serializable]
public class HealthData
{
    public int CurrentHealth;

    internal HealthData Copy()
    {
        return (HealthData)MemberwiseClone();
    }
}
