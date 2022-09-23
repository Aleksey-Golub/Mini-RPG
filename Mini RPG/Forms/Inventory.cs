namespace Mini_RPG;

public partial class Inventory : Form
{
    public Inventory()
    {
        InitializeComponent();

        ShowInventory();
    }

    private void ShowInventory()
    {
        // получить модель инвентаря и отрисовать
    }

    int counter = 0;
    private void AddItemButton1_Click_TEST(object sender, EventArgs e)
    {
        string itemDescription = $"item description {counter++}";

        var btn = new Button();
        btn.Size = new Size(100, 100);
        btn.Text = itemDescription;

        _flowLayoutPanel_Inventory.Controls.Add(btn);
    }
}
