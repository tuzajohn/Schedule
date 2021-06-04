using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.Views.Profile
{
    /// <summary>
    /// Interaction logic for UpdateAccountPopUpPage.xaml
    /// </summary>
    public partial class UpdateAccountPopUpWindow : Window
    {
        public string ID { get; set; }
        public string WardId { get; set; }
        public string DivisionId { get; set; }
        public string UserId { get; set; }
        public UpdateAccountPopUpWindow()
        {
            InitializeComponent();

            Closing += (s, e) => { Support.CreateSession("update-ui", "account-ui"); new AccountPage().UpdateUI(); };

            var _userDetails = new UserResponse();
            var _ward = new Ward();
            var _division = new Division();
            var _account = new UserResponse();

            var accountCheck = Support.TryGetSession("user", out string accountString);

            if (accountCheck)
            {
                _account = accountString.FromJson<UserResponse>();

                ID = _account.AccountId;
            }
            else { Close(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var password = PasswordBox.Password;
            var repPassword = RepeatPassowrdBox.Password;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please, fill in the required fields", "Password Empty", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (password != repPassword)
            {
                MessageBox.Show("Passwords do not match", "Password Missmatch", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Support.IsPasswordValid(password))
            {
                MessageBox.Show("The password must be of at least 8 characters long, " +
                        " and must include at least one upper case letter, one lower case letter, and one numeric digit ", "Password Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var loginService = new LoginService();
            var _account = loginService.ChangePassword(ID, password);
            if (_account.Check)
            {
                var accountCheck = Support.TryGetSession("user", out string accountString);
                if (accountCheck)
                {
                    var outPut = accountString.FromJson<LoginResponse>();
                    outPut.Password = _account.Data.Password;
                    Support.DestroySession("user");
                    Support.CreateSession("user", outPut.ToJsonString());
                    PasswordBox.Password = "";
                    RepeatPassowrdBox.Password = "";
                    MessageBox.Show("The password has been changed successsfully!");
                }
            }
            else { MessageBox.Show(_account.Message); }
        }

        private void UpdateDivisionBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateUserDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
