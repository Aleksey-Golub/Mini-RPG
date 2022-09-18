using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Player_;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Controllers;

public class Player : IPlayer
{
    private readonly PlayerData _data;

    public Wallet Wallet { get; private set; }
    public Character Character { get; private set; }

    IWallet IPlayer.Wallet => Wallet;
    ICharacter IPlayer.Character => Character;

    public Player(PlayerData data)
    {
        _data = data;

        Wallet = new Wallet(data.WalletData);
        Character = new Character(data.CharacterData);
    }

    internal void Init()
    {
        Character.Init();
    }

    internal bool TryRestoreHealth() => Character.TryRestoreHealth();
    internal void UpdateEffects() => Character.UpdateEffects();
}

