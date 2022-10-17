using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Datas.Quest_;

namespace Mini_RPG_Data.Player_;

[Serializable]
public class PlayerData
{
    public PlayerData()
    {
        CharacterData = new CharacterData();
        WalletData = new WalletData();
        QuestsData = new QuestsData();
    }

    public CharacterData CharacterData { get; set; }
    public WalletData WalletData { get; set; }

    public QuestsData QuestsData { get; set; }
}

