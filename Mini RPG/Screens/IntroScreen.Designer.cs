namespace Mini_RPG.Screens
{
    partial class IntroScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroScreen));
            this._button_GoToGame = new System.Windows.Forms.Button();
            this._label_Intro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _button_GoToGame
            // 
            this._button_GoToGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._button_GoToGame.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._button_GoToGame.ForeColor = System.Drawing.SystemColors.Control;
            this._button_GoToGame.Location = new System.Drawing.Point(1300, 856);
            this._button_GoToGame.Name = "_button_GoToGame";
            this._button_GoToGame.Size = new System.Drawing.Size(540, 115);
            this._button_GoToGame.TabIndex = 3;
            this._button_GoToGame.Text = "% НАЧАТЬ %";
            this._button_GoToGame.UseVisualStyleBackColor = false;
            this._button_GoToGame.Click += new System.EventHandler(this.Button_GoToGame_Click);
            // 
            // _label_Intro
            // 
            this._label_Intro.AutoEllipsis = true;
            this._label_Intro.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_Intro.Location = new System.Drawing.Point(158, 136);
            this._label_Intro.Name = "_label_Intro";
            this._label_Intro.Size = new System.Drawing.Size(1579, 614);
            this._label_Intro.TabIndex = 4;
            this._label_Intro.Text = resources.GetString("_label_Intro.Text");
            this._label_Intro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IntroScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this._label_Intro);
            this.Controls.Add(this._button_GoToGame);
            this.Name = "IntroScreen";
            this.Size = new System.Drawing.Size(1898, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private Button _button_GoToGame;
        private Label _label_Intro;
    }
}
