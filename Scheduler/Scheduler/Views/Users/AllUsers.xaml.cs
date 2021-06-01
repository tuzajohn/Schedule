using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public AllUsers()
        {
            InitializeComponent();
            _userService = new UserService(GlobalClass.CheckCoonection);
            _loginService = new LoginService(GlobalClass.CheckCoonection);
            List<User> items = new List<User>();
            List<UserBody> userBodies = new List<UserBody>();
            var _users = _userService.GetUsers();

            _users?.Data?.ForEach((x) =>
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

            lvDataBinding.ItemsSource = items;

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
            var user = (User)lvDataBinding.SelectedItem;

            var userResponse = _userService.GetUserByUserId(user.Id);
            var account = _loginService.GetAccount(user.AccountId);
            new ViewUser(userResponse.Data,account.Data).ShowDialog();
        }

        private void ViewShiftsUserBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)lvDataBinding.SelectedItem;

            var userResponse = _userService.GetUserByUserId(user.Id);
            new ShiftsForUser(userResponse.Data).ShowDialog();
        }
    }
}
