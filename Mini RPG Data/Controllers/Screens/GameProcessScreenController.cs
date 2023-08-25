using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.Enemy;
using Mini_RPG_Data.Controllers.Quest_;
using Mini_RPG_Data.Services.Quest_;
using Mini_RPG_Data.Services.EventBus;

namespace Mini_RPG_Data.Controllers.Screens;

public partial class GameProcessScreenController
{
    private readonly IGameProcessView _gameProcessView;
    private readonly ILogView _logView;
    private readonly IPlayerDeathView _playerDeathView;

    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly ILocalizationService _localizationService;
    private readonly IRandomService _randomService;
    private readonly IEnemyFactory _enemyFactory;
    private readonly IEventService _eventService;

    private Player _player = null!;
    private Map _map = null!;
    private QuestController _questSystem = null!;

    private GameProcessStateBase _state = null!;
    private readonly Dictionary<Type, GameProcessStateBase> _states;

    public event Action<GameProcessScreenController>? SaveAndExit;
    public event Action<GameProcessScreenController>? PlayerDied;

    public GameProcessScreenController(
        IGameProcessView gameProcessView,
        ILogView logView,
        IQuestsView questView,
        IPlayerDeathView playerDeathView,
        IPersistentProgressService progressService,
        ISaveLoadService saveLoadService,
        ILocalizationService localizationService,
        IRandomService randomService,
        IEnemyFactory enemyFactory,
        IQuestService questService,
        IEventService eventService)
    {
        _gameProcessView = gameProcessView;
        _logView = logView;
        _playerDeathView = playerDeathView;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _localizationService = localizationService;
        _randomService = randomService;
        _enemyFactory = enemyFactory;
        _eventService = eventService;

        _states = new Dictionary<Type, GameProcessStateBase>()
        {
            [typeof(InTownGameProcessState)] = new InTownGameProcessState(this),
            [typeof(TownEntranceGameProcessState)] = new TownEntranceGameProcessState(this),
            [typeof(AdventureGameProcessState)] = new AdventureGameProcessState(this),
            [typeof(BattleGameProcessState)] = new BattleGameProcessState(this),
        };

        _gameProcessView.SetGameProcessController(this);
        _playerDeathView.SetController(this);

        _questSystem = new QuestController(_progressService, questService, _localizationService, _eventService, _gameProcessView, questView);
    }

    public void Run()
    {
        _player = new Player(_progressService.Progress.PlayerData);
        _player.Character.Died += OnPlayerCharacterDied;
        _map = new Map(_progressService.Progress.MapData);
        _map.Explored += OnMapExplored;
        _questSystem.Init(_player);

        _gameProcessView.Init(_player);
        _gameProcessView.SetActiveState(true);

        if (_map.IsPlayerOnTownCell)
            TransitionTo<TownEntranceGameProcessState>();
        else
            TransitionTo<AdventureGameProcessState>();

        _gameProcessView.ShowMiniMap(_map, _player.Character.FieldOfView);
    }

    public void SaveGameAndExitMainMenu()
    {
        _saveLoadService.SaveProgress();

        _gameProcessView.DeInit();
        _gameProcessView.SetActiveState(false);
        _questSystem.DeInit();

        _player.Character.Died -= OnPlayerCharacterDied;

        SaveAndExit?.Invoke(this);
    }

    public void GoToMainMenuAfterDeath()
    {
        _playerDeathView.DeInit();
        _playerDeathView.SetActiveState(false);

        PlayerDied?.Invoke(this);
    }

    public void EnterTown() => TransitionTo<InTownGameProcessState>();
    public void ExitTown() => TransitionTo<TownEntranceGameProcessState>();
    public void Rest()
    {
        _state.Tick(PlayerAction.Rest);
        _logView.AddLog(_localizationService.GetLocalization("PlayerRest"));
    }

    public void StartRestInTown()
    {
        int restCost = _map.IsExplored ? 0 : GameRules.REST_IN_TOWN_COST;
        _gameProcessView.ShowRestInTownDialog(restCost);
    }

    public bool TryRestInTown(int restCost)
    {
        if (_player.Wallet.Money >= restCost)
        {
            _progressService.Progress.TownTraderData = GameRules.GetRandomTownTraderData();

            _map.Regenerate(_randomService);
            _gameProcessView.ShowMiniMap(_map, _player.Character.FieldOfView);

            _player.Character.RestoreFullHealth();
            _player.Wallet.RemoveMoney(restCost);

            _gameProcessView.ShowSuccessRestInTownMessage();
            return true;
        }
        else
        {
            _gameProcessView.ShowFailRestInTownMessage();
            return false;
        }
    }

    public bool TryMove(Direction direction)
    {
        //_logView.AddLog($"{_player.Character.Satiation.FoodSatiationValue} {_player.Character.Satiation.WaterSatiationValue}");
        return _state.TryMove(direction);
    }

    public void Tick(PlayerAction playerAction)
    {
        //_logView.AddLog($"{_player.Character.Satiation.FoodSatiationValue} {_player.Character.Satiation.WaterSatiationValue}");
        _state.Tick(playerAction);
    }

    public void ShowMap() => _gameProcessView.ShowMap(_map);
    private void TransitionTo<TState>() where TState : GameProcessStateBase
    {
        _state?.Exit();
        _state = _states[typeof(TState)];
        _state.Enter();
    }

    private void OnPlayerCharacterDied(ICharacter character)
    {
        _player.Character.Died -= OnPlayerCharacterDied;
        _gameProcessView.DeInit();
        _gameProcessView.SetActiveState(false);

        _playerDeathView.SetActiveState(true);
        _playerDeathView.ShowPlayerResult(_player);
        _saveLoadService.DeleteCurrentPlayerSave();
    }

    private void OnMapExplored() => _gameProcessView.ShowMapExploredMessage();

    private class InTownGameProcessState : GameProcessStateBase
    {
        public InTownGameProcessState(GameProcessScreenController controller) : base(controller)
        { }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTown();
        }

        internal override bool TryMove(Direction direction)
        {
            throw new NotImplementedException();
        }

        internal override void Tick(PlayerAction playerAction)
        { }

        internal override void Exit()
        { }
    }

    private class TownEntranceGameProcessState : GameProcessStateBase
    {
        public TownEntranceGameProcessState(GameProcessScreenController controller) : base(controller)
        { }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowTownEntrance();
        }

        internal override bool TryMove(Direction direction)
        {
            Controller._player.UpdateEffects();

            var res = Controller._map.TryMovePlayer(direction);
            if (res)
            {
                Controller._gameProcessView.ShowMiniMap(Controller._map, Controller._player.Character.FieldOfView);
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

        internal override void Tick(PlayerAction playerAction)
        {
            Controller._player.TryRestoreHealth();
            Controller._player.UpdateEffects();
        }

        internal override void Exit()
        { }
    }

    private class BattleGameProcessState : GameProcessStateBase
    {
        private ICharacter? _enemy = null;
        private bool _playerEscaped = false;

        public BattleGameProcessState(GameProcessScreenController controller) : base(controller)
        { }

        internal override void Enter()
        {
            _enemy = Controller._enemyFactory.CreateRandom(Controller._player);

            Controller._eventService.Publish(EventType.MeetEnemyWithId, _enemy.Id);
            Controller._eventService.Publish(EventType.MeetEnemyWithRace, _enemy.Race.ToString());
            Controller._logView.AddLog(Controller._localizationService.Message_MeetingWithEnemy(_enemy.Name));

            Controller._gameProcessView.ShowBattle(_enemy);
        }

        internal override bool TryMove(Direction direction)
        {
            throw new NotImplementedException();
        }

        internal override void Tick(PlayerAction playerAction)
        {
            int playerInitiative = GameRules.CalculateInitiative(Controller._player.Character);
            int enemyInitiative = GameRules.CalculateInitiative(_enemy);

            if (playerInitiative >= enemyInitiative)
            {
                HandlePlayerAction(playerAction);
                if (NeedEndBattle())
                    return;
                HandleEnemyAction();
            }
            else
            {
                HandleEnemyAction();
                if (NeedEndBattle())
                    return;
                HandlePlayerAction(playerAction);
            }
            if (NeedEndBattle())
                return;
        }

        internal override void Exit()
        {
            _enemy = null;
            _playerEscaped = false;
        }

        private void HandlePlayerAction(PlayerAction playerAction)
        {
            switch (playerAction)
            {
                case PlayerAction.AttackEnemy:
                    var res = GameRules.HandleAttack(Controller._player.Character, _enemy);
                    LogAttackResult(res);
                    break;
                case PlayerAction.TryLeaveBattle:
                    _playerEscaped = GameRules.HandlePlayerBattleEscape(Controller._player.Character);
                    if (_playerEscaped == false)
                        Controller._logView.AddLog($"{Controller._localizationService.GetLocalization("GUI_Message_YouAreNotEscaped")}");
                    break;
                case PlayerAction.Rest:
                    break;
                case PlayerAction.UseItemSuccessfully:
                    break;
                case PlayerAction.UnEquipItem:
                    break;
                case PlayerAction.None:
                default:
                    break;
            }
        }

        private void HandleEnemyAction()
        {
            var res = GameRules.HandleAttack(_enemy, Controller._player.Character);
            LogAttackResult(res);
        }

        private void LogAttackResult((string attackerName, string defenderName, int damage, bool isSuccess, bool isCrit, BodyPart bodyPart) res)
        {
            if (res.isSuccess && res.isCrit == false)
                Controller._logView.AddLog(Controller._localizationService.Message_FirstHitsSecondWithDamage(res.attackerName, res.defenderName, res.damage, res.bodyPart));
            else if (res.isSuccess && res.isCrit)
                Controller._logView.AddLogImportant(Controller._localizationService.Message_FirstHitsSecondWithCriticalDamage(res.attackerName, res.defenderName, res.damage, res.bodyPart));
            else if (res.isSuccess == false)
                Controller._logView.AddLog(Controller._localizationService.Message_FirstMissedSecond(res.attackerName, res.defenderName));
        }

        private bool NeedEndBattle()
        {
            if (_enemy.IsAlive == false)
            {
                Controller._gameProcessView.HideBattle(BattleResult.PlayerWon, _enemy.Inventory.Items, _enemy.Experience);
                Controller._player.Character.Level.TakeExperience(_enemy.Experience);
                Controller._player.Character.Inventory.AddItems(_enemy.Inventory.Items.ToList());

                Controller._eventService.Publish(EventType.KilledEnemyWithId, _enemy.Id);
                Controller._eventService.Publish(EventType.KilledEnemyWithRace, _enemy.Race.ToString());

                Controller.TransitionTo<AdventureGameProcessState>();
                return true;
            }

            if (Controller._player.Character.IsAlive == false)
                return true;

            if (_playerEscaped)
            {
                Controller._logView.AddLog($"{Controller._localizationService.GetLocalization("GUI_Message_YouAreEscaped")}");
                Controller._gameProcessView.HideBattle(BattleResult.PlayerEscaped, _enemy.Inventory.Items, _enemy.Experience);
                Controller.TransitionTo<AdventureGameProcessState>();
                return true;
            }

            return false;
        }
    }

    private class AdventureGameProcessState : GameProcessStateBase
    {
        private readonly CellEventHandler _cellEventHandler;

        public AdventureGameProcessState(GameProcessScreenController controller) : base(controller)
        {
            _cellEventHandler = new CellEventHandler(controller);
        }

        internal override void Enter()
        {
            Controller._gameProcessView.ShowLocation(Controller._map.PlayerCell);

            _cellEventHandler.HandlePlayerCell();
        }

        internal override bool TryMove(Direction direction)
        {
            Controller._player.UpdateEffects();

            var res = Controller._map.TryMovePlayer(direction);
            if (res)
            {
                Controller._gameProcessView.ShowMiniMap(Controller._map, Controller._player.Character.FieldOfView);
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

        internal override void Tick(PlayerAction playerAction)
        {
            Controller._player.TryRestoreHealth();
            Controller._player.UpdateEffects();
        }

        internal override void Exit()
        { }

        private class CellEventHandler
        {
            private readonly GameProcessScreenController _controller;

            public CellEventHandler(GameProcessScreenController controller)
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
                        HandleEnemyCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
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
                    case CellType.HiddenChest:
                        HandleHiddenChestCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.Trap:
                        HandleTrapCell();
                        _controller._map.MakeEmpty(_controller._map.PlayerPosition);
                        break;
                    case CellType.None:
                    default:
                        throw new NotImplementedException();
                }
            }

            private void HandleEnemyCell()
            {
                _controller._gameProcessView.ShowBattleStartMessage();
                _controller.TransitionTo<BattleGameProcessState>();
            }

            private void HandleTrapCell()
            {
                var trapType = GameRules.GetTrapType();
                if (GameRules.TryFindTrap(_controller._player))
                {
                    _controller._gameProcessView.ShowSuccessFindTrapMessage(trapType);
                }
                else
                {
                    _controller._gameProcessView.ShowFailFindTrapMessage(trapType);
                    int damage = GameRules.CalculateTrapDamage(trapType, _controller._player);
                    Character character = _controller._player.Character;
                    character.TakeDamage(damage);
                    _controller._logView.AddLog(_controller._localizationService.Message_FirstHitsSecondWithDamage(_controller._localizationService.TrapTypeName(trapType), character.Name, damage, BodyPart.Body));
                }
            }

            private void HandleHiddedLootCell()
            {
                if (GameRules.TryFindHiddenLoot(_controller._player))
                {
                    List<ItemBase> loot = GameRules.CalculateFoundedHiddenLoot(_controller._player);
                    int money = GameRules.CalculateFoundedInHiddenLootMoney(_controller._player);
                    
                    _controller._gameProcessView.ShowSuccessFindHiddenLootMessage(money, loot);
                    _controller._player.Wallet.AddMoney(money);
                    _controller._player.Character.Inventory.AddItems(loot);
                }
            }

            private void HandleHiddenChestCell()
            {
                if (GameRules.TryFindHiddenChest(_controller._player))
                {
                    List<ItemBase> loot = GameRules.CalculateFoundedInHiddenChestLoot(_controller._player);
                    int money = GameRules.CalculateFoundedInHiddenChestMoney(_controller._player);
                    
                    _controller._gameProcessView.ShowSuccessFindHiddenChestMessage(money, loot);
                    _controller._player.Wallet.AddMoney(money);
                    _controller._player.Character.Inventory.AddItems(loot);
                }
            }

            private void HandleLootCell()
            {
                List<ItemBase> loot = GameRules.CalculateFoundedLoot(_controller._player);
                int money = GameRules.CalculateFoundedInLootMoney(_controller._player);

                _controller._gameProcessView.ShowLootCellMessage(money, loot);

                _controller._player.Wallet.AddMoney(money);
                _controller._player.Character.Inventory.AddItems(loot);
            }

            private void HandleLockedChestCell()
            {
                List<ItemBase> loot = GameRules.CalculateFoundedInChestLoot(_controller._player);
                int money = GameRules.CalculateFoundedInChestMoney(_controller._player);

                _controller._gameProcessView.ShowFindChestMessage();
                if (GameRules.TryPickLock(_controller._player))
                {
                    _controller._gameProcessView.ShowSuccessPickLockedChestMessage(money, loot);
                    _controller._player.Wallet.AddMoney(money);
                    _controller._player.Character.Inventory.AddItems(loot);
                }
                else
                {
                    _controller._gameProcessView.ShowFailPickLockedChestMessage();
                    if (GameRules.TryBreakChest(_controller._player))
                    {
                        _controller._gameProcessView.ShowSuccessBreakChestMessage(money, loot);
                        _controller._player.Wallet.AddMoney(money);
                        _controller._player.Character.Inventory.AddItems(loot);
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