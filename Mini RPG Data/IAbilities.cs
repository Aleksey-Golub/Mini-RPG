namespace Mini_RPG_Data;

public interface IAbilities
{
    IAbility Strength { get; }
    IAbility Dexterity { get; }
    IAbility Constitution { get; }
    IAbility Perception { get; }
    IAbility Charisma { get; }

    Abilities Get(Abilities baseAbilities, Race race);
}
