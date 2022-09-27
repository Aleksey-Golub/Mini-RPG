namespace Mini_RPG
{
    partial class SelectingLoadGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectingLoadGame));
            this._flowLayoutPanel_Saves = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel_Saves
            // 
            this._flowLayoutPanel_Saves.AutoScroll = true;
            this._flowLayoutPanel_Saves.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanel_Saves.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanel_Saves.Name = "_flowLayoutPanel_Saves";
            this._flowLayoutPanel_Saves.Size = new System.Drawing.Size(214, 444);
            this._flowLayoutPanel_Saves.TabIndex = 0;
            // 
            // SelectingLoadGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(214, 444);
            this.Controls.Add(this._flowLayoutPanel_Saves);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectingLoadGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel _flowLayoutPanel_Saves;
    }
}