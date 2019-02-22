namespace Staff_Schedulling_System
{
    partial class HomeManagement
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.SignOutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.UserBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AccountBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DashboardBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.PanelDashboard = new MetroFramework.Controls.MetroPanel();
            this.WardInfoLAbel = new MaterialSkin.Controls.MaterialLabel();
            this.StaffListView = new MaterialSkin.Controls.MaterialListView();
            this.IndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StaffIdNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShiftColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PanelAccount = new MetroFramework.Controls.MetroPanel();
            this.OldUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.NewPasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.CurrentUserPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Newpassvalue = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.NewUsernameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.EditProfileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.WardLabel = new MaterialSkin.Controls.MaterialLabel();
            this.DoBLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.PanelUser = new MetroFramework.Controls.MetroPanel();
            this.FemaleGender = new MetroFramework.Controls.MetroRadioButton();
            this.MaleGender = new MetroFramework.Controls.MetroRadioButton();
            this.StaffRepPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.StaffUsernameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.DoBPicker = new System.Windows.Forms.DateTimePicker();
            this.ContactBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.EmailBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.LnameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.FnameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.CancelBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SaveStaffBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.fnameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ToPdfBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.metroPanel1.SuspendLayout();
            this.PanelDashboard.SuspendLayout();
            this.PanelAccount.SuspendLayout();
            this.PanelUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.SignOutBtn);
            this.metroPanel1.Controls.Add(this.UserBtn);
            this.metroPanel1.Controls.Add(this.AccountBtn);
            this.metroPanel1.Controls.Add(this.DashboardBtn);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 64);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(169, 386);
            this.metroPanel1.TabIndex = 1;
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
            this.SignOutBtn.Location = new System.Drawing.Point(0, 108);
            this.SignOutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Primary = true;
            this.SignOutBtn.Size = new System.Drawing.Size(169, 36);
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
            this.UserBtn.Location = new System.Drawing.Point(0, 72);
            this.UserBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Primary = true;
            this.UserBtn.Size = new System.Drawing.Size(169, 36);
            this.UserBtn.TabIndex = 5;
            this.UserBtn.Text = "USERS";
            this.UserBtn.UseVisualStyleBackColor = true;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
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
            this.AccountBtn.Size = new System.Drawing.Size(169, 36);
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
            this.DashboardBtn.Size = new System.Drawing.Size(169, 36);
            this.DashboardBtn.TabIndex = 2;
            this.DashboardBtn.Text = "DASHBOARD";
            this.DashboardBtn.UseVisualStyleBackColor = true;
            this.DashboardBtn.Click += new System.EventHandler(this.DashboardBtn_Click);
            // 
            // PanelDashboard
            // 
            this.PanelDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDashboard.Controls.Add(this.ToPdfBtn);
            this.PanelDashboard.Controls.Add(this.WardInfoLAbel);
            this.PanelDashboard.Controls.Add(this.StaffListView);
            this.PanelDashboard.HorizontalScrollbarBarColor = true;
            this.PanelDashboard.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelDashboard.HorizontalScrollbarSize = 10;
            this.PanelDashboard.Location = new System.Drawing.Point(175, 64);
            this.PanelDashboard.Name = "PanelDashboard";
            this.PanelDashboard.Size = new System.Drawing.Size(623, 386);
            this.PanelDashboard.TabIndex = 2;
            this.PanelDashboard.VerticalScrollbarBarColor = true;
            this.PanelDashboard.VerticalScrollbarHighlightOnWheel = false;
            this.PanelDashboard.VerticalScrollbarSize = 10;
            this.PanelDashboard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDashboard_Paint);
            // 
            // WardInfoLAbel
            // 
            this.WardInfoLAbel.AutoSize = true;
            this.WardInfoLAbel.Depth = 0;
            this.WardInfoLAbel.Font = new System.Drawing.Font("Roboto", 11F);
            this.WardInfoLAbel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WardInfoLAbel.Location = new System.Drawing.Point(13, 16);
            this.WardInfoLAbel.MouseState = MaterialSkin.MouseState.HOVER;
            this.WardInfoLAbel.Name = "WardInfoLAbel";
            this.WardInfoLAbel.Size = new System.Drawing.Size(116, 19);
            this.WardInfoLAbel.TabIndex = 3;
            this.WardInfoLAbel.Text = "materialLabel13";
            // 
            // StaffListView
            // 
            this.StaffListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexColumn,
            this.StaffIdNumberColumn,
            this.NameColumn,
            this.DateColumn,
            this.ShiftColumn});
            this.StaffListView.Depth = 0;
            this.StaffListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.StaffListView.FullRowSelect = true;
            this.StaffListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StaffListView.Location = new System.Drawing.Point(0, 50);
            this.StaffListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StaffListView.MouseState = MaterialSkin.MouseState.OUT;
            this.StaffListView.Name = "StaffListView";
            this.StaffListView.OwnerDraw = true;
            this.StaffListView.Size = new System.Drawing.Size(623, 333);
            this.StaffListView.TabIndex = 2;
            this.StaffListView.UseCompatibleStateImageBehavior = false;
            this.StaffListView.View = System.Windows.Forms.View.Details;
            this.StaffListView.Click += new System.EventHandler(this.StaffListView_Click);
            // 
            // IndexColumn
            // 
            this.IndexColumn.Text = "#";
            // 
            // StaffIdNumberColumn
            // 
            this.StaffIdNumberColumn.Text = "Staff Id";
            this.StaffIdNumberColumn.Width = 122;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Staff Name";
            this.NameColumn.Width = 184;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Sart Date";
            this.DateColumn.Width = 156;
            // 
            // ShiftColumn
            // 
            this.ShiftColumn.Text = "";
            this.ShiftColumn.Width = 78;
            // 
            // PanelAccount
            // 
            this.PanelAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelAccount.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.PanelAccount.Controls.Add(this.OldUsername);
            this.PanelAccount.Controls.Add(this.materialLabel12);
            this.PanelAccount.Controls.Add(this.UsernameLabel);
            this.PanelAccount.Controls.Add(this.NewPasswordBox);
            this.PanelAccount.Controls.Add(this.CurrentUserPassword);
            this.PanelAccount.Controls.Add(this.Newpassvalue);
            this.PanelAccount.Controls.Add(this.materialLabel11);
            this.PanelAccount.Controls.Add(this.NewUsernameBox);
            this.PanelAccount.Controls.Add(this.materialLabel10);
            this.PanelAccount.Controls.Add(this.materialLabel9);
            this.PanelAccount.Controls.Add(this.EditProfileBtn);
            this.PanelAccount.Controls.Add(this.WardLabel);
            this.PanelAccount.Controls.Add(this.DoBLabel);
            this.PanelAccount.Controls.Add(this.label5);
            this.PanelAccount.Controls.Add(this.ContactLabel);
            this.PanelAccount.Controls.Add(this.label2);
            this.PanelAccount.Controls.Add(this.NameLabel);
            this.PanelAccount.Controls.Add(this.label);
            this.PanelAccount.HorizontalScrollbarBarColor = true;
            this.PanelAccount.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelAccount.HorizontalScrollbarSize = 10;
            this.PanelAccount.Location = new System.Drawing.Point(175, 64);
            this.PanelAccount.Name = "PanelAccount";
            this.PanelAccount.Size = new System.Drawing.Size(623, 383);
            this.PanelAccount.TabIndex = 3;
            this.PanelAccount.VerticalScrollbarBarColor = true;
            this.PanelAccount.VerticalScrollbarHighlightOnWheel = false;
            this.PanelAccount.VerticalScrollbarSize = 10;
            this.PanelAccount.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAccount_Paint);
            // 
            // OldUsername
            // 
            this.OldUsername.Depth = 0;
            this.OldUsername.Hint = "";
            this.OldUsername.Location = new System.Drawing.Point(138, 169);
            this.OldUsername.MaxLength = 32767;
            this.OldUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.OldUsername.Name = "OldUsername";
            this.OldUsername.PasswordChar = '\0';
            this.OldUsername.SelectedText = "";
            this.OldUsername.SelectionLength = 0;
            this.OldUsername.SelectionStart = 0;
            this.OldUsername.Size = new System.Drawing.Size(258, 23);
            this.OldUsername.TabIndex = 24;
            this.OldUsername.TabStop = false;
            this.OldUsername.UseSystemPasswordChar = false;
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(20, 174);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(103, 19);
            this.materialLabel12.TabIndex = 23;
            this.materialLabel12.Text = "Old Username";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(390, 74);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(35, 13);
            this.UsernameLabel.TabIndex = 22;
            this.UsernameLabel.Text = "label1";
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Depth = 0;
            this.NewPasswordBox.Hint = "";
            this.NewPasswordBox.Location = new System.Drawing.Point(138, 283);
            this.NewPasswordBox.MaxLength = 32767;
            this.NewPasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.PasswordChar = '\0';
            this.NewPasswordBox.SelectedText = "";
            this.NewPasswordBox.SelectionLength = 0;
            this.NewPasswordBox.SelectionStart = 0;
            this.NewPasswordBox.Size = new System.Drawing.Size(258, 23);
            this.NewPasswordBox.TabIndex = 21;
            this.NewPasswordBox.TabStop = false;
            this.NewPasswordBox.UseSystemPasswordChar = true;
            // 
            // CurrentUserPassword
            // 
            this.CurrentUserPassword.Depth = 0;
            this.CurrentUserPassword.Hint = "";
            this.CurrentUserPassword.Location = new System.Drawing.Point(155, 239);
            this.CurrentUserPassword.MaxLength = 32767;
            this.CurrentUserPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentUserPassword.Name = "CurrentUserPassword";
            this.CurrentUserPassword.PasswordChar = '\0';
            this.CurrentUserPassword.SelectedText = "";
            this.CurrentUserPassword.SelectionLength = 0;
            this.CurrentUserPassword.SelectionStart = 0;
            this.CurrentUserPassword.Size = new System.Drawing.Size(258, 23);
            this.CurrentUserPassword.TabIndex = 20;
            this.CurrentUserPassword.TabStop = false;
            this.CurrentUserPassword.UseSystemPasswordChar = true;
            // 
            // Newpassvalue
            // 
            this.Newpassvalue.AutoSize = true;
            this.Newpassvalue.Depth = 0;
            this.Newpassvalue.Font = new System.Drawing.Font("Roboto", 11F);
            this.Newpassvalue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Newpassvalue.Location = new System.Drawing.Point(20, 287);
            this.Newpassvalue.MouseState = MaterialSkin.MouseState.HOVER;
            this.Newpassvalue.Name = "Newpassvalue";
            this.Newpassvalue.Size = new System.Drawing.Size(109, 19);
            this.Newpassvalue.TabIndex = 19;
            this.Newpassvalue.Text = "New Password";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(20, 243);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(128, 19);
            this.materialLabel11.TabIndex = 18;
            this.materialLabel11.Text = "Current Password";
            // 
            // NewUsernameBox
            // 
            this.NewUsernameBox.Depth = 0;
            this.NewUsernameBox.Hint = "";
            this.NewUsernameBox.Location = new System.Drawing.Point(138, 203);
            this.NewUsernameBox.MaxLength = 32767;
            this.NewUsernameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewUsernameBox.Name = "NewUsernameBox";
            this.NewUsernameBox.PasswordChar = '\0';
            this.NewUsernameBox.SelectedText = "";
            this.NewUsernameBox.SelectionLength = 0;
            this.NewUsernameBox.SelectionStart = 0;
            this.NewUsernameBox.Size = new System.Drawing.Size(258, 23);
            this.NewUsernameBox.TabIndex = 17;
            this.NewUsernameBox.TabStop = false;
            this.NewUsernameBox.UseSystemPasswordChar = false;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(20, 208);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(111, 19);
            this.materialLabel10.TabIndex = 16;
            this.materialLabel10.Text = "New Username";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(272, 70);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(77, 19);
            this.materialLabel9.TabIndex = 15;
            this.materialLabel9.Text = "Username";
            // 
            // EditProfileBtn
            // 
            this.EditProfileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditProfileBtn.AutoSize = true;
            this.EditProfileBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditProfileBtn.Depth = 0;
            this.EditProfileBtn.Icon = null;
            this.EditProfileBtn.Location = new System.Drawing.Point(21, 327);
            this.EditProfileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditProfileBtn.Name = "EditProfileBtn";
            this.EditProfileBtn.Primary = true;
            this.EditProfileBtn.Size = new System.Drawing.Size(93, 36);
            this.EditProfileBtn.TabIndex = 14;
            this.EditProfileBtn.Text = "Edit Login";
            this.EditProfileBtn.UseVisualStyleBackColor = true;
            this.EditProfileBtn.Click += new System.EventHandler(this.EditProfileBtn_Click);
            // 
            // WardLabel
            // 
            this.WardLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WardLabel.AutoSize = true;
            this.WardLabel.Depth = 0;
            this.WardLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.WardLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WardLabel.Location = new System.Drawing.Point(400, 15);
            this.WardLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.WardLabel.Name = "WardLabel";
            this.WardLabel.Size = new System.Drawing.Size(47, 19);
            this.WardLabel.TabIndex = 13;
            this.WardLabel.Text = "Ward:";
            // 
            // DoBLabel
            // 
            this.DoBLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DoBLabel.AutoSize = true;
            this.DoBLabel.Location = new System.Drawing.Point(113, 76);
            this.DoBLabel.Name = "DoBLabel";
            this.DoBLabel.Size = new System.Drawing.Size(35, 13);
            this.DoBLabel.TabIndex = 10;
            this.DoBLabel.Text = "label1";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "DOB";
            // 
            // ContactLabel
            // 
            this.ContactLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(113, 44);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(44, 13);
            this.ContactLabel.TabIndex = 8;
            this.ContactLabel.Text = "Contact";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contact";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(113, 16);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "label1";
            this.NameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(18, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 5;
            this.label.Text = "Name";
            // 
            // PanelUser
            // 
            this.PanelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelUser.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.PanelUser.Controls.Add(this.FemaleGender);
            this.PanelUser.Controls.Add(this.MaleGender);
            this.PanelUser.Controls.Add(this.StaffRepPassBox);
            this.PanelUser.Controls.Add(this.materialLabel8);
            this.PanelUser.Controls.Add(this.PasswordBox);
            this.PanelUser.Controls.Add(this.StaffUsernameBox);
            this.PanelUser.Controls.Add(this.materialLabel7);
            this.PanelUser.Controls.Add(this.materialLabel6);
            this.PanelUser.Controls.Add(this.DoBPicker);
            this.PanelUser.Controls.Add(this.ContactBox);
            this.PanelUser.Controls.Add(this.EmailBox);
            this.PanelUser.Controls.Add(this.LnameBox);
            this.PanelUser.Controls.Add(this.FnameBox);
            this.PanelUser.Controls.Add(this.CancelBtn);
            this.PanelUser.Controls.Add(this.SaveStaffBtn);
            this.PanelUser.Controls.Add(this.materialLabel5);
            this.PanelUser.Controls.Add(this.materialLabel4);
            this.PanelUser.Controls.Add(this.materialLabel3);
            this.PanelUser.Controls.Add(this.materialLabel2);
            this.PanelUser.Controls.Add(this.materialLabel1);
            this.PanelUser.Controls.Add(this.fnameLabel);
            this.PanelUser.HorizontalScrollbarBarColor = true;
            this.PanelUser.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelUser.HorizontalScrollbarSize = 10;
            this.PanelUser.Location = new System.Drawing.Point(175, 64);
            this.PanelUser.Name = "PanelUser";
            this.PanelUser.Size = new System.Drawing.Size(623, 386);
            this.PanelUser.TabIndex = 3;
            this.PanelUser.VerticalScrollbarBarColor = true;
            this.PanelUser.VerticalScrollbarHighlightOnWheel = false;
            this.PanelUser.VerticalScrollbarSize = 10;
            this.PanelUser.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelUser_Paint);
            // 
            // FemaleGender
            // 
            this.FemaleGender.AutoSize = true;
            this.FemaleGender.Location = new System.Drawing.Point(221, 182);
            this.FemaleGender.Name = "FemaleGender";
            this.FemaleGender.Size = new System.Drawing.Size(61, 15);
            this.FemaleGender.TabIndex = 26;
            this.FemaleGender.TabStop = true;
            this.FemaleGender.Text = "Female";
            this.FemaleGender.UseVisualStyleBackColor = true;
            // 
            // MaleGender
            // 
            this.MaleGender.AutoSize = true;
            this.MaleGender.Location = new System.Drawing.Point(138, 182);
            this.MaleGender.Name = "MaleGender";
            this.MaleGender.Size = new System.Drawing.Size(49, 15);
            this.MaleGender.TabIndex = 25;
            this.MaleGender.TabStop = true;
            this.MaleGender.Text = "Male";
            this.MaleGender.UseVisualStyleBackColor = true;
            // 
            // StaffRepPassBox
            // 
            this.StaffRepPassBox.Depth = 0;
            this.StaffRepPassBox.Hint = "";
            this.StaffRepPassBox.Location = new System.Drawing.Point(168, 282);
            this.StaffRepPassBox.MaxLength = 32767;
            this.StaffRepPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.StaffRepPassBox.Name = "StaffRepPassBox";
            this.StaffRepPassBox.PasswordChar = '\0';
            this.StaffRepPassBox.SelectedText = "";
            this.StaffRepPassBox.SelectionLength = 0;
            this.StaffRepPassBox.SelectionStart = 0;
            this.StaffRepPassBox.Size = new System.Drawing.Size(409, 23);
            this.StaffRepPassBox.TabIndex = 24;
            this.StaffRepPassBox.TabStop = false;
            this.StaffRepPassBox.UseSystemPasswordChar = true;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(17, 282);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(127, 19);
            this.materialLabel8.TabIndex = 23;
            this.materialLabel8.Text = "Password (Again)";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Hint = "";
            this.PasswordBox.Location = new System.Drawing.Point(138, 247);
            this.PasswordBox.MaxLength = 32767;
            this.PasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '\0';
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.Size = new System.Drawing.Size(439, 23);
            this.PasswordBox.TabIndex = 22;
            this.PasswordBox.TabStop = false;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // StaffUsernameBox
            // 
            this.StaffUsernameBox.Depth = 0;
            this.StaffUsernameBox.Hint = "";
            this.StaffUsernameBox.Location = new System.Drawing.Point(138, 218);
            this.StaffUsernameBox.MaxLength = 32767;
            this.StaffUsernameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.StaffUsernameBox.Name = "StaffUsernameBox";
            this.StaffUsernameBox.PasswordChar = '\0';
            this.StaffUsernameBox.SelectedText = "";
            this.StaffUsernameBox.SelectionLength = 0;
            this.StaffUsernameBox.SelectionStart = 0;
            this.StaffUsernameBox.Size = new System.Drawing.Size(439, 23);
            this.StaffUsernameBox.TabIndex = 21;
            this.StaffUsernameBox.TabStop = false;
            this.StaffUsernameBox.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(20, 252);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(75, 19);
            this.materialLabel7.TabIndex = 20;
            this.materialLabel7.Text = "Password";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(20, 218);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(77, 19);
            this.materialLabel6.TabIndex = 19;
            this.materialLabel6.Text = "Username";
            // 
            // DoBPicker
            // 
            this.DoBPicker.Location = new System.Drawing.Point(138, 141);
            this.DoBPicker.Name = "DoBPicker";
            this.DoBPicker.Size = new System.Drawing.Size(439, 20);
            this.DoBPicker.TabIndex = 17;
            // 
            // ContactBox
            // 
            this.ContactBox.Depth = 0;
            this.ContactBox.Hint = "";
            this.ContactBox.Location = new System.Drawing.Point(138, 111);
            this.ContactBox.MaxLength = 32767;
            this.ContactBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ContactBox.Name = "ContactBox";
            this.ContactBox.PasswordChar = '\0';
            this.ContactBox.SelectedText = "";
            this.ContactBox.SelectionLength = 0;
            this.ContactBox.SelectionStart = 0;
            this.ContactBox.Size = new System.Drawing.Size(439, 23);
            this.ContactBox.TabIndex = 16;
            this.ContactBox.TabStop = false;
            this.ContactBox.UseSystemPasswordChar = false;
            // 
            // EmailBox
            // 
            this.EmailBox.Depth = 0;
            this.EmailBox.Hint = "";
            this.EmailBox.Location = new System.Drawing.Point(138, 82);
            this.EmailBox.MaxLength = 32767;
            this.EmailBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.PasswordChar = '\0';
            this.EmailBox.SelectedText = "";
            this.EmailBox.SelectionLength = 0;
            this.EmailBox.SelectionStart = 0;
            this.EmailBox.Size = new System.Drawing.Size(439, 23);
            this.EmailBox.TabIndex = 15;
            this.EmailBox.TabStop = false;
            this.EmailBox.UseSystemPasswordChar = false;
            // 
            // LnameBox
            // 
            this.LnameBox.Depth = 0;
            this.LnameBox.Hint = "";
            this.LnameBox.Location = new System.Drawing.Point(138, 46);
            this.LnameBox.MaxLength = 32767;
            this.LnameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.LnameBox.Name = "LnameBox";
            this.LnameBox.PasswordChar = '\0';
            this.LnameBox.SelectedText = "";
            this.LnameBox.SelectionLength = 0;
            this.LnameBox.SelectionStart = 0;
            this.LnameBox.Size = new System.Drawing.Size(439, 23);
            this.LnameBox.TabIndex = 14;
            this.LnameBox.TabStop = false;
            this.LnameBox.UseSystemPasswordChar = false;
            this.LnameBox.Click += new System.EventHandler(this.materialSingleLineTextField2_Click);
            // 
            // FnameBox
            // 
            this.FnameBox.Depth = 0;
            this.FnameBox.Hint = "";
            this.FnameBox.Location = new System.Drawing.Point(138, 16);
            this.FnameBox.MaxLength = 32767;
            this.FnameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.FnameBox.Name = "FnameBox";
            this.FnameBox.PasswordChar = '\0';
            this.FnameBox.SelectedText = "";
            this.FnameBox.SelectionLength = 0;
            this.FnameBox.SelectionStart = 0;
            this.FnameBox.Size = new System.Drawing.Size(439, 23);
            this.FnameBox.TabIndex = 13;
            this.FnameBox.TabStop = false;
            this.FnameBox.UseSystemPasswordChar = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(504, 331);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = true;
            this.CancelBtn.Size = new System.Drawing.Size(73, 36);
            this.CancelBtn.TabIndex = 12;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveStaffBtn
            // 
            this.SaveStaffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveStaffBtn.AutoSize = true;
            this.SaveStaffBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveStaffBtn.Depth = 0;
            this.SaveStaffBtn.Icon = null;
            this.SaveStaffBtn.Location = new System.Drawing.Point(24, 331);
            this.SaveStaffBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveStaffBtn.Name = "SaveStaffBtn";
            this.SaveStaffBtn.Primary = true;
            this.SaveStaffBtn.Size = new System.Drawing.Size(55, 36);
            this.SaveStaffBtn.TabIndex = 11;
            this.SaveStaffBtn.Text = "Save";
            this.SaveStaffBtn.UseVisualStyleBackColor = true;
            this.SaveStaffBtn.Click += new System.EventHandler(this.SaveStaffBtn_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(17, 179);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(56, 19);
            this.materialLabel5.TabIndex = 7;
            this.materialLabel5.Text = "Gender";
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(17, 142);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(93, 19);
            this.materialLabel4.TabIndex = 6;
            this.materialLabel4.Text = "Date of Birth";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(17, 115);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(62, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Contact";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(17, 82);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(47, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Email";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(17, 50);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(79, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Last name";
            // 
            // fnameLabel
            // 
            this.fnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fnameLabel.AutoSize = true;
            this.fnameLabel.Depth = 0;
            this.fnameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.fnameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fnameLabel.Location = new System.Drawing.Point(17, 20);
            this.fnameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(80, 19);
            this.fnameLabel.TabIndex = 2;
            this.fnameLabel.Text = "First name";
            // 
            // ToPdfBtn
            // 
            this.ToPdfBtn.AutoSize = true;
            this.ToPdfBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ToPdfBtn.Depth = 0;
            this.ToPdfBtn.Icon = null;
            this.ToPdfBtn.Location = new System.Drawing.Point(490, 7);
            this.ToPdfBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ToPdfBtn.Name = "ToPdfBtn";
            this.ToPdfBtn.Primary = true;
            this.ToPdfBtn.Size = new System.Drawing.Size(123, 36);
            this.ToPdfBtn.TabIndex = 4;
            this.ToPdfBtn.Text = "Export to PDF";
            this.ToPdfBtn.UseVisualStyleBackColor = true;
            this.ToPdfBtn.Click += new System.EventHandler(this.ToPdfBtn_Click);
            // 
            // HomeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelDashboard);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.PanelAccount);
            this.Controls.Add(this.PanelUser);
            this.MaximizeBox = false;
            this.Name = "HomeManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Charge";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeManagement_FormClosed);
            this.Load += new System.EventHandler(this.HomeManagement_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.PanelDashboard.ResumeLayout(false);
            this.PanelDashboard.PerformLayout();
            this.PanelAccount.ResumeLayout(false);
            this.PanelAccount.PerformLayout();
            this.PanelUser.ResumeLayout(false);
            this.PanelUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton SignOutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton UserBtn;
        private MaterialSkin.Controls.MaterialRaisedButton AccountBtn;
        private MaterialSkin.Controls.MaterialRaisedButton DashboardBtn;
        private MetroFramework.Controls.MetroPanel PanelDashboard;
        private MaterialSkin.Controls.MaterialListView StaffListView;
        private System.Windows.Forms.ColumnHeader IndexColumn;
        private System.Windows.Forms.ColumnHeader StaffIdNumberColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader ShiftColumn;
        private MetroFramework.Controls.MetroPanel PanelAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label ContactLabel;
        private MaterialSkin.Controls.MaterialRaisedButton EditProfileBtn;
        private MaterialSkin.Controls.MaterialLabel WardLabel;
        private System.Windows.Forms.Label DoBLabel;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroPanel PanelUser;
        private MaterialSkin.Controls.MaterialRaisedButton CancelBtn;
        private MaterialSkin.Controls.MaterialRaisedButton SaveStaffBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel fnameLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField LnameBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField FnameBox;
        private System.Windows.Forms.DateTimePicker DoBPicker;
        private MaterialSkin.Controls.MaterialSingleLineTextField ContactBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField EmailBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField StaffRepPassBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField StaffUsernameBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField NewPasswordBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField CurrentUserPassword;
        private MaterialSkin.Controls.MaterialLabel Newpassvalue;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialSingleLineTextField NewUsernameBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.Label UsernameLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField OldUsername;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MetroFramework.Controls.MetroRadioButton FemaleGender;
        private MetroFramework.Controls.MetroRadioButton MaleGender;
        private MaterialSkin.Controls.MaterialLabel WardInfoLAbel;
        private MaterialSkin.Controls.MaterialRaisedButton ToPdfBtn;
    }
}