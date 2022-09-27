namespace Mini_RPG
{
    partial class Trader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trader));
            this._flowLayoutPanel_Inventory = new System.Windows.Forms.FlowLayoutPanel();
            this._flowLayoutPanel_Trader = new System.Windows.Forms.FlowLayoutPanel();
            this._label_Trader = new System.Windows.Forms.Label();
            this._label_Inventory = new System.Windows.Forms.Label();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel_CharacterMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusLabel_TraderMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this._button_Close = new System.Windows.Forms.Button();
            this._toolTip_Inventory = new System.Windows.Forms.ToolTip(this.components);
            this._toolTip_Trader = new System.Windows.Forms.ToolTip(this.components);
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel_Inventory
            // 
            this._flowLayoutPanel_Inventory.AutoScroll = true;
            this._flowLayoutPanel_Inventory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanel_Inventory.Location = new System.Drawing.Point(29, 81);
            this._flowLayoutPanel_Inventory.Name = "_flowLayoutPanel_Inventory";
            this._flowLayoutPanel_Inventory.Size = new System.Drawing.Size(320, 560);
            this._flowLayoutPanel_Inventory.TabIndex = 2;
            // 
            // _flowLayoutPanel_Trader
            // 
            this._flowLayoutPanel_Trader.AutoScroll = true;
            this._flowLayoutPanel_Trader.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanel_Trader.Location = new System.Drawing.Point(1052, 81);
            this._flowLayoutPanel_Trader.Name = "_flowLayoutPanel_Trader";
            this._flowLayoutPanel_Trader.Size = new System.Drawing.Size(320, 560);
            this._flowLayoutPanel_Trader.TabIndex = 4;
            // 
            // _label_Trader
            // 
            this._label_Trader.Location = new System.Drawing.Point(1052, 33);
            this._label_Trader.Name = "_label_Trader";
            this._label_Trader.Size = new System.Drawing.Size(320, 25);
            this._label_Trader.TabIndex = 7;
            this._label_Trader.Text = "% магазин %";
            this._label_Trader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _label_Inventory
            // 
            this._label_Inventory.Location = new System.Drawing.Point(29, 33);
            this._label_Inventory.Name = "_label_Inventory";
            this._label_Inventory.Size = new System.Drawing.Size(320, 25);
            this._label_Inventory.TabIndex = 8;
            this._label_Inventory.Text = "% инвентарь %";
            this._label_Inventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel_CharacterMoney,
            this.toolStripStatusLabel1,
            this._statusLabel_TraderMoney});
            this._statusStrip.Location = new System.Drawing.Point(0, 698);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1401, 36);
            this._statusStrip.TabIndex = 9;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusLabel_CharacterMoney
            // 
            this._statusLabel_CharacterMoney.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._statusLabel_CharacterMoney.Image = global::Mini_RPG.Properties.Resources.Gold_Coin_64x64;
            this._statusLabel_CharacterMoney.Name = "_statusLabel_CharacterMoney";
            this._statusLabel_CharacterMoney.Size = new System.Drawing.Size(80, 29);
            this._statusLabel_CharacterMoney.Text = "1234";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1226, 29);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // _statusLabel_TraderMoney
            // 
            this._statusLabel_TraderMoney.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._statusLabel_TraderMoney.Image = global::Mini_RPG.Properties.Resources.Gold_Coin_64x64;
            this._statusLabel_TraderMoney.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._statusLabel_TraderMoney.Name = "_statusLabel_TraderMoney";
            this._statusLabel_TraderMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._statusLabel_TraderMoney.Size = new System.Drawing.Size(80, 29);
            this._statusLabel_TraderMoney.Text = "1234";
            this._statusLabel_TraderMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _button_Close
            // 
            this._button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._button_Close.Location = new System.Drawing.Point(618, 607);
            this._button_Close.Name = "_button_Close";
            this._button_Close.Size = new System.Drawing.Size(160, 34);
            this._button_Close.TabIndex = 10;
            this._button_Close.Text = "% закрыть %";
            this._button_Close.UseVisualStyleBackColor = true;
            // 
            // Trader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1401, 734);
            this.Controls.Add(this._button_Close);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._label_Inventory);
            this.Controls.Add(this._label_Trader);
            this.Controls.Add(this._flowLayoutPanel_Trader);
            this.Controls.Add(this._flowLayoutPanel_Inventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Trader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlowLayoutPanel _flowLayoutPanel_Inventory;
        private FlowLayoutPanel _flowLayoutPanel_Trader;
        private Label _label_Trader;
        private Label _label_Inventory;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _statusLabel_CharacterMoney;
        private ToolStripStatusLabel _statusLabel_TraderMoney;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button _button_Close;
        private ToolTip _toolTip_Inventory;
        private ToolTip _toolTip_Trader;
    }
}