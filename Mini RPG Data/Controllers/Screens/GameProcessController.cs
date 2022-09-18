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

        _gameProcessView.ShowMap(_map, _player.Character.FieldOfView);
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
    public void Rest()
    {
        _player.TryRestoreHealth();
        _player.UpdateEffects();
        _logView.AddLog(_localizationService.PlayerRest());
    }

    public bool TryMove(Direction direction) => _state.TryMove(direction);

    private void TransitionTo<TState>() where TState : GameProcessStateBase
    {
        _state?.Exit();
        _state = _states[typeof(TState)];
        _state.Enter();
    }

    private class InTownGameProcessState : GameProcessStateBase
    {
        public InTownGameProcessState(GameProcessController controller) : base(controller)
        { }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTown();
            //Controller._gameProcessView.ShowMap(Controller._map);
        }

        internal override bool TryMove(Direction direction)
        {
            throw new NotImplementedException();
        }

        internal override void Exit()
        { }
    }

    private class TownEntranceGameProcessState : GameProcessStateBase
    {
        public TownEntranceGameProcessState(GameProcessController controller) : base(controller)
        { }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTownEntrance();
            //Controller._gameProcessView.ShowMap(Controller._map);
        }

        internal override bool TryMove(Direction direction)
        {
            Controller._player.UpdateEffects();

            var res = Controller._map.TryMovePlayer(direction);
            if (res)
            {
                Controller._gameProcessView.ShowMap(Controller._map, Controller._player.Character.FieldOfView);
                Controller._logView.AddLog(Controller._localizationService.PlayerMoveSuccessfully(direction));
            }
            else
            {
                Controller._logView.AddLog(Controller._localizationService.PlayerMoveUnsuccessfully(direction));
            }

            if (res)
                Controller.TransitionTo<AdventureGameProcessState>();

            return res;
        }

        internal override void Exit()
        { }
    }

    private class AdventureGameProcessState : GameProcessStateBase
    {
        private readonly CellEventHandler _cellEventHandler;

        public AdventureGameProcessState(GameProcessController controller) : base(controller)
        {
            _cellEventHandler = new CellEventHandler(controller);
        }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowLocation(Controller._map.PlayerCell);
            //Controller._gameProcessView.ShowMap(Controller._map);

            // detect cellType and handle this
            // loot, enemy, trap etc

            _cellEventHandler.HandlePlayerCell();

        }

        internal override bool TryMove(Direction direction)
        {
            Controller._player.UpdateEffects();

            var res = Controller._map.TryMovePlayer(direction);
            if (res)
            {
                Controller._gameProcessView.ShowMap(Controller._map, Controller._player.Character.FieldOfView);
                Controller._logView.AddLog(Controller._localizationService.PlayerMoveSuccessfully(direction));

            }
            else
            {
                Controller._logView.AddLog(Controller._localizationService.PlayerMoveUnsuccessfully(direction));
            }

            if (res)
            {
                if (Controller._map.IsPlayerOnTownCell)
                    Controller.TransitionTo<TownEntranceGameProcessState>();
                else
                    Enter();
            }

            return res;
        }

        internal override void Exit()
        { }

        private class CellEventHandler
        {
            private readonly GameProcessController _controller;

            public CellEventHandler(GameProcessController controller)
            {
                _controller = controller;
            }

            internal void HandlePlayerCell()
            {
                _controller._map.Explore(_controller._map.PlayerPosition);
                switch (_controller._map.PlayerCell.CellType)
                {
                    case CellType.Empty:
                        break;
                    case CellType.Town:
                        break;
                    case CellType.Enemy:
                        // battle
                        break;
                    case CellType.Loot:
                        HandleLootCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.LockedChest:
                        HandleLockedChestCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.HiddedLoot:
                        HandleHiddedLootCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.Trap:
                        HandleTrapCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.None:
                    default:
                        break;
                }
            }

            private void HandleTrapCell()
            {
                var trapType = Settings.GetTrapType();
                if (Settings.TryFindTrap(_controller._player))
                {
                    _controller._gameProcessView.ShowSuccessFindTrapMessage(trapType);
                }
                else
                {
                    _controller._gameProcessView.ShowFailFindTrapMessage(trapType);
                    int damage = Settings.CalculateTrapDamage(trapType, _controller._player);
                    _controller._player.Character.Health.TakeDamage(damage);
                }
            }

            private void HandleHiddedLootCell()
            {
                // generate random loot
                int money = Settings.CalculateFoundedInHiddenLootMoney(_controller._player);

                if (Settings.TryFindHiddenLoot(_controller._player))
                {
                    _controller._gameProcessView.ShowSuccessFindHiddenLootMessage(money); // and loot
                    _controller._player.Wallet.AddMoney(money);
                    // add loot
                }
            }

            private void HandleLootCell()
            {
                // generate random loot
                int money = Settings.CalculateFoundedInLootMoney(_controller._player);

                _controller._gameProcessView.ShowLootCellMessage(money); // and loot

                // pick up loot
                _controller._player.Wallet.AddMoney(money);
            }

            private void HandleLockedChestCell()
            {
                // generate chest loot
                int money = Settings.CalculateFoundedInChestMoney(_controller._player);

                _controller._gameProcessView.ShowFindChestMessage();
                if (Settings.TryPickLock(_controller._player))
                {
                    _controller._gameProcessView.ShowSuccessPickLockedChestMessage(money); // and loot
                    _controller._player.Wallet.AddMoney(money);
                    // add loot
                }
                else
                {
                    _controller._gameProcessView.ShowFailPickLockedChestMessage();
                    if (Settings.TryBreakChest(_controller._player))
                    {
                        _controller._gameProcessView.ShowSuccessBreakChestMessage(money); // and loot
                        _controller._player.Wallet.AddMoney(money);
                        // add loot
                    }
                    else
                    {
                        _controller._gameProcessView.ShowFailBreakChestMessage();
                    }
                }
            }
        }
    }
}