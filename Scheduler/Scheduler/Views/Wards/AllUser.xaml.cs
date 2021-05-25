using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Scheduler.Models;
using Scheduler.RestServices;

namespace Scheduler.Views.Wards
{
    /// <summary>
    /// Interaction logic for AllUser.xaml
    /// </summary>
    public partial class AllUser : Window
    {
        private UserService _userService;
        private WardService _wardService;
        private ObservableCollection<User> _userList;
        public AllUser()
        {
            InitializeComponent();
            _userList = new ObservableCollection<User>();
            _userService = new UserService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);

            LoadUsers();
            Support.TryGetSession("ward-name", out string title);
            Support.DestroySession("ward-name");
            Title = $"Worker in {(title ?? "this ward")} ";
            lvDataBinding.ItemsSource = _userList;

        }

        private void CallUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadUsers()
        {
            if (Support.TryGetSession("ward-id", out string id))
            {
                var _users = _wardService.GetUsers(id);

                _users?.Data?.ForEach((x) =>
                {
                    _userList.Add(new User
                    {
                        Name = x.FirstName + ' ' + x.LastName,
                        Date = x.CreatedOn.AddHours(3).ToString("dd/MM/yyyy hh:mm tt"),
                        Id = x.Id
                    });
                });
                Support.DestroySession("ward-id");
            }
        }
    }
}
