namespace Mini_RPG.Screens
{
    partial class PlayerDeathScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerDeathScreen));
            this._label_PlayerResult = new System.Windows.Forms.Label();
            this._button_GoToMainMenu = new System.Windows.Forms.Button();
            this._panel_PlayerDeath = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _label_PlayerResult
            // 
            this._label_PlayerResult.AutoEllipsis = true;
            this._label_PlayerResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_PlayerResult.Location = new System.Drawing.Point(1265, 115);
            this._label_PlayerResult.Name = "_label_PlayerResult";
            this._label_PlayerResult.Size = new System.Drawing.Size(575, 706);
            this._label_PlayerResult.TabIndex = 5;
            this._label_PlayerResult.Text = resources.GetString("_label_PlayerResult.Text");
            this._label_PlayerResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _button_GoToMainMenu
            // 
            this._button_GoToMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_GoToMainMenu.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_GoToMainMenu.ForeColor = System.Drawing.SystemColors.Control;
            this._button_GoToMainMenu.Location = new System.Drawing.Point(1300, 856);
            this._button_GoToMainMenu.Name = "_button_GoToMainMenu";
            this._button_GoToMainMenu.Size = new System.Drawing.Size(540, 115);
            this._button_GoToMainMenu.TabIndex = 6;
            this._button_GoToMainMenu.Text = "% В ГЛАВНОЕ МЕНЮ %";
            this._button_GoToMainMenu.UseVisualStyleBackColor = false;
            this._button_GoToMainMenu.Click += new System.EventHandler(this.Button_GoToMainMenu_Click);
            // 
            // _panel_PlayerDeath
            // 
            this._panel_PlayerDeath.BackgroundImage = global::Mini_RPG.Properties.Resources.Graveyard;
            this._panel_PlayerDeath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_PlayerDeath.Location = new System.Drawing.Point(54, 55);
            this._panel_PlayerDeath.Name = "_panel_PlayerDeath";
            this._panel_PlayerDeath.Size = new System.Drawing.Size(1205, 766);
            this._panel_PlayerDeath.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1265, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 62);
            this.label1.TabIndex = 9;
            this.label1.Text = "GAME OVER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerDeathScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.label1);
            this.Controls.Add(this._panel_PlayerDeath);
            this.Controls.Add(this._button_GoToMainMenu);
            this.Controls.Add(this._label_PlayerResult);
            this.Name = "PlayerDeathScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private Label _label_PlayerResult;
        private Button _button_GoToMainMenu;
        private Panel _panel_PlayerDeath;
        private Label label1;
    }
}
