namespace Staff_Schedulling_System.Admin
{
    partial class Ward
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
            this.WardPanel = new MetroFramework.Controls.MetroPanel();
            this.WardListView = new MaterialSkin.Controls.MaterialListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Name_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteWardBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.UpdateWardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.CancelWardBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.AddWardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.WardDescBox = new System.Windows.Forms.TextBox();
            this.WardNameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.SignOutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.UserBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.WardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AccountBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DashboardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.WardPanel.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WardPanel
            // 
            this.WardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WardPanel.Controls.Add(this.WardListView);
            this.WardPanel.Controls.Add(this.DeleteWardBtn);
            this.WardPanel.Controls.Add(this.UpdateWardBtn);
            this.WardPanel.Controls.Add(this.CancelWardBtn);
            this.WardPanel.Controls.Add(this.AddWardBtn);
            this.WardPanel.Controls.Add(this.WardDescBox);
            this.WardPanel.Controls.Add(this.WardNameBox);
            this.WardPanel.Controls.Add(this.materialLabel3);
            this.WardPanel.Controls.Add(this.materialLabel1);
            this.WardPanel.HorizontalScrollbarBarColor = true;
            this.WardPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.WardPanel.HorizontalScrollbarSize = 10;
            this.WardPanel.Location = new System.Drawing.Point(175, 64);
            this.WardPanel.Name = "WardPanel";
            this.WardPanel.Size = new System.Drawing.Size(625, 386);
            this.WardPanel.TabIndex = 7;
            this.WardPanel.VerticalScrollbarBarColor = true;
            this.WardPanel.VerticalScrollbarHighlightOnWheel = false;
            this.WardPanel.VerticalScrollbarSize = 10;
            this.WardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WardPanel_Paint);
            // 
            // WardListView
            // 
            this.WardListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Name_});
            this.WardListView.Depth = 0;
            this.WardListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.WardListView.FullRowSelect = true;
            this.WardListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.WardListView.Location = new System.Drawing.Point(3, 3);
            this.WardListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.WardListView.MouseState = MaterialSkin.MouseState.OUT;
            this.WardListView.Name = "WardListView";
            this.WardListView.OwnerDraw = true;
            this.WardListView.Size = new System.Drawing.Size(206, 384);
            this.WardListView.TabIndex = 13;
            this.WardListView.UseCompatibleStateImageBehavior = false;
            this.WardListView.View = System.Windows.Forms.View.Details;
            this.WardListView.Click += new System.EventHandler(this.WardListView_Click);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 100;
            // 
            // Name_
            // 
            this.Name_.Text = "Name";
            this.Name_.Width = 100;
            // 
            // DeleteWardBtn
            // 
            this.DeleteWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteWardBtn.AutoSize = true;
            this.DeleteWardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteWardBtn.Depth = 0;
            this.DeleteWardBtn.Icon = null;
            this.DeleteWardBtn.Location = new System.Drawing.Point(363, 335);
            this.DeleteWardBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteWardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteWardBtn.Name = "DeleteWardBtn";
            this.DeleteWardBtn.Primary = false;
            this.DeleteWardBtn.Size = new System.Drawing.Size(69, 36);
            this.DeleteWardBtn.TabIndex = 12;
            this.DeleteWardBtn.Text = "Delete";
            this.DeleteWardBtn.UseVisualStyleBackColor = true;
            this.DeleteWardBtn.Click += new System.EventHandler(this.DeleteWardBtn_Click);
            // 
            // UpdateWardBtn
            // 
            this.UpdateWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateWardBtn.AutoSize = true;
            this.UpdateWardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UpdateWardBtn.Depth = 0;
            this.UpdateWardBtn.Icon = null;
            this.UpdateWardBtn.Location = new System.Drawing.Point(283, 335);
            this.UpdateWardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.UpdateWardBtn.Name = "UpdateWardBtn";
            this.UpdateWardBtn.Primary = true;
            this.UpdateWardBtn.Size = new System.Drawing.Size(73, 36);
            this.UpdateWardBtn.TabIndex = 11;
            this.UpdateWardBtn.Text = "Update";
            this.UpdateWardBtn.UseVisualStyleBackColor = true;
            this.UpdateWardBtn.Click += new System.EventHandler(this.UpdateWardBtn_Click);
            // 
            // CancelWardBtn
            // 
            this.CancelWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelWardBtn.AutoSize = true;
            this.CancelWardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelWardBtn.Depth = 0;
            this.CancelWardBtn.Icon = null;
            this.CancelWardBtn.Location = new System.Drawing.Point(440, 335);
            this.CancelWardBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelWardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelWardBtn.Name = "CancelWardBtn";
            this.CancelWardBtn.Primary = false;
            this.CancelWardBtn.Size = new System.Drawing.Size(73, 36);
            this.CancelWardBtn.TabIndex = 10;
            this.CancelWardBtn.Text = "Cancel";
            this.CancelWardBtn.UseVisualStyleBackColor = true;
            this.CancelWardBtn.Click += new System.EventHandler(this.CancelWardBtn_Click);
            // 
            // AddWardBtn
            // 
            this.AddWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddWardBtn.AutoSize = true;
            this.AddWardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddWardBtn.Depth = 0;
            this.AddWardBtn.Icon = null;
            this.AddWardBtn.Location = new System.Drawing.Point(229, 335);
            this.AddWardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddWardBtn.Name = "AddWardBtn";
            this.AddWardBtn.Primary = true;
            this.AddWardBtn.Size = new System.Drawing.Size(48, 36);
            this.AddWardBtn.TabIndex = 9;
            this.AddWardBtn.Text = "Add";
            this.AddWardBtn.UseVisualStyleBackColor = true;
            this.AddWardBtn.Click += new System.EventHandler(this.AddWardBtn_Click);
            // 
            // WardDescBox
            // 
            this.WardDescBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WardDescBox.Location = new System.Drawing.Point(341, 81);
            this.WardDescBox.Multiline = true;
            this.WardDescBox.Name = "WardDescBox";
            this.WardDescBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WardDescBox.Size = new System.Drawing.Size(284, 207);
            this.WardDescBox.TabIndex = 8;
            // 
            // WardNameBox
            // 
            this.WardNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WardNameBox.Depth = 0;
            this.WardNameBox.Hint = "";
            this.WardNameBox.Location = new System.Drawing.Point(344, 39);
            this.WardNameBox.MaxLength = 32767;
            this.WardNameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.WardNameBox.Name = "WardNameBox";
            this.WardNameBox.PasswordChar = '\0';
            this.WardNameBox.SelectedText = "";
            this.WardNameBox.SelectionLength = 0;
            this.WardNameBox.SelectionStart = 0;
            this.WardNameBox.Size = new System.Drawing.Size(270, 23);
            this.WardNameBox.TabIndex = 7;
            this.WardNameBox.TabStop = false;
            this.WardNameBox.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(224, 80);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(86, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Description";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(224, 44);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Name";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.SignOutBtn);
            this.metroPanel1.Controls.Add(this.UserBtn);
            this.metroPanel1.Controls.Add(this.WardBtn);
            this.metroPanel1.Controls.Add(this.AccountBtn);
            this.metroPanel1.Controls.Add(this.DashboardBtn);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 64);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(176, 385);
            this.metroPanel1.TabIndex = 10;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.AutoSize = true;
            this.SignOutBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SignOutBtn.Depth = 0;
            this.SignOutBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SignOutBtn.Icon = null;
            this.SignOutBtn.Location = new System.Drawing.Point(0, 144);
            this.SignOutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Primary = true;
            this.SignOutBtn.Size = new System.Drawing.Size(176, 36);
            this.SignOutBtn.TabIndex = 6;
            this.SignOutBtn.Text = "SIGNOUT";
            this.SignOutBtn.UseVisualStyleBackColor = true;
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // UserBtn
            // 
            this.UserBtn.AutoSize = true;
            this.UserBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UserBtn.Depth = 0;
            this.UserBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserBtn.Icon = null;
            this.UserBtn.Location = new System.Drawing.Point(0, 108);
            this.UserBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Primary = true;
            this.UserBtn.Size = new System.Drawing.Size(176, 36);
            this.UserBtn.TabIndex = 5;
            this.UserBtn.Text = "USERS";
            this.UserBtn.UseVisualStyleBackColor = true;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
            // 
            // WardBtn
            // 
            this.WardBtn.AutoSize = true;
            this.WardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WardBtn.Depth = 0;
            this.WardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.WardBtn.Icon = null;
            this.WardBtn.Location = new System.Drawing.Point(0, 72);
            this.WardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.WardBtn.Name = "WardBtn";
            this.WardBtn.Primary = true;
            this.WardBtn.Size = new System.Drawing.Size(176, 36);
            this.WardBtn.TabIndex = 4;
            this.WardBtn.Text = "WARD";
            this.WardBtn.UseVisualStyleBackColor = true;
            this.WardBtn.Click += new System.EventHandler(this.WardBtn_Click);
            // 
            // AccountBtn
            // 
            this.AccountBtn.AutoSize = true;
            this.AccountBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AccountBtn.Depth = 0;
            this.AccountBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AccountBtn.Icon = null;
            this.AccountBtn.Location = new System.Drawing.Point(0, 36);
            this.AccountBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AccountBtn.Name = "AccountBtn";
            this.AccountBtn.Primary = true;
            this.AccountBtn.Size = new System.Drawing.Size(176, 36);
            this.AccountBtn.TabIndex = 3;
            this.AccountBtn.Text = "ACCOUNT";
            this.AccountBtn.UseVisualStyleBackColor = true;
            this.AccountBtn.Click += new System.EventHandler(this.AccountBtn_Click);
            // 
            // DashboardBtn
            // 
            this.DashboardBtn.AutoSize = true;
            this.DashboardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DashboardBtn.Depth = 0;
            this.DashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DashboardBtn.Icon = null;
            this.DashboardBtn.Location = new System.Drawing.Point(0, 0);
            this.DashboardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DashboardBtn.Name = "DashboardBtn";
            this.DashboardBtn.Primary = true;
            this.DashboardBtn.Size = new System.Drawing.Size(176, 36);
            this.DashboardBtn.TabIndex = 2;
            this.DashboardBtn.Text = "DASHBOARD";
            this.DashboardBtn.UseVisualStyleBackColor = true;
            this.DashboardBtn.Click += new System.EventHandler(this.DashboardBtn_Click);
            // 
            // Ward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.WardPanel);
            this.MaximizeBox = false;
            this.Name = "Ward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ward";
            this.Load += new System.EventHandler(this.Ward_Load);
            this.WardPanel.ResumeLayout(false);
            this.WardPanel.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel WardPanel;
        private MaterialSkin.Controls.MaterialListView WardListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Name_;
        private MaterialSkin.Controls.MaterialFlatButton DeleteWardBtn;
        private MaterialSkin.Controls.MaterialRaisedButton UpdateWardBtn;
        private MaterialSkin.Controls.MaterialFlatButton CancelWardBtn;
        private MaterialSkin.Controls.MaterialRaisedButton AddWardBtn;
        private System.Windows.Forms.TextBox WardDescBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField WardNameBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton SignOutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton UserBtn;
        private MaterialSkin.Controls.MaterialRaisedButton WardBtn;
        private MaterialSkin.Controls.MaterialRaisedButton AccountBtn;
        private MaterialSkin.Controls.MaterialRaisedButton DashboardBtn;
    }
}