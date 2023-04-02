using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Enemy_;
using Mini_RPG_Data.Datas.Enemy_;
using Mini_RPG_Data.Datas.Enemy_.EnemiesDB;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Services.Enemy;

public class EnemyFactory : IEnemyFactory
{
    private readonly IEnemyService _enemyService;
    private readonly IRandomService _randomService;

    public EnemyFactory(IEnemyService enemyService, IRandomService randomService)
    {
        _enemyService = enemyService;
        _randomService = randomService;
    }

    public ICharacter CreateRandom(IPlayer player)
    {
        int targetLevel = player.Character.Level.Value;
        int randomEnemyLevelRange = GameRules.RANDOM_ENEMY_LEVEL_RANGE;

        ICharacter enemy = null;
        do
        {

            int enemyLevel = _randomService.GetIntInclusive(targetLevel - randomEnemyLevelRange, targetLevel + randomEnemyLevelRange);
            enemyLevel = Math.Clamp(enemyLevel, 1, int.MaxValue);
            EnemyType enemyType = Utils.GetRandomEnumValueExcludeFirst<EnemyType>();

            switch (enemyType)
            {
                case EnemyType.Character:
                    CharacterData? characterData = _enemyService.GetRandomCharacterEnemyDataOrNull(enemyLevel);
                    if (characterData != null)
                        enemy = new Character(characterData);
                    break;
                case EnemyType.Beast:
                    BeastEnemyDataBase? beastData = _enemyService.GetRandomBeastEnemyDataOrNull(enemyLevel);
                    if (beastData != null)
                        enemy = new Beast(beastData);
                    break;
                case EnemyType.None:
                default:
                    throw new NotImplementedException();
            }
        } while (enemy == null);

        enemy.Health.Init();
        return enemy;
    }
}
