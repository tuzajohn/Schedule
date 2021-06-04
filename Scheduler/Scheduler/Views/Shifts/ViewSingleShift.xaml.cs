using Scheduler.Models;
using Scheduler.Models.ViewModel;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
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

namespace Scheduler.Views.Shifts
{
    /// <summary>
    /// Interaction logic for ViewSingleShift.xaml
    /// </summary>
    public partial class ViewSingleShift : Window
    {
        ShiftService _shiftService;
        WardService _wardService;
        UserService userService;
        public ViewSingleShift(ShiftViewModel shift)
        {
            InitializeComponent();

            _shiftService = new ShiftService(GlobalClass.CheckCoonection);
            _wardService = new WardService(GlobalClass.CheckCoonection);
            userService = new UserService(GlobalClass.CheckCoonection);

            var ward = _wardService.GetWardById(shift.WardId);
            var user = userService.GetUserByUserId(shift.UserId);

            UserName.Text = user.Data.FirstName + " " + user.Data.LastName;
            WardName.Text = ward.Data.Name;
            EndDay.Text = shift.EndDay;
            StartDay.Text = shift.StartDay;
            EndTime.Text = shift.EndTime;
            StartTime.Text = shift.StartTime;
        }
    }
}
