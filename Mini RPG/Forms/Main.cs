﻿using Mini_RPG.Screens;
using Mini_RPG_Data;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Items;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Enemy;
using Mini_RPG_Data.Services.Quest_;
using Mini_RPG_Data.Services.EventBus;

namespace Mini_RPG;

public partial class Main : Form
{
    private readonly StartScreen _startScreen;
    private readonly CharacterCreationScreen _characterCreationScreen;
    private readonly IntroScreen _introScreen;
    private readonly GameProcessScreen _gameProcessScreen;
    private readonly PlayerDeathScreen _playerDeathScreen;

    private readonly StartScreenController _startScreenController;
    private readonly CharacterCreationScreenController _characterCreationScreenController;

    private AllServices _services;

    public Main()
    {
        InitializeComponent();
        RegisterServices();

        _startScreen = new StartScreen(_services.Single<ILocalizationService>());
        Controls.Add(_startScreen);
        _startScreen.SetActiveState(false);

        _characterCreationScreen = new CharacterCreationScreen(_services.Single<ILocalizationService>());
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.SetActiveState(false);

        _introScreen = new IntroScreen(_services.Single<ILocalizationService>());
        Controls.Add(_introScreen);
        _introScreen.SetActiveState(false);

        _gameProcessScreen = new GameProcessScreen(_services.Single<ILocalizationService>());
        Controls.Add(_gameProcessScreen);
        _gameProcessScreen.SetActiveState(false);

        _startScreenController = new StartScreenController(
            _startScreen, 
            _characterCreationScreen,
            _services.Single<ISaveLoadService>(),
            _services.Single<IPersistentProgressService>());
        _startScreenController.Init();
        _startScreenController.GameLoaded += StartGameProcess;
        _startScreen.SetController(_startScreenController);

        _characterCreationScreenController = new CharacterCreationScreenController(
            _characterCreationScreen, 
            _introScreen,
            _services.Single<IPersistentProgressService>(), 
            _services.Single<IRandomService>(),
            _services.Single<ISaveLoadService>(),
            _services.Single<IQuestService>());
        _characterCreationScreenController.GameStarted += StartGameProcess;
        _characterCreationScreen.SetController(_characterCreationScreenController);
        _characterCreationScreenController.Init();
        _introScreen.SetController(_characterCreationScreenController);

        _playerDeathScreen = new PlayerDeathScreen(_services.Single<ILocalizationService>());
        Controls.Add(_playerDeathScreen);
        _playerDeathScreen.SetActiveState(false);
    }

    private void StartGameProcess()
    {
        var gameProcessController = new GameProcessScreenController(
            _gameProcessScreen, 
            _gameProcessScreen, 
            _gameProcessScreen, 
            _playerDeathScreen, 
            _services.Single<IPersistentProgressService>(),
            _services.Single<ISaveLoadService>(), 
            _services.Single<ILocalizationService>(),
            _services.Single<IRandomService>(),
            _services.Single<IEnemyFactory>(),
            _services.Single<IQuestService>(),
            _services.Single<IEventService>()
            );
        gameProcessController.SaveAndExit += GoToMainMenu;
        gameProcessController.PlayerDied += GoToMainMenu;
        gameProcessController.Run();
    }

    private void GoToMainMenu(GameProcessScreenController oldController)
    {
        oldController.SaveAndExit -= GoToMainMenu;
        oldController.PlayerDied += GoToMainMenu;

        _startScreenController.Init();
        _characterCreationScreenController.Init();
    }

    private void RegisterServices()
    {
        _services = AllServices.Container;

        _services.RegisterSingle<ILocalizationService>(new TxtLocalizationService());
        _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
        _services.RegisterSingle<IRandomService>(new RandomService());
        _services.RegisterSingle<ISaveLoadService>(new JsonFileSaveLoadService(
            _services.Single<IPersistentProgressService>()));
        _services.RegisterSingle<IItemsService>(new JsonItemsService());
        _services.RegisterSingle<IItemFactory>(new ItemFactory(
            _services.Single<IItemsService>(),
            _services.Single<ILocalizationService>()));
        _services.RegisterSingle<IEnemyService>(new JsonEnemyService());
        _services.RegisterSingle<IEnemyFactory>(new EnemyFactory(
            _services.Single<IEnemyService>(),
            _services.Single<IRandomService>()));
        _services.RegisterSingle<IQuestService>(new JsonQuestService());
        _services.RegisterSingle<IEventService>(new EventService());

        GameRules.RandomService = _services.Single<IRandomService>();
        GameRules.ItemFactory = _services.Single<IItemFactory>();
    }
}
