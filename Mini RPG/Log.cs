using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public class Log : ILogView
{
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

    public void AddLog(string message)
    {
        for (int i = _flowLayoutPanel_GameLog.Controls.Count - 1; i > 0; i--)
            _flowLayoutPanel_GameLog.Controls[i].Text = _flowLayoutPanel_GameLog.Controls[i - 1].Text;

        _flowLayoutPanel_GameLog.Controls[0].Text = message;
    }

    public void FillLog()
    {
        for (int i = 0; i < _logMessageCount; i++)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = $"{i}"; // String.Empty; // 
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            _flowLayoutPanel_GameLog.Controls.Add(label);

            label.Visible = i >= _logMessageCountInMinimizeState ? !_isLogMinimize : _isLogMinimize;
        }
    }

    private void SwitchLogState(object? sender, EventArgs e)
    {
        _isLogMinimize = !_isLogMinimize;

        for (int i = 0; i < _flowLayoutPanel_GameLog.Controls.Count; i++)
            if (i >= _logMessageCountInMinimizeState)
                _flowLayoutPanel_GameLog.Controls[i].Visible = !_isLogMinimize;
    }
}
