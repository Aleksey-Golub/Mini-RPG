using Mini_RPG_Data.Datas.Quest_.QuestDB;
using System.Text.Json;

namespace Mini_RPG_Data.Services.Quest;

public class JsonQuestService : IQuestService
{
    private const string DB_PATH = "QuestDB.json";
    private readonly QuestDB? _questDB;
    private readonly JsonSerializerOptions _options;

    public JsonQuestService()
    {
        _options = new JsonSerializerOptions { IncludeFields = true };

        try
        {
            string text = File.ReadAllText(DB_PATH);
            _questDB = JsonSerializer.Deserialize<QuestDB>(text, _options);
        }
        catch { }

        WriteCommentsToFile("Comments_QuestDB.json");

        WriteExamplesToFile("ExampleQuestDB.json");
        //WriteExamplesToFile(DB_PATH);
    }

    public QuestData? GetByIdOrNull(int id)
    {
        foreach (var quest in _questDB.Quests)
            if (quest.Id == id)
                return quest;

        return null;
    }

    private void WriteCommentsToFile(string localFilePath)
    {
        var comments = new List<string>();

        comments.Add(Utils.EnumToString<QuestPhaseGoalType>());

        try
        {
            string jsonString = JsonSerializer.Serialize(comments, _options);

            File.WriteAllText(localFilePath, jsonString);
        }
        catch
        { }
    }

    private void WriteExamplesToFile(string localFilePath)
    {
        var questDB = new QuestDB();
        questDB.Quests.Add(new QuestData() { Id = 0, Name = "", Description = "", Phases = new List<QuestPhaseData>() { new QuestPhaseData() { Goals = new List<QuestPhaseGoal>() { new QuestPhaseGoal()} } } });

        try
        {
            string jsonString = JsonSerializer.Serialize(questDB, _options);

            File.WriteAllText(localFilePath, jsonString);
        }
        catch
        { }
    }

    [Serializable]
    public class QuestDB
    {
        public List<QuestData> Quests = new List<QuestData>();
    }
}
