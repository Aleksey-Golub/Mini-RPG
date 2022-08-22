namespace Mini_RPG_Data.Character;

public class Level
{
    public Level()
    {
        Value = 1;
        CurrentExperience = 0;
    }

    public int Value { get; private set; }
    public int CurrentExperience { get; private set; }
    public int RequiredForNextLevelExperience => Settings.CalculateRequiredForNextLevelExperience(Value);

    internal event Action? Changed;

    internal void TakeExperience(int value)
    {
        CurrentExperience += value;
        if (CurrentExperience > RequiredForNextLevelExperience)
            Value++;
    }
}
