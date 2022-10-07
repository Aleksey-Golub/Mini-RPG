namespace Mini_RPG_Data.Character_;

[Serializable]
public class SatiationData
{
    public int FoodSatiation;
    public int WaterSatiation;

    internal SatiationData Copy()
    {
        return (SatiationData)MemberwiseClone();
    }
}
