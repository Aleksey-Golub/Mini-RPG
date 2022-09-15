using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;

namespace Mini_RPG_Data.Controllers.Screens;

public class CharacterProgressController
{
    private readonly Character _character;
    private readonly Dictionary<AbilityType, int> _abilitiesStartValues;

    public CharacterProgressController(Character character)
    {
        _character = character;

        _abilitiesStartValues = new Dictionary<AbilityType, int>()
        {
            [AbilityType.Strength] = character.AllAbilities.Strength.Value,
            [AbilityType.Dexterity] = character.AllAbilities.Dexterity.Value,
            [AbilityType.Constitution] = character.AllAbilities.Constitution.Value,
            [AbilityType.Perception] = character.AllAbilities.Perception.Value,
            [AbilityType.Charisma] = character.AllAbilities.Charisma.Value,
        };
    }

    public void DecreaseAbility(AbilityType abilityType)
    {
        if (_character.AllAbilities.AllAbilities[abilityType].Value > _abilitiesStartValues[abilityType])
            _character.AllAbilities.Decrease(abilityType);
    }

    public void IncreaseAbility(AbilityType abilityType)
    {
        _character.AllAbilities.Increase(abilityType);
    }
}
