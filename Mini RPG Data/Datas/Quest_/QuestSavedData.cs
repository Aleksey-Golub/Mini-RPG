﻿namespace Mini_RPG_Data.Datas.Quest_;

[Serializable]
public class QuestSavedData
{
    public QuestSavedData(string id, string name, string description, QuestPhaseSavedData currentPhaseSavedData)
    {
        Id = id;
        Name = name;
        Description = description;
        CurrentPhaseSavedData = currentPhaseSavedData;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public QuestPhaseSavedData CurrentPhaseSavedData { get; set; }
}
