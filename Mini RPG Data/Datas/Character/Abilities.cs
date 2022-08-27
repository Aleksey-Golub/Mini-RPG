namespace Mini_RPG_Data.Character;

public class Abilities : IAbilities
{
    public Abilities(int strength, int dexterity, int constitution, int perception, int charisma)
    {
        Strength = new Ability(strength);
        Dexterity = new Ability(dexterity);
        Constitution = new Ability(constitution);
        Perception = new Ability(perception);
        Charisma = new Ability(charisma);

        AbilityPoints = 0;
    }

    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Perception { get; set; }
    public Ability Charisma { get; set; }
    public int AbilityPoints { get; set; }

    IAbility IAbilities.Strength => Strength;
    IAbility IAbilities.Dexterity => Dexterity;
    IAbility IAbilities.Constitution => Constitution;
    IAbility IAbilities.Perception => Perception;
    IAbility IAbilities.Charisma => Charisma;

    public Abilities Get(Abilities baseAbilities, Race race)
    {
        //int defaultAbilityValue = Settings.DEFAULT_ABILITY_VALUE;
        //var defaultAbilities = new Abilities(strength: defaultAbilityValue, dexterity: defaultAbilityValue, constitution: defaultAbilityValue, perception: defaultAbilityValue, charisma: defaultAbilityValue);

        var humanAbilities = new Abilities(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 0);
        var elfAbilities = new Abilities(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 0);
        var dwarfAbilities = new Abilities(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 0);

        return race switch
        {
            Race.None => baseAbilities,
            Race.Human => baseAbilities + humanAbilities,
            Race.Elf => baseAbilities + elfAbilities,
            Race.Dwarf => baseAbilities + dwarfAbilities,
            _ => throw new NotImplementedException(),
        };
    }

    public static Abilities operator +(Abilities a, Abilities b)
    {
        int newStrength = a.Strength.Value + b.Strength.Value;
        int newDexterity = a.Dexterity.Value + b.Dexterity.Value;
        int newConstitution = a.Constitution.Value + b.Constitution.Value;
        int newPerception = a.Perception.Value + b.Perception.Value;
        int newCharisma = a.Charisma.Value + b.Charisma.Value;

        return new Abilities(newStrength, newDexterity, newConstitution, newPerception, newCharisma);
    }
}
