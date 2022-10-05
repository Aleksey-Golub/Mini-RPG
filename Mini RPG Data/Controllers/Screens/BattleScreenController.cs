//using Mini_RPG_Data.Controllers.Character_;
//using Mini_RPG_Data.Controllers.Enemy_;
//using Mini_RPG_Data.Services.Localization;
//using Mini_RPG_Data.Services.Random_;
//using Mini_RPG_Data.Viewes;

//namespace Mini_RPG_Data.Controllers.Screens;

//public class BattleScreenController
//{
//    private readonly IRandomService _randomService;

//    private readonly IBattleView _battleView;
//    private readonly ILogView _logView;

//    private readonly ICharacter _character;
//    private readonly ICharacter _enemy;
//    private readonly GameProcessScreenController _gameController;

//    public BattleScreenController(IRandomService randomService, GameProcessScreenController gameController, IBattleView battleView, ILogView logView, IPlayer player, ICharacter enemy)
//    {
//        _randomService = randomService;
//        _gameController = gameController;
//        _battleView = battleView;
//        _logView = logView;
//        _character = player.Character;
//        _character.Died += OnCharacterDied;
//        _enemy = enemy;
//        _enemy.Died += OnEnemyDied;
//    }

//    private void OnEnemyDied(Character enemy)
//    {
//        throw new NotImplementedException();
//    }

//    private void OnCharacterDied(Character playerCharacter)
//    {
//        throw new NotImplementedException();
//    }

//    public void AttackEnemy()
//    {
//        Run(PlayerAttactEnemy());
//    }

//    public void TryLeaveBattle()
//    {
//        Run(PlayerTryKeaveBattle());
//    }

//    private void Run(Action playerAction)
//    {
//        // определить инициативу
//        int playerInitiative = Settings.CalculateInitiative(_character);
//        int enemyInitiative = Settings.CalculateInitiative(_enemy);
//        // ход первого

//        // ход второго
//    }

//    private Action PlayerAttactEnemy()
//    {
//        throw new NotImplementedException();
//    }

//    private Action PlayerTryKeaveBattle()
//    {
//        throw new NotImplementedException();
//    }

//}
