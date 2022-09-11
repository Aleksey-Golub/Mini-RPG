using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Services.SaveLoad;

public interface ISaveLoadService : IService
{
    void SaveProgress();
    PlayerProgress? LoadProgressOrNull(string fullFilePath);
    string[] GetAllSaves();
}
