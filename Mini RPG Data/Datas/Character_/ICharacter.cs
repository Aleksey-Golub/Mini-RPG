using Mini_RPG_Data.Datas.Character_.Abilities_;

namespace Mini_RPG_Data.Character_
{
    public interface ICharacter
    {
        string Name { get; }
        string AvatarPath { get; }
        CharacterRace Race { get; }
        IAbilities AllAbilities { get; }
        Level Level { get; }
        Health Health { get; }

        event Action<Character>? Changed;
        event Action<Character>? LevelChanged;
        event Action<Character>? HealthChanged;
    }
}