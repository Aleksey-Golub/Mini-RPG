namespace Mini_RPG
{
    partial class SelectingCharacterAvatar
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
            this._flowLayoutPanel_Avatars = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel_Avatars
            // 
            this._flowLayoutPanel_Avatars.AutoScroll = true;
            this._flowLayoutPanel_Avatars.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanel_Avatars.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanel_Avatars.Name = "_flowLayoutPanel_Avatars";
            this._flowLayoutPanel_Avatars.Size = new System.Drawing.Size(518, 308);
            this._flowLayoutPanel_Avatars.TabIndex = 0;
            // 
            // SelectingCharacterAvatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(518, 308);
            this.ControlBox = false;
            this.Controls.Add(this._flowLayoutPanel_Avatars);
            this.Name = "SelectingCharacterAvatar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel _flowLayoutPanel_Avatars;
    }
}