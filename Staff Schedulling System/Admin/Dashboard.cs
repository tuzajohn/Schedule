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
    public partial class Dashboard : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public Dashboard(LoginForm login)
        {
            InitializeComponent();
            Login = login;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);

            //call list view populating function
            LoadListView();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();
            NumberOfWardBtn.Text += $"({dbEntities.Wards.Count()})";
            NumberOfStaffBtn.Text += $"({dbEntities.Staffs.Count()})";
            NumberOfInChargeBtn.Text += $"({dbEntities.Staffs.Where(s => s.Account.UserType == "management").Count()})";
            FormClosing += ClosingForm;
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }
        //signout currently logged in guy
        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            Login.Show();
            Close();
        }
        //opens account page
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
        //opens settings
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            new Users(Login).Show();
            Close();
        }
        //load all user data onto list view on dashboard
        void LoadListView()
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var users = dbEntities3.Staffs.ToList();
            int i = 0;
            foreach (var user in users)
            {
                i++;
                var type = user.Account.UserType;
                var ward = dbEntities3.Wards.FirstOrDefault(w => w.Id == dbEntities3.StaffWards.FirstOrDefault(s => s.StaffID == user.Id).WardId).Name;
                string[] userObj = { i.ToString(), user.Fname + " " + user.Lname, type, ward, user.Date.ToString() };
                ListViewItem item = new ListViewItem(userObj);
                materialListView1.Items.Add(item);
            }
        }
        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
