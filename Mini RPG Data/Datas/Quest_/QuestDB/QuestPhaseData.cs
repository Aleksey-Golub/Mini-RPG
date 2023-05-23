namespace Mini_RPG_Data.Datas.Quest_.QuestDB;

[Serializable]
public class QuestPhaseData
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string DescriptionLocalizationKey { get; set; }
    public string NextPhaseId { get; set; }
    public List<QuestPhaseGoalData> Goals { get; set; } = new List<QuestPhaseGoalData>();
    public string PhaseGoalsComplitedMessageKey { get; set; }
}
