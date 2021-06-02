using Scheduler.Models;
using Scheduler.Models.ViewModel;
using Scheduler.RestServices;
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
    public partial class Index : Page
    {
        ShiftService _shiftService;
        WardService _wardService;
        UserService _userService;
        ObservableCollection<ShiftViewModel> shiftsList;

        public Index(string wardId)
        {
            InitializeComponent();

            _shiftService = new ShiftService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);

            shiftsListView.ItemsSource = shiftsList = new ObservableCollection<ShiftViewModel>();

            var shifts = _shiftService.GetShiftForWard(wardId);

            Task.Run(() =>
            {
                if (shifts.Check && shifts.Data.Count > 0)
                {
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
                            EndTime = shift.EndTime.ToString("hh:mm tt"),
                            StartTime = shift.StartTime.ToString("hh:mm tt")
                        };

                        shiftsList.Add(shiftData);
                    }
                }
            });

        }
    }
}
