using Scheduler.Models;
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

namespace Scheduler.Views.Divisions
{
    /// <summary>
    /// Interaction logic for ViewEditDeleteDivision.xaml
    /// </summary>
    public partial class ViewEditDeleteDivision : Window
    {
        DivisionService _divisionService;
        HealthFacilityService _healthFacilityService;
        HealthFacilityResponse healthFacility;
        UserService _userService;
        UserResponse user;
        private dynamic Division;
        private ObservableCollection<dynamic> divisionList;
        public ViewEditDeleteDivision(DivisionService divisionService, HealthFacilityService healthFacilityService, UserResponse user, HealthFacilityResponse healthFacility,
            dynamic Division, ObservableCollection<dynamic> divisionList)
        {
            InitializeComponent();
            _healthFacilityService = healthFacilityService;
            _divisionService = divisionService;
            _userService = new UserService(GlobalClass.CheckCoonection);
            this.user = user;
            this.healthFacility = healthFacility;
            this.Division = Division;
            this.divisionList = divisionList;

            DivName.Text = Division.Name;
            Title += ": " + Division.Name + "-" + Division.Id;
        }

        private void UpdateDivision_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("You sure that you want to perform this action?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(DivName.Text))
                {
                    MessageBox.Show("Please set the name for this division");
                    this.DivName.Focus();
                    return;
                }

                var response = _divisionService.UpdateDivision((string)Division.Id, DivName.Text);

                MessageBox.Show(response.Message);
                if (!response.Check)
                {
                    this.DivName.Focus();
                    return;
                }

                var itemIndex = divisionList.IndexOf(Division);

                var tempDynamic = new
                {
                    response.Data.Name,
                    Division.CreatedOn,
                    Center = healthFacility.Name,
                    Division.Id
                };

                divisionList[itemIndex] = tempDynamic;

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

        private void DeleteDivision_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
