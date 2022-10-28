using Mini_RPG_Data.Datas.Quest_;
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
            TownTraderData = new TownTraderData();

            UniqueId = DateTime.Now.GetHashCode().ToString();
        }

        public string UniqueId { get; set; }
        public PlayerData PlayerData { get; set; }
        public MapData MapData { get; set; }
        public TownTraderData TownTraderData { get; set; }

        internal void PrepareForSerialize()
        {
            PlayerData.CharacterData.InventoryData.PrepareForSerialize();
            PlayerData.QuestsData.PrepareForSerialize();
            MapData.PrepareForSerialize();
        }

        internal void PrepareForDeserialize() => MapData.PrepareForDeserialize();
    }
}