using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Controllers.Screens;

public partial class GameProcessController
{
    private readonly IGameProcessView _gameProcessView;
    private readonly ILogView _logView;

    private readonly IRandomService _randomService;
    private readonly IPersistentProgressService _progressService;

    private Player _player;
    private Map _map;

    private GameProcessStateBase _state;
    private readonly Dictionary<Type, GameProcessStateBase> _states;

    public event Action<GameProcessController>? SaveAndExit;

    public GameProcessController(IGameProcessView gameProcessView, ILogView logView, IRandomService randomService, IPersistentProgressService progressService)
    {
        _gameProcessView = gameProcessView;
        _logView = logView;
        _randomService = randomService;
        _progressService = progressService;

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
        SaveAndExit?.Invoke(this);
    }

    public void EnterTown() => TransitionTo<InTownGameProcessState>();
    public void ExitTown() => TransitionTo<TownEntranceGameProcessState>();

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