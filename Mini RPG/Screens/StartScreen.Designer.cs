namespace Mini_RPG.Screens
{
    partial class StartScreen
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
            this._button_NewGame = new System.Windows.Forms.Button();
            this._button_LoadGame = new System.Windows.Forms.Button();
            this._button_Exit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _button_NewGame
            // 
            this._button_NewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_NewGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_NewGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_NewGame.Location = new System.Drawing.Point(688, 220);
            this._button_NewGame.Name = "_button_NewGame";
            this._button_NewGame.Size = new System.Drawing.Size(544, 110);
            this._button_NewGame.TabIndex = 0;
            this._button_NewGame.Text = "% новая игра %";
            this._button_NewGame.UseVisualStyleBackColor = false;
            this._button_NewGame.Click += new System.EventHandler(this.Button_NewGame_Click);
            // 
            // _button_LoadGame
            // 
            this._button_LoadGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_LoadGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_LoadGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_LoadGame.Location = new System.Drawing.Point(688, 411);
            this._button_LoadGame.Name = "_button_LoadGame";
            this._button_LoadGame.Size = new System.Drawing.Size(544, 110);
            this._button_LoadGame.TabIndex = 1;
            this._button_LoadGame.Text = "% загрузить %";
            this._button_LoadGame.UseVisualStyleBackColor = false;
            this._button_LoadGame.Click += new System.EventHandler(this.Button_LoadGame_Click);
            // 
            // _button_Exit
            // 
            this._button_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_Exit.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_Exit.ForeColor = System.Drawing.SystemColors.Control;
            this._button_Exit.Location = new System.Drawing.Point(688, 829);
            this._button_Exit.Name = "_button_Exit";
            this._button_Exit.Size = new System.Drawing.Size(544, 110);
            this._button_Exit.TabIndex = 2;
            this._button_Exit.Text = "% выход %";
            this._button_Exit.UseVisualStyleBackColor = false;
            this._button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ru",
            "en"});
            this.comboBox1.Location = new System.Drawing.Point(1664, 924);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(68, 33);
            this.comboBox1.TabIndex = 4;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this._button_Exit);
            this.Controls.Add(this._button_LoadGame);
            this.Controls.Add(this._button_NewGame);
            this.DoubleBuffered = true;
            this.Name = "StartScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private Button _button_NewGame;
        private Button _button_LoadGame;
        private Button _button_Exit;
        private ComboBox comboBox1;
    }
}
