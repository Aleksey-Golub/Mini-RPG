namespace Mini_RPG
{
    partial class CharacterProgress
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
            this._label_CharacterRace = new System.Windows.Forms.Label();
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
            this._button_IncreaseStrenth = new System.Windows.Forms.Button();
            this._button_DecreaseStrenth = new System.Windows.Forms.Button();
            this._label_StrengthPoints = new System.Windows.Forms.Label();
            this._label_Strength = new System.Windows.Forms.Label();
            this._label_AbilityPointsCount = new System.Windows.Forms.Label();
            this._label_AbilityPoints = new System.Windows.Forms.Label();
            this._label_LevelAndExperience = new System.Windows.Forms.Label();
            this._button_CloseCharacterProgress = new System.Windows.Forms.Button();
            this._pictureBox_CharacterAvatar = new System.Windows.Forms.PictureBox();
            this._label_CharacterName = new System.Windows.Forms.Label();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._panel_Abilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_CharacterAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // _label_CharacterRace
            // 
            this._label_CharacterRace.AutoSize = true;
            this._label_CharacterRace.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_CharacterRace.Location = new System.Drawing.Point(35, 28);
            this._label_CharacterRace.Name = "_label_CharacterRace";
            this._label_CharacterRace.Size = new System.Drawing.Size(198, 41);
            this._label_CharacterRace.TabIndex = 19;
            this._label_CharacterRace.Text = "% человек %";
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
            this._panel_Abilities.Controls.Add(this._button_IncreaseStrenth);
            this._panel_Abilities.Controls.Add(this._button_DecreaseStrenth);
            this._panel_Abilities.Controls.Add(this._label_StrengthPoints);
            this._panel_Abilities.Controls.Add(this._label_Strength);
            this._panel_Abilities.Location = new System.Drawing.Point(35, 247);
            this._panel_Abilities.Name = "_panel_Abilities";
            this._panel_Abilities.Size = new System.Drawing.Size(554, 395);
            this._panel_Abilities.TabIndex = 18;
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
            // _button_IncreaseStrenth
            // 
            this._button_IncreaseStrenth.Location = new System.Drawing.Point(485, 26);
            this._button_IncreaseStrenth.Name = "_button_IncreaseStrenth";
            this._button_IncreaseStrenth.Size = new System.Drawing.Size(40, 40);
            this._button_IncreaseStrenth.TabIndex = 3;
            this._button_IncreaseStrenth.Text = "+";
            this._button_IncreaseStrenth.UseVisualStyleBackColor = true;
            this._button_IncreaseStrenth.Click += new System.EventHandler(this.Button_IncreaseStrength_Click);
            // 
            // _button_DecreaseStrenth
            // 
            this._button_DecreaseStrenth.Location = new System.Drawing.Point(423, 26);
            this._button_DecreaseStrenth.Name = "_button_DecreaseStrenth";
            this._button_DecreaseStrenth.Size = new System.Drawing.Size(40, 40);
            this._button_DecreaseStrenth.TabIndex = 2;
            this._button_DecreaseStrenth.Text = "-";
            this._button_DecreaseStrenth.UseVisualStyleBackColor = true;
            this._button_DecreaseStrenth.Click += new System.EventHandler(this.Button_DecreaseStrength_Click);
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
            this._label_AbilityPointsCount.Location = new System.Drawing.Point(383, 194);
            this._label_AbilityPointsCount.Name = "_label_AbilityPointsCount";
            this._label_AbilityPointsCount.Size = new System.Drawing.Size(66, 41);
            this._label_AbilityPointsCount.TabIndex = 17;
            this._label_AbilityPointsCount.Text = "999";
            // 
            // _label_AbilityPoints
            // 
            this._label_AbilityPoints.AutoSize = true;
            this._label_AbilityPoints.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_AbilityPoints.Location = new System.Drawing.Point(35, 194);
            this._label_AbilityPoints.Name = "_label_AbilityPoints";
            this._label_AbilityPoints.Size = new System.Drawing.Size(353, 41);
            this._label_AbilityPoints.TabIndex = 16;
            this._label_AbilityPoints.Text = "%Очки характеристик:%";
            // 
            // _label_LevelAndExperience
            // 
            this._label_LevelAndExperience.AutoSize = true;
            this._label_LevelAndExperience.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_LevelAndExperience.Location = new System.Drawing.Point(35, 85);
            this._label_LevelAndExperience.Name = "_label_LevelAndExperience";
            this._label_LevelAndExperience.Size = new System.Drawing.Size(378, 41);
            this._label_LevelAndExperience.TabIndex = 20;
            this._label_LevelAndExperience.Text = "% 1 уровень: 0000/0000 %";
            // 
            // _button_CloseCharacterProgress
            // 
            this._button_CloseCharacterProgress.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_CloseCharacterProgress.Location = new System.Drawing.Point(1150, 603);
            this._button_CloseCharacterProgress.Name = "_button_CloseCharacterProgress";
            this._button_CloseCharacterProgress.Size = new System.Drawing.Size(219, 57);
            this._button_CloseCharacterProgress.TabIndex = 21;
            this._button_CloseCharacterProgress.Text = "% закрыть %";
            this._button_CloseCharacterProgress.UseVisualStyleBackColor = true;
            this._button_CloseCharacterProgress.Click += new System.EventHandler(this.Button_CloseCharacterProgress_Click);
            // 
            // _pictureBox_CharacterAvatar
            // 
            this._pictureBox_CharacterAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pictureBox_CharacterAvatar.Location = new System.Drawing.Point(735, 42);
            this._pictureBox_CharacterAvatar.Name = "_pictureBox_CharacterAvatar";
            this._pictureBox_CharacterAvatar.Size = new System.Drawing.Size(240, 300);
            this._pictureBox_CharacterAvatar.TabIndex = 22;
            this._pictureBox_CharacterAvatar.TabStop = false;
            // 
            // _label_CharacterName
            // 
            this._label_CharacterName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_CharacterName.Location = new System.Drawing.Point(627, 373);
            this._label_CharacterName.Name = "_label_CharacterName";
            this._label_CharacterName.Size = new System.Drawing.Size(454, 41);
            this._label_CharacterName.TabIndex = 23;
            this._label_CharacterName.Text = "% имя персонажа %";
            this._label_CharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharacterProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1381, 672);
            this.ControlBox = false;
            this.Controls.Add(this._label_CharacterName);
            this.Controls.Add(this._pictureBox_CharacterAvatar);
            this.Controls.Add(this._button_CloseCharacterProgress);
            this.Controls.Add(this._label_LevelAndExperience);
            this.Controls.Add(this._label_CharacterRace);
            this.Controls.Add(this._panel_Abilities);
            this.Controls.Add(this._label_AbilityPointsCount);
            this.Controls.Add(this._label_AbilityPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CharacterProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this._panel_Abilities.ResumeLayout(false);
            this._panel_Abilities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_CharacterAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _label_CharacterRace;
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
        private Button _button_IncreaseStrenth;
        private Button _button_DecreaseStrenth;
        private Label _label_StrengthPoints;
        private Label _label_Strength;
        private Label _label_AbilityPointsCount;
        private Label _label_AbilityPoints;
        private Label _label_LevelAndExperience;
        private Button _button_CloseCharacterProgress;
        private PictureBox _pictureBox_CharacterAvatar;
        private Label _label_CharacterName;
        private ToolTip _toolTip;
    }
}