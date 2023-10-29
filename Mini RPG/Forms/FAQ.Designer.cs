namespace Mini_RPG
{
    partial class FAQ
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
            this._label_FAQ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _label_FAQ
            // 
            this._label_FAQ.AutoEllipsis = true;
            this._label_FAQ.AutoSize = true;
            this._label_FAQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._label_FAQ.Location = new System.Drawing.Point(0, 0);
            this._label_FAQ.MaximumSize = new System.Drawing.Size(1000, 0);
            this._label_FAQ.Name = "_label_FAQ";
            this._label_FAQ.Size = new System.Drawing.Size(934, 96);
            this._label_FAQ.TabIndex = 1;
            this._label_FAQ.Text = "% FAQ %\r\nqweqwerrrrrrrrrrrrrr qwrrrqwrqwr qwrqwrqwrqw qwrqwrq qweq qweqwe qwew eq" +
    "ewqe weqew qweqwe \r\n";
            // 
            // FAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1033, 1009);
            this.Controls.Add(this._label_FAQ);
            this.MinimizeBox = false;
            this.Name = "FAQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FAQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _label_FAQ;
    }
}