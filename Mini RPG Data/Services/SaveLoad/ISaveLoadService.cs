using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Player_;

namespace Mini_RPG_Data.Services.SaveLoad;

public interface ISaveLoadService : IService
{
    void SaveProgress();
    PlayerProgress? LoadProgressOrNull();
    PlayerData? LoadPlayerDataOrNull();
    MapData? LoadMapDataOrNull();
}
