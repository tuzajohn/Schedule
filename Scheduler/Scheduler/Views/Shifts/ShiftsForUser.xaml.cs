using Scheduler.Models;
using Scheduler.Models.ViewModel;
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

namespace Scheduler.Views.Shifts
{
    /// <summary>
    /// Interaction logic for ShiftsForUser.xaml
    /// </summary>
    public partial class ShiftsForUser : Window
    {
        ShiftService _shiftService;
        WardService _wardService;
        ObservableCollection<ShiftViewModel> shiftsList;
        public ShiftsForUser(UserResponse data)
        {
            InitializeComponent();

            _shiftService = new ShiftService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);

            shiftsListView.ItemsSource = shiftsList = new ObservableCollection<ShiftViewModel>();
            Title = "Shift for " + data.FirstName + " " + data.LastName;

            var shifts = _shiftService.GetShiftForUser(data.Id);

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
                        var shiftData = new ShiftViewModel
                        {
                            CreatedOn = shift.CreatedOn.ToString("MM/dd/yyyy"),
                            Id = shift.Id,
                            UserId = shift.UserId,
                            UserName = data.FirstName + " " + data.LastName,
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
