namespace Mini_RPG.Screens
{
    partial class GameProcessScreen
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._panel_Navigation = new System.Windows.Forms.Panel();
            this._button_Rest = new System.Windows.Forms.Button();
            this._button_E = new System.Windows.Forms.Button();
            this._button_W = new System.Windows.Forms.Button();
            this._button_S = new System.Windows.Forms.Button();
            this._button_N = new System.Windows.Forms.Button();
            this._panel_MiniMap = new System.Windows.Forms.Panel();
            this._label_Map = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._label_Strength = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_StrengthPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Dexterity = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_DexterityPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Constitution = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_ConstitutionPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Perception = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_PerceptionPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Charisma = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_CharismaPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Money = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_Health = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._button_Inventory = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItem_SaveAndExit = new System.Windows.Forms.ToolStripMenuItem();
            this._panel_Location = new System.Windows.Forms.Panel();
            this._pictureBox_Enemy = new System.Windows.Forms.PictureBox();
            this._flowLayoutPanel_GameLog = new System.Windows.Forms.FlowLayoutPanel();
            this._panel_Town = new System.Windows.Forms.Panel();
            this._button_RestInTown = new System.Windows.Forms.Button();
            this._button_Trader = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this._panel_Navigation.SuspendLayout();
            this._panel_MiniMap.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._panel_Location.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_Enemy)).BeginInit();
            this._panel_Town.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel_Navigation
            // 
            this._panel_Navigation.Controls.Add(this._button_Rest);
            this._panel_Navigation.Controls.Add(this._button_E);
            this._panel_Navigation.Controls.Add(this._button_W);
            this._panel_Navigation.Controls.Add(this._button_S);
            this._panel_Navigation.Controls.Add(this._button_N);
            this._panel_Navigation.Location = new System.Drawing.Point(1476, 650);
            this._panel_Navigation.Name = "_panel_Navigation";
            this._panel_Navigation.Size = new System.Drawing.Size(380, 335);
            this._panel_Navigation.TabIndex = 0;
            // 
            // _button_Rest
            // 
            this._button_Rest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button_Rest.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_Rest.Location = new System.Drawing.Point(100, 150);
            this._button_Rest.MaximumSize = new System.Drawing.Size(180, 50);
            this._button_Rest.MinimumSize = new System.Drawing.Size(180, 50);
            this._button_Rest.Name = "_button_Rest";
            this._button_Rest.Size = new System.Drawing.Size(180, 50);
            this._button_Rest.TabIndex = 4;
            this._button_Rest.Text = "% отдых %";
            this._button_Rest.UseVisualStyleBackColor = true;
            // 
            // _button_E
            // 
            this._button_E.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button_E.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_E.Location = new System.Drawing.Point(280, 150);
            this._button_E.MaximumSize = new System.Drawing.Size(50, 50);
            this._button_E.MinimumSize = new System.Drawing.Size(50, 50);
            this._button_E.Name = "_button_E";
            this._button_E.Size = new System.Drawing.Size(50, 50);
            this._button_E.TabIndex = 3;
            this._button_E.Text = "E";
            this._button_E.UseVisualStyleBackColor = true;
            // 
            // _button_W
            // 
            this._button_W.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button_W.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_W.Location = new System.Drawing.Point(50, 150);
            this._button_W.MaximumSize = new System.Drawing.Size(50, 50);
            this._button_W.MinimumSize = new System.Drawing.Size(50, 50);
            this._button_W.Name = "_button_W";
            this._button_W.Size = new System.Drawing.Size(50, 50);
            this._button_W.TabIndex = 2;
            this._button_W.Text = "W";
            this._button_W.UseVisualStyleBackColor = true;
            // 
            // _button_S
            // 
            this._button_S.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button_S.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_S.Location = new System.Drawing.Point(165, 224);
            this._button_S.MaximumSize = new System.Drawing.Size(50, 50);
            this._button_S.MinimumSize = new System.Drawing.Size(50, 50);
            this._button_S.Name = "_button_S";
            this._button_S.Size = new System.Drawing.Size(50, 50);
            this._button_S.TabIndex = 1;
            this._button_S.Text = "S";
            this._button_S.UseVisualStyleBackColor = true;
            // 
            // _button_N
            // 
            this._button_N.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button_N.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_N.Location = new System.Drawing.Point(165, 64);
            this._button_N.MaximumSize = new System.Drawing.Size(50, 50);
            this._button_N.MinimumSize = new System.Drawing.Size(50, 50);
            this._button_N.Name = "_button_N";
            this._button_N.Size = new System.Drawing.Size(50, 50);
            this._button_N.TabIndex = 0;
            this._button_N.Text = "N";
            this._button_N.UseVisualStyleBackColor = true;
            // 
            // _panel_MiniMap
            // 
            this._panel_MiniMap.Controls.Add(this._label_Map);
            this._panel_MiniMap.Location = new System.Drawing.Point(1541, 103);
            this._panel_MiniMap.Name = "_panel_MiniMap";
            this._panel_MiniMap.Size = new System.Drawing.Size(250, 250);
            this._panel_MiniMap.TabIndex = 1;
            // 
            // _label_Map
            // 
            this._label_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this._label_Map.Location = new System.Drawing.Point(0, 0);
            this._label_Map.Name = "_label_Map";
            this._label_Map.Size = new System.Drawing.Size(250, 250);
            this._label_Map.TabIndex = 0;
            this._label_Map.Text = "OOOOO\r\n      O      \r\nQQQQQ\r\nOO@OO\r\nOOMOO";
            this._label_Map.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1562, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 208);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(162, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 180);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(33, 180);
            this.panel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 180);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._label_Strength,
            this._label_StrengthPoints,
            this._label_Dexterity,
            this._label_DexterityPoints,
            this._label_Constitution,
            this._label_ConstitutionPoints,
            this._label_Perception,
            this._label_PerceptionPoints,
            this._label_Charisma,
            this._label_CharismaPoints,
            this._label_Money,
            this._label_Health});
            this._statusStrip.Location = new System.Drawing.Point(0, 988);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.ShowItemToolTips = true;
            this._statusStrip.Size = new System.Drawing.Size(1898, 36);
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _label_Strength
            // 
            this._label_Strength.Name = "_label_Strength";
            this._label_Strength.Size = new System.Drawing.Size(88, 29);
            this._label_Strength.Text = "% сила %";
            // 
            // _label_StrengthPoints
            // 
            this._label_StrengthPoints.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_StrengthPoints.Name = "_label_StrengthPoints";
            this._label_StrengthPoints.Size = new System.Drawing.Size(36, 29);
            this._label_StrengthPoints.Text = "00";
            // 
            // _label_Dexterity
            // 
            this._label_Dexterity.Name = "_label_Dexterity";
            this._label_Dexterity.Size = new System.Drawing.Size(126, 29);
            this._label_Dexterity.Text = "% ловкость %";
            // 
            // _label_DexterityPoints
            // 
            this._label_DexterityPoints.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_DexterityPoints.Name = "_label_DexterityPoints";
            this._label_DexterityPoints.Size = new System.Drawing.Size(36, 29);
            this._label_DexterityPoints.Text = "00";
            // 
            // _label_Constitution
            // 
            this._label_Constitution.Name = "_label_Constitution";
            this._label_Constitution.Size = new System.Drawing.Size(168, 29);
            this._label_Constitution.Text = "% выносливость %";
            // 
            // _label_ConstitutionPoints
            // 
            this._label_ConstitutionPoints.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_ConstitutionPoints.Name = "_label_ConstitutionPoints";
            this._label_ConstitutionPoints.Size = new System.Drawing.Size(36, 29);
            this._label_ConstitutionPoints.Text = "00";
            // 
            // _label_Perception
            // 
            this._label_Perception.Name = "_label_Perception";
            this._label_Perception.Size = new System.Drawing.Size(147, 29);
            this._label_Perception.Text = "% восприятие %";
            // 
            // _label_PerceptionPoints
            // 
            this._label_PerceptionPoints.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_PerceptionPoints.Name = "_label_PerceptionPoints";
            this._label_PerceptionPoints.Size = new System.Drawing.Size(36, 29);
            this._label_PerceptionPoints.Text = "00";
            // 
            // _label_Charisma
            // 
            this._label_Charisma.Name = "_label_Charisma";
            this._label_Charisma.Size = new System.Drawing.Size(120, 29);
            this._label_Charisma.Text = "% харизма %";
            // 
            // _label_CharismaPoints
            // 
            this._label_CharismaPoints.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_CharismaPoints.Name = "_label_CharismaPoints";
            this._label_CharismaPoints.Size = new System.Drawing.Size(36, 29);
            this._label_CharismaPoints.Text = "00";
            // 
            // _label_Money
            // 
            this._label_Money.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_Money.Image = global::Mini_RPG.Properties.Resources.Аватар_персонажа_1;
            this._label_Money.Name = "_label_Money";
            this._label_Money.Size = new System.Drawing.Size(90, 29);
            this._label_Money.Text = "00000";
            // 
            // _label_Health
            // 
            this._label_Health.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_Health.Image = global::Mini_RPG.Properties.Resources.Аватар_персонажа_4;
            this._label_Health.Name = "_label_Health";
            this._label_Health.Size = new System.Drawing.Size(87, 29);
            this._label_Health.Text = "00/00";
            this._label_Health.ToolTipText = "1323214";
            // 
            // _button_Inventory
            // 
            this._button_Inventory.Location = new System.Drawing.Point(1606, 593);
            this._button_Inventory.Name = "_button_Inventory";
            this._button_Inventory.Size = new System.Drawing.Size(112, 34);
            this._button_Inventory.TabIndex = 5;
            this._button_Inventory.UseVisualStyleBackColor = true;
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItem_Menu});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1898, 33);
            this._menuStrip.TabIndex = 6;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _menuItem_Menu
            // 
            this._menuItem_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItem_SaveAndExit});
            this._menuItem_Menu.Name = "_menuItem_Menu";
            this._menuItem_Menu.Size = new System.Drawing.Size(115, 29);
            this._menuItem_Menu.Text = "% меню %";
            // 
            // _menuItem_SaveAndExit
            // 
            this._menuItem_SaveAndExit.Name = "_menuItem_SaveAndExit";
            this._menuItem_SaveAndExit.Size = new System.Drawing.Size(307, 34);
            this._menuItem_SaveAndExit.Text = "% сохранить и выйти %";
            this._menuItem_SaveAndExit.Click += new System.EventHandler(this.MenuItem_SaveAndExit_Click);
            // 
            // _panel_Location
            // 
            this._panel_Location.BackColor = System.Drawing.SystemColors.ControlDark;
            this._panel_Location.Controls.Add(this._pictureBox_Enemy);
            this._panel_Location.Controls.Add(this._flowLayoutPanel_GameLog);
            this._panel_Location.Location = new System.Drawing.Point(93, 55);
            this._panel_Location.Name = "_panel_Location";
            this._panel_Location.Size = new System.Drawing.Size(1334, 766);
            this._panel_Location.TabIndex = 7;
            // 
            // _pictureBox_Enemy
            // 
            this._pictureBox_Enemy.Location = new System.Drawing.Point(455, 174);
            this._pictureBox_Enemy.Name = "_pictureBox_Enemy";
            this._pictureBox_Enemy.Size = new System.Drawing.Size(312, 398);
            this._pictureBox_Enemy.TabIndex = 0;
            this._pictureBox_Enemy.TabStop = false;
            this._pictureBox_Enemy.Visible = false;
            // 
            // _flowLayoutPanel_GameLog
            // 
            this._flowLayoutPanel_GameLog.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this._flowLayoutPanel_GameLog.Location = new System.Drawing.Point(3, 28);
            this._flowLayoutPanel_GameLog.Name = "_flowLayoutPanel_GameLog";
            this._flowLayoutPanel_GameLog.Size = new System.Drawing.Size(414, 735);
            this._flowLayoutPanel_GameLog.TabIndex = 1;
            // 
            // _panel_Town
            // 
            this._panel_Town.Controls.Add(this._button_RestInTown);
            this._panel_Town.Controls.Add(this._button_Trader);
            this._panel_Town.Location = new System.Drawing.Point(1081, 835);
            this._panel_Town.Name = "_panel_Town";
            this._panel_Town.Size = new System.Drawing.Size(346, 131);
            this._panel_Town.TabIndex = 8;
            // 
            // _button_RestInTown
            // 
            this._button_RestInTown.Location = new System.Drawing.Point(62, 78);
            this._button_RestInTown.Name = "_button_RestInTown";
            this._button_RestInTown.Size = new System.Drawing.Size(229, 34);
            this._button_RestInTown.TabIndex = 1;
            this._button_RestInTown.Text = "% отдыхать в городе %";
            this._button_RestInTown.UseVisualStyleBackColor = true;
            // 
            // _button_Trader
            // 
            this._button_Trader.Location = new System.Drawing.Point(62, 21);
            this._button_Trader.Name = "_button_Trader";
            this._button_Trader.Size = new System.Drawing.Size(229, 34);
            this._button_Trader.TabIndex = 0;
            this._button_Trader.Text = "% торговец %";
            this._button_Trader.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 827);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add log";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddLogTest);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(226, 827);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "Switch log size";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SwitchLogState);
            // 
            // GameProcessScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mini_RPG.Properties.Resources.Макет_локация_вне_города;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._panel_Town);
            this.Controls.Add(this._panel_Location);
            this.Controls.Add(this._button_Inventory);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._panel_MiniMap);
            this.Controls.Add(this._panel_Navigation);
            this.DoubleBuffered = true;
            this.Name = "GameProcessScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this._panel_Navigation.ResumeLayout(false);
            this._panel_MiniMap.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._panel_Location.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_Enemy)).EndInit();
            this._panel_Town.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel _panel_Navigation;
        private Button _button_Rest;
        private Button _button_E;
        private Button _button_W;
        private Button _button_S;
        private Button _button_N;
        private Panel _panel_MiniMap;
        private Label _label_Map;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _label_Strength;
        private ToolStripStatusLabel _label_StrengthPoints;
        private ToolStripStatusLabel _label_Dexterity;
        private ToolStripStatusLabel _label_DexterityPoints;
        private ToolStripStatusLabel _label_Constitution;
        private ToolStripStatusLabel _label_ConstitutionPoints;
        private ToolStripStatusLabel _label_Perception;
        private ToolStripStatusLabel _label_PerceptionPoints;
        private ToolStripStatusLabel _label_Charisma;
        private ToolStripStatusLabel _label_CharismaPoints;
        private ToolStripStatusLabel _label_Money;
        private ToolStripStatusLabel _label_Health;
        private ToolTip _toolTip;
        private Button _button_Inventory;
        private MenuStrip _menuStrip;
        private ToolStripMenuItem _menuItem_Menu;
        private ToolStripMenuItem _menuItem_SaveAndExit;
        private Panel _panel_Location;
        private PictureBox _pictureBox_Enemy;
        private Panel _panel_Town;
        private Button _button_RestInTown;
        private Button _button_Trader;
        private FlowLayoutPanel _flowLayoutPanel_GameLog;
        private Button button2;
        private Button button3;
    }
}
