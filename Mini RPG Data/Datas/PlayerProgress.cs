using Mini_RPG_Data.Map;
using Mini_RPG_Data.Player;

namespace Mini_RPG_Data.Datas
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress(MapData mapData)
        {
            MapData = mapData;
            PlayerData = new PlayerData();
        }

        public PlayerData PlayerData { get; private set; } = null!;
        public MapData MapData { get; private set; } = null!;
    }
}