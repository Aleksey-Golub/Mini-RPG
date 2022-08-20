namespace Mini_RPG
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._panel_StartScreen = new System.Windows.Forms.Panel();
            this._button_Exit = new System.Windows.Forms.Button();
            this._button_LoadGame = new System.Windows.Forms.Button();
            this._button_NewGame = new System.Windows.Forms.Button();
            this._panel_CharacterCreation = new System.Windows.Forms.Panel();
            this._label_Race = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._button_IncreaseCharisma = new System.Windows.Forms.Button();
            this._button_DecreaseCharisma = new System.Windows.Forms.Button();
            this._label_CharismaPoints = new System.Windows.Forms.Label();
            this._label_Charisma = new System.Windows.Forms.Label();
            this._button_IncreasePerception = new System.Windows.Forms.Button();
            this._button_DecreasePerception = new System.Windows.Forms.Button();
            this._label_PerceptionPoints = new System.Windows.Forms.Label();
            this._label_Perception = new System.Windows.Forms.Label();
            this._button_IncreaseConstitution = new System.Windows.Forms.Button();
            this._button_DecreaseConstitution = new System.Windows.Forms.Button();
            this._label_ConstitutionPoints = new System.Windows.Forms.Label();
            this._label_Constitution = new System.Windows.Forms.Label();
            this._button_IncreaseDexterity = new System.Windows.Forms.Button();
            this._button_DecreaseDexterity = new System.Windows.Forms.Button();
            this._label_DexterityPoints = new System.Windows.Forms.Label();
            this._label_Dexterity = new System.Windows.Forms.Label();
            this._button_IncreaseStrenth = new System.Windows.Forms.Button();
            this._button_DecreaseStrenth = new System.Windows.Forms.Button();
            this._label_StrengthPoints = new System.Windows.Forms.Label();
            this._label_Strength = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._label_AbilityPointsCount = new System.Windows.Forms.Label();
            this._label_AbilityPoints = new System.Windows.Forms.Label();
            this._comboBox_Race = new System.Windows.Forms.ComboBox();
            this._button_StartGame = new System.Windows.Forms.Button();
            this._button_SelectCharacterAvatar = new System.Windows.Forms.Button();
            this._panel_GameProcess = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._panel_Intro = new System.Windows.Forms.Panel();
            this._label_Intro = new System.Windows.Forms.Label();
            this._button_GoToGame = new System.Windows.Forms.Button();
            this._panel_StartScreen.SuspendLayout();
            this._panel_CharacterCreation.SuspendLayout();
            this.panel1.SuspendLayout();
            this._panel_GameProcess.SuspendLayout();
            this._panel_Intro.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel_StartScreen
            // 
            this._panel_StartScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_StartScreen.Controls.Add(this._button_Exit);
            this._panel_StartScreen.Controls.Add(this._button_LoadGame);
            this._panel_StartScreen.Controls.Add(this._button_NewGame);
            this._panel_StartScreen.Location = new System.Drawing.Point(43, 12);
            this._panel_StartScreen.Name = "_panel_StartScreen";
            this._panel_StartScreen.Size = new System.Drawing.Size(1874, 1000);
            this._panel_StartScreen.TabIndex = 0;
            // 
            // _button_Exit
            // 
            this._button_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_Exit.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_Exit.ForeColor = System.Drawing.SystemColors.Control;
            this._button_Exit.Location = new System.Drawing.Point(690, 811);
            this._button_Exit.Name = "_button_Exit";
            this._button_Exit.Size = new System.Drawing.Size(540, 115);
            this._button_Exit.TabIndex = 2;
            this._button_Exit.Text = "ВЫХОД";
            this._button_Exit.UseVisualStyleBackColor = false;
            this._button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // _button_LoadGame
            // 
            this._button_LoadGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_LoadGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_LoadGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_LoadGame.Location = new System.Drawing.Point(690, 401);
            this._button_LoadGame.Name = "_button_LoadGame";
            this._button_LoadGame.Size = new System.Drawing.Size(540, 115);
            this._button_LoadGame.TabIndex = 1;
            this._button_LoadGame.Text = "ЗАГРУЗИТЬ";
            this._button_LoadGame.UseVisualStyleBackColor = false;
            this._button_LoadGame.Click += new System.EventHandler(this.Button_LoadGame_Click);
            // 
            // _button_NewGame
            // 
            this._button_NewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_NewGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_NewGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_NewGame.Location = new System.Drawing.Point(690, 231);
            this._button_NewGame.Name = "_button_NewGame";
            this._button_NewGame.Size = new System.Drawing.Size(540, 115);
            this._button_NewGame.TabIndex = 0;
            this._button_NewGame.Text = "НОВАЯ ИГРА";
            this._button_NewGame.UseVisualStyleBackColor = false;
            this._button_NewGame.Click += new System.EventHandler(this.Button_NewGame_Click);
            // 
            // _panel_CharacterCreation
            // 
            this._panel_CharacterCreation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_CharacterCreation.Controls.Add(this._label_Race);
            this._panel_CharacterCreation.Controls.Add(this.panel1);
            this._panel_CharacterCreation.Controls.Add(this.textBox1);
            this._panel_CharacterCreation.Controls.Add(this._label_AbilityPointsCount);
            this._panel_CharacterCreation.Controls.Add(this._label_AbilityPoints);
            this._panel_CharacterCreation.Controls.Add(this._comboBox_Race);
            this._panel_CharacterCreation.Controls.Add(this._button_StartGame);
            this._panel_CharacterCreation.Controls.Add(this._button_SelectCharacterAvatar);
            this._panel_CharacterCreation.Location = new System.Drawing.Point(29, 35);
            this._panel_CharacterCreation.Name = "_panel_CharacterCreation";
            this._panel_CharacterCreation.Size = new System.Drawing.Size(1874, 1000);
            this._panel_CharacterCreation.TabIndex = 3;
            this._panel_CharacterCreation.Visible = false;
            // 
            // _label_Race
            // 
            this._label_Race.AutoSize = true;
            this._label_Race.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Race.Location = new System.Drawing.Point(34, 63);
            this._label_Race.Name = "_label_Race";
            this._label_Race.Size = new System.Drawing.Size(86, 41);
            this._label_Race.TabIndex = 9;
            this._label_Race.Text = "Раса:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this._button_IncreaseCharisma);
            this.panel1.Controls.Add(this._button_DecreaseCharisma);
            this.panel1.Controls.Add(this._label_CharismaPoints);
            this.panel1.Controls.Add(this._label_Charisma);
            this.panel1.Controls.Add(this._button_IncreasePerception);
            this.panel1.Controls.Add(this._button_DecreasePerception);
            this.panel1.Controls.Add(this._label_PerceptionPoints);
            this.panel1.Controls.Add(this._label_Perception);
            this.panel1.Controls.Add(this._button_IncreaseConstitution);
            this.panel1.Controls.Add(this._button_DecreaseConstitution);
            this.panel1.Controls.Add(this._label_ConstitutionPoints);
            this.panel1.Controls.Add(this._label_Constitution);
            this.panel1.Controls.Add(this._button_IncreaseDexterity);
            this.panel1.Controls.Add(this._button_DecreaseDexterity);
            this.panel1.Controls.Add(this._label_DexterityPoints);
            this.panel1.Controls.Add(this._label_Dexterity);
            this.panel1.Controls.Add(this._button_IncreaseStrenth);
            this.panel1.Controls.Add(this._button_DecreaseStrenth);
            this.panel1.Controls.Add(this._label_StrengthPoints);
            this.panel1.Controls.Add(this._label_Strength);
            this.panel1.Location = new System.Drawing.Point(34, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 730);
            this.panel1.TabIndex = 8;
            // 
            // _button_IncreaseCharisma
            // 
            this._button_IncreaseCharisma.Location = new System.Drawing.Point(485, 323);
            this._button_IncreaseCharisma.Name = "_button_IncreaseCharisma";
            this._button_IncreaseCharisma.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseCharisma.TabIndex = 19;
            this._button_IncreaseCharisma.Text = "+";
            this._button_IncreaseCharisma.UseVisualStyleBackColor = true;
            // 
            // _button_DecreaseCharisma
            // 
            this._button_DecreaseCharisma.Location = new System.Drawing.Point(423, 323);
            this._button_DecreaseCharisma.Name = "_button_DecreaseCharisma";
            this._button_DecreaseCharisma.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseCharisma.TabIndex = 18;
            this._button_DecreaseCharisma.Text = "-";
            this._button_DecreaseCharisma.UseVisualStyleBackColor = true;
            // 
            // _label_CharismaPoints
            // 
            this._label_CharismaPoints.AutoSize = true;
            this._label_CharismaPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_CharismaPoints.Location = new System.Drawing.Point(327, 323);
            this._label_CharismaPoints.Name = "_label_CharismaPoints";
            this._label_CharismaPoints.Size = new System.Drawing.Size(66, 41);
            this._label_CharismaPoints.TabIndex = 17;
            this._label_CharismaPoints.Text = "999";
            // 
            // _label_Charisma
            // 
            this._label_Charisma.AutoSize = true;
            this._label_Charisma.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Charisma.Location = new System.Drawing.Point(22, 323);
            this._label_Charisma.Name = "_label_Charisma";
            this._label_Charisma.Size = new System.Drawing.Size(135, 41);
            this._label_Charisma.TabIndex = 16;
            this._label_Charisma.Text = "Харизма";
            // 
            // _button_IncreasePerception
            // 
            this._button_IncreasePerception.Location = new System.Drawing.Point(485, 244);
            this._button_IncreasePerception.Name = "_button_IncreasePerception";
            this._button_IncreasePerception.Size = new System.Drawing.Size(40, 40);
            this._button_IncreasePerception.TabIndex = 15;
            this._button_IncreasePerception.Text = "+";
            this._button_IncreasePerception.UseVisualStyleBackColor = true;
            // 
            // _button_DecreasePerception
            // 
            this._button_DecreasePerception.Location = new System.Drawing.Point(423, 244);
            this._button_DecreasePerception.Name = "_button_DecreasePerception";
            this._button_DecreasePerception.Size = new System.Drawing.Size(40, 40);
            this._button_DecreasePerception.TabIndex = 14;
            this._button_DecreasePerception.Text = "-";
            this._button_DecreasePerception.UseVisualStyleBackColor = true;
            // 
            // _label_PerceptionPoints
            // 
            this._label_PerceptionPoints.AutoSize = true;
            this._label_PerceptionPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_PerceptionPoints.Location = new System.Drawing.Point(327, 244);
            this._label_PerceptionPoints.Name = "_label_PerceptionPoints";
            this._label_PerceptionPoints.Size = new System.Drawing.Size(66, 41);
            this._label_PerceptionPoints.TabIndex = 13;
            this._label_PerceptionPoints.Text = "999";
            // 
            // _label_Perception
            // 
            this._label_Perception.AutoSize = true;
            this._label_Perception.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Perception.Location = new System.Drawing.Point(22, 244);
            this._label_Perception.Name = "_label_Perception";
            this._label_Perception.Size = new System.Drawing.Size(179, 41);
            this._label_Perception.TabIndex = 12;
            this._label_Perception.Text = "Восприятие";
            // 
            // _button_IncreaseConstitution
            // 
            this._button_IncreaseConstitution.Location = new System.Drawing.Point(485, 169);
            this._button_IncreaseConstitution.Name = "_button_IncreaseConstitution";
            this._button_IncreaseConstitution.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseConstitution.TabIndex = 11;
            this._button_IncreaseConstitution.Text = "+";
            this._button_IncreaseConstitution.UseVisualStyleBackColor = true;
            // 
            // _button_DecreaseConstitution
            // 
            this._button_DecreaseConstitution.Location = new System.Drawing.Point(423, 169);
            this._button_DecreaseConstitution.Name = "_button_DecreaseConstitution";
            this._button_DecreaseConstitution.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseConstitution.TabIndex = 10;
            this._button_DecreaseConstitution.Text = "-";
            this._button_DecreaseConstitution.UseVisualStyleBackColor = true;
            // 
            // _label_ConstitutionPoints
            // 
            this._label_ConstitutionPoints.AutoSize = true;
            this._label_ConstitutionPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_ConstitutionPoints.Location = new System.Drawing.Point(327, 169);
            this._label_ConstitutionPoints.Name = "_label_ConstitutionPoints";
            this._label_ConstitutionPoints.Size = new System.Drawing.Size(66, 41);
            this._label_ConstitutionPoints.TabIndex = 9;
            this._label_ConstitutionPoints.Text = "999";
            // 
            // _label_Constitution
            // 
            this._label_Constitution.AutoSize = true;
            this._label_Constitution.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Constitution.Location = new System.Drawing.Point(22, 169);
            this._label_Constitution.Name = "_label_Constitution";
            this._label_Constitution.Size = new System.Drawing.Size(213, 41);
            this._label_Constitution.TabIndex = 8;
            this._label_Constitution.Text = "Выносливость";
            // 
            // _button_IncreaseDexterity
            // 
            this._button_IncreaseDexterity.Location = new System.Drawing.Point(485, 96);
            this._button_IncreaseDexterity.Name = "_button_IncreaseDexterity";
            this._button_IncreaseDexterity.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseDexterity.TabIndex = 7;
            this._button_IncreaseDexterity.Text = "+";
            this._button_IncreaseDexterity.UseVisualStyleBackColor = true;
            // 
            // _button_DecreaseDexterity
            // 
            this._button_DecreaseDexterity.Location = new System.Drawing.Point(423, 96);
            this._button_DecreaseDexterity.Name = "_button_DecreaseDexterity";
            this._button_DecreaseDexterity.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseDexterity.TabIndex = 6;
            this._button_DecreaseDexterity.Text = "-";
            this._button_DecreaseDexterity.UseVisualStyleBackColor = true;
            // 
            // _label_DexterityPoints
            // 
            this._label_DexterityPoints.AutoSize = true;
            this._label_DexterityPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_DexterityPoints.Location = new System.Drawing.Point(327, 96);
            this._label_DexterityPoints.Name = "_label_DexterityPoints";
            this._label_DexterityPoints.Size = new System.Drawing.Size(66, 41);
            this._label_DexterityPoints.TabIndex = 5;
            this._label_DexterityPoints.Text = "999";
            // 
            // _label_Dexterity
            // 
            this._label_Dexterity.AutoSize = true;
            this._label_Dexterity.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Dexterity.Location = new System.Drawing.Point(22, 96);
            this._label_Dexterity.Name = "_label_Dexterity";
            this._label_Dexterity.Size = new System.Drawing.Size(146, 41);
            this._label_Dexterity.TabIndex = 4;
            this._label_Dexterity.Text = "Ловкость";
            // 
            // _button_IncreaseStrenth
            // 
            this._button_IncreaseStrenth.Location = new System.Drawing.Point(485, 26);
            this._button_IncreaseStrenth.Name = "_button_IncreaseStrenth";
            this._button_IncreaseStrenth.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseStrenth.TabIndex = 3;
            this._button_IncreaseStrenth.Text = "+";
            this._button_IncreaseStrenth.UseVisualStyleBackColor = true;
            // 
            // _button_DecreaseStrenth
            // 
            this._button_DecreaseStrenth.Location = new System.Drawing.Point(423, 26);
            this._button_DecreaseStrenth.Name = "_button_DecreaseStrenth";
            this._button_DecreaseStrenth.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseStrenth.TabIndex = 2;
            this._button_DecreaseStrenth.Text = "-";
            this._button_DecreaseStrenth.UseVisualStyleBackColor = true;
            // 
            // _label_StrengthPoints
            // 
            this._label_StrengthPoints.AutoSize = true;
            this._label_StrengthPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_StrengthPoints.Location = new System.Drawing.Point(327, 26);
            this._label_StrengthPoints.Name = "_label_StrengthPoints";
            this._label_StrengthPoints.Size = new System.Drawing.Size(66, 41);
            this._label_StrengthPoints.TabIndex = 1;
            this._label_StrengthPoints.Text = "999";
            // 
            // _label_Strength
            // 
            this._label_Strength.AutoSize = true;
            this._label_Strength.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Strength.Location = new System.Drawing.Point(22, 26);
            this._label_Strength.Name = "_label_Strength";
            this._label_Strength.Size = new System.Drawing.Size(85, 41);
            this._label_Strength.TabIndex = 0;
            this._label_Strength.Text = "Сила";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1342, 378);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 47);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Введите имя";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _label_AbilityPointsCount
            // 
            this._label_AbilityPointsCount.AutoSize = true;
            this._label_AbilityPointsCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_AbilityPointsCount.Location = new System.Drawing.Point(361, 122);
            this._label_AbilityPointsCount.Name = "_label_AbilityPointsCount";
            this._label_AbilityPointsCount.Size = new System.Drawing.Size(66, 41);
            this._label_AbilityPointsCount.TabIndex = 6;
            this._label_AbilityPointsCount.Text = "999";
            // 
            // _label_AbilityPoints
            // 
            this._label_AbilityPoints.AutoSize = true;
            this._label_AbilityPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_AbilityPoints.Location = new System.Drawing.Point(34, 122);
            this._label_AbilityPoints.Name = "_label_AbilityPoints";
            this._label_AbilityPoints.Size = new System.Drawing.Size(303, 41);
            this._label_AbilityPoints.TabIndex = 5;
            this._label_AbilityPoints.Text = "Очки характеристик:";
            // 
            // _comboBox_Race
            // 
            this._comboBox_Race.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox_Race.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._comboBox_Race.FormattingEnabled = true;
            this._comboBox_Race.Items.AddRange(new object[] {
            "орк",
            "человек",
            "эльф"});
            this._comboBox_Race.Location = new System.Drawing.Point(158, 60);
            this._comboBox_Race.Name = "_comboBox_Race";
            this._comboBox_Race.Size = new System.Drawing.Size(250, 49);
            this._comboBox_Race.TabIndex = 4;
            // 
            // _button_StartGame
            // 
            this._button_StartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_StartGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_StartGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_StartGame.Location = new System.Drawing.Point(1284, 853);
            this._button_StartGame.Name = "_button_StartGame";
            this._button_StartGame.Size = new System.Drawing.Size(540, 115);
            this._button_StartGame.TabIndex = 2;
            this._button_StartGame.Text = "НАЧАТЬ";
            this._button_StartGame.UseVisualStyleBackColor = false;
            this._button_StartGame.Click += new System.EventHandler(this.Button_StartGame_Click);
            // 
            // _button_SelectCharacterAvatar
            // 
            this._button_SelectCharacterAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_SelectCharacterAvatar.BackgroundImage = global::Mini_RPG.Properties.Resources.Аватар_персонажа_1;
            this._button_SelectCharacterAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._button_SelectCharacterAvatar.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_SelectCharacterAvatar.ForeColor = System.Drawing.SystemColors.Control;
            this._button_SelectCharacterAvatar.Location = new System.Drawing.Point(1342, 73);
            this._button_SelectCharacterAvatar.Name = "_button_SelectCharacterAvatar";
            this._button_SelectCharacterAvatar.Size = new System.Drawing.Size(241, 295);
            this._button_SelectCharacterAvatar.TabIndex = 0;
            this._button_SelectCharacterAvatar.UseVisualStyleBackColor = false;
            this._button_SelectCharacterAvatar.Click += new System.EventHandler(this.Button_SelectCharacterAvatar_Click);
            // 
            // _panel_GameProcess
            // 
            this._panel_GameProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_GameProcess.Controls.Add(this.button1);
            this._panel_GameProcess.Location = new System.Drawing.Point(12, 675);
            this._panel_GameProcess.Name = "_panel_GameProcess";
            this._panel_GameProcess.Size = new System.Drawing.Size(1874, 1000);
            this._panel_GameProcess.TabIndex = 4;
            this._panel_GameProcess.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(1284, 853);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(540, 115);
            this.button1.TabIndex = 2;
            this.button1.Text = "НАЧАТЬ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // _panel_Intro
            // 
            this._panel_Intro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_Intro.Controls.Add(this._label_Intro);
            this._panel_Intro.Controls.Add(this._button_GoToGame);
            this._panel_Intro.Location = new System.Drawing.Point(12, 15);
            this._panel_Intro.Name = "_panel_Intro";
            this._panel_Intro.Size = new System.Drawing.Size(1874, 1000);
            this._panel_Intro.TabIndex = 5;
            this._panel_Intro.Visible = false;
            // 
            // _label_Intro
            // 
            this._label_Intro.AutoEllipsis = true;
            this._label_Intro.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Intro.Location = new System.Drawing.Point(175, 96);
            this._label_Intro.Name = "_label_Intro";
            this._label_Intro.Size = new System.Drawing.Size(1579, 614);
            this._label_Intro.TabIndex = 3;
            this._label_Intro.Text = resources.GetString("_label_Intro.Text");
            this._label_Intro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _button_GoToGame
            // 
            this._button_GoToGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_GoToGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_GoToGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_GoToGame.Location = new System.Drawing.Point(1284, 853);
            this._button_GoToGame.Name = "_button_GoToGame";
            this._button_GoToGame.Size = new System.Drawing.Size(540, 115);
            this._button_GoToGame.TabIndex = 2;
            this._button_GoToGame.Text = "НАЧАТЬ";
            this._button_GoToGame.UseVisualStyleBackColor = false;
            this._button_GoToGame.Click += new System.EventHandler(this.Button_GoToGame_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.ControlBox = false;
            this.Controls.Add(this._panel_Intro);
            this.Controls.Add(this._panel_GameProcess);
            this.Controls.Add(this._panel_CharacterCreation);
            this.Controls.Add(this._panel_StartScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Mini RPG";
            this._panel_StartScreen.ResumeLayout(false);
            this._panel_CharacterCreation.ResumeLayout(false);
            this._panel_CharacterCreation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._panel_GameProcess.ResumeLayout(false);
            this._panel_Intro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel _panel_StartScreen;
        private Button _button_Exit;
        private Button _button_LoadGame;
        private Button _button_NewGame;
        private Panel _panel_CharacterCreation;
        private Button _button_StartGame;
        private Button _button_SelectCharacterAvatar;
        private Panel _panel_GameProcess;
        private Button button1;
        private ComboBox _comboBox_Race;
        private Label _label_AbilityPoints;
        private Label _label_AbilityPointsCount;
        private TextBox textBox1;
        private Panel panel1;
        private Button _button_IncreasePerception;
        private Button _button_DecreasePerception;
        private Label _label_PerceptionPoints;
        private Label _label_Perception;
        private Button _button_IncreaseConstitution;
        private Button _button_DecreaseConstitution;
        private Label _label_ConstitutionPoints;
        private Label _label_Constitution;
        private Button _button_IncreaseDexterity;
        private Button _button_DecreaseDexterity;
        private Label _label_DexterityPoints;
        private Label _label_Dexterity;
        private Button _button_IncreaseStrenth;
        private Button _button_DecreaseStrenth;
        private Label _label_StrengthPoints;
        private Label _label_Strength;
        private Button _button_IncreaseCharisma;
        private Button _button_DecreaseCharisma;
        private Label _label_CharismaPoints;
        private Label _label_Charisma;
        private Label _label_Race;
        private ToolTip _toolTip;
        private Panel _panel_Intro;
        private Label _label_Intro;
        private Button _button_GoToGame;
    }
}