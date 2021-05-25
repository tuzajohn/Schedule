using Newtonsoft.Json;
using Scheduler.Models;
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
        UserService _userService;
        UserResponse user;
        private ObservableCollection<dynamic> divisionList;
        public NewDivision(DivisionService divisionService, HealthFacilityService healthFacilityService, UserResponse user, HealthFacilityResponse healthFacility,
            ObservableCollection<dynamic> divisionList)
        {
            InitializeComponent();

            _userService = new UserService(GlobalClass.CheckCoonection);

            _healthFacilityService = healthFacilityService;
            _divisionService = divisionService;
            this.user = user;
            this.healthFacility = healthFacility;
            this.divisionList = divisionList;
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

            divisionList.Add(new
            {
                response.Data.Name,
                CreatedOn = response.Data.CreatedOn.ToString("MM/dd/yyyy"),
                Center = healthFacility.Name,
                response.Data.Id
            });

            if (user.CenterId == default)
            {
                user.CenterId = healthFacility.Id;

                var responseUse = _userService.UpdateUser(user);
                if (responseUse.Check)
                {
                    user = responseUse.Data;
                }
            }

            this.Close();
        }
    }
}
