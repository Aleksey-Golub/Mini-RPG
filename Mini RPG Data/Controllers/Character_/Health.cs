using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers.Character_;

public class Health
{
    private readonly HealthData _data;
    private readonly Character _character;

    internal Health(HealthData data, Character character)
    {
        _character = character;
        _character.AllAbilities.Constitution.ValueChanged += () => Changed?.Invoke();
        _data = data;
    }

    public int CurrentHealth => _data.CurrentHealth;
    public int MaxHealth => Settings.CalculateMaxHealth(_character);
    public event Action? Changed;

    internal void Init()
    {
        _data.CurrentHealth = MaxHealth;
    }

    internal void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        if (_data.CurrentHealth < 0)
            _data.CurrentHealth = 0;

        Changed?.Invoke();
    }

    internal void Restore(int value = Settings.HEALTH_RESTORE_VALUE)
    {
        _data.CurrentHealth += value;
        if (_data.CurrentHealth > MaxHealth)
            _data.CurrentHealth = MaxHealth;

        Changed?.Invoke();
    }

    internal void RestoreFullHealth()
    {
        _data.CurrentHealth = MaxHealth;
        Changed?.Invoke();
    }
}
