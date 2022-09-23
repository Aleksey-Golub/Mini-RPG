using Mini_RPG.Screens.CharacterCreationScreen_;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG;

public partial class OpenedMap : Form
{
    private readonly MapView _mapView;

    public OpenedMap(IMap map, ILocalizationService localizationService, string playerName)
    {
        InitializeComponent();

        _mapView = new MapView(_label_Map, _toolTip, localizationService);
        _mapView.Init(playerName);

        _mapView.DrawOpenedMap(map);

        WindowState = FormWindowState.Maximized;
    }
}
