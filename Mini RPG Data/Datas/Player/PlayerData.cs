using Mini_RPG_Data.Character;

namespace Mini_RPG_Data.Player;

[Serializable]
public class PlayerData
{
    public PlayerData()
    {
        CharacterData = new CharacterData();
        Wallet = new Wallet();
    }

    public CharacterData CharacterData { get; }
    public Wallet Wallet { get; }
}

