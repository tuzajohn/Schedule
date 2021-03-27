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
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;
using Scheduler.RestServices;
using Scheduler.RestServices.Models.Responses;
using Scheduler.Views;
using Scheduler.Views.Profile;
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

            _userService = new UserService(Support.CheckInternetConnection());
            var check = Support.TryGetSession("user", out string data);
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
    }
}
