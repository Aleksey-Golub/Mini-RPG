namespace Mini_RPG_Data.Player;

public class Wallet : IWallet
{
    public int Money { get; private set; }

    public event Action<int>? MoneyChanged;

    public void AddMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Money += count;
        MoneyChanged?.Invoke(Money);
    }

    public void RemoveMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (Money < count)
            throw new InvalidOperationException("Money count less then you try to remove");

        Money -= count;
        MoneyChanged?.Invoke(Money);
    }
}

