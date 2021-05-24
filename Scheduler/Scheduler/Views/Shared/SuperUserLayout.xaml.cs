


using Newtonsoft.Json;
using Scheduler.RestServices.Models.Responses;
using Scheduler.Views.SuperUser;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Scheduler.Views.Shared
{
    /// <summary>
    /// Interaction logic for SuperUserLayout.xaml
    /// </summary>
    public partial class SuperUserLayout : Window
    {
        public SuperUserLayout()
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

            ShowTime();


            controlInstance.Content = new SuperUser.Dashboard();


            var check = Support.TryGetSession("user", out string data);
            if (!check)
            {
                new AccountWindow().Show();
                Close();
            }

            var user = JsonConvert.DeserializeObject<LoginResponse>(data);
            AccountData.Content = user.Email;

            Color newColor = (Color)ColorConverter.ConvertFromString("#ff844c");
            HomeBtn.Background = new SolidColorBrush(newColor);
        }
        void ShowTime()
        {
            ///TODO Threading
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.TimerTick.Text = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
            }, this.Dispatcher);
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new SuperUser.Dashboard();
            Color newColor = (Color)ColorConverter.ConvertFromString("#ff844c");
            HomeBtn.Background = new SolidColorBrush(newColor);
            HealthFacilityBtn.Background = SignOutBtn.Background;
            Director.Background = SignOutBtn.Background;
        }

        private void HealthFacilityBtn_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new SuperUser.HealthFacility();
            Color newColor = (Color)ColorConverter.ConvertFromString("#ff844c");
            HealthFacilityBtn.Background = new SolidColorBrush(newColor);
            HomeBtn.Background = SignOutBtn.Background;
            Director.Background = SignOutBtn.Background;
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
        private void Director_Click(object sender, RoutedEventArgs e)
        {
            controlInstance.Content = new Directors();
            Color newColor = (Color)ColorConverter.ConvertFromString("#ff844c");
            Director.Background = new SolidColorBrush(newColor);
            HomeBtn.Background = SignOutBtn.Background;
            HealthFacilityBtn.Background = SignOutBtn.Background;
        }
    }
}
