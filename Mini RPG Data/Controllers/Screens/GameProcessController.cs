using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Controllers.Screens;

public partial class GameProcessController
{
    private readonly IGameProcessView _gameProcessView;
    private readonly ILogView _logView;

    private readonly IRandomService _randomService;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly ILocalizationService _localizationService;
    private Player _player = null!;
    private Map _map = null!;

    private GameProcessStateBase _state = null!;
    private readonly Dictionary<Type, GameProcessStateBase> _states;

    public event Action<GameProcessController>? SaveAndExit;

    public GameProcessController(
        IGameProcessView gameProcessView, 
        ILogView logView, 
        IRandomService randomService, 
        IPersistentProgressService progressService, 
        ISaveLoadService saveLoadService,
        ILocalizationService localizationService)
    {
        _gameProcessView = gameProcessView;
        _logView = logView;
        _randomService = randomService;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _localizationService = localizationService;
        _states = new Dictionary<Type, GameProcessStateBase>()
        {
            [typeof(InTownGameProcessState)] = new InTownGameProcessState(this),
            [typeof(TownEntranceGameProcessState)] = new TownEntranceGameProcessState(this),
            [typeof(AdventureGameProcessState)] = new AdventureGameProcessState(this),
        };

        _gameProcessView.SetGameProcessController(this);
    }

    public void Run()
    {
        _player = new Player(_progressService.Progress.PlayerData);
        _map = new Map(_progressService.Progress.MapData);

        _gameProcessView.Init(_player);
        _gameProcessView.SetActiveState(true);

        if (_map.IsPlayerOnTownCell)
            TransitionTo<TownEntranceGameProcessState>();
        else
            TransitionTo<AdventureGameProcessState>();
    }

    public void SaveGameAndExitMainMenu()
    {
        _gameProcessView.DeInit();
        _gameProcessView.SetActiveState(false);

        _saveLoadService.SaveProgress();
        SaveAndExit?.Invoke(this);
    }

    public void EnterTown() => TransitionTo<InTownGameProcessState>();
    public void ExitTown() => TransitionTo<TownEntranceGameProcessState>();
    public void Rest() => _player.Character.Rest(_randomService);
    public bool TryMove(Direction direction)
    {
        var res = _map.TryMovePlayer(direction);
        if (res)
        {
            _gameProcessView.ShowMap(_map);
            _logView.AddLog(_localizationService.PlayerMoveSuccessfully(direction));
        }
        else
        {
            _logView.AddLog(_localizationService.PlayerMoveUnsuccessfully(direction));
        }

        return res;
    }

    private void TransitionTo<TState>() where TState : GameProcessStateBase
    {
        _state?.Exit();
        _state = _states[typeof(TState)];
        _state.Enter();
    }

    private class InTownGameProcessState : GameProcessStateBase
    {
        public InTownGameProcessState(GameProcessController controller) : base(controller)
        {}

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTown();
            Controller._gameProcessView.ShowMap(Controller._map);
        }

        internal override void Execute()
        {
            throw new NotImplementedException();
        }

        internal override void Exit()
        {}

        protected override bool CheckNeedAndDoTransition()
        {
            throw new NotImplementedException();
        }
    }

    private class TownEntranceGameProcessState : GameProcessStateBase
    {
        public TownEntranceGameProcessState(GameProcessController controller) : base(controller)
        {}

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTownEntrance();
            Controller._gameProcessView.ShowMap(Controller._map);
        }

        internal override void Execute()
        {
            throw new NotImplementedException();
        }

        internal override void Exit()
        {
        }

        protected override bool CheckNeedAndDoTransition()
        {
            throw new NotImplementedException();
        }
    }

    private class AdventureGameProcessState : GameProcessStateBase
    {
        public AdventureGameProcessState(GameProcessController controller) : base(controller)
        {}

        protected override bool CheckNeedAndDoTransition()
        {
            throw new NotImplementedException();
        }

        internal override void Enter()
        {
            throw new NotImplementedException();
        }

        internal override void Execute()
        {
            throw new NotImplementedException();
        }

        internal override void Exit()
        {
            throw new NotImplementedException();
        }
    }
}