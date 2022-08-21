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
}
