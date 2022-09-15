using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG;

public partial class SelectingLoadGame : Form
{
    private readonly List<StartScreenController.SaveDTO> _savesDTO;
    private readonly ILocalizationService _localizationService;

    public SelectingLoadGame(List<StartScreenController.SaveDTO> savesDTO, ILocalizationService localizationService)
    {
        InitializeComponent();

        _savesDTO = savesDTO;
        _localizationService = localizationService;

        SpawnSaveViewes();
    }

    public string? SelectedSave { get; private set; }

    private void SpawnSaveViewes()
    {
        for (int i = 0; i < _savesDTO.Count; i++)
        {
            var newButton = new SaveViewButton();
            newButton.Size = new Size(200, 100);

            StartScreenController.SaveDTO saveDTO = _savesDTO[i];
            newButton.Text = $"{saveDTO.Name}, {_localizationService.Level()}: {saveDTO.Level}";

            _flowLayoutPanel_Saves.Controls.Add(newButton);
            newButton.DialogResult = DialogResult.OK;
            newButton.Index = i;
            newButton.Click += OnNewButtonClick;
        }
    }

    private void OnNewButtonClick(object? sender, EventArgs e) => SelectedSave = _savesDTO[(sender as SaveViewButton).Index].FullFilePath;

    private class SaveViewButton : Button
    {
        public int Index { get; set; }
    }
}
