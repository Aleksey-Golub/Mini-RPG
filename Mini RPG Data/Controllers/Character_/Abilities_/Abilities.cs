using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Datas.Character_.Abilities_;

namespace Mini_RPG_Data.Controllers.Character_.Abilities_;

public class Abilities : IAbilities
{
    public Dictionary<AbilityType, Ability> AllAbilities { get; private set; }
    private AbilitiesDatas _data;

    internal Abilities(AbilitiesDatas data)
    {
        _data = data;

        AllAbilities = new Dictionary<AbilityType, Ability>();

        AllAbilities[AbilityType.Strength] = new Ability(_data.StrengthData);
        AllAbilities[AbilityType.Dexterity] = new Ability(_data.DexterityData);
        AllAbilities[AbilityType.Constitution] = new Ability(_data.ConstitutionData);
        AllAbilities[AbilityType.Perception] = new Ability(_data.PerceptionData);
        AllAbilities[AbilityType.Charisma] = new Ability(_data.CharismaData);

        Strength.ValueChanged += SomeAbilityValueChanged;
        Dexterity.ValueChanged += SomeAbilityValueChanged;
        Constitution.ValueChanged += SomeAbilityValueChanged;
        Perception.ValueChanged += SomeAbilityValueChanged;
        Charisma.ValueChanged += SomeAbilityValueChanged;
    }

    internal void Init(AbilitiesDatas data)
    {
        _data = data;

        Strength.Init(_data.StrengthData);
        Dexterity.Init(_data.DexterityData);
        Constitution.Init(_data.ConstitutionData);
        Perception.Init(_data.PerceptionData);
        Charisma.Init(_data.CharismaData);

        SomeAbilityValueChanged();
    }

    IAbility IAbilities.Strength => Strength;
    IAbility IAbilities.Dexterity => Dexterity;
    IAbility IAbilities.Constitution => Constitution;
    IAbility IAbilities.Perception => Perception;
    IAbility IAbilities.Charisma => Charisma;

    public int AbilityPoints
    {
        get => _data.AbilityPoints;
        private set
        {
            _data.AbilityPoints = value;
            Changed?.Invoke();
        }
    }

    public event Action? Changed;

    public Ability Strength => AllAbilities[AbilityType.Strength];
    public Ability Dexterity => AllAbilities[AbilityType.Dexterity];
    public Ability Constitution => AllAbilities[AbilityType.Constitution];
    public Ability Perception => AllAbilities[AbilityType.Perception];
    public Ability Charisma => AllAbilities[AbilityType.Charisma];

    internal static AbilitiesDatas GetFor(CharacterRace race)
    {
        int defaultAbilityValue = Settings.DEFAULT_ABILITY_VALUE;
        int defaultAbilityPoints = Settings.DEFAULT_ABILITYPOINTS_COUNT;
        var baseAbilitiesDatas = new AbilitiesDatas(
            strength: defaultAbilityValue,
            dexterity: defaultAbilityValue,
            constitution: defaultAbilityValue,
            perception: defaultAbilityValue,
            charisma: defaultAbilityValue,
            abilityPoints: defaultAbilityPoints);

        var humanAbilitiesDatas = new AbilitiesDatas(strength: 0, dexterity: 0, constitution: 0, perception: 0, charisma: 2, abilityPoints: 0);
        var elfAbilitiesDatas = new AbilitiesDatas(strength: 0, dexterity: 1, constitution: 0, perception: 1, charisma: 0, abilityPoints: 0);
        var dwarfAbilitiesDatas = new AbilitiesDatas(strength: 0, dexterity: 0, constitution: 2, perception: 0, charisma: 0, abilityPoints: 0);

        return race switch
        {
            CharacterRace.Human => baseAbilitiesDatas + humanAbilitiesDatas,
            CharacterRace.Elf => baseAbilitiesDatas + elfAbilitiesDatas,
            CharacterRace.Dwarf => baseAbilitiesDatas + dwarfAbilitiesDatas,
            CharacterRace.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    internal void Decrease(AbilityType type)
    {
        if (AllAbilities.ContainsKey(type))
        {
            Ability ability = AllAbilities[type];
            if (ability.Value > Settings.MIN_ABILITY_VALUE)
            {
                AbilityPoints++;
                ability.Value--;
            }
        }
    }

    internal void Increase(AbilityType type)
    {
        if (AllAbilities.ContainsKey(type))
        {
            Ability ability = AllAbilities[type];
            if (AbilityPoints > 0 && ability.Value < Settings.MAX_ABILITY_VALUE)
            {
                ability.Value++;
                AbilityPoints--;
            }
        }
    }

    private void SomeAbilityValueChanged() => Changed?.Invoke();
}
