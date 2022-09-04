﻿namespace Mini_RPG_Data.Character_;

public class Level
{
    private readonly LevelData _data;

    internal Level(LevelData data)
    {
        _data = data;
    }

    internal void Init()
    {
        Value = 1;
    }

    public int Value 
    { 
        get => _data.Value;
        private set
        {
            _data.Value = value;
            Changed?.Invoke();
        }
    }

    public int CurrentExperience => _data.CurrentExperience;
    public int RequiredForNextLevelExperience => Settings.CalculateRequiredForNextLevelExperience(Value);

    public event Action? Changed;

    internal void TakeExperience(int value)
    {
        _data.CurrentExperience += value;
        if (CurrentExperience > RequiredForNextLevelExperience)
            Value++;
    }
}

