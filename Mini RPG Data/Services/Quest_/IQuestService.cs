using Mini_RPG_Data.Datas.Quest_.QuestDB;

namespace Mini_RPG_Data.Services.Quest_;

public interface IQuestService : IService
{
    QuestData? GetByIdOrNull(int id);
}
