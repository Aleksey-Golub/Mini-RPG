using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public abstract class ItemBase
{
    protected readonly ILocalizationService LocalizationService;

    private readonly ItemDataBase _data;

    public ItemBase(ILocalizationService localizationService, ItemDataBase data)
    {
        LocalizationService = localizationService;
        _data = data;
    }

    public string Id => _data.Id;
    public int Rating => _data.Rating;
    public float Weight => _data.Weight;
    public string LocalizedName => LocalizationService.GetLocalization(Id);
    public int Cost => _data.Cost;
    public string PictureName => _data.PictureName;
    public bool IsStackable => _data.IsStackable;
    public abstract ItemType Type { get; }
    public virtual string Description => $"{LocalizedName}, {LocalizationService.GetLocalization("Cost")}: {Cost}";

    internal abstract bool TryUse(Character character);
}
