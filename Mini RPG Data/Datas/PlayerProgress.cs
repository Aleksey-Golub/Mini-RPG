using Mini_RPG_Data.Map;
using Mini_RPG_Data.Player;

namespace Mini_RPG_Data.Datas
{
    [Serializable]
    public class PlayerProgress
    {
        internal PlayerData PlayerData { get; set; } = null!;
        internal MapData MapData { get; set; } = null!;
    }
}