using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Character : ICharacter
{
    private readonly CharacterData _data;

    internal Character(CharacterData data)
    {
        _data = data;

        AllAbilities = new Abilities(data.AbilitiesDatas);
        AllAbilities.Changed += OnAbilitiesChanged;

        Level = new Level(data.LevelData);
        Level.Changed += () => LevelChanged?.Invoke(this);
        Health = new Health(data.HealthData, this);
        Health.Changed += () => HealthChanged?.Invoke(this);
        Satiation = new Satiation(data.SatiationData, this);
    }

    internal void Init()
    {
        Race = CharacterRace.Human;
        Name = "default name";
        AvatarPath = Settings.DefaultAvatarPath;

        Level.Init();
        Health.Init();
    }

    public string Name
    {
        get => _data.Name;
        set
        {
            _data.Name = value;
            Changed?.Invoke(this);
        }
    }

    public string AvatarPath
    {
        get => _data.AvatarPath;
        set
        {
            _data.AvatarPath = value;
            Changed?.Invoke(this);
        }
    }
    public CharacterRace Race
    {
        get => _data.Race;
        set
        {
            _data.Race = value;
            AllAbilities.Changed -= OnAbilitiesChanged;
            _data.AbilitiesDatas = Abilities.GetFor(_data.Race);
            AllAbilities.Init(_data.AbilitiesDatas);
            AllAbilities.Changed += OnAbilitiesChanged;
            Health.Init();
            Changed?.Invoke(this);
        }
    }

    IAbilities ICharacter.AllAbilities => AllAbilities;
    public Abilities AllAbilities { get; private set; }
    public Level Level { get; }
    public Health Health { get; }
    public Satiation Satiation { get; }

    public event Action<Character>? Changed;
    public event Action<Character>? LevelChanged;
    public event Action<Character>? HealthChanged;

    internal void Rest(IRandomService randomService)
    {
        Satiation.Starve();
        Satiation.Thirst();

        if (Settings.CheckHealthRecoveryAfterRest(randomService, this))
            Health.Restore();
    }

    private void OnAbilitiesChanged() => Changed?.Invoke(this);
}
