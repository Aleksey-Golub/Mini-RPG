using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Player;

[Serializable]
public class PlayerData
{
    public PlayerData()
    {
        Character = new CharacterData();
        Wallet = new Wallet();
    }

    public CharacterData Character { get; }
    public Wallet Wallet { get; }
}

