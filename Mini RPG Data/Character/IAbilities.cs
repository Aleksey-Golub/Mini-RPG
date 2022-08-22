namespace Mini_RPG_Data.Character;

public interface IAbilities
{
    IAbility Strength { get; }
    IAbility Dexterity { get; }
    IAbility Constitution { get; }
    IAbility Perception { get; }
    IAbility Charisma { get; }
    int AbilityPoints { get; }

    Abilities Get(Abilities baseAbilities, Race race);
}
