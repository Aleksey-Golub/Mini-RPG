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
            this._panel_Character = new System.Windows.Forms.Panel();
            this._pictureBox_HasFreeAbilityActions = new System.Windows.Forms.PictureBox();
            this._panel_CharacterHealthBarBG = new System.Windows.Forms.Panel();
            this._panel_CharacterHealthBarFG = new System.Windows.Forms.Panel();
            this._button_CharacterProgress = new System.Windows.Forms.Button();
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
            this._label_HungerLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this._label_ThirstLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._button_Inventory = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItem_SaveAndExit = new System.Windows.Forms.ToolStripMenuItem();
            this._panel_Location = new System.Windows.Forms.Panel();
            this._panel_Battle = new System.Windows.Forms.Panel();
            this._pictureBox_Enemy = new System.Windows.Forms.PictureBox();
            this._flowLayoutPanel_GameLog = new System.Windows.Forms.FlowLayoutPanel();
            this._panel_Town = new System.Windows.Forms.Panel();
            this._button_RestInTown = new System.Windows.Forms.Button();
            this._button_LeaveTown = new System.Windows.Forms.Button();
            this._button_Trader = new System.Windows.Forms.Button();
            this._button_SwitchLogSize = new System.Windows.Forms.Button();
            this._panel_BattleActions = new System.Windows.Forms.Panel();
            this._button_TryLeaveBattle = new System.Windows.Forms.Button();
            this._button_Attack = new System.Windows.Forms.Button();
            this._panel_TownEntrance = new System.Windows.Forms.Panel();
            this._button_EnterTown = new System.Windows.Forms.Button();
            this._panel_Navigation.SuspendLayout();
            this._panel_MiniMap.SuspendLayout();
            this._panel_Character.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_HasFreeAbilityActions)).BeginInit();
            this._panel_CharacterHealthBarBG.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._panel_Location.SuspendLayout();
            this._panel_Battle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_Enemy)).BeginInit();
            this._panel_Town.SuspendLayout();
            this._panel_BattleActions.SuspendLayout();
            this._panel_TownEntrance.SuspendLayout();
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
            this._button_Rest.Click += new System.EventHandler(this.Button_Rest_Click);
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
            this._button_E.Click += new System.EventHandler(this.Button_E_Click);
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
            this._button_W.Click += new System.EventHandler(this.Button_W_Click);
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
            this._button_S.Click += new System.EventHandler(this.Button_S_Click);
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
            this._button_N.Click += new System.EventHandler(this.Button_N_Click);
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
            this._label_Map.Text = "QQQQQQQQQQQ\r\nQQQQQQQQQQQ\r\nOONOOOOONQQ\r\nOON      O      NQQ\r\nOONQQ@QQNQQ\r\nOONOOQOO" +
    "NOO\r\nOONOOMOONQQ\r\nOONOOOOONQQ\r\nOOOOOOOOOQQ";
            this._label_Map.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._label_Map.Click += new System.EventHandler(this.Label_Map_Click);
            // 
            // _panel_Character
            // 
            this._panel_Character.Controls.Add(this._pictureBox_HasFreeAbilityActions);
            this._panel_Character.Controls.Add(this._panel_CharacterHealthBarBG);
            this._panel_Character.Controls.Add(this._button_CharacterProgress);
            this._panel_Character.Location = new System.Drawing.Point(1562, 369);
            this._panel_Character.Name = "_panel_Character";
            this._panel_Character.Size = new System.Drawing.Size(203, 208);
            this._panel_Character.TabIndex = 2;
            // 
            // _pictureBox_HasFreeAbilityActions
            // 
            this._pictureBox_HasFreeAbilityActions.BackgroundImage = global::Mini_RPG.Properties.Resources.level_up;
            this._pictureBox_HasFreeAbilityActions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pictureBox_HasFreeAbilityActions.Location = new System.Drawing.Point(111, 147);
            this._pictureBox_HasFreeAbilityActions.Name = "_pictureBox_HasFreeAbilityActions";
            this._pictureBox_HasFreeAbilityActions.Size = new System.Drawing.Size(40, 40);
            this._pictureBox_HasFreeAbilityActions.TabIndex = 2;
            this._pictureBox_HasFreeAbilityActions.TabStop = false;
            this._pictureBox_HasFreeAbilityActions.Visible = false;
            // 
            // _panel_CharacterHealthBarBG
            // 
            this._panel_CharacterHealthBarBG.BackColor = System.Drawing.Color.Red;
            this._panel_CharacterHealthBarBG.Controls.Add(this._panel_CharacterHealthBarFG);
            this._panel_CharacterHealthBarBG.Location = new System.Drawing.Point(162, 12);
            this._panel_CharacterHealthBarBG.Name = "_panel_CharacterHealthBarBG";
            this._panel_CharacterHealthBarBG.Size = new System.Drawing.Size(33, 180);
            this._panel_CharacterHealthBarBG.TabIndex = 1;
            // 
            // _panel_CharacterHealthBarFG
            // 
            this._panel_CharacterHealthBarFG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._panel_CharacterHealthBarFG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panel_CharacterHealthBarFG.Location = new System.Drawing.Point(0, 0);
            this._panel_CharacterHealthBarFG.Name = "_panel_CharacterHealthBarFG";
            this._panel_CharacterHealthBarFG.Size = new System.Drawing.Size(33, 180);
            this._panel_CharacterHealthBarFG.TabIndex = 2;
            // 
            // _button_CharacterProgress
            // 
            this._button_CharacterProgress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._button_CharacterProgress.Location = new System.Drawing.Point(14, 14);
            this._button_CharacterProgress.Name = "_button_CharacterProgress";
            this._button_CharacterProgress.Size = new System.Drawing.Size(142, 175);
            this._button_CharacterProgress.TabIndex = 0;
            this._button_CharacterProgress.UseVisualStyleBackColor = true;
            this._button_CharacterProgress.Click += new System.EventHandler(this.Button_CharacterProgress_Click);
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
            this._label_Health,
            this._label_HungerLevel,
            this._label_ThirstLevel});
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
            this._label_Money.Image = global::Mini_RPG.Properties.Resources.Gold_Coin_64x64;
            this._label_Money.Name = "_label_Money";
            this._label_Money.Size = new System.Drawing.Size(90, 29);
            this._label_Money.Text = "00000";
            // 
            // _label_Health
            // 
            this._label_Health.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_Health.Image = global::Mini_RPG.Properties.Resources.Health_64x64;
            this._label_Health.Name = "_label_Health";
            this._label_Health.Size = new System.Drawing.Size(87, 29);
            this._label_Health.Text = "00/00";
            // 
            // _label_HungerLevel
            // 
            this._label_HungerLevel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_HungerLevel.Image = global::Mini_RPG.Properties.Resources.HungerLevel_64x64;
            this._label_HungerLevel.Name = "_label_HungerLevel";
            this._label_HungerLevel.Size = new System.Drawing.Size(128, 29);
            this._label_HungerLevel.Text = "% голод %";
            // 
            // _label_ThirstLevel
            // 
            this._label_ThirstLevel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._label_ThirstLevel.Image = global::Mini_RPG.Properties.Resources.ThirstLevel_64x64;
            this._label_ThirstLevel.Name = "_label_ThirstLevel";
            this._label_ThirstLevel.Size = new System.Drawing.Size(134, 29);
            this._label_ThirstLevel.Text = "% жажда %";
            // 
            // _button_Inventory
            // 
            this._button_Inventory.BackgroundImage = global::Mini_RPG.Properties.Resources.Inventory_button;
            this._button_Inventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._button_Inventory.Location = new System.Drawing.Point(1606, 579);
            this._button_Inventory.Name = "_button_Inventory";
            this._button_Inventory.Size = new System.Drawing.Size(112, 69);
            this._button_Inventory.TabIndex = 5;
            this._button_Inventory.UseVisualStyleBackColor = true;
            this._button_Inventory.Click += new System.EventHandler(this.Button_Inventory_Click);
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
            this._panel_Location.BackgroundImage = global::Mini_RPG.Properties.Resources.Avatar_1;
            this._panel_Location.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_Location.Controls.Add(this._panel_Battle);
            this._panel_Location.Controls.Add(this._flowLayoutPanel_GameLog);
            this._panel_Location.Location = new System.Drawing.Point(93, 55);
            this._panel_Location.Name = "_panel_Location";
            this._panel_Location.Size = new System.Drawing.Size(1334, 766);
            this._panel_Location.TabIndex = 7;
            // 
            // _panel_Battle
            // 
            this._panel_Battle.Controls.Add(this._pictureBox_Enemy);
            this._panel_Battle.Location = new System.Drawing.Point(444, 134);
            this._panel_Battle.Name = "_panel_Battle";
            this._panel_Battle.Size = new System.Drawing.Size(750, 502);
            this._panel_Battle.TabIndex = 2;
            // 
            // _pictureBox_Enemy
            // 
            this._pictureBox_Enemy.Location = new System.Drawing.Point(31, 51);
            this._pictureBox_Enemy.Name = "_pictureBox_Enemy";
            this._pictureBox_Enemy.Size = new System.Drawing.Size(312, 398);
            this._pictureBox_Enemy.TabIndex = 0;
            this._pictureBox_Enemy.TabStop = false;
            this._pictureBox_Enemy.Visible = false;
            // 
            // _flowLayoutPanel_GameLog
            // 
            this._flowLayoutPanel_GameLog.AutoScroll = true;
            this._flowLayoutPanel_GameLog.BackColor = System.Drawing.Color.Transparent;
            this._flowLayoutPanel_GameLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._flowLayoutPanel_GameLog.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this._flowLayoutPanel_GameLog.Location = new System.Drawing.Point(3, 28);
            this._flowLayoutPanel_GameLog.Name = "_flowLayoutPanel_GameLog";
            this._flowLayoutPanel_GameLog.Size = new System.Drawing.Size(414, 735);
            this._flowLayoutPanel_GameLog.TabIndex = 1;
            // 
            // _panel_Town
            // 
            this._panel_Town.Controls.Add(this._button_RestInTown);
            this._panel_Town.Controls.Add(this._button_LeaveTown);
            this._panel_Town.Controls.Add(this._button_Trader);
            this._panel_Town.Location = new System.Drawing.Point(1477, 650);
            this._panel_Town.Name = "_panel_Town";
            this._panel_Town.Size = new System.Drawing.Size(379, 335);
            this._panel_Town.TabIndex = 8;
            // 
            // _button_RestInTown
            // 
            this._button_RestInTown.Location = new System.Drawing.Point(74, 154);
            this._button_RestInTown.Name = "_button_RestInTown";
            this._button_RestInTown.Size = new System.Drawing.Size(229, 34);
            this._button_RestInTown.TabIndex = 2;
            this._button_RestInTown.Text = "% отдыхать в городе %";
            this._button_RestInTown.UseVisualStyleBackColor = true;
            this._button_RestInTown.Click += new System.EventHandler(this.Button_RestInTown_Click);
            // 
            // _button_LeaveTown
            // 
            this._button_LeaveTown.Location = new System.Drawing.Point(74, 197);
            this._button_LeaveTown.Name = "_button_LeaveTown";
            this._button_LeaveTown.Size = new System.Drawing.Size(229, 34);
            this._button_LeaveTown.TabIndex = 1;
            this._button_LeaveTown.Text = "% покинуть город %";
            this._button_LeaveTown.UseVisualStyleBackColor = true;
            this._button_LeaveTown.Click += new System.EventHandler(this.Button_LeaveTown_Click);
            // 
            // _button_Trader
            // 
            this._button_Trader.Location = new System.Drawing.Point(74, 110);
            this._button_Trader.Name = "_button_Trader";
            this._button_Trader.Size = new System.Drawing.Size(229, 34);
            this._button_Trader.TabIndex = 0;
            this._button_Trader.Text = "% торговец %";
            this._button_Trader.UseVisualStyleBackColor = true;
            this._button_Trader.Click += new System.EventHandler(this.Button_Trader_Click);
            // 
            // _button_SwitchLogSize
            // 
            this._button_SwitchLogSize.Location = new System.Drawing.Point(96, 824);
            this._button_SwitchLogSize.Name = "_button_SwitchLogSize";
            this._button_SwitchLogSize.Size = new System.Drawing.Size(176, 34);
            this._button_SwitchLogSize.TabIndex = 9;
            this._button_SwitchLogSize.Text = "% Switch log size %";
            this._button_SwitchLogSize.UseVisualStyleBackColor = true;
            // 
            // _panel_BattleActions
            // 
            this._panel_BattleActions.Controls.Add(this._button_TryLeaveBattle);
            this._panel_BattleActions.Controls.Add(this._button_Attack);
            this._panel_BattleActions.Location = new System.Drawing.Point(1079, 835);
            this._panel_BattleActions.Name = "_panel_BattleActions";
            this._panel_BattleActions.Size = new System.Drawing.Size(346, 131);
            this._panel_BattleActions.TabIndex = 9;
            // 
            // _button_TryLeaveBattle
            // 
            this._button_TryLeaveBattle.Location = new System.Drawing.Point(62, 77);
            this._button_TryLeaveBattle.Name = "_button_TryLeaveBattle";
            this._button_TryLeaveBattle.Size = new System.Drawing.Size(229, 34);
            this._button_TryLeaveBattle.TabIndex = 3;
            this._button_TryLeaveBattle.Text = "% попытаться сбежать %";
            this._button_TryLeaveBattle.UseVisualStyleBackColor = true;
            // 
            // _button_Attack
            // 
            this._button_Attack.Location = new System.Drawing.Point(62, 20);
            this._button_Attack.Name = "_button_Attack";
            this._button_Attack.Size = new System.Drawing.Size(229, 34);
            this._button_Attack.TabIndex = 2;
            this._button_Attack.Text = "% атаковать %";
            this._button_Attack.UseVisualStyleBackColor = true;
            // 
            // _panel_TownEntrance
            // 
            this._panel_TownEntrance.Controls.Add(this._button_EnterTown);
            this._panel_TownEntrance.Location = new System.Drawing.Point(1093, 827);
            this._panel_TownEntrance.Name = "_panel_TownEntrance";
            this._panel_TownEntrance.Size = new System.Drawing.Size(346, 131);
            this._panel_TownEntrance.TabIndex = 10;
            // 
            // _button_EnterTown
            // 
            this._button_EnterTown.Location = new System.Drawing.Point(62, 53);
            this._button_EnterTown.Name = "_button_EnterTown";
            this._button_EnterTown.Size = new System.Drawing.Size(229, 34);
            this._button_EnterTown.TabIndex = 2;
            this._button_EnterTown.Text = "% войти в город %";
            this._button_EnterTown.UseVisualStyleBackColor = true;
            this._button_EnterTown.Click += new System.EventHandler(this.Button_EnterTown_Click);
            // 
            // GameProcessScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this._panel_TownEntrance);
            this.Controls.Add(this._panel_BattleActions);
            this.Controls.Add(this._panel_Town);
            this.Controls.Add(this._button_SwitchLogSize);
            this.Controls.Add(this._panel_Location);
            this.Controls.Add(this._button_Inventory);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._panel_Character);
            this.Controls.Add(this._panel_MiniMap);
            this.Controls.Add(this._panel_Navigation);
            this.DoubleBuffered = true;
            this.Name = "GameProcessScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this._panel_Navigation.ResumeLayout(false);
            this._panel_MiniMap.ResumeLayout(false);
            this._panel_Character.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_HasFreeAbilityActions)).EndInit();
            this._panel_CharacterHealthBarBG.ResumeLayout(false);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._panel_Location.ResumeLayout(false);
            this._panel_Battle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_Enemy)).EndInit();
            this._panel_Town.ResumeLayout(false);
            this._panel_BattleActions.ResumeLayout(false);
            this._panel_TownEntrance.ResumeLayout(false);
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
        private Panel _panel_Character;
        private Panel _panel_CharacterHealthBarBG;
        private Panel _panel_CharacterHealthBarFG;
        private Button _button_CharacterProgress;
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
        private Button _button_LeaveTown;
        private Button _button_Trader;
        private FlowLayoutPanel _flowLayoutPanel_GameLog;
        private Button _button_SwitchLogSize;
        private PictureBox _pictureBox_HasFreeAbilityActions;
        private Button _button_RestInTown;
        private Panel _panel_Battle;
        private Panel _panel_BattleActions;
        private Button _button_Attack;
        private Button _button_TryLeaveBattle;
        private Panel _panel_TownEntrance;
        private Button _button_EnterTown;
        private ToolStripStatusLabel _label_HungerLevel;
        private ToolStripStatusLabel _label_ThirstLevel;
    }
}
