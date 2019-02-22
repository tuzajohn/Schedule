using CustomMessageBox;
using Customs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Staff_Schedulling_System.Personel
{
    public partial class BasicStaff : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private LoginForm Login;
        private Encryption enc;
        public string Uid { get; internal set; }
        public BasicStaff(LoginForm loginForm)
        {
            InitializeComponent();
            Login = loginForm;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void BasicStaff_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("LoginInfo.txt");
            var uid = reader.ReadLine();
            reader.Close();
            Uid = uid;
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var myAccount = dbEntities3.Staffs.FirstOrDefault(s => s.AccountId == uid);
            NameLabel.Text = myAccount.Fname + " " + myAccount.Lname;
            EmailLabel.Text = myAccount.Email;
            ContactLabel.Text = myAccount.PhoneNumber;
            DobLabel.Text = myAccount.DateOfBirth.ToLongDateString();
            
            FormClosing += CloseForm;

            var shifts = dbEntities3.Shifts.Where(sh => sh.StaffId == myAccount.Id).ToList();//select from shift 
            string[] DaysOfWeek = { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
            var weekList = DaysOfWeek.ToList();
            List<DateTime> workDays = new List<DateTime>();
            foreach (var item in shifts)
            {
                foreach (var day in EachDay(DateTime.Now, DateTime.Now.AddDays(30)))
                {
                    if (weekList.ElementAt(item.Day - 1).ToLower() == day.DayOfWeek.ToString().ToLower())
                    {
                        var t = day.ToString().Replace("00:00:00", item.StartTime.ToString());
                        workDays.Add(DateTime.Parse(t));
                    }
                }
            }
            ShiftDays.BoldedDates = workDays.ToArray();
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime end)
        {
            for (var day = from.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            Login.Show();
            Close();
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
            var myAccount = dbEntities3.Accounts.FirstOrDefault(s => s.Id == Uid);
            
            enc = new Encryption { Key = new Controls().Key };
            if (enc.GetMD5(enc.StrongEncrypt(OldPassBox.Text)) == myAccount.Password)
            {
                if (NewRepPassBox.Text == NewPassBox.Text)
                {
                    var (check, result) = new RegExpression().IsPassword(NewPassBox.Text);
                    if (check)
                    {
                        myAccount.Password = enc.GetMD5(enc.StrongEncrypt(NewPassBox.Text));
                        dbEntities3.SaveChanges();
                        new MyCustomMessageBox(MyCustomMessageBox.State.SUCCESS, "Password has been changed successfully!").ShowDialog();
                        
                        NewPassBox.Text = "";
                        OldPassBox.Text = "";
                        NewRepPassBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Passwords do not match!").ShowDialog();
                }
            }
            else
            {
                new MyCustomMessageBox(MyCustomMessageBox.State.ERROR, "Wrong password!").ShowDialog();
            }
        }

        private void ShiftDays_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start < DateTime.Now || e.Start > DateTime.Now.AddDays(30)) 
            {

            }
            else
            {
                List<string> weekList = new List<string> { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
                var day = e.Start.DayOfWeek.ToString();

                int dayId = weekList.IndexOf(day.ToUpper()) + 1;
                StaffSchedullingDbEntities3 dbEntities3 = new StaffSchedullingDbEntities3();
                var myAccount = dbEntities3.Staffs.FirstOrDefault(s => s.AccountId == Uid);
                var shift = dbEntities3.Shifts.FirstOrDefault(sh => sh.StaffId == myAccount.Id && sh.Day == dayId);
                if (shift != null)
                {
                    DateLabel.Text = e.Start.ToLongDateString();
                    StartTimeLabel.Text = shift.StartTime.ToString();
                    EndTimeLabel.Text = shift.EndTime.ToString();
                }
                else
                {
                    new MyCustomMessageBox(MyCustomMessageBox.State.WARNING, "This is a day off").ShowDialog();
                }
            }

        }
    }
}
