using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using Customs;
using System.IO;
using CustomMessageBox;

namespace Staff_Schedulling_System
{
    public partial class LoginForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        Encryption enc;
        Controls controls;
        public LoginForm()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange800, Primary.DeepOrange900, Primary.DeepOrange500, Accent.LightBlue200, TextShade.WHITE);
            this.FormClosing += LoginForm_FormClosing;
            UsernameBox.Text = "johntuza";
            PasswordBox.Text = "Sylver94";            
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void SigninBtn_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            controls = new Controls();
            enc = new Encryption { Key = controls.Key };
            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();
            if (dbEntities.Accounts.Count() == 0)
            {
                DateTime date = DateTime.Now;
                Controls controls = new Controls();
                enc = new Encryption { Key = controls.Key };
                RegExpression reg = new RegExpression();
                Staff_Schedulling_System.Account account_ = new Staff_Schedulling_System.Account
                {
                    Id = $"A/{date.Day}/{date.Year}/{date.Month}/{(dbEntities.Accounts.Count() == 0 ? 1 : dbEntities.Accounts.Count() + 1)}",
                    Username = UsernameBox.Text,
                    Password = enc.GetMD5(enc.StrongEncrypt(PasswordBox.Text)),
                    Date = date,
                    UserType = "admin"
                };
                dbEntities.Accounts.Add(account_);
                dbEntities.SaveChanges();
            }
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || UsernameBox.Text == ""
                || string.IsNullOrWhiteSpace(PasswordBox.Text) || UsernameBox.Text == "")
            {
                new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Please fill in all fields").ShowDialog();
            }
            else
            {
                account = dbEntities.Accounts.Where(a => a.Username == UsernameBox.Text).FirstOrDefault();
                if (account == null)
                {
                    new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Wrong username or password").ShowDialog();
                }
                else
                {
                    if (enc.GetMD5(enc.StrongEncrypt(PasswordBox.Text)) == account.Password)
                    {
                        StreamWriter writer = new StreamWriter("LoginInfo.txt");
                        writer.WriteLine(account.Id);
                        writer.Close();
                        controls.UserId = account.Id;
                        Hide();
                        switch (account.UserType.ToLower())
                        {
                            case "admin": new Admin.Dashboard(this).Show(); ; break;
                            case "management": new HomeManagement(this).Show(); break;
                            case "basic": new Personel.BasicStaff(this).Show(); break;
                            default: break;
                        }
                    }
                    else
                    {
                        new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Wrong username or password").ShowDialog();
                    }
                }
            }
        }
    }
}
