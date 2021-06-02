using System;
using System.Windows;
using System.Windows.Threading;
using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models.Responses;
using Scheduler.Views.Divisions;
using Scheduler.Views.Profile;
using Scheduler.Views.Shifts;
using Scheduler.Views.Users;
using Scheduler.Views.Wards;

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        private UserService _userService;
        public MasterWindow()
        {
            InitializeComponent();

            #region center
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
            #endregion

            _userService = new UserService(GlobalClass.CheckCoonection);
            var check = Support.TryGetSession("userAccount", out string data);
            if (!check)
            {
                new AccountWindow().Show();
                Close();
            }

            var account = JsonConvert.DeserializeObject<LoginResponse>(data);
            AccountData.Content = account.Email;
            controlInstance.Content = new Views.Home.IndexPage();

            ShowTime();
        }
        void ShowTime()
        {
            ///TODO Threading
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.TimerTick.Text = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
            }, this.Dispatcher);
        }
        private void WardPageBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new IndexPage();
            CancelAddUserBtn.Visibility = Visibility.Collapsed;
            AddUserBtn.Visibility = Visibility.Collapsed;
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            var check = Support.DestroySession("user");
            if (check)
            {
                new AccountWindow().Show();
                Close();
            }
        }

        private void UserPageBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new AllUsers();
            AddUserBtn.Visibility = Visibility.Visible;
        }

        private void AccountPageBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new AccountPage();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new Views.Home.IndexPage();
        }

        private void CancelAddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new AllUsers();
            CancelAddUserBtn.Visibility = Visibility.Collapsed;
            AddUserBtn.Visibility = Visibility.Visible;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new AddUsers();
            CancelAddUserBtn.Visibility = Visibility.Visible;
            AddUserBtn.Visibility = Visibility.Collapsed;
        }

        private void DivisionPageBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new DivisionsIndexPage();
        }

        private void ShiftPage_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new SetingShiftPage();
        }
    }
}
