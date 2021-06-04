using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Scheduler.Views.Wards
{
    /// <summary>
    /// Interaction logic for AddNewWard.xaml
    /// </summary>
    public partial class AddNewWard : Window
    {
        private WardService _wardService;
        UserService _userService;
        DivisionService _divisionService;
        HealthFacilityService _healthFacilityService;
        private ObservableCollection<DivisionResponse> divList;
        private ObservableCollection<UserResponse> userList;

        UserResponse user;
        UserResponse selectedInCharg;
        DivisionResponse selectedDivision;


        HealthFacilityResponse healthFacility;
        public AddNewWard()
        {
            InitializeComponent();

            _wardService = new WardService(GlobalClass.CheckCoonection);
            _divisionService = new DivisionService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);

            var check = Support.TryGetSession("user", out string userData);
            user = JsonConvert.DeserializeObject<UserResponse>(userData);

            divList = new ObservableCollection<DivisionResponse>();
            userList = new ObservableCollection<UserResponse>();


            //AddItemToList();
            ComboBoxItemsUI();
        }

        private void UpdateDat()
        {
            var _check = Support.TryGetSession("index", out string elementIndex);
            if (_check)
            {
                Support.TryGetSession("description", out string description);
                Support.TryGetSession("name", out string name);
                Support.TryGetSession("max-hours", out string maxHours);
                Support.TryGetSession("min-hours", out string minHours);

                Support.DestroySession("description");
                Support.DestroySession("name");
                Support.DestroySession("max-hours");
                Support.DestroySession("min-hours");
                Support.DestroySession("index");
            }
        }
        private void AddWardOrDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MaxHours.Text.IsValidNumber() || !MinHours.Text.IsValidNumber())
            {
                MessageBox.Show("Please, use right format for the hours!");
                return;
            }

            if (int.Parse(MaxHours.Text) == 0 && int.Parse(MinHours.Text) == 0)
            {
                MessageBox.Show("Max and mean can be the same but not '0'");
                return;
            }
            if (int.Parse(MaxHours.Text) < int.Parse(MinHours.Text))
            {
                MessageBox.Show("Please, maximum hours can not be less than the minimum hours!");
                return;
            }
            var _response = _wardService.Add(new Ward
            {
                Description = DescriptionBox.Text,
                DivisionId = selectedDivision.Id,
                Name = NameBox.Text,
                InchargeId = selectedInCharg.Id,
                MaximumHoursAday = int.Parse(MaxHours.Text),
                MinimunHoursAday = int.Parse(MinHours.Text),
                CenterId = healthFacility.Id
            });


            if (!_response.Check)
            {
                MessageBox.Show(_response.Message);
                return;
            }
        }

        private void DeleteWardorDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var _ward = button.DataContext as WardInfo;
            var id = _ward.ID;
            MessageBox.Show(id);
        }


        void ComboBoxItemsUI()
        {
            for (int i = 1; i <= 24; i++)
            {
                MaxHours.Items.Add(i);
                MinHours.Items.Add(i);
            }

            Task.Run(() =>
            {
                healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;
                var divisionResponse = _divisionService.GetDivisionsByHealthCenter(healthFacility.Id);
                if (divisionResponse.Check)
                {
                    foreach (var div in divisionResponse.Data)
                    {
                        divList.Add(div);
                    }

                    Dispatcher.Invoke(() =>
                    {
                        DivisionList.ItemsSource = divList;
                    });
                }

                var usersResponse = _userService.GetUsersByCenter(healthFacility.Id);
                if (usersResponse.Check)
                {
                    foreach (var _user in usersResponse.Data)
                    {
                        userList.Add(_user);
                    }

                    Dispatcher.Invoke(() =>
                    {
                        InchargeBox.ItemsSource = userList;
                    });
                }

            });
        }



        private void InchargeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = InchargeBox.SelectedItem as UserResponse;
            if (item != null)
            {
                selectedInCharg = item;
            }
        }

        private void DivisionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = DivisionList.SelectedItem as DivisionResponse;
            if (item != null)
            {
                selectedDivision = item;
            }
        }

    }
}
