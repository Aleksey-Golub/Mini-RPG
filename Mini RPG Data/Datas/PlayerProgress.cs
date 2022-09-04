using Mini_RPG_Data.Map;
using Mini_RPG_Data.Player_;

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

        public PlayerData PlayerData { get; set; }
        public MapData MapData { get; set; }
    }
}