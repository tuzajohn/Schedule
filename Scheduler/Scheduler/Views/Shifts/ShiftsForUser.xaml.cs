using Scheduler.Models;
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
    /// Interaction logic for ShiftsForUser.xaml
    /// </summary>
    public partial class ShiftsForUser : Window
    {
        ShiftService _shiftService;
        public ShiftsForUser(UserResponse data)
        {
            InitializeComponent();

            _shiftService = new ShiftService(GlobalClass.CheckCoonection);


            var shifts = _shiftService.GetShiftForUser(data.Id);

        }
    }
}
