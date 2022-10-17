using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Controllers.Character_;

public interface ICharacter
{
    int Id { get; }
    string Name { get; }
    string AvatarPath { get; }
    Race Race { get; }
    IAbilities AllAbilities { get; }
    Level Level { get; }
    Health Health { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    Satiation Satiation { get; }
    Inventory Inventory { get; }
    int Experience { get; }
    int AttackModifier { get; }
    int DefenseModifier { get; }
    int MinDamage { get; }
    int MaxDamage { get; }
    DamageType DamageType { get; }
    int FieldOfView { get; }
    int InitiativeModifier { get; }

    event Action<ICharacter>? Changed;
    event Action<ICharacter>? LevelChanged;
    event Action<ICharacter>? HealthChanged;
    event Action<ICharacter>? Died;

    internal void TakeDamage(int damage);
    internal Armor GetArmor(BodyPart bodyPart);
    internal bool IsAttackCritical(BodyPart bodyPart);
}