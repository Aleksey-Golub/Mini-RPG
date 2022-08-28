using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Services.PersistentProgress;

public class PersistentProgressService : IPersistentProgressService
{
    public PlayerProgress Progress { get; set; } = null!;
}
