using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;

namespace Scheduler.Views.SuperUser
{
    /// <summary>
    /// Interaction logic for HealthFacility.xaml
    /// </summary>
    public partial class HealthFacility : Page
    {
        ObservableCollection<HealthFacilityResponse> healthFacilityResponses;
        ObservableCollection<Director> directorList;
        HealthFacilityService _healthFacilityService;
        UserService userService;
        LoginService loginService;
        private DirectorService _directorService;
        public HealthFacility()
        {
            InitializeComponent();
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);
            _directorService = new DirectorService(GlobalClass.CheckCoonection);
            userService = new UserService(GlobalClass.CheckCoonection);
            loginService = new LoginService(GlobalClass.CheckCoonection);
            healthFacilityResponses = new ObservableCollection<HealthFacilityResponse>();

            facilities.ItemsSource = healthFacilityResponses;
            DirectorBox.ItemsSource = directorList = new ObservableCollection<Director>();

            LoadDirector();
            LoadFacilities();
        }

        private void AddNewHealthCenterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Give the name for the facility");
                NameBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(DirectorBox.Text))
            {
                MessageBox.Show("Give the directer for the facility");
                DirectorBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(AddressBox.Text))
            {
                MessageBox.Show("Give the address for the facility");
                AddressBox.Focus();
                return;
            }
            var selectedDirector = (Director)DirectorBox.SelectedItem;
            var user = userService.GetUserByAccountId(selectedDirector.AccountId);
            var _response = _healthFacilityService.CreateCenter(NameBox.Text, AddressBox.Text, user.Data.Id);
            MessageBox.Show(_response.Message);

            if (_response.Check)
            {
                healthFacilityResponses.Add(_response.Data);
            }

            AddressBox.Text = "";
            NameBox.Text = "";
            DirectorBox.Text = "";

        }

        private void AddNewDirector_Click(object sender, RoutedEventArgs e)
        {
            var _director = new NewDirector();
            
        }
        private void LoadFacilities()
        {
            
            foreach (var facility in _healthFacilityService.Get())
            {
                var director = _directorService.GetDirector(facility.Director);
                facility.Director = director?.Name;
                healthFacilityResponses.Add(facility);
            }
        }

        private void LoadDirector()
        {
            foreach (var _director in _directorService.GetAll())
            {
                directorList.Add(_director);
            }
        }
    }
}
