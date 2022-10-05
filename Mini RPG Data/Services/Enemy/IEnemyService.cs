using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Datas.Enemy_.EnemiesDB;

namespace Mini_RPG_Data.Services.Enemy;

public interface IEnemyService : IService
{
    BeastEnemyDataBase? GetRandomBeastEnemyDataOrNull(int enemyLevel);
    CharacterData? GetRandomCharacterEnemyDataOrNull(int enemyLevel);
}
