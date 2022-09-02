namespace Mini_RPG_Data.Character_;

public class Health
{
    private readonly IAbility _constitution;
    private readonly CharacterData _character;

    internal Health(CharacterData character)
    {
        _constitution = character.Abilities.Constitution;
        _character = character;
    }

    public int CurrentHealth { get; }
    public int MaxHealth => _constitution.Value + _constitution.Bonus * Settings.CalculateLevelModifier(_character.Level.Value);
    public event Action<int, int>? Changed;
}
