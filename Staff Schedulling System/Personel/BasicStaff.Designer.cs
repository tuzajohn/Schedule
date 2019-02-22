namespace Staff_Schedulling_System.Personel
{
    partial class BasicStaff
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
            this.ShiftDays = new System.Windows.Forms.MonthCalendar();
            this.DobLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SignOutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.OldPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NewRepPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.NewPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ChangePassBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ShiftPanel = new MetroFramework.Controls.MetroPanel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.DateLabel = new MaterialSkin.Controls.MaterialLabel();
            this.StartTimeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.EndTimeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ShiftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShiftDays
            // 
            this.ShiftDays.Location = new System.Drawing.Point(40, 175);
            this.ShiftDays.Name = "ShiftDays";
            this.ShiftDays.TabIndex = 0;
            this.ShiftDays.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.ShiftDays_DateChanged);
            // 
            // DobLabel
            // 
            this.DobLabel.AutoSize = true;
            this.DobLabel.Location = new System.Drawing.Point(411, 131);
            this.DobLabel.Name = "DobLabel";
            this.DobLabel.Size = new System.Drawing.Size(55, 13);
            this.DobLabel.TabIndex = 19;
            this.DobLabel.Text = "Username";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "D.O.B.:";
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(411, 93);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(55, 13);
            this.ContactLabel.TabIndex = 17;
            this.ContactLabel.Text = "Username";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(125, 129);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(55, 13);
            this.EmailLabel.TabIndex = 16;
            this.EmailLabel.Text = "Username";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(125, 93);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(55, 13);
            this.NameLabel.TabIndex = 15;
            this.NameLabel.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Contact:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name:";
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.AutoSize = true;
            this.SignOutBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SignOutBtn.Depth = 0;
            this.SignOutBtn.Icon = null;
            this.SignOutBtn.Location = new System.Drawing.Point(706, 81);
            this.SignOutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Primary = true;
            this.SignOutBtn.Size = new System.Drawing.Size(82, 36);
            this.SignOutBtn.TabIndex = 20;
            this.SignOutBtn.Text = "Sign Out";
            this.SignOutBtn.UseVisualStyleBackColor = true;
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // OldPassBox
            // 
            this.OldPassBox.Depth = 0;
            this.OldPassBox.Hint = "";
            this.OldPassBox.Location = new System.Drawing.Point(40, 388);
            this.OldPassBox.MaxLength = 32767;
            this.OldPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.OldPassBox.Name = "OldPassBox";
            this.OldPassBox.PasswordChar = '\0';
            this.OldPassBox.SelectedText = "";
            this.OldPassBox.SelectionLength = 0;
            this.OldPassBox.SelectionStart = 0;
            this.OldPassBox.Size = new System.Drawing.Size(212, 23);
            this.OldPassBox.TabIndex = 21;
            this.OldPassBox.TabStop = false;
            this.OldPassBox.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Old password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "New password (A):";
            // 
            // NewRepPassBox
            // 
            this.NewRepPassBox.Depth = 0;
            this.NewRepPassBox.Hint = "";
            this.NewRepPassBox.Location = new System.Drawing.Point(296, 417);
            this.NewRepPassBox.MaxLength = 32767;
            this.NewRepPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewRepPassBox.Name = "NewRepPassBox";
            this.NewRepPassBox.PasswordChar = '\0';
            this.NewRepPassBox.SelectedText = "";
            this.NewRepPassBox.SelectionLength = 0;
            this.NewRepPassBox.SelectionStart = 0;
            this.NewRepPassBox.Size = new System.Drawing.Size(212, 23);
            this.NewRepPassBox.TabIndex = 23;
            this.NewRepPassBox.TabStop = false;
            this.NewRepPassBox.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "New password:";
            // 
            // NewPassBox
            // 
            this.NewPassBox.Depth = 0;
            this.NewPassBox.Hint = "";
            this.NewPassBox.Location = new System.Drawing.Point(296, 360);
            this.NewPassBox.MaxLength = 32767;
            this.NewPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewPassBox.Name = "NewPassBox";
            this.NewPassBox.PasswordChar = '\0';
            this.NewPassBox.SelectedText = "";
            this.NewPassBox.SelectionLength = 0;
            this.NewPassBox.SelectionStart = 0;
            this.NewPassBox.Size = new System.Drawing.Size(212, 23);
            this.NewPassBox.TabIndex = 25;
            this.NewPassBox.TabStop = false;
            this.NewPassBox.UseSystemPasswordChar = false;
            // 
            // ChangePassBtn
            // 
            this.ChangePassBtn.AutoSize = true;
            this.ChangePassBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangePassBtn.Depth = 0;
            this.ChangePassBtn.Icon = null;
            this.ChangePassBtn.Location = new System.Drawing.Point(562, 394);
            this.ChangePassBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangePassBtn.Name = "ChangePassBtn";
            this.ChangePassBtn.Primary = true;
            this.ChangePassBtn.Size = new System.Drawing.Size(153, 36);
            this.ChangePassBtn.TabIndex = 27;
            this.ChangePassBtn.Text = "Change Password";
            this.ChangePassBtn.UseVisualStyleBackColor = true;
            this.ChangePassBtn.Click += new System.EventHandler(this.ChangePassBtn_Click);
            // 
            // ShiftPanel
            // 
            this.ShiftPanel.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ShiftPanel.Controls.Add(this.EndTimeLabel);
            this.ShiftPanel.Controls.Add(this.StartTimeLabel);
            this.ShiftPanel.Controls.Add(this.DateLabel);
            this.ShiftPanel.Controls.Add(this.materialLabel3);
            this.ShiftPanel.Controls.Add(this.materialLabel2);
            this.ShiftPanel.Controls.Add(this.materialLabel1);
            this.ShiftPanel.HorizontalScrollbarBarColor = true;
            this.ShiftPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ShiftPanel.HorizontalScrollbarSize = 10;
            this.ShiftPanel.Location = new System.Drawing.Point(326, 175);
            this.ShiftPanel.Name = "ShiftPanel";
            this.ShiftPanel.Size = new System.Drawing.Size(444, 140);
            this.ShiftPanel.TabIndex = 28;
            this.ShiftPanel.VerticalScrollbarBarColor = true;
            this.ShiftPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ShiftPanel.VerticalScrollbarSize = 10;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(32, 27);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(44, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Date:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(32, 67);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(45, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Start:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(32, 107);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(38, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "End:";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Depth = 0;
            this.DateLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.DateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DateLabel.Location = new System.Drawing.Point(160, 27);
            this.DateLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(13, 19);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "-";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Depth = 0;
            this.StartTimeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.StartTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StartTimeLabel.Location = new System.Drawing.Point(160, 67);
            this.StartTimeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(13, 19);
            this.StartTimeLabel.TabIndex = 6;
            this.StartTimeLabel.Text = "-";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Depth = 0;
            this.EndTimeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.EndTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EndTimeLabel.Location = new System.Drawing.Point(160, 107);
            this.EndTimeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(13, 19);
            this.EndTimeLabel.TabIndex = 7;
            this.EndTimeLabel.Text = "-";
            // 
            // BasicStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShiftPanel);
            this.Controls.Add(this.ChangePassBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NewPassBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NewRepPassBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OldPassBox);
            this.Controls.Add(this.SignOutBtn);
            this.Controls.Add(this.DobLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShiftDays);
            this.MaximizeBox = false;
            this.Name = "BasicStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Shifts";
            this.Load += new System.EventHandler(this.BasicStaff_Load);
            this.ShiftPanel.ResumeLayout(false);
            this.ShiftPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar ShiftDays;
        private System.Windows.Forms.Label DobLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRaisedButton SignOutBtn;
        private MaterialSkin.Controls.MaterialSingleLineTextField OldPassBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialSingleLineTextField NewRepPassBox;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialSingleLineTextField NewPassBox;
        private MaterialSkin.Controls.MaterialRaisedButton ChangePassBtn;
        private MetroFramework.Controls.MetroPanel ShiftPanel;
        private MaterialSkin.Controls.MaterialLabel EndTimeLabel;
        private MaterialSkin.Controls.MaterialLabel StartTimeLabel;
        private MaterialSkin.Controls.MaterialLabel DateLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}