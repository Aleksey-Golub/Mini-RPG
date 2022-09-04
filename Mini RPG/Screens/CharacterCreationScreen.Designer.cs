namespace Mini_RPG.Screens
{
    partial class CharacterCreationScreen
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
            this._label_Race = new System.Windows.Forms.Label();
            this._panel_Abilities = new System.Windows.Forms.Panel();
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
            this._button_IncreaseStrength = new System.Windows.Forms.Button();
            this._button_DecreaseStrength = new System.Windows.Forms.Button();
            this._label_StrengthPoints = new System.Windows.Forms.Label();
            this._label_Strength = new System.Windows.Forms.Label();
            this._label_AbilityPointsCount = new System.Windows.Forms.Label();
            this._label_AbilityPoints = new System.Windows.Forms.Label();
            this._comboBox_Race = new System.Windows.Forms.ComboBox();
            this._textBox_Name = new System.Windows.Forms.TextBox();
            this._button_StartGame = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._pictureBox_SelectCharacterAvatar = new System.Windows.Forms.PictureBox();
            this._panel_Abilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_SelectCharacterAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // _label_Race
            // 
            this._label_Race.AutoSize = true;
            this._label_Race.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Race.Location = new System.Drawing.Point(40, 64);
            this._label_Race.Name = "_label_Race";
            this._label_Race.Size = new System.Drawing.Size(136, 41);
            this._label_Race.TabIndex = 14;
            this._label_Race.Text = "%Раса:%";
            // 
            // _panel_Abilities
            // 
            this._panel_Abilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._panel_Abilities.Controls.Add(this._button_IncreaseCharisma);
            this._panel_Abilities.Controls.Add(this._button_DecreaseCharisma);
            this._panel_Abilities.Controls.Add(this._label_CharismaPoints);
            this._panel_Abilities.Controls.Add(this._label_Charisma);
            this._panel_Abilities.Controls.Add(this._button_IncreasePerception);
            this._panel_Abilities.Controls.Add(this._button_DecreasePerception);
            this._panel_Abilities.Controls.Add(this._label_PerceptionPoints);
            this._panel_Abilities.Controls.Add(this._label_Perception);
            this._panel_Abilities.Controls.Add(this._button_IncreaseConstitution);
            this._panel_Abilities.Controls.Add(this._button_DecreaseConstitution);
            this._panel_Abilities.Controls.Add(this._label_ConstitutionPoints);
            this._panel_Abilities.Controls.Add(this._label_Constitution);
            this._panel_Abilities.Controls.Add(this._button_IncreaseDexterity);
            this._panel_Abilities.Controls.Add(this._button_DecreaseDexterity);
            this._panel_Abilities.Controls.Add(this._label_DexterityPoints);
            this._panel_Abilities.Controls.Add(this._label_Dexterity);
            this._panel_Abilities.Controls.Add(this._button_IncreaseStrength);
            this._panel_Abilities.Controls.Add(this._button_DecreaseStrength);
            this._panel_Abilities.Controls.Add(this._label_StrengthPoints);
            this._panel_Abilities.Controls.Add(this._label_Strength);
            this._panel_Abilities.Location = new System.Drawing.Point(40, 174);
            this._panel_Abilities.Name = "_panel_Abilities";
            this._panel_Abilities.Size = new System.Drawing.Size(556, 730);
            this._panel_Abilities.TabIndex = 13;
            // 
            // _button_IncreaseCharisma
            // 
            this._button_IncreaseCharisma.Location = new System.Drawing.Point(485, 323);
            this._button_IncreaseCharisma.Name = "_button_IncreaseCharisma";
            this._button_IncreaseCharisma.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseCharisma.TabIndex = 19;
            this._button_IncreaseCharisma.Text = "+";
            this._button_IncreaseCharisma.UseVisualStyleBackColor = true;
            this._button_IncreaseCharisma.Click += new System.EventHandler(this.Button_IncreaseCharisma_Click);
            // 
            // _button_DecreaseCharisma
            // 
            this._button_DecreaseCharisma.Location = new System.Drawing.Point(423, 323);
            this._button_DecreaseCharisma.Name = "_button_DecreaseCharisma";
            this._button_DecreaseCharisma.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseCharisma.TabIndex = 18;
            this._button_DecreaseCharisma.Text = "-";
            this._button_DecreaseCharisma.UseVisualStyleBackColor = true;
            this._button_DecreaseCharisma.Click += new System.EventHandler(this.Button_DecreaseCharisma_Click);
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
            this._label_Charisma.Size = new System.Drawing.Size(185, 41);
            this._label_Charisma.TabIndex = 16;
            this._label_Charisma.Text = "%Харизма%";
            // 
            // _button_IncreasePerception
            // 
            this._button_IncreasePerception.Location = new System.Drawing.Point(485, 244);
            this._button_IncreasePerception.Name = "_button_IncreasePerception";
            this._button_IncreasePerception.Size = new System.Drawing.Size(40, 40);
            this._button_IncreasePerception.TabIndex = 15;
            this._button_IncreasePerception.Text = "+";
            this._button_IncreasePerception.UseVisualStyleBackColor = true;
            this._button_IncreasePerception.Click += new System.EventHandler(this.Button_IncreasePerception_Click);
            // 
            // _button_DecreasePerception
            // 
            this._button_DecreasePerception.Location = new System.Drawing.Point(423, 244);
            this._button_DecreasePerception.Name = "_button_DecreasePerception";
            this._button_DecreasePerception.Size = new System.Drawing.Size(40, 40);
            this._button_DecreasePerception.TabIndex = 14;
            this._button_DecreasePerception.Text = "-";
            this._button_DecreasePerception.UseVisualStyleBackColor = true;
            this._button_DecreasePerception.Click += new System.EventHandler(this.Button_DecreasePerception_Click);
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
            this._label_Perception.Size = new System.Drawing.Size(229, 41);
            this._label_Perception.TabIndex = 12;
            this._label_Perception.Text = "%Восприятие%";
            // 
            // _button_IncreaseConstitution
            // 
            this._button_IncreaseConstitution.Location = new System.Drawing.Point(485, 169);
            this._button_IncreaseConstitution.Name = "_button_IncreaseConstitution";
            this._button_IncreaseConstitution.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseConstitution.TabIndex = 11;
            this._button_IncreaseConstitution.Text = "+";
            this._button_IncreaseConstitution.UseVisualStyleBackColor = true;
            this._button_IncreaseConstitution.Click += new System.EventHandler(this.Button_IncreaseConstitution_Click);
            // 
            // _button_DecreaseConstitution
            // 
            this._button_DecreaseConstitution.Location = new System.Drawing.Point(423, 169);
            this._button_DecreaseConstitution.Name = "_button_DecreaseConstitution";
            this._button_DecreaseConstitution.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseConstitution.TabIndex = 10;
            this._button_DecreaseConstitution.Text = "-";
            this._button_DecreaseConstitution.UseVisualStyleBackColor = true;
            this._button_DecreaseConstitution.Click += new System.EventHandler(this.Button_DecreaseConstitution_Click);
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
            this._label_Constitution.Size = new System.Drawing.Size(263, 41);
            this._label_Constitution.TabIndex = 8;
            this._label_Constitution.Text = "%Выносливость%";
            // 
            // _button_IncreaseDexterity
            // 
            this._button_IncreaseDexterity.Location = new System.Drawing.Point(485, 96);
            this._button_IncreaseDexterity.Name = "_button_IncreaseDexterity";
            this._button_IncreaseDexterity.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseDexterity.TabIndex = 7;
            this._button_IncreaseDexterity.Text = "+";
            this._button_IncreaseDexterity.UseVisualStyleBackColor = true;
            this._button_IncreaseDexterity.Click += new System.EventHandler(this.Button_IncreaseDexterity_Click);
            // 
            // _button_DecreaseDexterity
            // 
            this._button_DecreaseDexterity.Location = new System.Drawing.Point(423, 96);
            this._button_DecreaseDexterity.Name = "_button_DecreaseDexterity";
            this._button_DecreaseDexterity.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseDexterity.TabIndex = 6;
            this._button_DecreaseDexterity.Text = "-";
            this._button_DecreaseDexterity.UseVisualStyleBackColor = true;
            this._button_DecreaseDexterity.Click += new System.EventHandler(this.Button_DecreaseDexterity_Click);
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
            this._label_Dexterity.Size = new System.Drawing.Size(196, 41);
            this._label_Dexterity.TabIndex = 4;
            this._label_Dexterity.Text = "%Ловкость%";
            // 
            // _button_IncreaseStrength
            // 
            this._button_IncreaseStrength.Location = new System.Drawing.Point(485, 26);
            this._button_IncreaseStrength.Name = "_button_IncreaseStrength";
            this._button_IncreaseStrength.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseStrength.TabIndex = 3;
            this._button_IncreaseStrength.Text = "+";
            this._button_IncreaseStrength.UseVisualStyleBackColor = true;
            this._button_IncreaseStrength.Click += new System.EventHandler(this.Button_IncreaseStrength_Click);
            // 
            // _button_DecreaseStrength
            // 
            this._button_DecreaseStrength.Location = new System.Drawing.Point(423, 26);
            this._button_DecreaseStrength.Name = "_button_DecreaseStrength";
            this._button_DecreaseStrength.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseStrength.TabIndex = 2;
            this._button_DecreaseStrength.Text = "-";
            this._button_DecreaseStrength.UseVisualStyleBackColor = true;
            this._button_DecreaseStrength.Click += new System.EventHandler(this.Button_DecreaseStrength_Click);
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
            this._label_Strength.Size = new System.Drawing.Size(135, 41);
            this._label_Strength.TabIndex = 0;
            this._label_Strength.Text = "%Сила%";
            // 
            // _label_AbilityPointsCount
            // 
            this._label_AbilityPointsCount.AutoSize = true;
            this._label_AbilityPointsCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_AbilityPointsCount.Location = new System.Drawing.Point(388, 123);
            this._label_AbilityPointsCount.Name = "_label_AbilityPointsCount";
            this._label_AbilityPointsCount.Size = new System.Drawing.Size(66, 41);
            this._label_AbilityPointsCount.TabIndex = 12;
            this._label_AbilityPointsCount.Text = "999";
            // 
            // _label_AbilityPoints
            // 
            this._label_AbilityPoints.AutoSize = true;
            this._label_AbilityPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_AbilityPoints.Location = new System.Drawing.Point(40, 123);
            this._label_AbilityPoints.Name = "_label_AbilityPoints";
            this._label_AbilityPoints.Size = new System.Drawing.Size(353, 41);
            this._label_AbilityPoints.TabIndex = 11;
            this._label_AbilityPoints.Text = "%Очки характеристик:%";
            // 
            // _comboBox_Race
            // 
            this._comboBox_Race.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox_Race.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._comboBox_Race.FormattingEnabled = true;
            this._comboBox_Race.Location = new System.Drawing.Point(182, 61);
            this._comboBox_Race.Name = "_comboBox_Race";
            this._comboBox_Race.Size = new System.Drawing.Size(250, 49);
            this._comboBox_Race.TabIndex = 10;
            this._comboBox_Race.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Race_SelectedIndexChanged);
            // 
            // _textBox_Name
            // 
            this._textBox_Name.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._textBox_Name.Location = new System.Drawing.Point(1416, 475);
            this._textBox_Name.Name = "_textBox_Name";
            this._textBox_Name.Size = new System.Drawing.Size(324, 47);
            this._textBox_Name.TabIndex = 21;
            this._textBox_Name.Text = "% Введите имя %";
            this._textBox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._textBox_Name.TextChanged += new System.EventHandler(this.TextBox_Name_TextChanged);
            // 
            // _button_StartGame
            // 
            this._button_StartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_StartGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_StartGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_StartGame.Location = new System.Drawing.Point(1312, 867);
            this._button_StartGame.Name = "_button_StartGame";
            this._button_StartGame.Size = new System.Drawing.Size(540, 115);
            this._button_StartGame.TabIndex = 22;
            this._button_StartGame.Text = "% начать %";
            this._button_StartGame.UseVisualStyleBackColor = false;
            this._button_StartGame.Click += new System.EventHandler(this.Button_StartGame_Click);
            // 
            // _pictureBox_SelectCharacterAvatar
            // 
            this._pictureBox_SelectCharacterAvatar.Location = new System.Drawing.Point(1458, 174);
            this._pictureBox_SelectCharacterAvatar.Name = "_pictureBox_SelectCharacterAvatar";
            this._pictureBox_SelectCharacterAvatar.Size = new System.Drawing.Size(241, 295);
            this._pictureBox_SelectCharacterAvatar.TabIndex = 23;
            this._pictureBox_SelectCharacterAvatar.TabStop = false;
            this._pictureBox_SelectCharacterAvatar.Click += new System.EventHandler(this.PictureBox_SelectCharacterAvatar_Click);
            // 
            // CharacterCreationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this._pictureBox_SelectCharacterAvatar);
            this.Controls.Add(this._button_StartGame);
            this.Controls.Add(this._textBox_Name);
            this.Controls.Add(this._label_Race);
            this.Controls.Add(this._panel_Abilities);
            this.Controls.Add(this._label_AbilityPointsCount);
            this.Controls.Add(this._label_AbilityPoints);
            this.Controls.Add(this._comboBox_Race);
            this.Name = "CharacterCreationScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this._panel_Abilities.ResumeLayout(false);
            this._panel_Abilities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_SelectCharacterAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _label_Race;
        private Panel _panel_Abilities;
        private Button _button_IncreaseCharisma;
        private Button _button_DecreaseCharisma;
        private Label _label_CharismaPoints;
        private Label _label_Charisma;
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
        private Button _button_IncreaseStrength;
        private Button _button_DecreaseStrength;
        private Label _label_StrengthPoints;
        private Label _label_Strength;
        private Label _label_AbilityPointsCount;
        private Label _label_AbilityPoints;
        private ComboBox _comboBox_Race;
        private TextBox _textBox_Name;
        private Button _button_StartGame;
        private ToolTip _toolTip;
        private PictureBox _pictureBox_SelectCharacterAvatar;
    }
}
