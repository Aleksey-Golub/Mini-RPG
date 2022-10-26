namespace Mini_RPG_Data.Datas.Quest_.QuestDB;

[Serializable]
public class QuestData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameLocalizationKey { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
    public List<QuestPhaseData> Phases { get; set; } = new List<QuestPhaseData>();
}

[Serializable]
public class QuestPhaseData
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
    public int NextPhaseId { get; set; }
    public List<QuestPhaseGoalData> Goals { get; set; } = new List<QuestPhaseGoalData>();
    public string PhaseGoalsComplitedMessageKey { get; set; }
}

[Serializable]
public class QuestPhaseGoalData
{
    public QuestPhaseGoalType GoalType { get; set; }
    public int TargetId { get; set; }
    public int RequaredProgress { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
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
