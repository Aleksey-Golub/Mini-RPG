using Mini_RPG_Data.Controllers.Quest_;

namespace Mini_RPG_Data.Viewes;

public interface IQuestsView
{
    void ShowQuests(IReadOnlyList<Quest> quests);
}
