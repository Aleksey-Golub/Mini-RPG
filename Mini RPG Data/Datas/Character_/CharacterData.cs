namespace Mini_RPG_Data.Character_;

public class CharacterData : ICharacterData
{
    private CharacterRace _race;
    private string _name;
    private byte[] _avatar;

    internal CharacterData()
    {
        var defaultRace = CharacterRace.Human;

        Name = "default name";
        Avatar = new byte[0];
        Abilities = Character_.Abilities.GetFor(defaultRace);
        Race = defaultRace;
        Abilities.Changed += OnAbilitiesChanged;

        Level = new Level();
        Level.Changed += () => LevelChanged?.Invoke(this);
        Health = new Health(this);
        Health.Changed += (x, y) => HealthChanged?.Invoke(this);
    }

    private void OnAbilitiesChanged() => Changed?.Invoke(this);

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Changed?.Invoke(this);
        }
    }
    public byte[] Avatar
    {
        get => _avatar;
        set
        {
            _avatar = value;
            Changed?.Invoke(this);
        }
    }
    public CharacterRace Race
    {
        get => _race;
        set
        {
            _race = value;
            Abilities.Changed -= OnAbilitiesChanged;
            Abilities = Character_.Abilities.GetFor(Race);
            Abilities.Changed += OnAbilitiesChanged;
            Changed?.Invoke(this);
        }
    }

    IAbilities ICharacterData.Abilities => Abilities;

    public Abilities Abilities {get; private set;}
    public Level Level { get; }
    public Health Health { get; }

    public event Action<CharacterData>? Changed;
    public event Action<CharacterData>? LevelChanged;
    public event Action<CharacterData>? HealthChanged;
}

