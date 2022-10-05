//using Mini_RPG_Data.Controllers;
//using Mini_RPG_Data.Controllers.Enemy_;
//using Mini_RPG_Data.Controllers.Screens;
//using Mini_RPG_Data.Services;
//using Mini_RPG_Data.Services.Enemy;
//using Mini_RPG_Data.Services.Random_;
//using Mini_RPG_Data.Viewes;

//namespace Mini_RPG.Screens;

//internal class BattleView : IBattleView
//{
//    private readonly Panel _panel_Battle;
//    private readonly Panel _panel_BattleActions;
//    private readonly Button _button_Attack;
//    private readonly Button _button_TryLeaveBattle;
//    private readonly PictureBox _pictureBox_Enemy;

//    private readonly GameProcessScreenController _gameController;
//    private readonly ILogView _logView;
//    private readonly IGameProcessView _gameProcessView;
//    private BattleScreenController _controller;

//    public BattleView(
//        Panel panel_Battle, 
//        Panel panel_BattleActions, 
//        Button button_Attack, 
//        Button button_TryLeaveBattle, 
//        PictureBox pictureBox_Enemy, 
//        GameProcessScreenController gameController, 
//        ILogView logView)
//    {
//        _panel_Battle = panel_Battle;
//        _panel_BattleActions = panel_BattleActions;
//        _button_Attack = button_Attack;
//        _button_TryLeaveBattle = button_TryLeaveBattle;
//        _pictureBox_Enemy = pictureBox_Enemy;
        
//        _gameController = gameController;
//        _logView = logView;
        
//        _panel_Battle.Hide();
//        _panel_BattleActions.Hide();
//    }

//    public void View(IPlayer player, EnemyBase enemy)
//    {
//        _pictureBox_Enemy.BackgroundImage = ImageManager.GetEnemyImage(enemy);

//        _panel_Battle.Show();
//        _panel_BattleActions.Show();

//        _button_Attack.Click += Button_Attack_Click;
//        _button_TryLeaveBattle.Click += Button_TryLeaveBattle_Click;

//        _controller = new BattleScreenController(AllServices.Container.Single<IRandomService>(), _gameController, this, _logView, player, enemy);
//    }

//    public void Hide()
//    {
//        _panel_Battle.Hide();
//        _panel_BattleActions.Hide();

//        _button_Attack.Click -= Button_Attack_Click;
//        _button_TryLeaveBattle.Click -= Button_TryLeaveBattle_Click;

//        _controller = null;
//    }

//    private void Button_Attack_Click(object? sender, EventArgs e) => _controller.AttackEnemy();
//    private void Button_TryLeaveBattle_Click(object? sender, EventArgs e) => _controller.TryLeaveBattle();
//}
