using Customs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Staff_Schedulling_System.Admin
{
    public partial class Settings : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private Encryption enc;
        Controls controls = new Controls();
        public Settings()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var obj = dbEntities3.Settings.Where(set=>set.Ward.Name == WardComboBox.SelectedItem.ToString()).ToList();
            if (obj.Count() == 0)
            {
                if (WardComboBox.SelectedIndex != -1)
                {
                    if (NumberShistComboBox.SelectedIndex != -1 && NumberStaffWardComboBox.SelectedIndex != -1)
                    {
                        DateTime date = DateTime.Now;
                        Setting setting = new Setting
                        {
                            Id = $"Set/{date.Month}/{date.Day}/{date.Year}/" + (dbEntities3.Settings.Count() + 1),
                            NumberOfShiftaDayInWard = int.Parse(NumberShistComboBox.SelectedItem.ToString()),
                            NumberOfStaffInWard = int.Parse(NumberStaffWardComboBox.SelectedItem.ToString()),
                            Date = date,
                            WardId = dbEntities3.Wards.Where(w=>w.Name == WardComboBox.SelectedItem.ToString()).First().Id
                        };
                        dbEntities3.Settings.Add(setting);
                        dbEntities3.SaveChanges();
                        controls.ReSchedule(
                            int.Parse(NumberStaffWardComboBox.SelectedItem.ToString()),
                            int.Parse(NumberShistComboBox.SelectedItem.ToString()), "");
                        MessageBox.Show("Settings changed successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Provide necessary information!");
                    }
                }
                else
                {
                    MessageBox.Show("Select a ward!");
                }
            }
            else
            {
                var ward = dbEntities3.Wards.FirstOrDefault(w => w.Name == WardComboBox.SelectedItem.ToString());
                var settingObj = dbEntities3.Settings.FirstOrDefault(s => s.WardId == ward.Id);
                settingObj.NumberOfShiftaDayInWard = int.Parse(NumberShistComboBox.SelectedItem.ToString());
                settingObj.NumberOfStaffInWard = int.Parse(NumberStaffWardComboBox.SelectedItem.ToString());
                settingObj.Date = DateTime.Now;
                dbEntities3.SaveChanges();
                controls.ReSchedule(
                    int.Parse(NumberStaffWardComboBox.SelectedItem.ToString()),
                    int.Parse(NumberShistComboBox.SelectedItem.ToString()), "");
                MessageBox.Show("Settings changed successfully!");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            foreach (var ward in dbEntities3.Wards)
            {
                WardComboBox.Items.Add(ward.Name);
            }
        }

        private void WardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var settingObj = dbEntities3.Settings.FirstOrDefault(s => s.Ward.Name == WardComboBox.SelectedItem.ToString());
            NumberShistComboBox.SelectedItem = settingObj == null ? "0" : settingObj.NumberOfShiftaDayInWard.ToString();
            NumberStaffWardComboBox.SelectedItem = settingObj == null ? "0" : settingObj.NumberOfStaffInWard.ToString();
        }
    }
}
