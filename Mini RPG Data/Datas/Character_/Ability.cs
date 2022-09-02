namespace Mini_RPG_Data.Character_;

public class Ability : IAbility
{
    private int _value;

    public Ability(int value = Settings.DEFAULT_ABILITY_VALUE)
    {
        Value = value;
    }

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChanged?.Invoke();
        }
    }

    public int Bonus => Value - Settings.DEFAULT_ABILITY_VALUE;

    public event Action? ValueChanged;
}
