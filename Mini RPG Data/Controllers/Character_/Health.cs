using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Health
{
    private readonly HealthData _data;
    private readonly Character _character;

    internal Health(HealthData data, Character character)
    {
        _character = character;
        _data = data;
    }

    internal void Init()
    {
        _data.CurrentHealth = MaxHealth;
    }

    public int CurrentHealth => _data.CurrentHealth;
    public int MaxHealth => _character.AllAbilities.Constitution.Value + _character.AllAbilities.Constitution.Bonus * Settings.CalculateLevelModifier(_character.Level.Value);
    public event Action? Changed;

    internal void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        if (_data.CurrentHealth < 0)
            _data.CurrentHealth = 0;

        Changed?.Invoke();
    }
}
