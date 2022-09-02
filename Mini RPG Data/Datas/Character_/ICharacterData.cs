namespace Mini_RPG_Data.Character_
{
    public interface ICharacterData
    {
        string Name { get; }
        byte[] Avatar { get; }
        CharacterRace Race { get; }
        IAbilities Abilities { get; }
        Level Level { get; }
        Health Health { get; }

        event Action<CharacterData>? Changed;
        event Action<CharacterData>? LevelChanged;
        event Action<CharacterData>? HealthChanged;
    }
}