using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Datas.Inventory_.Items
{
    [Serializable]
    public class Effect
    {
        public EffectType EffectType { get; set; }
        public int Value { get; set; }

        internal void ComeTo(Character target)
        {
            switch (EffectType)
            {
                case EffectType.RestoreHealth:
                    target.RestoreHealth(Value);
                    break;
                case EffectType.RestoreFoodSatiation:
                    target.RestoreFood(Value);
                    break;
                case EffectType.RestoreWaterSatiation:
                    target.RestoreWater(Value);
                    break;
                case EffectType.None:
                default:
                    break;
            }
        }
    }
}
