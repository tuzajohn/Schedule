using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Scheduler.Models;
using Scheduler.RestServices;

namespace Scheduler.Views.Users
{
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        UserService _userService;
        public AllUsers()
        {
            InitializeComponent();
            _userService = new UserService(GlobalClass.CheckCoonection);
            List<User> items = new List<User>();
            List<UserBody> userBodies = new List<UserBody>();
            var _users = _userService.GetUsers();

            _users?.Data?.ForEach((x) =>
            {
                items.Add(new User
                {
                    Name = x.FirstName + ' ' + x.LastName,
                    Date = x.CreatedOn.AddHours(3).ToString("dd/MM/yyyy hh:mm tt"),
                    Ward = new WardService(GlobalClass.CheckCoonection).GetWardById(x.WardId)?.Data?.Name
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
    }
}
