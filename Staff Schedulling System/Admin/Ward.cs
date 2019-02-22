using Customs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;
using Staff_Schedulling_System;
using CustomMessageBox;

namespace Staff_Schedulling_System.Admin
{
    public partial class Ward : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public string WardID { get; internal set; }
        public Ward(LoginForm login)
        {
            InitializeComponent();
            Login = login;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);
            WardListView.ItemSelectionChanged += ItemChanged;
        }

        //list view event for the ward panel
        private void ItemChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();
            Staff_Schedulling_System.Ward ward = dbEntities.Wards.ToList()[e.ItemIndex];            
            WardNameBox.Text = ward.Name;
        }

        //load onto the list view on the "ward panel"
        private void LoadWardListView(StaffSchedullingDbEntities3 dbEntities)
        {
            WardListView.Items.Clear();
            foreach (Staff_Schedulling_System.Ward ward in dbEntities.Wards)
            {
                string[] column = { ward.Id, ward.Name };
                ListViewItem listViewItem = new ListViewItem(column);
                WardListView.Items.Add(listViewItem);
            }
        }

        private void AddWardBtn_Click(object sender, EventArgs e)
        {
            using (StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3())
            {
                if (WardNameBox.Text != "" || !string.IsNullOrWhiteSpace(WardNameBox.Text))
                {
                    Staff_Schedulling_System.Ward ward = dbEntities.Wards.FirstOrDefault(w => w.Name == WardNameBox.Text);
                    if (ward == null)
                    {
                        DateTime date = DateTime.Now;
                        ward = new Staff_Schedulling_System.Ward
                        {
                            Id = $"W/{date.Day}/{date.Year}/{date.Month}/{(dbEntities.Wards.Count() == 0 ? 1 : dbEntities.Wards.Count() + 1)}",
                            Name = WardNameBox.Text,
                            Date = date
                        };
                        dbEntities.Wards.Add(ward);
                        dbEntities.SaveChanges();
                        //message of success
                        new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "Ward added successfully!").ShowDialog();
                        WardNameBox.Text = "";
                        WardDescBox.Text = "";
                        LoadWardListView(dbEntities);
                        new Settings().ShowDialog();
                    }
                    else
                    {
                        //ward exist already
                        new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "Ward already exist!").ShowDialog();
                    }
                }
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

        private void UpdateWardBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var selectedWard = dbEntities3.Wards.FirstOrDefault(w => w.Id == WardID);
            selectedWard.Name = WardNameBox.Text;
            dbEntities3.SaveChanges();
            LoadWardListViewItems();
            new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "Changes saved!");
        }

        private void DeleteWardBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var selectedWard = dbEntities3.Wards.FirstOrDefault(w => w.Id == WardID);

            var dialogResult = MessageBox.Show("You are about to delete the following ward "+ selectedWard.Name + " this will result in the removal of al the staff " +
                "related to this ward.\n Are you sure of this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            new MyCustomMessageBox(MyCustomMessageBox.State.WARNING, "You are about to delete the following ward " + selectedWard.Name + " this will result in the removal of al the staff " +
                "related to this ward.\n Are you sure of this?", MessageBoxButtons.YesNo, out DialogResult dialogResult1);
            if (DialogResult.OK == dialogResult)
            {
                var staffWards = dbEntities3.StaffWards.Where(sw => sw.WardId == selectedWard.Id);
                foreach (var staffWard in staffWards)
                {
                    var staff = dbEntities3.Staffs.FirstOrDefault(s => s.Id == staffWard.StaffID);
                    dbEntities3.Staffs.Remove(staff);
                    dbEntities3.StaffWards.Remove(staffWard);
                }
                dbEntities3.Wards.Remove(selectedWard);
                MessageBox.Show("Deletion complete!");
            }
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

        private void WardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ward_Load(object sender, EventArgs e)
        {
            LoadWardListViewItems();
        }

        private void LoadWardListViewItems()
        {
            WardListView.Items.Clear();
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            foreach (var ward_ in dbEntities3.Wards)
            {
                string[] items = { ward_.Id, ward_.Name };
                ListViewItem item = new ListViewItem(items);
                WardListView.Items.Add(item);
            }
        }

        private void WardListView_Click(object sender, EventArgs e)
        {
            WardID = WardListView.SelectedItems[0].SubItems[0].Text;

            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var selectedWard = dbEntities3.Wards.FirstOrDefault(w => w.Id == WardID);

            WardNameBox.Text = selectedWard.Name;
        }

        private void CancelWardBtn_Click(object sender, EventArgs e)
        {
            WardNameBox.Text = "";
            WardDescBox.Text = "";
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            Close();
        }
    }
}
