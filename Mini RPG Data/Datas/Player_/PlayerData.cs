using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Player_;

[Serializable]
public class PlayerData
{
    public PlayerData()
    {
        CharacterData = new CharacterData();
        WalletData = new WalletData();
    }

    public CharacterData CharacterData { get; set; }
    public WalletData WalletData { get; set; }
}

