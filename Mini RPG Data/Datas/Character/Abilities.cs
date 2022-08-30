namespace Mini_RPG_Data.Character;

public class Abilities : IAbilities
{
    private Abilities(int strength, int dexterity, int constitution, int perception, int charisma, int abilityPoints)
    {
        Strength = new Ability(strength);
        Dexterity = new Ability(dexterity);
        Constitution = new Ability(constitution);
        Perception = new Ability(perception);
        Charisma = new Ability(charisma);

        AbilityPoints = abilityPoints;

        Strength.ValueChanged += SomeAbilityValueChanged;
        Dexterity.ValueChanged += SomeAbilityValueChanged;
        Constitution.ValueChanged += SomeAbilityValueChanged;
        Perception.ValueChanged += SomeAbilityValueChanged;
        Charisma.ValueChanged += SomeAbilityValueChanged;
    }

    public event Action? Changed;

    private void SomeAbilityValueChanged() => Changed?.Invoke();

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

    public static Abilities GetFor(CharacterRace race)
    {
        int defaultAbilityValue = Settings.DEFAULT_ABILITY_VALUE;
        int defaultAbilityPoints = Settings.DEFAULT_ABILITYPOINTS_COUNT;
        var baseAbilities = new Abilities(
            strength: defaultAbilityValue, 
            dexterity: defaultAbilityValue, 
            constitution: defaultAbilityValue, 
            perception: defaultAbilityValue, 
            charisma: defaultAbilityValue, 
            abilityPoints: defaultAbilityPoints);

        var humanAbilities  = new Abilities(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 2, abilityPoints: 0);
        var elfAbilities    = new Abilities(strength: 0, dexterity: 1, constitution: 0, perception: 1, charisma: 0, abilityPoints: 0);
        var dwarfAbilities  = new Abilities(strength: 0, dexterity: 0, constitution: 2, perception: 0, charisma: 0, abilityPoints: 0);

        return race switch
        {
            CharacterRace.Human => baseAbilities + humanAbilities,
            CharacterRace.Elf => baseAbilities + elfAbilities,
            CharacterRace.Dwarf => baseAbilities + dwarfAbilities,
            CharacterRace.None => throw new NotImplementedException(),
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
        int newAbilityPoints = a.AbilityPoints + b.AbilityPoints;

        return new Abilities(newStrength, newDexterity, newConstitution, newPerception, newCharisma, newAbilityPoints);
    }
}
