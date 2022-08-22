﻿namespace Mini_RPG_Data;

public class Health
{
    private readonly IAbility _constitution;
    private readonly Character _character;

    public Health(Character character)
    {
        _constitution = character.Abilities.Constitution;
        _character = character;
    }

    public int CurrentHealth { get; }
    public int MaxHealth => _constitution.Value + _constitution.Bonus * Settings.CalculateLevelModifier(_character.Level.Value);
    public event Action<int, int>? HealthChanged;
}
