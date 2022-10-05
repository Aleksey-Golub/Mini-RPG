using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;

namespace Mini_RPG_Data.Services.Enemy;

public interface IEnemyFactory : IService
{
    ICharacter CreateRandom(IPlayer player);
}
