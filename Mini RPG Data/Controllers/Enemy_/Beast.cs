using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Enemy_.EnemiesDB;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Enemy_;

internal class Beast : ICharacter
{
    private readonly ILocalizationService _localizationService;
    private readonly BeastEnemyDataBase _data;

    public Beast(BeastEnemyDataBase beastData)
    {
        _localizationService = AllServices.Container.Single<ILocalizationService>();

        _data = beastData;

        AllAbilities = new Abilities(_data.CharacterData.AbilitiesDatas);
        Level = new Level(_data.CharacterData.LevelData);
        Health = new Health(_data.CharacterData.HealthData, this);
        Satiation = new Satiation(_data.CharacterData.SatiationData, this);
        Inventory = new Inventory(AllServices.Container.Single<IItemFactory>(), _data.CharacterData.InventoryData);
    }

    public string Name => _localizationService.CharacterName(_data.CharacterData.Name);
    public string AvatarPath => _data.CharacterData.AvatarPath;
    public Race Race => _data.CharacterData.Race;
    public IAbilities AllAbilities { get; }
    public Level Level { get; }
    public Health Health { get; }
    public int MaxHealth => _data.MaxHealth;
    public bool IsAlive => Health.CurrentHealth > 0;
    public Satiation Satiation { get; }
    public Inventory Inventory { get; }
    public int Experience => _data.Experience;
    public int FieldOfView => _data.FieldOfView;
    public int AttackModifier => _data.AttackModifier;
    public int DefenseModifier => _data.DefenseModifier;
    public int MinDamage => _data.MinDamage;
    public int MaxDamage => _data.MaxDamage;
    public DamageType DamageType => _data.DamageType;
    public int InitiativeModifier => _data.InitiativeModifier;

    public event Action<ICharacter>? Changed;
    public event Action<ICharacter>? LevelChanged;
    public event Action<ICharacter>? HealthChanged;
    public event Action<ICharacter>? Died;

    public Armor GetArmor(BodyPart bodyPart)
    {
        return bodyPart switch
        {
            BodyPart.Head => _data.HeadArmor,
            BodyPart.RightHand => _data.HandsArmor,
            BodyPart.LeftHand => _data.HandsArmor,
            BodyPart.Body => _data.BodyArmor,
            BodyPart.RightLeg => _data.LegsArmor,
            BodyPart.LeftLeg => _data.LegsArmor,
            BodyPart.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public bool IsAttackCritical(BodyPart bodyPart) => bodyPart == BodyPart.Head;
    public void TakeDamage(int damage) => Health.TakeDamage(damage);
}
