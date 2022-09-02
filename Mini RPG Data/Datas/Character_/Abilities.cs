namespace Mini_RPG_Data.Character_;

public class Abilities : IAbilities
{
    private readonly Dictionary<AbilityType, Ability> _abilities;
    private int _abilityPoints;

    private Abilities(int strength, int dexterity, int constitution, int perception, int charisma, int abilityPoints)
    {
        _abilities = new Dictionary<AbilityType, Ability>();

        _abilities[AbilityType.Strength] = new Ability(strength);
        _abilities[AbilityType.Dexterity] = new Ability(dexterity);
        _abilities[AbilityType.Constitution] = new Ability(constitution);
        _abilities[AbilityType.Perception] = new Ability(perception);
        _abilities[AbilityType.Charisma] = new Ability(charisma);

        AbilityPoints = abilityPoints;

        Strength.ValueChanged += SomeAbilityValueChanged;
        Dexterity.ValueChanged += SomeAbilityValueChanged;
        Constitution.ValueChanged += SomeAbilityValueChanged;
        Perception.ValueChanged += SomeAbilityValueChanged;
        Charisma.ValueChanged += SomeAbilityValueChanged;
    }

    public event Action? Changed;

    private void SomeAbilityValueChanged() => Changed?.Invoke();

    public Ability Strength => _abilities[AbilityType.Strength];
    public Ability Dexterity => _abilities[AbilityType.Dexterity];
    public Ability Constitution => _abilities[AbilityType.Constitution];
    public Ability Perception => _abilities[AbilityType.Perception];
    public Ability Charisma => _abilities[AbilityType.Charisma];
    public int AbilityPoints 
    { 
        get => _abilityPoints;
        private set
        {
            _abilityPoints = value;
            Changed?.Invoke();
        }
    }

    IAbility IAbilities.Strength => Strength;
    IAbility IAbilities.Dexterity => Dexterity;
    IAbility IAbilities.Constitution => Constitution;
    IAbility IAbilities.Perception => Perception;
    IAbility IAbilities.Charisma => Charisma;

    internal static Abilities GetFor(CharacterRace race)
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

        var humanAbilities = new Abilities(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 2, abilityPoints: 0);
        var elfAbilities = new Abilities(strength: 0, dexterity: 1, constitution: 0, perception: 1, charisma: 0, abilityPoints: 0);
        var dwarfAbilities = new Abilities(strength: 0, dexterity: 0, constitution: 2, perception: 0, charisma: 0, abilityPoints: 0);

        return race switch
        {
            CharacterRace.Human => baseAbilities + humanAbilities,
            CharacterRace.Elf => baseAbilities + elfAbilities,
            CharacterRace.Dwarf => baseAbilities + dwarfAbilities,
            CharacterRace.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    internal void Decrease(AbilityType type)
    {
        if (_abilities.ContainsKey(type))
        {
            Ability ability = _abilities[type];
            if (ability.Value > Settings.MIN_ABILITY_VALUE)
            {
                AbilityPoints++;
                ability.Value--;
            }
        }
    }

    internal void Increase(AbilityType type)
    {
        if (_abilities.ContainsKey(type))
        {
            Ability ability = _abilities[type];
            if (AbilityPoints > 0)
            {
                ability.Value++;
                AbilityPoints--;
            }
        }
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
