namespace Mini_RPG.Screens;

public partial class GameProcessScreen : UserControl
{
    private readonly int _logMessageCount = 10;
    private readonly int _logMessageCountInMinimizeState = 3;
    private bool _isLogMinimize = true;

    public GameProcessScreen()
    {
        InitializeComponent();

        FillLog();
        SetAllToolTips();
    }

    public event Action? SaveAndExitClicked;

    private void MenuItem_SaveAndExit_Click(object sender, EventArgs e)
    {
        SaveAndExitClicked?.Invoke();
    }

    int counter = 0;
    private void AddLogTest(object sender, EventArgs e)
    {
        AddLog("some log");
    }

    private void AddLog(string message)
    {
        message = $"asqwew erwet rewqt qewqe   qwrq    wrdaf {counter++}";

        for (int i = _flowLayoutPanel_GameLog.Controls.Count - 1; i > 0; i--)
            _flowLayoutPanel_GameLog.Controls[i].Text = _flowLayoutPanel_GameLog.Controls[i - 1].Text;

        _flowLayoutPanel_GameLog.Controls[0].Text = message;
    }

    private void SwitchLogState(object sender, EventArgs e)
    {
        _isLogMinimize = !_isLogMinimize;

        for (int i = 0; i < _flowLayoutPanel_GameLog.Controls.Count; i++)
            if (i >= _logMessageCountInMinimizeState)
                _flowLayoutPanel_GameLog.Controls[i].Visible = !_isLogMinimize;
    }

    private void FillLog()
    {
        for (int i = 0; i < _logMessageCount; i++)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = $"{i}";//String.Empty;
            _flowLayoutPanel_GameLog.Controls.Add(label);
            
            label.Visible = i >= _logMessageCountInMinimizeState ? !_isLogMinimize : _isLogMinimize;
        }
    }

    private void Button_CharacterProgress_Click(object sender, EventArgs e)
    {
        using var characterProgressForm = new CharacterProgress();
        if (characterProgressForm.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void SetAllToolTips()
    {
        _label_Strength.ToolTipText = "% Описание СИЛ и за что она отвечает %";
        _label_Dexterity.ToolTipText = "% Описание ЛОВ и за что она отвечает %";
        _label_Constitution.ToolTipText = "% Описание ВЫН и за что она отвечает %";
        _label_Perception.ToolTipText = "% Описание ВОС и за что она отвечает %";
        _label_Charisma.ToolTipText = "% Описание ХАР и за что она отвечает %";
    }

    private void Button_Inventory_Click(object sender, EventArgs e)
    {
        using var inventoryForm = new Inventory();
        if (inventoryForm.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void Button_Trader_Click(object sender, EventArgs e)
    {
        using var traderForm = new Trader();
        if (traderForm.ShowDialog() == DialogResult.OK)
        {

        }
    }
}
