using Customs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Staff_Schedulling_System.Admin
{
    public partial class All : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public string State { get; set; }
        public string Name { get; set; }
        public All(string name)
        {
            InitializeComponent();
            Name = name;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the the pdf file in any location of his/her choice
            
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
                StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
                StreamReader reader = new StreamReader("LoginInfo.txt");
                var uid = reader.ReadLine();
                reader.Close();

                var staffs = new List<Staff>();
                if (!string.IsNullOrEmpty(State))
                {
                    List<Person> personels = new List<Person>();
                    if (State == "all")
                    {
                        staffs = dbEntities3.Staffs.OrderByDescending(s => s.Date).ToList();                       
                    }
                    else
                    {
                        staffs = dbEntities3.Staffs.Where(s => s.Account.UserType.ToLower() == State)
                              .OrderByDescending(s => s.Date).ToList();
                    }
                    foreach (var item in staffs)
                    {
                        if (item.AccountId == uid)
                        {
                            continue;
                        }
                        var person = new Person
                        {
                            StaffId = item.Id,
                            Contact = item.PhoneNumber,
                            Email = item.Email,
                            DOB = item.DateOfBirth.ToString("dd/MM/yyyy"),
                            Name = item.Fname + " " + item.Lname,
                            Ward = dbEntities3.Wards
                                .FirstOrDefault(s => s.StaffWards.FirstOrDefault(sw => sw.StaffID == item.Id).WardId != "").Name
                        };
                        personels.Add(person);
                    }
                    DataTable data = new Controls().ToDataTable(personels);
                    new Controls().WriteToPdf(data,
                        saveFileDialog1.FileName,
                        State.ToUpper(),
                        Name);

                    MessageBox.Show("Pdf saved!");
                }
                else
                {
                    MessageBox.Show("Something went wrong and the pdf could not be generated");
                }
            }
        }

        private void All_Load(object sender, EventArgs e)
        {
            State = "all";
               StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            AllUsersListView.Items.Clear();
            int i = 0;
            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();
            reader.Close();
            foreach (Staff member in dbEntities3.Staffs.OrderByDescending(d => d.Date))
            {
                if (member.AccountId == uid)
                {
                    continue;
                }
                i++;
                string role = member.Account.UserType == "management" ? "in charge" : member.Account.UserType;
                string age = (Math.Floor((DateTime.Now - member.DateOfBirth).TotalSeconds / 31556952)).ToString();
                string name = member.Fname + " " + member.Lname;
                string[] memberArray = { i.ToString(), member.Id, name, role, age, member.Email, member.PhoneNumber };
                ListViewItem item = new ListViewItem(memberArray);
                AllUsersListView.Items.Add(item);
            }
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AllUsersListView.Items.Clear();
            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();
            State = "admin";
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            AllUsersListView.Items.Clear();
            int i = 0;
            foreach (Staff member in dbEntities3.Staffs.OrderByDescending(d => d.Date))
            {
                if (member.AccountId == uid)
                {
                    continue;
                }
                i++;
                string role = member.Account.UserType.ToLower() == "management" ? "in charge" : member.Account.UserType;
                if (role != "admin") { continue; }
                string age = (Math.Floor((DateTime.Now - member.DateOfBirth).TotalSeconds / 31556952)).ToString();
                string name = member.Fname + " " + member.Lname;
                string[] memberArray = { i.ToString(), member.Id, name, role, age, member.Email, member.PhoneNumber };
                ListViewItem item = new ListViewItem(memberArray);
                AllUsersListView.Items.Add(item);
            }
        }

        private void InChargeBtn_Click(object sender, EventArgs e)
        {
            State = "management";
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            AllUsersListView.Items.Clear();
            int i = 0;
            foreach (Staff member in dbEntities3.Staffs.OrderByDescending(d => d.Date))
            {
                i++;
                string role = member.Account.UserType.ToLower() == "management" ? "in charge" : member.Account.UserType;
                if (role != "in charge") { continue; }
                string age = (Math.Floor((DateTime.Now - member.DateOfBirth).TotalSeconds / 31556952)).ToString();
                string name = member.Fname + " " + member.Lname;
                string[] memberArray = { i.ToString(), member.Id, name, role, age, member.Email, member.PhoneNumber };
                ListViewItem item = new ListViewItem(memberArray);
                AllUsersListView.Items.Add(item);
            }
        }
    }
}
