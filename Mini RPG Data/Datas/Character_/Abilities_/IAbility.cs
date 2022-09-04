namespace Mini_RPG_Data.Datas.Character_.Abilities_;

public interface IAbility
{
    int Value { get; }
    int Bonus { get; }
    event Action? ValueChanged;
}