using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Items;

namespace Mini_RPG_Data.Controllers.Character_;

public class Character : ICharacter
{
    private readonly CharacterData _data;

    internal Character(CharacterData data)
    {
        _data = data;

        AllAbilities = new Abilities(data.AbilitiesDatas);
        AllAbilities.Changed += OnAbilitiesChanged;

        Level = new Level(data.LevelData);
        Level.Changed += () => LevelChanged?.Invoke(this);
        Health = new Health(data.HealthData, this);
        Health.Changed += OnHealthChanged;
        Satiation = new Satiation(data.SatiationData, this);
        Inventory = new Inventory(AllServices.Container.Single<IItemFactory>(), data.InventoryData);
    }

    internal void Init()
    {
        Race = CharacterRace.Human;
        Name = "default name";
        AvatarPath = Settings.DefaultAvatarPath;

        Level.Init();
        Health.Init();
    }

    public string Name
    {
        get => _data.Name;
        set
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
    public CharacterRace Race
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
    public Satiation Satiation { get; }
    public Inventory Inventory { get; }

    public int FieldOfView => Settings.CalculateFieldOfView(this);

    public event Action<Character>? Changed;
    public event Action<Character>? LevelChanged;
    public event Action<Character>? HealthChanged;
    public event Action<Character>? Died;

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

    internal void TakeDamage(int damage) => Health.TakeDamage(damage);
    internal void RestoreHealth(int value) => Health.Restore(value);
    internal void ChangeFoodSatiation(int value) => Satiation.ChangeFoodSatiation(value);
    internal void ChangeWaterSatiation(int value) => Satiation.ChangeWaterSatiation(value);

    internal bool TryRestoreHealth()
    {
        bool res = Settings.CheckHealthRecoveryAfterRest(this);
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
}
