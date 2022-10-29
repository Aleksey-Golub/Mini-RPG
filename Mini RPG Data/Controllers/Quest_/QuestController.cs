using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Quest_;
using Mini_RPG_Data.Datas.Quest_.QuestDB;
using Mini_RPG_Data.Services.EventBus;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Services.Quest_;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers.Quest_;

internal class QuestController
{
    private readonly IPersistentProgressService _progressService;
    private readonly IQuestService _questService;
    private readonly ILocalizationService _localizationService;
    private readonly IEventService _eventService;

    private readonly IGameProcessView _gameProcessView;
    private readonly IQuestsView _questView;

    private readonly List<Quest> _currentQuests = new List<Quest>();
    private Player _player;

    internal QuestController(
        IPersistentProgressService progressService,
        IQuestService questService,
        ILocalizationService localizationService,
        IEventService eventService,
        IGameProcessView gameProcessView,
        IQuestsView questView)
    {
        _progressService = progressService;
        _questService = questService;
        _localizationService = localizationService;
        _eventService = eventService;
        _gameProcessView = gameProcessView;
        _questView = questView;
    }

    internal void Init(Player player)
    {
        _player = player;
        _player.Character.LevelChanged += OnPlayerCharacterLevelChanged;
        _player.Character.Inventory.Changed += OnPlayerCharacterInventoryChanged;

        _eventService.Subscribe(EventType.KilledEnemyWithId, OnEventHappened);
        _eventService.Subscribe(EventType.KilledEnemyWithRace, OnEventHappened);
        _eventService.Subscribe(EventType.MeetEnemyWithId, OnEventHappened);
        _eventService.Subscribe(EventType.MeetEnemyWithRace, OnEventHappened);
        FillCurrentQuests();

        _progressService.Progress.PlayerData.QuestsData.SaveStarting += UpdateData;

        _questView.ShowQuests(_currentQuests);
    }

    internal void DeInit()
    {
        _progressService.Progress.PlayerData.QuestsData.SaveStarting -= UpdateData;

        ClearCurrentQuests();

        _player.Character.LevelChanged -= OnPlayerCharacterLevelChanged;
        _player.Character.Inventory.Changed -= OnPlayerCharacterInventoryChanged;
        _player = null;

        _eventService.Unsubscribe(EventType.KilledEnemyWithId, OnEventHappened);
        _eventService.Unsubscribe(EventType.KilledEnemyWithRace, OnEventHappened);
        _eventService.Unsubscribe(EventType.MeetEnemyWithId, OnEventHappened);
        _eventService.Unsubscribe(EventType.MeetEnemyWithRace, OnEventHappened);
    }

    private void FillCurrentQuests()
    {
        foreach (var questSavedData in _progressService.Progress.PlayerData.QuestsData.CurrentQuests)
        {
            var questData = _questService.GetByIdOrNull(questSavedData.Id);
            if (questData == null)
                continue;

            Quest quest = new Quest(questData, questSavedData.CurrentPhaseSavedData, _localizationService);
            _currentQuests.Add(quest);
            quest.QuestComplited += OnQuestComplited;
            quest.CurrentPhaseChanged += OnQuestCurrentPhaseChanged;
            quest.PhaseComplited += OnQuestPhaseComplited;
            quest.CurrentPhaseSwitched += OnQuestCurrentPhaseSwitched;
        }
    }

    private void ClearCurrentQuests()
    {
        foreach (var quest in _currentQuests)
        {
            quest.QuestComplited -= OnQuestComplited;
            quest.CurrentPhaseChanged -= OnQuestCurrentPhaseChanged;
            quest.PhaseComplited -= OnQuestPhaseComplited;
            quest.CurrentPhaseSwitched -= OnQuestCurrentPhaseSwitched;
        }
        _currentQuests.Clear();
    }

    private void UpdateData()
    {
        List<QuestSavedData> currentQuestsData = _progressService.Progress.PlayerData.QuestsData.CurrentQuests;

        currentQuestsData.Clear();

        foreach (var quest in _currentQuests)
        {
            var goalsProgresses = new List<int>();
            foreach (var goal in quest.CurrentPhase.Goals)
                goalsProgresses.Add(goal.CurrentProgress);

            var currentPhaseSavedData = new QuestPhaseSavedData(quest.CurrentPhase.Id, quest.CurrentPhaseLocalizedDescription, goalsProgresses);
            QuestSavedData questData = new QuestSavedData(quest.Id, quest.LocalizedName, quest.LocalizedDescription, currentPhaseSavedData);

            currentQuestsData.Add(questData);
        }
    }

    private void OnQuestCurrentPhaseSwitched(Quest quest)
    {
        OnPlayerCharacterInventoryChanged(_player.Character.Inventory);
        OnPlayerCharacterLevelChanged(_player.Character);
    }

    private void OnQuestPhaseComplited(Phase phase)
    {
        _gameProcessView.ShowMessage(_localizationService.QuestTranslation(phase.PhaseGoalsComplitedMessageKey));
    }

    private void OnQuestCurrentPhaseChanged(Phase phase)
    {
        _questView.ShowQuests(_currentQuests);
    }

    private void OnQuestComplited(Quest quest)
    {
        _currentQuests.Remove(quest);
        _questView.ShowQuests(_currentQuests);

        _gameProcessView.ShowMessage(_localizationService.Message_QuestComplited(quest));
    }

    private void OnPlayerCharacterInventoryChanged(Inventory playerCharacterInventory)
    {
        for (int i = 0; i < _currentQuests.Count; i++)
        {
            Quest? quest = _currentQuests[i];
            if (quest.HandlePlayerCharacterInventoryChanged(playerCharacterInventory.Items))
                i--;
        }
    }

    private void OnPlayerCharacterLevelChanged(ICharacter playerCharacter)
    {
        for (int i = 0; i < _currentQuests.Count; i++)
        {
            Quest? quest = _currentQuests[i];
            if (quest.HandlePlayerCharacterLevelChanged(playerCharacter.Level.Value))
                i--;
        }
    }

    private void OnEventHappened(EventType eventType, int index)
    {
        for (int i = 0; i < _currentQuests.Count; i++)
        {
            Quest? quest = _currentQuests[i];
            if (quest.HandleEvent(eventType, index))
                i--;
        }
    }
}

public class Quest
{
    private readonly ILocalizationService _localizationService;
    private readonly QuestData _data;
    private readonly List<Phase> _phases = new List<Phase>();

    internal Phase CurrentPhase { get; private set; } = null!;

    internal Quest(QuestData questData, QuestPhaseSavedData currentPhaseSavedData, ILocalizationService localizationService)
    {
        _localizationService = localizationService;

        _data = questData;

        foreach (var phaseData in _data.Phases)
        {
            Phase phase = new Phase(phaseData);
            _phases.Add(phase);

            if (phase.Id == currentPhaseSavedData.Id)
            {
                CurrentPhase = phase;
                CurrentPhase.LoadSavedProgress(currentPhaseSavedData.GoalsProgresses);
            }
        }
    }

    public string LocalizedName => _localizationService.QuestTranslation(_data.NameLocalizationKey);
    public string LocalizedDescription => _localizationService.QuestTranslation(_data.DescriptionLocalizationKey);
    public string CurrentPhaseLocalizedDescription => _localizationService.QuestTranslation(CurrentPhase.DescriptionLocalizationKey);
    public IEnumerable<string> LocalizedDescriptionsOfCurrentPhaseGoals
    {
        get
        {
            List<string> descriiptions = new List<string>();
            foreach (var goal in CurrentPhase.Goals)
            {
                string desc = $"{_localizationService.QuestTranslation(goal.DescriptionLocalizationKey)} {goal.CurrentProgress}/{goal.RequaredProgress}";
                descriiptions.Add(desc);
            }

            return descriiptions;
        }
    }

    internal int Id => _data.Id;
    internal event Action<Phase> CurrentPhaseChanged;
    internal event Action<Phase> PhaseComplited;
    internal event Action<Quest> QuestComplited;
    internal event Action<Quest> CurrentPhaseSwitched;

    internal bool HandleEvent(EventType eventType, int index)
    {
        CurrentPhase.HandleEvent(eventType, index);
        return CheckPhaseOrQuestEnded();
    }

    internal bool HandlePlayerCharacterInventoryChanged(IReadOnlyList<ItemBase> items)
    {
        CurrentPhase.HandlePlayerCharacterInventoryChanged(items);
        return CheckPhaseOrQuestEnded();
    }

    internal bool HandlePlayerCharacterLevelChanged(int newLevelValue)
    {
        CurrentPhase.HandlePlayerCharacterLevelChanged(newLevelValue);
        return CheckPhaseOrQuestEnded();
    }

    private bool CheckPhaseOrQuestEnded()
    {
        if (CurrentPhase.IsComplited)
        {
            PhaseComplited?.Invoke(CurrentPhase);

            int nextPhaseId = CurrentPhase.NextPhaseId;
            CurrentPhase = nextPhaseId == -1 ? null : _phases.FirstOrDefault(p => p.Id == nextPhaseId);
            if (CurrentPhase != null)
                CurrentPhaseSwitched?.Invoke(this);
        }

        if (CurrentPhase != null)
        {
            CurrentPhaseChanged?.Invoke(CurrentPhase);
        }
        else
        {
            QuestComplited?.Invoke(this);
            return true;
        }

        return false;
    }
}

internal class Phase
{
    private readonly QuestPhaseData _data;
    private readonly List<Goal> _goals = new List<Goal>();

    internal Phase(QuestPhaseData phaseData)
    {
        _data = phaseData;

        foreach (var goalData in phaseData.Goals)
        {
            Goal goal = new Goal(goalData);
            _goals.Add(goal);
        }
    }

    internal IReadOnlyList<Goal> Goals => _goals;
    internal int Id => _data.Id;
    internal string DescriptionLocalizationKey => _data.DescriptionLocalizationKey;
    internal int NextPhaseId => _data.NextPhaseId;
    internal string PhaseGoalsComplitedMessageKey => _data.PhaseGoalsComplitedMessageKey;
    internal bool IsComplited => _goals.All(x => x.IsComplited == true);

    internal void HandleEvent(EventType eventType, int index)
    {
        foreach (var goal in _goals)
            if (goal.CorrespondingEventType == eventType && goal.TargetId == index)
                goal.CurrentProgress++;
    }

    internal void HandlePlayerCharacterInventoryChanged(IReadOnlyList<ItemBase> items)
    {
        // TO DO
    }

    internal void HandlePlayerCharacterLevelChanged(int newLevelValue)
    {
        foreach (var goal in _goals)
            if (goal.GoalType == QuestPhaseGoalType.ReacheLevel)
                goal.CurrentProgress = newLevelValue;
    }

    internal void LoadSavedProgress(List<int> goalsProgresses)
    {
        if (goalsProgresses.Count != _goals.Count)
            return;

        for (int i = 0; i < _goals.Count; i++)
            _goals[i].CurrentProgress = goalsProgresses[i];
    }
}

internal class Goal
{
    private readonly QuestPhaseGoalData _data;

    internal Goal(QuestPhaseGoalData goalData)
    {
        _data = goalData;
    }

    internal QuestPhaseGoalType GoalType => _data.GoalType;
    internal EventType CorrespondingEventType => GetCorrespondingEventType(GoalType);
    internal int TargetId => _data.TargetId;
    internal int CurrentProgress { get; set; }
    internal int RequaredProgress => _data.RequaredProgress;
    internal string DescriptionLocalizationKey => _data.DescriptionLocalizationKey;
    internal bool IsComplited => CurrentProgress >= RequaredProgress;

    private EventType GetCorrespondingEventType(QuestPhaseGoalType goalType)
    {
        return goalType switch
        {
            QuestPhaseGoalType.KillEnemyWithId => EventType.KilledEnemyWithId,
            QuestPhaseGoalType.KillEnemyWithRace => EventType.KilledEnemyWithRace,
            QuestPhaseGoalType.MeetEnemyWithId => EventType.MeetEnemyWithId,
            QuestPhaseGoalType.MeetEnemyWithRace => EventType.MeetEnemyWithRace,
            QuestPhaseGoalType.ReacheLevel => EventType.SpecialEventType,
            QuestPhaseGoalType.CollectItem => EventType.SpecialEventType,

            QuestPhaseGoalType.QuestStarted => throw new NotImplementedException(),
            QuestPhaseGoalType.QuestEnded => throw new NotImplementedException(),
            QuestPhaseGoalType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
}
