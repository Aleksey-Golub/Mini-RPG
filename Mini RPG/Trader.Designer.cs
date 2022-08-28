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
            this.button1 = new System.Windows.Forms.Button();
            this._flowLayoutPanel_Inventory = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this._flowLayoutPanel_Shop = new System.Windows.Forms.FlowLayoutPanel();
            this._label_Shop = new System.Windows.Forms.Label();
            this._label_Inventory = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._statusLabel_CharacterMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusLabel_TraderMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this._button_Close = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Item TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickTEST);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(811, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Item TEST";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // _flowLayoutPanel_Shop
            // 
            this._flowLayoutPanel_Shop.AutoScroll = true;
            this._flowLayoutPanel_Shop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanel_Shop.Location = new System.Drawing.Point(1052, 81);
            this._flowLayoutPanel_Shop.Name = "_flowLayoutPanel_Shop";
            this._flowLayoutPanel_Shop.Size = new System.Drawing.Size(320, 560);
            this._flowLayoutPanel_Shop.TabIndex = 4;
            // 
            // _label_Shop
            // 
            this._label_Shop.Location = new System.Drawing.Point(1052, 33);
            this._label_Shop.Name = "_label_Shop";
            this._label_Shop.Size = new System.Drawing.Size(320, 25);
            this._label_Shop.TabIndex = 7;
            this._label_Shop.Text = "% магазин %";
            this._label_Shop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel_CharacterMoney,
            this.toolStripStatusLabel1,
            this._statusLabel_TraderMoney});
            this.statusStrip1.Location = new System.Drawing.Point(0, 698);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1401, 36);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _statusLabel_CharacterMoney
            // 
            this._statusLabel_CharacterMoney.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._statusLabel_CharacterMoney.Image = global::Mini_RPG.Properties.Resources.Avatar_1;
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
            this._statusLabel_TraderMoney.Image = global::Mini_RPG.Properties.Resources.Avatar_1;
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
            this.ControlBox = false;
            this.Controls.Add(this._button_Close);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._label_Inventory);
            this.Controls.Add(this._label_Shop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._flowLayoutPanel_Shop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._flowLayoutPanel_Inventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Trader";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private FlowLayoutPanel _flowLayoutPanel_Inventory;
        private Button button2;
        private FlowLayoutPanel _flowLayoutPanel_Shop;
        private Label _label_Shop;
        private Label _label_Inventory;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel _statusLabel_CharacterMoney;
        private ToolStripStatusLabel _statusLabel_TraderMoney;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button _button_Close;
    }
}