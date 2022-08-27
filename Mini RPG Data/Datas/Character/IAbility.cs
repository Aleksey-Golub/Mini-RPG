namespace Mini_RPG_Data.Character;

public interface IAbility
{
    int Bonus { get; }
    int Value { get; }
    event Action? ValueChanged;
}