using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Satiation
{
    public readonly SatiationData _data;
    private readonly Character _character;

    internal Satiation(SatiationData data, Character character)
    {
        _data = data;
        _character = character;

        SetHungerLevel();
        SetThirstLevel();
    }

    public HungerLevel HungerLevel { get; private set; }
    public ThirstLevel ThirstLevel { get; private set; }
    public int FoodSatiationValue => _data.FoodSatiation;
    public int WaterSatiationValue => _data.WaterSatiation;

    public event Action? Changed;

    internal void Starve()
    {
        _data.FoodSatiation -= Settings.CalculateStarve(_character, _data);
        SetHungerLevel();
    }

    internal void Thirst()
    {
        _data.WaterSatiation -= Settings.CalculateThirst(_character, _data);
        SetThirstLevel();
    }

    internal void RestoreFood(int value)
    {
        _data.FoodSatiation += value;
        SetHungerLevel();
    }

    internal void RestoreWater(int value)
    {
        _data.WaterSatiation += value;
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
