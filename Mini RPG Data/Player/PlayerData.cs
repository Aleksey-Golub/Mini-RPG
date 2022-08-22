using Mini_RPG_Data.Character;

namespace Mini_RPG_Data.Player;

public class PlayerData
{
    public PlayerData(CharacterData characterData)
    {
        CharacterData = characterData;
        Wallet = new Wallet();
    }

    public CharacterData CharacterData { get; }
    public Wallet Wallet { get; }
}

