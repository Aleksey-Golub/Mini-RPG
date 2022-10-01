using Mini_RPG_Data.Controllers.Character_;

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
                case EffectType.ChangeHealth:
                    if (Value > 0)
                        target.RestoreHealth(Value);
                    else
                        target.TakeDamage(-Value);
                    break;
                case EffectType.ChangeFoodSatiation:
                    target.ChangeFoodSatiation(Value);
                    break;
                case EffectType.ChangeWaterSatiation:
                    target.ChangeWaterSatiation(Value);
                    break;
                case EffectType.None:
                default:
                    break;
            }
        }
    }

    public enum EffectType
    {
        None,
        ChangeHealth,
        ChangeFoodSatiation,
        ChangeWaterSatiation,
    }
}
