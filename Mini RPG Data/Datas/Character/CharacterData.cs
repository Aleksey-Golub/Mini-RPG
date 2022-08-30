namespace Mini_RPG_Data.Character;

public class CharacterData
{
    private CharacterRace _race;
    private string _name;
    private byte[] _avatar;

    internal CharacterData()
    {
        Name = "default name";
        Avatar = new byte[0];
        Race = CharacterRace.Human;
        Abilities = Abilities.GetFor(Race);
        Abilities.Changed += OnAbilitiesChanged;

        Level = new Level();
        Level.Changed += () => LevelChanged?.Invoke();
        Health = new Health(this);
        Health.Changed += (x,y) => HealthChanged?.Invoke();
    }

    private void OnAbilitiesChanged() => Changed?.Invoke();

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            Changed?.Invoke();
        }
    }
    public byte[] Avatar
    {
        get => _avatar;
        set
        {
            _avatar = value;
            Changed?.Invoke();
        }
    }
    public CharacterRace Race
    {
        get => _race;
        set
        {
            _race = value;
            Abilities.Changed -= OnAbilitiesChanged;
            Abilities = Abilities.GetFor(Race);
            Abilities.Changed += OnAbilitiesChanged;
            Changed?.Invoke();
        }
    }
    public Abilities Abilities { get; private set; }

    //public IAbilities Abilities => _abilities;

    public Level Level { get; }
    public Health Health { get; }

    public event Action? Changed;
    public event Action? LevelChanged;
    public event Action? HealthChanged;
}

