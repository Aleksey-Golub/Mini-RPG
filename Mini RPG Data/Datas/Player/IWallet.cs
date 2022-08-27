namespace Mini_RPG_Data.Player;

public interface IWallet
{
    int Money { get; }

    event Action<int>? MoneyChanged;
}

