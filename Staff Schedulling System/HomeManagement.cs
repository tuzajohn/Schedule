using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customs;

namespace Staff_Schedulling_System
{
    public partial class HomeManagement : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        LoginForm Login;
        Controls controls;
        Account account;
        Encryption enc;
        private string WardName { get; set; }
        public HomeManagement(LoginForm loginForm)
        {
            InitializeComponent();
            controls = new Controls();
            this.Login = loginForm;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);
            PanelDashboard.Visible = true;
            LoadListViewStaff();
        }
        //load list view for staff and dahsboard panel
        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            PanelDashboard.Visible = true;
            PanelAccount.Visible = false;
            PanelUser.Visible = false;
            StaffListView.Items.Clear();
            LoadListViewStaff();
        }
        //staff list view
        void LoadListViewStaff()
        {
            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();
            reader.Close();

            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();

            var myStaffData = dbEntities.Staffs.FirstOrDefault(s => s.AccountId == uid);

            var getWard = dbEntities.StaffWards.FirstOrDefault(sw => sw.StaffID == myStaffData.Id);
            var myward = dbEntities.Wards.FirstOrDefault(w => w.Id == getWard.WardId);
            this.WardName = myward.Name;

            WardInfoLAbel.Text = "Staff under " + WardName + " ward!";

            var staffWards = dbEntities.StaffWards.Where(sw => sw.WardId == myward.Id).ToList();
            int i = 0;
            foreach (var staffWard in staffWards)
            {
                var staff = dbEntities.Staffs.FirstOrDefault(s => s.Id == staffWard.StaffID);
                i++;
                if (staff.Account.Id == uid)
                    continue;
                string[] item = { i.ToString(), staff.Id, staff.Fname + " " + staff.Lname, staff.Date.ToString("dd/MM/yyyy") };
                ListViewItem listView = new ListViewItem(item);
                StaffListView.Items.Add(listView);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Load Account panel but hides the rest
        private void AccountBtn_Click(object sender, EventArgs e)
        {
            PanelDashboard.Visible = false;
            PanelAccount.Visible = true;
            PanelUser.Visible = false;
            
            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();//reading user id from the text file
            reader.Close();

            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();

            account = dbEntities.Accounts.FirstOrDefault(a => a.Id == uid);
            var staff = dbEntities.Staffs.FirstOrDefault(s => s.Account.Id == uid);
            NameLabel.Text = staff.Fname + " " + staff.Lname;
            ContactLabel.Text = staff.PhoneNumber;
            DoBLabel.Text = (Math.Floor((DateTime.Now - staff.DateOfBirth).TotalSeconds / 31556952)).ToString();
            WardLabel.Text = dbEntities.Wards.FirstOrDefault(w => w.Id == (w.StaffWards.FirstOrDefault(s => s.StaffID == staff.Id).WardId)).Name;
            UsernameLabel.Text = account.Username;
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            PanelDashboard.Visible = false;
            PanelAccount.Visible = false;
            PanelUser.Visible = true;
        }

        //edit login information
        private void EditProfileBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();
            //for username change
            if (!string.IsNullOrWhiteSpace(OldUsername.Text) || OldUsername.Text != "")
            {
                if (OldUsername.Text == account.Username)
                {
                    if (!string.IsNullOrWhiteSpace(NewUsernameBox.Text) || NewUsernameBox.Text != "")
                    {
                        account.Username = NewUsernameBox.Text;
                        dbEntities.SaveChanges();
                        NewUsernameBox.Text = "";
                        OldUsername.Text = "";
                        MessageBox.Show("Username has been changed successfully!");
                    }
                }
            }
            //password
            if (!string.IsNullOrWhiteSpace(CurrentUserPassword.Text) || CurrentUserPassword.Text != "")
            {
                controls = new Controls();
                enc = new Encryption { Key = controls.Key };
                if (enc.GetMD5(enc.StrongEncrypt(CurrentUserPassword.Text)) == account.Password)
                {
                    if (!string.IsNullOrWhiteSpace(NewPasswordBox.Text) || NewPasswordBox.Text != "")
                    {
                        var (check, result) = new RegExpression().IsPassword(NewPasswordBox.Text);
                        if (check)
                        {
                            var response = MessageBox.Show("You are about to change your password, are you sure of this!", "Password change",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (DialogResult.Yes == response)
                            {
                                account.Password = enc.GetMD5(enc.StrongEncrypt(PasswordBox.Text));
                                dbEntities.SaveChanges();
                                MessageBox.Show("Password has been changed successfully!");
                                PasswordBox.Text = string.Empty;
                                NewPasswordBox.Text = string.Empty;
                            }
                            else
                            {
                                PasswordBox.Text = string.Empty;
                                NewPasswordBox.Text = string.Empty;
                            }
                        }
                        else
                        {
                            MessageBox.Show(result);
                        }
                    }
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void SaveStaffBtn_Click(object sender, EventArgs e)
        {
            if (IsNotEmpty(FnameBox) ||IsNotEmpty(LnameBox) ||IsNotEmpty(EmailBox) ||
                IsNotEmpty(StaffUsernameBox) || IsNotEmpty(PasswordBox) || IsNotEmpty(StaffRepPassBox)
                || DoBPicker.Value >= DateTime.Now.AddYears(-20))
            {
                StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
                if (PasswordBox.Text == StaffRepPassBox.Text)
                {
                    var reg = new RegExpression();
                    enc = new Encryption { Key = new Controls().Key };
                    var (check, result) = reg.IsPassword(PasswordBox.Text);
                    if (check)
                    {
                        var date = DateTime.Now;
                        var account = new Account
                        {
                            Id = $"A/{date.Day}/{date.Year}/{date.Month}/{(dbEntities3.Accounts.Count() == 0 ? 1 : dbEntities3.Accounts.Count() + 1)}",
                            Username = StaffUsernameBox.Text,
                            Password = enc.GetMD5(enc.StrongEncrypt(PasswordBox.Text)),
                            Date = date,
                            UserType = "basic"
                        };
                        var staff = new Staff
                        {
                            Id = $"S/{date.Day}/{date.Year}/{date.Month}/{(dbEntities3.Staffs.Count() == 0 ? 1 : dbEntities3.Staffs.Count() + 1)}",
                            Fname = FnameBox.Text,
                            Lname = LnameBox.Text,
                            PhoneNumber = reg.IsCorrect(ContactBox.Text, "[+256?0][0-9]{9}") ? ContactBox.Text : "",
                            Email = EmailBox.Text,
                            DateOfBirth = DoBPicker.Value,
                            Date = date,
                            AccountId = account.Id,
                            AccessLevel = "basic",
                            Account = account,                            
                        };
                        var ward = dbEntities3.Wards.FirstOrDefault(w => w.Name == WardName).Id;
                        var staffWard = new StaffWard
                        {
                            Id = ward + " - " + staff.Id,
                            StaffID = staff.Id,
                            WardId = dbEntities3.Wards.FirstOrDefault(w => w.Name == WardName).Id
                        };
                        dbEntities3.Accounts.Add(account);
                        dbEntities3.Staffs.Add(staff);
                        dbEntities3.StaffWards.Add(staffWard);
                        dbEntities3.SaveChanges();
                        ClearAllText();
                        controls.SetShift(staff.Id, ward);
                        MessageBox.Show($"{FnameBox.Text} {LnameBox.Text} has been added succesfully");

                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                }
            }
            else
            {
                MessageBox.Show("Please provide all the necessary information...");
            }
        }
        void ClearAllText()
        {
            FnameBox.Clear();
            LnameBox.Clear();
            EmailBox.Clear();
            StaffUsernameBox.Clear();
            PasswordBox.Clear();
            StaffRepPassBox.Clear();
            DoBPicker.Value = DateTime.Now.AddYears(-20);
        }
        bool IsNotEmpty(MaterialSingleLineTextField textField)
        {
            if (string.IsNullOrWhiteSpace(textField.Text) || textField.Text == "")
            {
                return false;
            }
            return true;
        }

        private void StaffPictureBrowseBtn_Click(object sender, EventArgs e)
        {

        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            Login.Show();
            Close();
        }

        private void StaffListView_Click(object sender, EventArgs e)
        {
            var selectedID = StaffListView.SelectedItems[0].SubItems[1].Text;
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var staff = dbEntities3.Staffs.FirstOrDefault(s => s.Id == selectedID);

            
        }

        private void HomeManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void HomeManagement_Load(object sender, EventArgs e)
        {
            FormClosing += FormClosed_;
        }

        private void FormClosed_(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }

        private void PanelDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ToPdfBtn_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pdf Files|*.pdf";
            saveFileDialog1.Title = "Save PDF file";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                var path = saveFileDialog1.FileName;
                FileStream fileStream = (FileStream)saveFileDialog1.OpenFile();

                fileStream.Close();
                StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();

                StreamReader reader = new StreamReader("LoginInfo.txt");
                var uid = reader.ReadLine();
                reader.Close();
                var ward = dbEntities3.Wards.FirstOrDefault(w => w.Name == WardName);
                var staffWards = dbEntities3.StaffWards.Where(sw => sw.WardId == ward.Id).ToList();
                var staffs = new List<Staff>();
                var name_ = "";
                try
                {
                    List<Person> persons = new List<Person>();
                    foreach (var item in staffWards)
                    {
                        var staff = dbEntities3.Staffs.FirstOrDefault(s => s.Id == item.StaffID);
                        name_ = staff.Fname + " " + staff.Lname;
                        if (staff.AccountId == uid)
                            continue;
                        var person = new Person
                        {
                            StaffId = staff.Id,
                            Contact = staff.PhoneNumber,
                            Email = staff.Email,
                            DOB = staff.DateOfBirth.ToString("dd/MM/yyyy"),
                            Name = staff.Fname + " " + staff.Lname,
                            Ward = dbEntities3.Wards
                                .FirstOrDefault(s => s.StaffWards.FirstOrDefault(sw => sw.StaffID == item.Id).WardId != "").Name
                        };
                        persons.Add(person);
                    }
                    if (persons.Count != 0)
                    {
                        DataTable data = new Controls().ToDataTable(persons);
                        new Controls().WriteToPdf(data,
                            saveFileDialog1.FileName,
                            "Medical Officer",
                            name_);
                        MessageBox.Show("Pdf saved!");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong and the pdf could not be generated");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong and the pdf could not be generated");
                }
            }
        }
    }
}
