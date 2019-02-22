using Customs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;


namespace Staff_Schedulling_System.Admin
{
    public partial class Users : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public Users(LoginForm loginForm)
        {
            InitializeComponent();
            Login = loginForm;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);

            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            foreach (var item in dbEntities3.Wards.ToList())
            {
                WardComboBox.Items.Add(item.Name);
            }
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            new Dashboard(Login).Show();
            Close();
        }

        private void AccountBtn_Click(object sender, EventArgs e)
        {
            new Account(Login).Show();
            Close();
        }

        private void WardBtn_Click(object sender, EventArgs e)
        {
            new Ward(Login).Show();
            Close();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            Close();
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            if (!Check(UserFnameBox) || !Check(UserLnameBox) || !Check(UserContactBox) || !Check(UserEmailBox)
                || !Check(UsernameBox) || !Check(PasswordBox) || DoBUser.Value >= DateTime.Now.AddYears(-20)
                || AccounTypeComboBox.SelectedIndex <= -1 ||
                (AccounTypeComboBox.SelectedItem.ToString() != "admin" && WardComboBox.SelectedIndex <= -1))
            {
                MessageBox.Show("Please, fill in all fields!");
            }
            else
            {
                using (StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3())
                {
                    try
                    {
                        if (PasswordBox.Text == PasswordBoxNex.Text)
                        {
                            DateTime date = DateTime.Now;
                            Controls controls = new Controls();
                            enc = new Encryption { Key = controls.Key };
                            RegExpression reg = new RegExpression();
                            Staff_Schedulling_System.Account account = new Staff_Schedulling_System.Account
                            {
                                Id = $"A/{date.Day}/{date.Year}/{date.Month}/{(dbEntities.Accounts.Count() == 0 ? 1 : dbEntities.Accounts.Count() + 1)}",
                                Username = UsernameBox.Text,
                                Password = enc.GetMD5(enc.StrongEncrypt(PasswordBox.Text)),
                                Date = date,
                                UserType = AccounTypeComboBox.SelectedItem.ToString().ToLower()
                            };
                            Staff staff = new Staff
                            {
                                Id = $"S/{date.Day}/{date.Year}/{date.Month}/{(dbEntities.Staffs.Count() == 0 ? 1 : dbEntities.Staffs.Count() + 1)}",
                                Fname = UserFnameBox.Text,
                                Lname = UserLnameBox.Text,
                                PhoneNumber = reg.IsCorrect(UserContactBox.Text, "[+256?0][0-9]{9}") ? UserContactBox.Text : "",
                                Email = UserEmailBox.Text,
                                DateOfBirth = DoBUser.Value,
                                Date = date,
                                AccountId = account.Id,
                                AccessLevel = AccounTypeComboBox.SelectedItem.ToString().ToLower()
                            };
                            dbEntities.Staffs.Add(staff);
                            dbEntities.Accounts.Add(account);
                            var ward = dbEntities.Wards.FirstOrDefault(w => w.Name == WardComboBox.SelectedItem.ToString()).Id;
                            StaffWard staffWard = new StaffWard
                            {
                                Id = ward + " - " + staff.Id,
                                StaffID = staff.Id,
                                WardId = dbEntities.Wards.FirstOrDefault(w => w.Name == WardComboBox.SelectedItem.ToString()).Id
                            };
                            dbEntities.StaffWards.Add(staffWard);
                            dbEntities.SaveChanges();
                            MessageBox.Show("New user has been added!");
                            UserFnameBox.Text = "";
                            UserLnameBox.Text = "";
                            UserContactBox.Text = "";
                            UserEmailBox.Text = "";
                            UsernameBox.Text = "";
                            PasswordBox.Text = "";
                            PasswordBoxNex.Text = "";
                            DoBUser.Value = date;
                            WardComboBox.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private bool Check(MaterialSingleLineTextField textField)
        {
            if (string.IsNullOrWhiteSpace(textField.Text) || textField.Text == "")
            {
                return false;
            }
            return true;
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void ViewAllUsersBtn_Click(object sender, EventArgs e)
        {
            new All("Admin").ShowDialog();
        }

        private void UsernameBox_Click(object sender, EventArgs e)
        {

        }
    }
}
