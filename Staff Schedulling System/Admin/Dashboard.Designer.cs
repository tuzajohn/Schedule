namespace Staff_Schedulling_System.Admin
{
    partial class Dashboard
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
            this.TitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.SignOutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.UserBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.WardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AccountBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DashboardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DashboardPanel = new MetroFramework.Controls.MetroPanel();
            this.SettingsBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.NumberOfStaffBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.NumberOfInChargeBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.NumberOfWardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.numberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WardName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroPanel1.SuspendLayout();
            this.DashboardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Depth = 0;
            this.TitleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TitleLabel.Location = new System.Drawing.Point(5, 8);
            this.TitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(0, 19);
            this.TitleLabel.TabIndex = 15;
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
            this.metroPanel1.Location = new System.Drawing.Point(-5, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(176, 390);
            this.metroPanel1.TabIndex = 9;
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
            // 
            // DashboardPanel
            // 
            this.DashboardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DashboardPanel.Controls.Add(this.materialListView1);
            this.DashboardPanel.Controls.Add(this.SettingsBtn);
            this.DashboardPanel.Controls.Add(this.NumberOfStaffBtn);
            this.DashboardPanel.Controls.Add(this.NumberOfInChargeBtn);
            this.DashboardPanel.Controls.Add(this.NumberOfWardBtn);
            this.DashboardPanel.HorizontalScrollbarBarColor = true;
            this.DashboardPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DashboardPanel.HorizontalScrollbarSize = 10;
            this.DashboardPanel.Location = new System.Drawing.Point(170, 63);
            this.DashboardPanel.Name = "DashboardPanel";
            this.DashboardPanel.Size = new System.Drawing.Size(636, 387);
            this.DashboardPanel.TabIndex = 10;
            this.DashboardPanel.VerticalScrollbarBarColor = true;
            this.DashboardPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DashboardPanel.VerticalScrollbarSize = 10;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.AutoSize = true;
            this.SettingsBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingsBtn.BackColor = System.Drawing.Color.Transparent;
            this.SettingsBtn.BackgroundImage = global::Staff_Schedulling_System.Properties.Resources.settings_gears;
            this.SettingsBtn.Depth = 0;
            this.SettingsBtn.Icon = global::Staff_Schedulling_System.Properties.Resources.settings_gears;
            this.SettingsBtn.Image = global::Staff_Schedulling_System.Properties.Resources.settings_gears;
            this.SettingsBtn.Location = new System.Drawing.Point(576, 10);
            this.SettingsBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SettingsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Primary = false;
            this.SettingsBtn.Size = new System.Drawing.Size(44, 36);
            this.SettingsBtn.TabIndex = 6;
            this.SettingsBtn.UseVisualStyleBackColor = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // NumberOfStaffBtn
            // 
            this.NumberOfStaffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfStaffBtn.AutoSize = true;
            this.NumberOfStaffBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NumberOfStaffBtn.Depth = 0;
            this.NumberOfStaffBtn.Icon = null;
            this.NumberOfStaffBtn.Location = new System.Drawing.Point(293, 10);
            this.NumberOfStaffBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NumberOfStaffBtn.Name = "NumberOfStaffBtn";
            this.NumberOfStaffBtn.Primary = true;
            this.NumberOfStaffBtn.Size = new System.Drawing.Size(94, 36);
            this.NumberOfStaffBtn.TabIndex = 5;
            this.NumberOfStaffBtn.Text = "# of Staff";
            this.NumberOfStaffBtn.UseVisualStyleBackColor = true;
            // 
            // NumberOfInChargeBtn
            // 
            this.NumberOfInChargeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfInChargeBtn.AutoSize = true;
            this.NumberOfInChargeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NumberOfInChargeBtn.Depth = 0;
            this.NumberOfInChargeBtn.Icon = null;
            this.NumberOfInChargeBtn.Location = new System.Drawing.Point(136, 11);
            this.NumberOfInChargeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NumberOfInChargeBtn.Name = "NumberOfInChargeBtn";
            this.NumberOfInChargeBtn.Primary = true;
            this.NumberOfInChargeBtn.Size = new System.Drawing.Size(120, 36);
            this.NumberOfInChargeBtn.TabIndex = 4;
            this.NumberOfInChargeBtn.Text = "# of InCharge";
            this.NumberOfInChargeBtn.UseVisualStyleBackColor = true;
            // 
            // NumberOfWardBtn
            // 
            this.NumberOfWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfWardBtn.AutoSize = true;
            this.NumberOfWardBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NumberOfWardBtn.Depth = 0;
            this.NumberOfWardBtn.Icon = null;
            this.NumberOfWardBtn.Location = new System.Drawing.Point(11, 11);
            this.NumberOfWardBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NumberOfWardBtn.Name = "NumberOfWardBtn";
            this.NumberOfWardBtn.Primary = true;
            this.NumberOfWardBtn.Size = new System.Drawing.Size(92, 36);
            this.NumberOfWardBtn.TabIndex = 3;
            this.NumberOfWardBtn.Text = "# of Ward";
            this.NumberOfWardBtn.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // materialListView1
            // 
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.NameColumn,
            this.TypeColumn,
            this.WardName,
            this.StartDateColumn});
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView1.Location = new System.Drawing.Point(11, 55);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(609, 329);
            this.materialListView1.TabIndex = 7;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            this.materialListView1.SelectedIndexChanged += new System.EventHandler(this.materialListView1_SelectedIndexChanged);
            // 
            // numberColumn
            // 
            this.numberColumn.Text = "#";
            this.numberColumn.Width = 100;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 160;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "User Type";
            this.TypeColumn.Width = 100;
            // 
            // WardName
            // 
            this.WardName.Text = "Ward";
            this.WardName.Width = 100;
            // 
            // StartDateColumn
            // 
            this.StartDateColumn.Text = "Start Date";
            this.StartDateColumn.Width = 128;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.DashboardPanel);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.DashboardPanel.ResumeLayout(false);
            this.DashboardPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel TitleLabel;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton SignOutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton UserBtn;
        private MaterialSkin.Controls.MaterialRaisedButton WardBtn;
        private MaterialSkin.Controls.MaterialRaisedButton AccountBtn;
        private MaterialSkin.Controls.MaterialRaisedButton DashboardBtn;
        private MetroFramework.Controls.MetroPanel DashboardPanel;
        private MaterialSkin.Controls.MaterialRaisedButton NumberOfStaffBtn;
        private MaterialSkin.Controls.MaterialRaisedButton NumberOfInChargeBtn;
        private MaterialSkin.Controls.MaterialRaisedButton NumberOfWardBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private MaterialSkin.Controls.MaterialFlatButton SettingsBtn;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.ColumnHeader numberColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ColumnHeader WardName;
        private System.Windows.Forms.ColumnHeader StartDateColumn;
    }
}