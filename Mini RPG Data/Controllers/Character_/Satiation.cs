using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Satiation
{
    public readonly SatiationData _data;
    private readonly ICharacter _character;

    internal Satiation(SatiationData data, ICharacter character)
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

    internal void Starve() => ChangeFoodSatiation(-GameRules.CalculateStarve(_character, _data));

    internal void Thirst() => ChangeWaterSatiation(-GameRules.CalculateThirst(_character, _data));

    internal void ChangeFoodSatiation(int value)
    {

        _data.FoodSatiation += value;
        _data.FoodSatiation = Math.Clamp(_data.FoodSatiation, 0, int.MaxValue);
        SetHungerLevel();
    }

    internal void ChangeWaterSatiation(int value)
    {
        _data.WaterSatiation += value;
        _data.WaterSatiation = Math.Clamp(_data.WaterSatiation, 0, int.MaxValue);
        SetThirstLevel();
    }

    private void SetHungerLevel()
    {
        var oldLevel = HungerLevel;
        HungerLevel = GameRules.CalculateHungerLevel(_character, _data);

        if (HungerLevel != oldLevel)
            Changed?.Invoke();
    }

    private void SetThirstLevel()
    {
        var oldLevel = ThirstLevel;
        ThirstLevel = GameRules.CalculateThirstLevel(_character, _data);

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
