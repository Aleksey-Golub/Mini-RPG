﻿using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.EventBus;
using Mini_RPG_Data.Services.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Character_;

public class Character : ICharacter
{
    private readonly ILocalizationService _localizationService;
    private readonly CharacterData _data;

    internal Character(CharacterData data)
    {
        AllServices services = AllServices.Container;
        _localizationService = services.Single<ILocalizationService>();

        _data = data;

        AllAbilities = new Abilities(data.AbilitiesDatas);
        AllAbilities.Changed += OnAbilitiesChanged;

        Level = new Level(data.LevelData);
        Level.Changed += OnLevelChanged;
        Health = new Health(data.HealthData, this);
        Health.Changed += OnHealthChanged;
        Satiation = new Satiation(data.SatiationData, this);
        Inventory = new Inventory(AllServices.Container.Single<IItemFactory>(), data.InventoryData);
    }

    internal void Init()
    {
        Race = Race.Human;
        Name = _localizationService.GetLocalization("DefaultCharacterName");
        AvatarPath = GameRules.DefaultAvatarPath;

        Level.Init();
        Health.Init();
    }

    public string Id => _data.Id;
    public string Name
    {
        get => _localizationService.GetLocalization(_data.Name);
        private set
        {
            _data.Name = value;
            Changed?.Invoke(this);
        }
    }

    public string AvatarPath
    {
        get => _data.AvatarPath;
        set
        {
            _data.AvatarPath = value;
            Changed?.Invoke(this);
        }
    }
    public Race Race
    {
        get => _data.Race;
        set
        {
            _data.Race = value;
            AllAbilities.Changed -= OnAbilitiesChanged;
            _data.AbilitiesDatas = Abilities.GetFor(_data.Race);
            AllAbilities.Init(_data.AbilitiesDatas);
            AllAbilities.Changed += OnAbilitiesChanged;
            Health.Init();
            Changed?.Invoke(this);
        }
    }

    IAbilities ICharacter.AllAbilities => AllAbilities;
    public Abilities AllAbilities { get; private set; }
    public Level Level { get; }
    public Health Health { get; }
    public int MaxHealth => GameRules.CalculateMaxHealth(this);
    public bool IsAlive => Health.CurrentHealth > 0;
    public Satiation Satiation { get; }
    public Inventory Inventory { get; }
    public int FieldOfView => GameRules.CalculateFieldOfView(this);
    public int Experience => GameRules.CalculateExperience(this);
    public int MinDamage
    {
        get
        {
            var weapon = Inventory.EquipmentSlots[EquipmentSlot.MainHand] as WeaponItem;
            if (weapon != null)
                return weapon.MinDamage;
            else
                return GameRules.MinHandToHandDamage(this);
        }
    }

    public int MaxDamage
    {
        get
        {
            var weapon = Inventory.EquipmentSlots[EquipmentSlot.MainHand] as WeaponItem;
            if (weapon != null)
                return weapon.MaxDamage;
            else
                return GameRules.MaxHandToHandDamage(this);
        }
    }

    public DamageType DamageType
    {
        get
        {
            var weapon = Inventory.EquipmentSlots[EquipmentSlot.MainHand] as WeaponItem;
            if (weapon != null)
                return weapon.DamageType;
            else
                return GameRules.HandToHandDamageType(this);
        }
    }

    public int AttackModifier => GameRules.CalculateAttackModifier(this);
    public int DefenseModifier => GameRules.CalculateDefenseModifier(this);
    public int InitiativeModifier => AllAbilities.Perception.Bonus;

    public event Action<ICharacter>? Changed;
    public event Action<ICharacter>? LevelChanged;
    public event Action<ICharacter>? HealthChanged;
    public event Action<ICharacter>? Died;

    public void TakeDamage(int damage) => Health.TakeDamage(damage);
    public bool IsAttackCritical(BodyPart bodyPart) => bodyPart == BodyPart.Head;

    public Armor GetArmor(BodyPart bodyPart)
    {
        EquipmentSlot slot = bodyPart switch
        {
            BodyPart.Head => EquipmentSlot.Head,
            BodyPart.RightHand => EquipmentSlot.Hands,
            BodyPart.LeftHand => EquipmentSlot.Hands,
            BodyPart.Body => EquipmentSlot.Body,
            BodyPart.RightLeg => EquipmentSlot.Legs,
            BodyPart.LeftLeg => EquipmentSlot.Legs,
            BodyPart.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };

        ArmorItem armor = Inventory.EquipmentSlots[slot] as ArmorItem;

        if (armor != null)
            return new Armor(armor.ArmorValue, armor.ArmorType);
        else
            return GameRules.ArmorForNoArmorSlot(this);
    }

    internal bool TryUse(ItemBase item) => item.TryUse(this);
    internal void Equip(WeaponItem weaponItem) => Inventory.Equip(weaponItem);
    internal void Equip(ShieldItem shieldItem) => Inventory.Equip(shieldItem);
    internal void Equip(ArmorItem armorItem) => Inventory.Equip(armorItem);
    internal void Eat(FoodItem foodItem) => Inventory.RemoveItem(foodItem);
    internal void Drink(PotionItem potionItem) => Inventory.RemoveItem(potionItem);

    internal void Unequip(EquipmentSlot slot)
    {
        switch (slot)
        {
            case EquipmentSlot.Head:
                Inventory.TryUnequipHead();
                break;
            case EquipmentSlot.Hands:
                Inventory.TryUnequipHands();
                break;
            case EquipmentSlot.Body:
                Inventory.TryUnequipBody();
                break;
            case EquipmentSlot.Legs:
                Inventory.TryUnequipLegs();
                break;
            case EquipmentSlot.MainHand:
                Inventory.TryUnequipMainHand();
                break;
            case EquipmentSlot.OffHand:
                Inventory.TryUnequipOffHand();
                break;
            case EquipmentSlot.None:
            default:
                throw new NotImplementedException();
        }
    }

    internal void RestoreHealth(int value) => Health.Restore(value);
    internal void RestoreFullHealth() => Health.RestoreFullHealth();
    internal void ChangeFoodSatiation(int value) => Satiation.ChangeFoodSatiation(value);
    internal void ChangeWaterSatiation(int value) => Satiation.ChangeWaterSatiation(value);

    internal bool TryRestoreHealth()
    {
        bool res = GameRules.CheckHealthRecoveryAfterRest(this);
        if (res)
        {
            Health.Restore();
            return true;
        }
        return false;
    }

    internal void UpdateEffects()
    {
        Satiation.Starve();
        Satiation.Thirst();
    }

    private void OnAbilitiesChanged() => Changed?.Invoke(this);
    private void OnHealthChanged()
    {
        HealthChanged?.Invoke(this);

        if (Health.CurrentHealth <= 0)
            Died?.Invoke(this);
    }

    private void OnLevelChanged()
    {
        AllAbilities.AddAbilityPoints(GameRules.LEVEL_UP_ABILITY_POINTS);
        LevelChanged?.Invoke(this);
    }
}
