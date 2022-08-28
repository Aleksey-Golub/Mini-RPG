using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Services.PersistentProgress;

public interface IPersistentProgressService : IService
{
    PlayerProgress Progress {get; set;}
}
