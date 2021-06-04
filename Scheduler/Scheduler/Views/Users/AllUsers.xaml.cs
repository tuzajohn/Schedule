using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.Views.Shifts;

namespace Scheduler.Views.Users
{
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        UserService _userService;
        LoginService _loginService;
        UserResponse user;
        HealthFacilityResponse healthFacility;
        HealthFacilityService _healthFacilityService;

        ObservableCollection<User> items;
        public AllUsers()
        {
            InitializeComponent(); 
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            _loginService = new LoginService(GlobalClass.CheckCoonection);
            List<UserBody> userBodies = new List<UserBody>();

            var check = Support.TryGetSession("user", out string userData);
            user = JsonConvert.DeserializeObject<UserResponse>(userData);

            lvDataBinding.ItemsSource = items = new ObservableCollection<User>();

            Task.Run(() =>
            {
                healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;
                var _users = _userService.GetUsersByCenter(healthFacility.Id);

                _users?.Data?.ForEach((x) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        items.Add(new User
                        {
                            Name = x.FirstName + ' ' + x.LastName,
                            Date = x.CreatedOn.AddHours(3).ToString("dd/MM/yyyy hh:mm tt"),
                            Ward = new WardService(GlobalClass.CheckCoonection).GetWardById(x.WardId)?.Data?.Name,
                            Id = x.Id,
                            AccountId = x.AccountId
                        });
                    });
                });
            });


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)lvDataBinding.SelectedItem;

            MessageBox.Show(user.Name, "My user");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)lvDataBinding.SelectedItem;

            MessageBox.Show("Calling " + user.Name, "My user");
        }

        private void ViewUSerBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var user = button.DataContext as User;

            var userResponse = _userService.GetUserByUserId(user.Id);
            var account = _loginService.GetAccount(user.AccountId);
            new ViewUser(userResponse.Data,account.Data).ShowDialog();
        }

        private void ViewShiftsUserBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var user = button.DataContext as User;

            var userResponse = _userService.GetUserByUserId(user.Id);
            new ShiftsForUser(userResponse.Data).ShowDialog();
        }
    }
}
