namespace Staff_Schedulling_System
{
    partial class LoginForm
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
            this.UsernameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SigninBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.Depth = 0;
            this.UsernameBox.Hint = "Username";
            this.UsernameBox.Location = new System.Drawing.Point(12, 74);
            this.UsernameBox.MaxLength = 32767;
            this.UsernameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.PasswordChar = '\0';
            this.UsernameBox.SelectedText = "";
            this.UsernameBox.SelectionLength = 0;
            this.UsernameBox.SelectionStart = 0;
            this.UsernameBox.Size = new System.Drawing.Size(281, 23);
            this.UsernameBox.TabIndex = 1;
            this.UsernameBox.TabStop = false;
            this.UsernameBox.UseSystemPasswordChar = false;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Hint = "Password";
            this.PasswordBox.Location = new System.Drawing.Point(12, 115);
            this.PasswordBox.MaxLength = 32767;
            this.PasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '#';
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.Size = new System.Drawing.Size(281, 23);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.TabStop = false;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // SigninBtn
            // 
            this.SigninBtn.AutoSize = true;
            this.SigninBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SigninBtn.Depth = 0;
            this.SigninBtn.Icon = null;
            this.SigninBtn.Location = new System.Drawing.Point(115, 144);
            this.SigninBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SigninBtn.Name = "SigninBtn";
            this.SigninBtn.Primary = true;
            this.SigninBtn.Size = new System.Drawing.Size(66, 36);
            this.SigninBtn.TabIndex = 3;
            this.SigninBtn.Text = "SIGNIN";
            this.SigninBtn.UseVisualStyleBackColor = true;
            this.SigninBtn.Click += new System.EventHandler(this.SigninBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 195);
            this.Controls.Add(this.SigninBtn);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField UsernameBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordBox;
        private MaterialSkin.Controls.MaterialRaisedButton SigninBtn;
    }
}

