namespace Mini_RPG
{
    partial class Inventory
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
            this._flowLayoutPanel_Inventory = new System.Windows.Forms.FlowLayoutPanel();
            this._panel_CharacterDoll = new System.Windows.Forms.Panel();
            this._button_OffHandEquippedItem = new System.Windows.Forms.Button();
            this._button_MainHandEquippedItem = new System.Windows.Forms.Button();
            this._button_LegsEquippedItem = new System.Windows.Forms.Button();
            this._button_BodyEquippedItem = new System.Windows.Forms.Button();
            this._button_HandsEquippedItem = new System.Windows.Forms.Button();
            this._button_HeadEquippedItem = new System.Windows.Forms.Button();
            this._button_Close = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._panel_CharacterDoll.SuspendLayout();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel_Inventory
            // 
            this._flowLayoutPanel_Inventory.AutoScroll = true;
            this._flowLayoutPanel_Inventory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanel_Inventory.Location = new System.Drawing.Point(39, 58);
            this._flowLayoutPanel_Inventory.Name = "_flowLayoutPanel_Inventory";
            this._flowLayoutPanel_Inventory.Size = new System.Drawing.Size(417, 646);
            this._flowLayoutPanel_Inventory.TabIndex = 0;
            // 
            // _panel_CharacterDoll
            // 
            this._panel_CharacterDoll.BackgroundImage = global::Mini_RPG.Properties.Resources.CharacterSilhouette;
            this._panel_CharacterDoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._panel_CharacterDoll.Controls.Add(this._button_OffHandEquippedItem);
            this._panel_CharacterDoll.Controls.Add(this._button_MainHandEquippedItem);
            this._panel_CharacterDoll.Controls.Add(this._button_LegsEquippedItem);
            this._panel_CharacterDoll.Controls.Add(this._button_BodyEquippedItem);
            this._panel_CharacterDoll.Controls.Add(this._button_HandsEquippedItem);
            this._panel_CharacterDoll.Controls.Add(this._button_HeadEquippedItem);
            this._panel_CharacterDoll.Location = new System.Drawing.Point(835, 58);
            this._panel_CharacterDoll.Name = "_panel_CharacterDoll";
            this._panel_CharacterDoll.Size = new System.Drawing.Size(470, 610);
            this._panel_CharacterDoll.TabIndex = 2;
            // 
            // _button_OffHandEquippedItem
            // 
            this._button_OffHandEquippedItem.Location = new System.Drawing.Point(337, 170);
            this._button_OffHandEquippedItem.Name = "_button_OffHandEquippedItem";
            this._button_OffHandEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_OffHandEquippedItem.TabIndex = 5;
            this._button_OffHandEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_MainHandEquippedItem
            // 
            this._button_MainHandEquippedItem.Location = new System.Drawing.Point(36, 170);
            this._button_MainHandEquippedItem.Name = "_button_MainHandEquippedItem";
            this._button_MainHandEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_MainHandEquippedItem.TabIndex = 4;
            this._button_MainHandEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_LegsEquippedItem
            // 
            this._button_LegsEquippedItem.Location = new System.Drawing.Point(175, 460);
            this._button_LegsEquippedItem.Name = "_button_LegsEquippedItem";
            this._button_LegsEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_LegsEquippedItem.TabIndex = 3;
            this._button_LegsEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_BodyEquippedItem
            // 
            this._button_BodyEquippedItem.Location = new System.Drawing.Point(175, 170);
            this._button_BodyEquippedItem.Name = "_button_BodyEquippedItem";
            this._button_BodyEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_BodyEquippedItem.TabIndex = 2;
            this._button_BodyEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_HandsEquippedItem
            // 
            this._button_HandsEquippedItem.Location = new System.Drawing.Point(289, 298);
            this._button_HandsEquippedItem.Name = "_button_HandsEquippedItem";
            this._button_HandsEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_HandsEquippedItem.TabIndex = 1;
            this._button_HandsEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_HeadEquippedItem
            // 
            this._button_HeadEquippedItem.Location = new System.Drawing.Point(175, 51);
            this._button_HeadEquippedItem.Name = "_button_HeadEquippedItem";
            this._button_HeadEquippedItem.Size = new System.Drawing.Size(100, 100);
            this._button_HeadEquippedItem.TabIndex = 0;
            this._button_HeadEquippedItem.UseVisualStyleBackColor = true;
            // 
            // _button_Close
            // 
            this._button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._button_Close.Location = new System.Drawing.Point(1095, 688);
            this._button_Close.Name = "_button_Close";
            this._button_Close.Size = new System.Drawing.Size(201, 48);
            this._button_Close.TabIndex = 3;
            this._button_Close.Text = "% закрыть %";
            this._button_Close.UseVisualStyleBackColor = true;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1347, 759);
            this.ControlBox = false;
            this.Controls.Add(this._button_Close);
            this.Controls.Add(this._panel_CharacterDoll);
            this.Controls.Add(this._flowLayoutPanel_Inventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this._panel_CharacterDoll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel _flowLayoutPanel_Inventory;
        private Panel _panel_CharacterDoll;
        private Button _button_LegsEquippedItem;
        private Button _button_BodyEquippedItem;
        private Button _button_HandsEquippedItem;
        private Button _button_HeadEquippedItem;
        private Button _button_Close;
        private Button _button_OffHandEquippedItem;
        private Button _button_MainHandEquippedItem;
        private ToolTip _toolTip;
    }
}