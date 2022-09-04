namespace Mini_RPG_Data.Controllers.Character_.Abilities_;

public interface IAbilities
{
    IAbility Strength { get; }
    IAbility Dexterity { get; }
    IAbility Constitution { get; }
    IAbility Perception { get; }
    IAbility Charisma { get; }
    int AbilityPoints { get; }

    event Action? Changed;
}
