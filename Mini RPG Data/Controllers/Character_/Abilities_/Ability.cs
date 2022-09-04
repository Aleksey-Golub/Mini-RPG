using Mini_RPG_Data.Datas.Character_.Abilities_;

namespace Mini_RPG_Data.Controllers.Character_.Abilities_;

public class Ability : IAbility
{
    private AbilityData _data;

    internal Ability(AbilityData data)
    {
        _data = data;
    }

    internal void Init(AbilityData data)
    {
        _data = data;
    }

    public int Value
    {
        get => _data.Value;
        set
        {
            _data.Value = value;
            ValueChanged?.Invoke();
        }
    }

    public int Bonus => Value - Settings.DEFAULT_ABILITY_VALUE;

    public event Action? ValueChanged;
}
