namespace Mini_RPG_Data.Datas.Quest_.QuestDB;

[Serializable]
public class QuestPhaseGoalData
{
    public QuestPhaseGoalType GoalType { get; set; }
    public int TargetId { get; set; }
    public int RequaredProgress { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
}
