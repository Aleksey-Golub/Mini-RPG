using Mini_RPG_Data.Viewes;

namespace Mini_RPG.Screens.GameProcessScreen_;

public class Log : ILogView
{
    private readonly Color _defaultBgColor = Color.Black;
    private readonly Color _defaultFgColor = Color.White;

    private readonly FlowLayoutPanel _flowLayoutPanel_GameLog;
    private readonly Button _button_SwitchLogSize;
    private readonly int _logMessageCount = 10;
    private readonly int _logMessageCountInMinimizeState = 3;
    private bool _isLogMinimize = true;

    public Log(FlowLayoutPanel flowLayoutPanel_GameLog, Button button_SwitchLogSize)
    {
        _flowLayoutPanel_GameLog = flowLayoutPanel_GameLog;
        _button_SwitchLogSize = button_SwitchLogSize;
        _button_SwitchLogSize.Click += SwitchLogState;
    }

    public void AddLog(string message) => AddLogInternal(message);
    public void AddLogImportant(string message) => AddLogInternal(message, Color.DarkRed, Color.White);

    public void AddLogInternal(string message, Color? bgColor = null, Color? fgColor = null)
    {
        bgColor = bgColor ?? _defaultBgColor;
        fgColor = fgColor ?? _defaultFgColor;

        for (int i = _flowLayoutPanel_GameLog.Controls.Count - 1; i > 0; i--)
        {
            _flowLayoutPanel_GameLog.Controls[i].Text = _flowLayoutPanel_GameLog.Controls[i - 1].Text;
            _flowLayoutPanel_GameLog.Controls[i].BackColor = _flowLayoutPanel_GameLog.Controls[i - 1].BackColor;
            _flowLayoutPanel_GameLog.Controls[i].ForeColor = _flowLayoutPanel_GameLog.Controls[i - 1].ForeColor;
        }

        _flowLayoutPanel_GameLog.Controls[0].Text = message;
        _flowLayoutPanel_GameLog.Controls[0].BackColor = bgColor.Value;
        _flowLayoutPanel_GameLog.Controls[0].ForeColor = fgColor.Value;
    }

    public void FillLog()
    {
        for (int i = 0; i < _logMessageCount; i++)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = string.Empty;
            label.BackColor = _defaultBgColor;
            label.ForeColor = _defaultFgColor;
            _flowLayoutPanel_GameLog.Controls.Add(label);

            label.Visible = i >= _logMessageCountInMinimizeState ? !_isLogMinimize : _isLogMinimize;
        }
    }

    public void ClearLogs() => _flowLayoutPanel_GameLog.Controls.Clear();

    private void SwitchLogState(object? sender, EventArgs e)
    {
        _isLogMinimize = !_isLogMinimize;

        for (int i = 0; i < _flowLayoutPanel_GameLog.Controls.Count; i++)
            if (i >= _logMessageCountInMinimizeState)
                _flowLayoutPanel_GameLog.Controls[i].Visible = !_isLogMinimize;
    }
}
