using Mini_RPG_Data.Controllers.Inventory_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Items;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers.Screens;

public class TraderScreenController
{
    private readonly ITradeView _traderView;
    private readonly Player _player;

    private readonly TownTraderData _data;
    private readonly Wallet _traderWallet;

    public Inventory TraderInventory { get; private set; }
    public IWallet TraderWallet => _traderWallet;

    public TraderScreenController(IPlayer player, ITradeView traderView)
    {
        _player = player as Player;
        _traderView = traderView;

        _data = AllServices.Container.Single<IPersistentProgressService>().Progress.TownTraderData;
        _traderWallet = new Wallet(_data.WalletData);
        TraderInventory = new Inventory(AllServices.Container.Single<IItemFactory>(), _data.InventoryData);
    }

    public bool TrySell(ItemBase item)
    {
        int itemCost = item.Cost;
        int finalItemCost = Settings.CalculateItemCostModifier(itemCost, _player);

        if (TraderWallet.Money >= finalItemCost)
        {
            _player.Character.Inventory.RemoveItem(item);
            TraderInventory.AddItem(item);

            _player.Wallet.AddMoney(finalItemCost);
            _traderWallet.RemoveMoney(finalItemCost);
            _traderView.ShowTraderInventory();
            _traderView.ShowInventory();
            return true;
        }

        return false;
    }

    public bool TryBuy(ItemBase item)
    {
        int itemCost = item.Cost;

        if (_player.Wallet.Money >= itemCost)
        {
            _player.Character.Inventory.AddItem(item);
            TraderInventory.RemoveItem(item);

            _player.Wallet.RemoveMoney(item.Cost);
            _traderWallet.AddMoney(item.Cost);
            _traderView.ShowTraderInventory();
            _traderView.ShowInventory();
            return true;
        }

        return false;
    }
}
