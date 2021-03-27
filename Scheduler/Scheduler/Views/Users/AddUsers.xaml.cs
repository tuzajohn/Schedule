using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.Views.Users
{
    /// <summary>
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        private LoginService _loginService;
        private UserService _userService;
        private WardService _wardService;
        public AddUsers()
        {
            InitializeComponent();
            _loginService = new LoginService(Support.CheckInternetConnection());
            _userService = new UserService(Support.CheckInternetConnection());
            _wardService = new WardService(Support.CheckInternetConnection());

            PopulateWardList();

        }
        void PopulateWardList()
        {
            var _wards = _wardService.GetWards();
            foreach (var _ward in _wards.Data)
            {
                WardComboBox.Items.Add(_ward.Name);
            }
        }
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            var message = "";
            if (string.IsNullOrEmpty(Fname.Text))
                message += "First name is required\n";
            if (string.IsNullOrEmpty(Lname.Text))
                message += "Last name is required\n";
            if (string.IsNullOrEmpty(Email.Text))
                message += "Email is required\n";
            if (string.IsNullOrEmpty(DOB.Text))
                message += "Date of Birth is required\n";
            //if (DateTime.TryParse(DOB.Text, out DateTime date) && (DateTime.Parse(DOB.Text) - DateTime.Now).TotalDays / 365 <= 20 )
            //    message += "This persone is way to young\n";
            if (string.IsNullOrEmpty(Gender.Text))
                message += "Gender is required\n";
            if (string.IsNullOrEmpty(PasswordBox.Password))
                message += "Password is required\n";
            if (message != "")
            {
                MessageBox.Show(message, "Error(s)");
                return;
            }

            var account = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Password = PasswordBox.Password,
                Email = Email.Text,
                IsAdmin = false,
                Date = DateTime.UtcNow
            };

            var accountResponse = _loginService.SendLogin(account);
            if (!accountResponse.Check)
            {
                MessageBox.Show(accountResponse.Message);
                return;
            }

            Support.TryGetSession("user", out string userData);

            var _loggedInUser = userData.FromJson<LoginResponse>();
            var user = new UserBody
            {
                Id = Guid.NewGuid().ToString(),
                AccountId = accountResponse.Data.Id,
                CreatedOn = DateTime.UtcNow,
                DoB = DateTime.Parse(DOB.Text),
                Email = Email.Text,
                FirstName = Fname.Text,
                LastName = Lname.Text,
                Gender = Gender.Text,
                Ward = _loggedInUser.Id
            };

            var userResponse = _userService.SendUser(user);
            if (!userResponse.Check)
            {
                MessageBox.Show(userResponse.Message);
                return;
            }
            MessageBox.Show("Wow");

            var masterWindow = new MasterWindow();
            masterWindow.controlInstance.Content = new AllUsers();
            masterWindow.CancelAddUserBtn.Visibility = Visibility.Collapsed;
            masterWindow.AddUserBtn.Visibility = Visibility.Visible;
        }
    }
}
