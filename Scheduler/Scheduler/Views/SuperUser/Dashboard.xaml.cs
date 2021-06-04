using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;

namespace Scheduler.Views.SuperUser
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        ObservableCollection<HealthFacilityResponse> _healthFacilities;
        HealthFacilityService _healthFacilityService;
        DirectorService _directorService;
        public Dashboard()
        {
            InitializeComponent();
            _healthFacilities = new ObservableCollection<HealthFacilityResponse>();
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);
            _directorService = new DirectorService(GlobalClass.CheckCoonection);

            var list = _healthFacilityService.Get();
            list.ForEach(x =>
            {
                var director = _directorService.GetDirector(x.Director);
                var tt = x;
                tt.Director = director?.Name;
                _healthFacilities.Add(tt);
            });


            Facilities.ItemsSource = _healthFacilities;
        }

        private void PrintBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = _healthFacilities.ToList();
            
        }

        private void ExportToCSVBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ExportToPDF_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
