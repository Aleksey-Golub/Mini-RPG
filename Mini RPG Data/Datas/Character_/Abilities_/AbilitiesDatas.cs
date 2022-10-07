namespace Mini_RPG_Data.Datas.Character_.Abilities_;

[Serializable]
public class AbilitiesDatas
{
    public int AbilityPoints;

    public AbilityData StrengthData;
    public AbilityData DexterityData;
    public AbilityData ConstitutionData;
    public AbilityData PerceptionData;
    public AbilityData CharismaData;
    
    public AbilitiesDatas()
    {
        StrengthData = new AbilityData();
        DexterityData = new AbilityData();
        ConstitutionData = new AbilityData();
        PerceptionData = new AbilityData();
        CharismaData = new AbilityData();
    }

    public AbilitiesDatas(int strength, int dexterity, int constitution, int perception, int charisma, int abilityPoints)
    {
        StrengthData = new AbilityData();
        DexterityData = new AbilityData();
        ConstitutionData = new AbilityData();
        PerceptionData = new AbilityData();
        CharismaData = new AbilityData();

        StrengthData.Value = strength;
        DexterityData.Value = dexterity;
        ConstitutionData.Value = constitution;
        PerceptionData.Value = perception;
        CharismaData.Value = charisma;
        
        AbilityPoints = abilityPoints;
    }

    internal AbilitiesDatas Copy()
    {
        return new AbilitiesDatas()
        {
            AbilityPoints = this.AbilityPoints,
            StrengthData = StrengthData.Copy(),
            DexterityData = DexterityData.Copy(),
            ConstitutionData = ConstitutionData.Copy(),
            PerceptionData = PerceptionData.Copy(),
            CharismaData = CharismaData.Copy()
        };
    }

    public static AbilitiesDatas operator +(AbilitiesDatas a, AbilitiesDatas b)
    {
        int newStrength = a.StrengthData.Value + b.StrengthData.Value;
        int newDexterity = a.DexterityData.Value + b.DexterityData.Value;
        int newConstitution = a.ConstitutionData.Value + b.ConstitutionData.Value;
        int newPerception = a.PerceptionData.Value + b.PerceptionData.Value;
        int newCharisma = a.CharismaData.Value + b.CharismaData.Value;
        int newAbilityPoints = a.AbilityPoints + b.AbilityPoints;

        return new AbilitiesDatas(newStrength, newDexterity, newConstitution, newPerception, newCharisma, newAbilityPoints);
    }
}
