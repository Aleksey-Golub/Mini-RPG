namespace Mini_RPG_Data;

public interface IAbility
{
    int Bonus { get; }
    int Value { get; }
    event Action? ValueChanged;
}