using CustomMessageBox;
using Customs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Staff_Schedulling_System.Admin
{
    public partial class Account : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public string Uid { get; internal set; }
        public Account(LoginForm login)
        {
            InitializeComponent();
            Login = login;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);

            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();
            reader.Close();

            Uid = uid;

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            new Dashboard(Login).Show();
            Close();
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {

        }

        private void WardBtn_Click(object sender, EventArgs e)
        {
            new Ward(Login).Show();
            Close();
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            new Users(Login).Show();
            Close();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            Login.Show();
            Close();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            //load user account details
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var myAccount = dbEntities3.Staffs.FirstOrDefault(s => s.AccountId == Uid);
            NameLabel.Text = myAccount.Fname + " " + myAccount.Lname;
            EmailLabel.Text = myAccount.Email;
            ContactLabel.Text = myAccount.PhoneNumber;
            DobLabel.Text = myAccount.DateOfBirth.ToLongDateString();
            FormClosing += CloseForm;
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }

        private void ChangeUsernameBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var myAccount = dbEntities3.Accounts.FirstOrDefault(s => s.Id == Uid);
            if (myAccount.Username == OldUsernameBox.Text)
            {
                myAccount.Username = NewUsernameBox.Text;
                dbEntities3.SaveChanges();
                OldUsernameBox.Text = "";
                NewUsernameBox.Text = "";
                new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "Username has been changed!").ShowDialog();
            }
            else
            {
                new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Wrong username!").ShowDialog();
            }
        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var myAccount = dbEntities3.Accounts.FirstOrDefault(s => s.Id == Uid);
            enc = new Encryption { Key = new Controls().Key };
            if (enc.GetMD5(enc.StrongEncrypt(OldPasswordBox.Text)) == myAccount.Password )
            {
                if (NewRepPassworBox.Text == NewPasswordBox.Text)
                {
                    var (check, result) = new RegExpression().IsPassword(NewPasswordBox.Text);
                    if (check)
                    {
                        myAccount.Password = enc.GetMD5(enc.StrongEncrypt(NewPasswordBox.Text));
                        dbEntities3.SaveChanges();
                        new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "The password has been changed successfully!");
                        NewPasswordBox.Text = "";
                        OldPasswordBox.Text = "";
                        NewRepPassworBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(result);
                        //new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, result);
                    }
                }
                else
                {
                    new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Passwords do not match!");
                }
            }
            else
            {
                new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Wrong password!");
            }
        }
    }
}
