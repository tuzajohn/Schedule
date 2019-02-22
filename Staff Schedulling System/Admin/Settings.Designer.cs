namespace Staff_Schedulling_System.Admin
{
    partial class Settings
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.NumberShistComboBox = new MetroFramework.Controls.MetroComboBox();
            this.NumberStaffWardComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SaveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.WardComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(13, 135);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(132, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Total Shifts a Day:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(13, 175);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(196, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Max Number of Stuff / Ward";
            // 
            // NumberShistComboBox
            // 
            this.NumberShistComboBox.FormattingEnabled = true;
            this.NumberShistComboBox.ItemHeight = 23;
            this.NumberShistComboBox.Items.AddRange(new object[] {
            "0",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.NumberShistComboBox.Location = new System.Drawing.Point(241, 128);
            this.NumberShistComboBox.Name = "NumberShistComboBox";
            this.NumberShistComboBox.Size = new System.Drawing.Size(179, 29);
            this.NumberShistComboBox.TabIndex = 2;
            // 
            // NumberStaffWardComboBox
            // 
            this.NumberStaffWardComboBox.FormattingEnabled = true;
            this.NumberStaffWardComboBox.ItemHeight = 23;
            this.NumberStaffWardComboBox.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.NumberStaffWardComboBox.Location = new System.Drawing.Point(241, 172);
            this.NumberStaffWardComboBox.Name = "NumberStaffWardComboBox";
            this.NumberStaffWardComboBox.Size = new System.Drawing.Size(179, 29);
            this.NumberStaffWardComboBox.TabIndex = 3;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSize = true;
            this.SaveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveBtn.Depth = 0;
            this.SaveBtn.Icon = null;
            this.SaveBtn.Location = new System.Drawing.Point(154, 219);
            this.SaveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Primary = true;
            this.SaveBtn.Size = new System.Drawing.Size(55, 36);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(239, 219);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(73, 36);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(13, 83);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(43, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Ward";
            // 
            // WardComboBox
            // 
            this.WardComboBox.FormattingEnabled = true;
            this.WardComboBox.ItemHeight = 23;
            this.WardComboBox.Location = new System.Drawing.Point(93, 80);
            this.WardComboBox.Name = "WardComboBox";
            this.WardComboBox.Size = new System.Drawing.Size(325, 29);
            this.WardComboBox.TabIndex = 7;
            this.WardComboBox.SelectedIndexChanged += new System.EventHandler(this.WardComboBox_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 272);
            this.Controls.Add(this.WardComboBox);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NumberStaffWardComboBox);
            this.Controls.Add(this.NumberShistComboBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MetroFramework.Controls.MetroComboBox NumberShistComboBox;
        private MetroFramework.Controls.MetroComboBox NumberStaffWardComboBox;
        private MaterialSkin.Controls.MaterialRaisedButton SaveBtn;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MetroFramework.Controls.MetroComboBox WardComboBox;
    }
}