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
            var _account = new LoginResponse();

            var accountCheck = Support.TryGetSession("user", out string accountString);
            var divCheck = Support.TryGetSession("account_division", out string divisionString);
            var wardCheck = Support.TryGetSession("account_ward", out string wardString);
            var userCheck = Support.TryGetSession("account_user", out string userString);

            if (accountCheck)
            {
                _account = accountString.FromJson<LoginResponse>();

                ID = _account.Id;
                if (divCheck)
                {
                    _division = divisionString.FromJson<Division>();
                    DivisionId = _division.Id;
                    DivisionName.Text = _division.Name;
                }
                if (wardCheck)
                {
                    _ward = wardString.FromJson<Ward>();
                    WardId = _ward?.Id;
                    WardNameBox.Text = _ward?.Name;
                    WardDescriptionBox.Text = _ward?.Description;
                }
                if (userCheck)
                {
                    _userDetails = userString.FromJson<UserResponse>();
                    UserId = _userDetails?.Id;
                    MaritalStatusComboBox.Text = _userDetails?.MaritalStatus;
                    address.Text = _userDetails?.Address;
                }
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
            //if (!IsPasswordValid(password))
            //{
            //    MessageBox.Show("The password must be of at least 8 characters long, " +
            //            " and must include at least one upper case letter, one lower case letter, and one numeric digit ", "Password Error", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            var loginService = new LoginService();
            Dispatcher.Invoke(() =>
            {
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
            });
        }

        private void UpdateDivisionBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateWardBtn_Click(object sender, RoutedEventArgs e)
        {
            var _name = WardNameBox.Text;
            var _description = WardDescriptionBox.Text;
            if (string.IsNullOrEmpty(_name))
            {
                MessageBox.Show("A ward should have a name!");
                return;
            }
            Dispatcher.Invoke(() =>
            {
                var _ward = new WardService(Support.CheckInternetConnection()).Update(WardId, new Ward { Name = _name, Description = _description, DivisionId = DivisionId });
                if (_ward.Check)
                {
                    var wardCheck = Support.TryGetSession("account_ward", out string wardString);
                    if (wardCheck)
                    {
                        var output = wardString.FromJson<Ward>();
                        output.Description = _ward.Data.Description;
                        output.Name = _ward.Data.Name;
                        output.DivisionId = DivisionId;

                        WardNameBox.Text = output.Name;
                        WardDescriptionBox.Text = output.Description;
                        Support.DestroySession("account_ward");
                        Support.CreateSession("account_ward", output.ToJsonString());

                        MessageBox.Show("Ward data has been updated successfully");
                    }
                }
                else { MessageBox.Show(_ward.Message); }
            });

        }

        private void UpdateUserDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        bool IsPasswordValid(string password)
        {
            var reg = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$");
            if (reg.IsMatch(password))
            {
                return true;
            }
            return false;
        }
    }
}
