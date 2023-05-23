namespace Mini_RPG_Data.Datas.Quest_.QuestDB;

[Serializable]
public class QuestData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string NameLocalizationKey { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
    public List<QuestPhaseData> Phases { get; set; } = new List<QuestPhaseData>();
}

public enum QuestPhaseGoalType
{
    None,
    QuestStarted,
    QuestEnded,
    KillEnemyWithId,
    KillEnemyWithRace,
    CollectItem,
    MeetEnemyWithId,
    MeetEnemyWithRace,
    ReacheLevel,
}
