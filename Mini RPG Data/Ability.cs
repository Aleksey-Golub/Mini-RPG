namespace Mini_RPG_Data;

public class Ability : IAbility
{
    public Ability(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }
    public int Bonus => Value - Settings.DEFAULT_ABILITY_VALUE;

    public event Action? ValueChanged;

    public void SetNewValue(int value) => Value = value;
}
