using Mini_RPG_Data;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG.Screens.GameProcessScreen_;

internal class SatiationView
{
    private readonly ILocalizationService _localizationService;
    private readonly ToolStripStatusLabel _label_HungerLevel;
    private readonly ToolStripStatusLabel _label_ThirstLevel;

    public SatiationView(ILocalizationService localizationService, ToolStripStatusLabel label_HungerLevel, ToolStripStatusLabel label_ThirstLevel)
    {
        _localizationService = localizationService;
        _label_HungerLevel = label_HungerLevel;
        _label_ThirstLevel = label_ThirstLevel;
    }

    internal void View(HungerLevel hungerLevel, ThirstLevel thirstLevel)
    {
        _label_HungerLevel.Text = _localizationService.HungerLevelName(hungerLevel);
        _label_ThirstLevel.Text = _localizationService.ThirstLevelName(thirstLevel);
    }
}