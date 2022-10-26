using Mini_RPG_Data.Controllers.Quest_;
using System.Text;

namespace Mini_RPG.Screens.GameProcessScreen_;

internal class QuestsView
{
    private readonly Label _label_Quests;

    public QuestsView(Label label_Quests)
    {
        _label_Quests = label_Quests;
    }

    internal void ShowQuests(IReadOnlyList<Quest> quests)
    {
        var sb = new StringBuilder();

        foreach (var quest in quests)
        {
            sb.AppendLine(quest.LocalizedName);
            sb.AppendLine(quest.LocalizedDescription);
            sb.AppendLine();
            sb.AppendLine(quest.CurrentPhaseLocalizedDescription);
            foreach (string phaseGoalDescription in quest.LocalizedDescriptionsOfCurrentPhaseGoals)
                sb.AppendLine(phaseGoalDescription);
        }

        _label_Quests.Text = sb.ToString();
    }
}
