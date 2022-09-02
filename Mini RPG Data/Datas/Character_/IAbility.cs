namespace Mini_RPG_Data.Character_;

public interface IAbility
{
    int Bonus { get; }
    int Value { get; }
    event Action? ValueChanged;
}