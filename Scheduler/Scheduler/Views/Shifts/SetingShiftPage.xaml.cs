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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler.Views.Shifts
{
    /// <summary>
    /// Interaction logic for SetingShiftPage.xaml
    /// </summary>
    public partial class SetingShiftPage : Page
    {
        public SetingShiftPage()
        {
            InitializeComponent();
        }

        private void AddnewScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            new Index().ShowDialog();
        }
    }
}
