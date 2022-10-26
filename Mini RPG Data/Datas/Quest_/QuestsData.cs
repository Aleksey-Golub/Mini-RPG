namespace Mini_RPG_Data.Datas.Quest_
{
    [Serializable]
    public class QuestsData
    {
        public List<QuestSavedData> CurrentQuests = new List<QuestSavedData>();
        
        public event Action? SaveStarting;

        internal void PrepareForSerialize() => SaveStarting?.Invoke();
    }
}