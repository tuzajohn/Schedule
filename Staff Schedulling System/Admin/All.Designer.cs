namespace Staff_Schedulling_System.Admin
{
    partial class All
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AllUsersListView = new MaterialSkin.Controls.MaterialListView();
            this.CountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.InChargeBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AdminBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.AllUsersListView);
            this.panel1.Location = new System.Drawing.Point(12, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 305);
            this.panel1.TabIndex = 0;
            // 
            // AllUsersListView
            // 
            this.AllUsersListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllUsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CountColumn,
            this.Id,
            this.NameColumn,
            this.Role,
            this.Age,
            this.Email,
            this.Number});
            this.AllUsersListView.Depth = 0;
            this.AllUsersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllUsersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.AllUsersListView.FullRowSelect = true;
            this.AllUsersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AllUsersListView.Location = new System.Drawing.Point(0, 0);
            this.AllUsersListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AllUsersListView.MouseState = MaterialSkin.MouseState.OUT;
            this.AllUsersListView.Name = "AllUsersListView";
            this.AllUsersListView.OwnerDraw = true;
            this.AllUsersListView.Size = new System.Drawing.Size(776, 305);
            this.AllUsersListView.TabIndex = 0;
            this.AllUsersListView.UseCompatibleStateImageBehavior = false;
            this.AllUsersListView.View = System.Windows.Forms.View.Details;
            // 
            // CountColumn
            // 
            this.CountColumn.Text = "";
            // 
            // Id
            // 
            this.Id.Text = "ID";
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 150;
            // 
            // Role
            // 
            this.Role.Text = "Role";
            this.Role.Width = 100;
            // 
            // Age
            // 
            this.Age.Text = "Age";
            this.Age.Width = 90;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 150;
            // 
            // Number
            // 
            this.Number.Text = "Number";
            this.Number.Width = 150;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(12, 76);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(101, 36);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "Export Pdf";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // InChargeBtn
            // 
            this.InChargeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InChargeBtn.AutoSize = true;
            this.InChargeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InChargeBtn.Depth = 0;
            this.InChargeBtn.Icon = null;
            this.InChargeBtn.Location = new System.Drawing.Point(685, 76);
            this.InChargeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.InChargeBtn.Name = "InChargeBtn";
            this.InChargeBtn.Primary = true;
            this.InChargeBtn.Size = new System.Drawing.Size(100, 36);
            this.InChargeBtn.TabIndex = 3;
            this.InChargeBtn.Text = "In Charges";
            this.InChargeBtn.UseVisualStyleBackColor = true;
            this.InChargeBtn.Click += new System.EventHandler(this.InChargeBtn_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminBtn.AutoSize = true;
            this.AdminBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AdminBtn.Depth = 0;
            this.AdminBtn.Icon = null;
            this.AdminBtn.Location = new System.Drawing.Point(606, 76);
            this.AdminBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Primary = true;
            this.AdminBtn.Size = new System.Drawing.Size(73, 36);
            this.AdminBtn.TabIndex = 4;
            this.AdminBtn.Text = "Admins";
            this.AdminBtn.UseVisualStyleBackColor = true;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.InChargeBtn);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "All";
            this.Text = "All";
            this.Load += new System.EventHandler(this.All_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialListView AllUsersListView;
        private System.Windows.Forms.ColumnHeader CountColumn;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Number;
        private MaterialSkin.Controls.MaterialRaisedButton InChargeBtn;
        private MaterialSkin.Controls.MaterialRaisedButton AdminBtn;
    }
}