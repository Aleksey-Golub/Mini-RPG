namespace Mini_RPG.Screens.CharacterCreationScreen_;

internal class HealthView
{
    private readonly ToolStripStatusLabel _label_Health;
    private readonly Panel _panel_CharacterHealthBarFG;
    private readonly int _startHeight;

    public HealthView(ToolStripStatusLabel label_Health, Panel panel_CharacterHealthBarFG)
    {
        _label_Health = label_Health;
        _panel_CharacterHealthBarFG = panel_CharacterHealthBarFG;

        _startHeight = _panel_CharacterHealthBarFG.Size.Height;
    }

    internal void View(int currentHealth, int maxHealth)
    {
        _label_Health.Text = $"{currentHealth}/{maxHealth}";

        float t = (float)currentHealth / maxHealth;
        _panel_CharacterHealthBarFG.Size = new Size(_panel_CharacterHealthBarFG.Size.Width, (int)(_startHeight * t));
    }
}
