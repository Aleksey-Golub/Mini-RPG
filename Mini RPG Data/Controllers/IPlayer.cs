using Mini_RPG_Data.Controllers.Character_;

namespace Mini_RPG_Data.Controllers;

public interface IPlayer
{
    IWallet Wallet { get; }
    ICharacter Character { get; }
}

