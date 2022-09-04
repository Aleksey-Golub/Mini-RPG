namespace Mini_RPG_Data.Player_;

public interface IWallet
{
    int Money { get; }

    event Action<int>? MoneyChanged;
}

