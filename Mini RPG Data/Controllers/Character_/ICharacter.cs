using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Inventory_;

namespace Mini_RPG_Data.Controllers.Character_
{
    public interface ICharacter
    {
        string Name { get; }
        string AvatarPath { get; }
        CharacterRace Race { get; }
        IAbilities AllAbilities { get; }
        Level Level { get; }
        Health Health { get; }
        Satiation Satiation { get; }
        Inventory Inventory { get; }

        event Action<Character>? Changed;
        event Action<Character>? LevelChanged;
        event Action<Character>? HealthChanged;
        event Action<Character>? Died;
    }
}