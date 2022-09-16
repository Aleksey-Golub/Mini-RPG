using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Satiation
{
    public readonly SatiationData _data;
    private readonly Character _character;

    public Satiation(SatiationData data, Character character)
    {
        _data = data;
        _character = character;

        SetHungerLevel();
        SetThirstLevel();
    }

    public HungerLevel HungerLevel { get; private set; }
    public ThirstLevel ThirstLevel { get; private set; }

    public Action? Changed;

    internal void Starve()
    {
        Settings.Starve(_character, _data);
        SetHungerLevel();
    }

    internal void Thirst()
    {
        Settings.Thirst(_character, _data);
        SetThirstLevel();
    }

    private void SetHungerLevel()
    {
        var oldLevel = HungerLevel;
        HungerLevel = Settings.CalculateHungerLevel(_character, _data);

        if (HungerLevel != oldLevel)
            Changed?.Invoke();
    }

    private void SetThirstLevel()
    {
        var oldLevel = ThirstLevel;
        ThirstLevel = Settings.CalculateThirstLevel(_character, _data);

        if (ThirstLevel != oldLevel)
            Changed?.Invoke();
    }
}

public enum HungerLevel
{
    None,
    Hungry,
    Neutral,
    Satiated,
}

public enum ThirstLevel
{
    None,
    Thirsty,
    Neutral,
    Satiated,
}
