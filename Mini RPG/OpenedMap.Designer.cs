namespace Mini_RPG
{
    partial class OpenedMap
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
            this._label_Map = new System.Windows.Forms.Label();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _label_Map
            // 
            this._label_Map.Location = new System.Drawing.Point(0, 0);
            this._label_Map.Name = "_label_Map";
            this._label_Map.Size = new System.Drawing.Size(800, 450);
            this._label_Map.TabIndex = 0;
            this._label_Map.Text = "% MAP %";
            this._label_Map.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenedMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._label_Map);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenedMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map";
            this.ResumeLayout(false);

        }

        #endregion

        private Label _label_Map;
        private ToolTip _toolTip;
    }
}