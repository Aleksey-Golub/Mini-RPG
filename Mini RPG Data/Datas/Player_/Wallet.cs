namespace Mini_RPG_Data.Player_;

public class Wallet : IWallet
{
    private readonly WalletData _data;

    internal Wallet(WalletData data)
    {
        _data = data;
    }

    public int Money => _data.Money;

    public event Action<int>? MoneyChanged;

    internal void AddMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        _data.Money += count;
        MoneyChanged?.Invoke(Money);
    }

    internal void RemoveMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (Money < count)
            throw new InvalidOperationException("Money count less then you try to remove");

        _data.Money -= count;
        MoneyChanged?.Invoke(Money);
    }
}
