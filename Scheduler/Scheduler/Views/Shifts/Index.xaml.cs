using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.Models.ViewModel;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.Views.Wards;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler.Views.Shifts
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        ShiftService _shiftService;
        WardService _wardService;
        HealthFacilityService _healthFacilityService;
        UserService _userService;
        ObservableCollection<ShiftViewModel> shiftsList;
        ObservableCollection<UserResponse> userList;
        ObservableCollection<Ward> wardsList;

        UserResponse user;
        HealthFacilityResponse healthFacility;

        public Index()
        {
            InitializeComponent();

            _shiftService = new ShiftService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);

            shiftsListView.ItemsSource = shiftsList = new ObservableCollection<ShiftViewModel>();
            WardDepartmentComboBox.ItemsSource = wardsList = new ObservableCollection<Ward>();
            UserComboBox.ItemsSource = userList = new ObservableCollection<UserResponse>();
            shiftsListView.ItemsSource = shiftsList = new ObservableCollection<ShiftViewModel>();

            var check = Support.TryGetSession("user", out string userData);
            user = JsonConvert.DeserializeObject<UserResponse>(userData);

            //var shifts = _shiftService.GetShiftForWard("");

            Task.Run(() =>
            {
                healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;
                var users = _userService.GetUsersByCenter(healthFacility.Id);

                if (users.Check)
                {
                    foreach (var user in users.Data)
                    {
                        Dispatcher.Invoke(() => { userList.Add(user); });
                    }
                }

                var wards = _wardService.GetWardsByCenter(healthFacility.Id);
                if (wards.Check)
                {
                    foreach (var ward in wards.Data)
                    {
                        Dispatcher.Invoke(() => { wardsList.Add(ward); });
                    }
                }


            });

        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (UserResponse)UserComboBox.SelectedItem;
            var selectedWard = (Ward)WardDepartmentComboBox.SelectedItem;

            var selectedDate = StartDate.SelectedDate;
            var message = "";
            if (selectedUser == null)
            {
                message = "Select a user/nurse";
            }
            if (selectedWard == null)
            {
                message = "Select a ward/department";
            }
            if (selectedDate == null)
            {
                message = "Select a starting date";
            }

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            var shifts = _shiftService.SetShift(new RestServices.Models.Responses.ShiftRequest
            {
                StartingDateTime = selectedDate.Value,
                UserId = selectedUser.Id,
                WardId = selectedWard.Id,
                MaxOrMin = 1
            });

            MessageBox.Show(shifts.Message);

            if (shifts.Check)
            {
                UserComboBox.SelectedItem = null;
                WardDepartmentComboBox.SelectedItem = null;
                StartDate.SelectedDate = null;

                foreach (var shift in shifts.Data)
                {
                    if (shift.IsDeleted)
                    {
                        continue;
                    }

                    var ward = _wardService.GetWardById(shift.WardId);
                    var user = _userService.GetUserByUserId(shift.UserId);
                    var shiftData = new ShiftViewModel
                    {
                        CreatedOn = shift.CreatedOn.ToString("MM/dd/yyyy"),
                        Id = shift.Id,
                        UserId = shift.UserId,
                        UserName = user.Data.FirstName + " " + user.Data.LastName,
                        IsDeleted = shift.IsDeleted,
                        WardId = shift.WardId,
                        WardName = ward.Data.Name,
                        EndDay = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, shift.EndDay).ToString("MM/dd/yyyy"),
                        StartDay = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, shift.StartDay).ToString("MM/dd/yyyy"),
                        EndTime = shift.EndTime.hours + ":" + shift.EndTime.minutes,
                        StartTime = shift.StartTime.hours + ":" + shift.StartTime.minutes
                    };

                    Dispatcher.Invoke(() => { shiftsList.Add(shiftData); });
                }

            }
        }
    }
}
