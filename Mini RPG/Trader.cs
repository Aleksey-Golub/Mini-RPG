namespace Mini_RPG;

public partial class Trader : Form
{
    public Trader()
    {
        InitializeComponent();

        FillInventory();
        FillShop();
    }

    int counter = 0;
    private void button1_ClickTEST(object sender, EventArgs e)
    {
        string itemDescription = $"item description {counter++}";

        var btn = new Button();
        btn.Size = new Size(100, 100);
        btn.Text = itemDescription;

        _flowLayoutPanel_Inventory.Controls.Add(btn);
    }

    private void FillInventory()
    {
        // создать кнопки под предметы инвентаря
    }

    private void FillShop()
    {
        // создать кнопки под предметы магазина
    }
}
