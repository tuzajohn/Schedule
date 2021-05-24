using Newtonsoft.Json;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;
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

namespace Scheduler.Views.Divisions
{
    /// <summary>
    /// Interaction logic for DivisionsIndexPage.xaml
    /// </summary>
    public partial class DivisionsIndexPage : Page
    {
        DivisionService _divisionService;
        HealthFacilityService _healthFacilityService;
        HealthFacilityResponse healthFacility;
        UserResponse user;

        private ObservableCollection<dynamic> divisionList;

        public DivisionsIndexPage()
        {
            InitializeComponent();
            _divisionService = new DivisionService(Support.CheckInternetConnection());
            _healthFacilityService = new HealthFacilityService(Support.CheckInternetConnection());
            divisions.ItemsSource = divisionList = new ObservableCollection<dynamic>();
            user = new UserResponse();
            Task.Run(() =>
            {
                var check = Support.TryGetSession("user", out string loginData);
                if (check)
                {
                    user = JsonConvert.DeserializeObject<Response<UserResponse>>(loginData).Data;
                    healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;
                }
            });
        }

        private void AddnewDirectorBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDivision = new NewDivision(_divisionService, _healthFacilityService, user, healthFacility);
            newDivision.ShowDialog();
        }

        private void LoadDivisions()
        {
            var divisionResponse = _divisionService.GetDivisionsByHealthCenter(healthFacility.Id);
            if (divisionResponse.Check)
            {
                foreach (var division in divisionResponse.Data)
                {
                    divisionList.Add(new
                    {
                        division.Name,
                        CreatedOn = division.CreatedOn.ToString("MM/dd/yyyy"),
                        Center = healthFacility.Name,
                        division.Id
                    });
                }
            }
        }
    }
}
