namespace Mini_RPG_Data.Controllers;

public interface IWallet
{
    int Money { get; }

    event Action<int>? MoneyChanged;
}

