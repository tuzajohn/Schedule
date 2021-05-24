using Newtonsoft.Json;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;
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

namespace Scheduler.Views.Divisions
{
    /// <summary>
    /// Interaction logic for NewDivision.xaml
    /// </summary>
    public partial class NewDivision : Window
    {
        DivisionService _divisionService;
        HealthFacilityService _healthFacilityService;
        HealthFacilityResponse healthFacility;
        UserResponse user;
        public NewDivision(DivisionService divisionService, HealthFacilityService healthFacilityService, UserResponse user, HealthFacilityResponse healthFacility)
        {
            InitializeComponent();
            _healthFacilityService = healthFacilityService;
            _divisionService = divisionService;
            this.user = user;
            this.healthFacility = healthFacility;
        }

        private void SaveDivision_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                MessageBox.Show("Set a name");
                name.Focus();
            }

            var response = _divisionService.CreateDivision(name.Text, healthFacility.Id);
            if (!response.Check)
            {
                MessageBox.Show(response.Message);
                return;
            }

            this.Close();
        }
    }
}
