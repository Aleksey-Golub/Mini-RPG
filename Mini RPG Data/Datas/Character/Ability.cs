namespace Mini_RPG_Data.Character;

public class Ability : IAbility
{
    public Ability(int value = Settings.DEFAULT_ABILITY_VALUE)
    {
        Value = value;
    }

    public int Value { get; set; }
    public int Bonus => Value - Settings.DEFAULT_ABILITY_VALUE;

    public event Action? ValueChanged;
}
