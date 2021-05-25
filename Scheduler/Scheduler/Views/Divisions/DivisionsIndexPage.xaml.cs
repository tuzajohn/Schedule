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
            _divisionService = new DivisionService(GlobalClass.CheckCoonection);
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);
            divisions.ItemsSource = divisionList = new ObservableCollection<dynamic>();
            user = new UserResponse();
            
            Task.Run(() =>
            {
                var check = Support.TryGetSession("user", out string userData);
                if (check)
                {
                    user = JsonConvert.DeserializeObject<UserResponse>(userData);
                    healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;
                    Dispatcher.Invoke(() =>
                    {
                        LoadDivisions();
                    });
                }
            });
        }

        private void AddnewDirectorBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDivision = new NewDivision(_divisionService, _healthFacilityService, user, healthFacility, divisionList);
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

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var value = (dynamic)item.Content;
                var newDivision = new ViewEditDeleteDivision(_divisionService, _healthFacilityService, user, healthFacility, value, divisionList);
                newDivision.ShowDialog();
            }
        }
    }
}
