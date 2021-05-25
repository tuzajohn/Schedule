using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.Views.Profile
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        private LoginService _loginService;
        private UserService _userService;
        private WardService _wardService;
        private DivisionService _divisionService;

        DispatcherTimer timer = new DispatcherTimer();

        public AccountPage()
        {
            InitializeComponent();
            _loginService = new LoginService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);
            _divisionService = new DivisionService(GlobalClass.CheckCoonection);

            timer.Interval = TimeSpan.FromSeconds(5);

            Support.DestroySession("account_division");
            Support.DestroySession("account_ward");
            Support.DestroySession("account_user");

            LoadMyAccount();


            UpdateUI();
        }

        public void LoadMyAccount()
        {
            progressbar.Visibility = Visibility.Visible;
            var _check = Support.TryGetSession("user", out string outPut);
            if (!_check)
                return;

            var _accountInfo = JsonConvert.DeserializeObject<LoginResponse>(outPut);

            var _userDetails = new Response<UserResponse>();
            var _ward = new Response<Ward>();
            var _division = new Response<Division>();

            Dispatcher.Invoke(() =>
            {
                _userDetails = _userService.GetUserByAccountId(_accountInfo.Id);
                _ward = _wardService.GetWardById(_userDetails?.Data?.WardId);
                _division = _divisionService.Get(_ward?.Data?.DivisionId);

                Support.CreateSession("account_ward", JsonConvert.SerializeObject(_ward?.Data));
                Support.CreateSession("account_user", JsonConvert.SerializeObject(_userDetails.Data));

                if (_ward?.Data?.DivisionId != null)
                    Support.CreateSession("account_division", JsonConvert.SerializeObject(_division.Data));
            });

            progressbar.Visibility = Visibility.Collapsed;
            wardCard.Visibility = Visibility.Visible;

            Email.Text = _accountInfo.Email;
            Fname.Text = _userDetails.Data?.FirstName;
            Lname.Text = _userDetails.Data?.LastName;
            Gender.Text = _userDetails.Data?.Gender;
            Dob.Text = _userDetails.Data?.DoB.ToString("MMM dd, yyyy");
            Contact.Text = _userDetails.Data?.Contact;
            MaritalStatus.Text = _userDetails.Data?.MaritalStatus;
            MedicalHistory.Text = _userDetails.Data?.MedicalIssues;
            Ward.Text = _ward?.Data?.Name;
            Division.Text = _division?.Data?.Name;
        }

        private void UpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            var _updatePopUp = new UpdateAccountPopUpWindow();
            _updatePopUp.ShowDialog();
        }
        public void UpdateUI()
        {
            Dispatcher.Invoke(() => 
            {
                if (Support.TryGetSession("update-ui", out string _))
                {
                    var _check = Support.TryGetSession("user", out string outPut);
                    if (!_check)
                        return;

                    var _accountInfo = JsonConvert.DeserializeObject<LoginResponse>(outPut);
                    var accountCheck = Support.TryGetSession("user", out string accountString);
                    var divCheck = Support.TryGetSession("account_division", out string divisionString);
                    var wardCheck = Support.TryGetSession("account_ward", out string wardString);
                    var userCheck = Support.TryGetSession("account_user", out string userString);

                    if (accountCheck)
                    {
                        Email.Text = _accountInfo.Email;
                        var _account = accountString.FromJson<LoginResponse>();
                        if (divCheck)
                        {
                            var _division = divisionString.FromJson<Division>();
                            Division.Text = _division.Name;
                        }
                        if (wardCheck)
                        {
                            var _ward = wardString.FromJson<Ward>();
                            Ward.Text = _ward?.Name;
                        }
                        if (userCheck)
                        {
                            var _userDetails = userString.FromJson<UserResponse>();
                            Fname.Text = _userDetails?.FirstName;
                            Lname.Text = _userDetails?.LastName;
                            Gender.Text = _userDetails?.Gender;
                            Dob.Text = _userDetails?.DoB.ToString("MMM dd, yyyy");
                            Contact.Text = _userDetails?.Contact;
                            MaritalStatus.Text = _userDetails?.MaritalStatus;
                            MedicalHistory.Text = _userDetails?.MedicalIssues;
                        }
                    }
                    Support.DestroySession("update-ui");
                }
            });

        }
    }
}
