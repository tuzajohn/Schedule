using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.Views.Wards
{
    /// <summary>
    /// Interaction logic for IndexPage.xaml
    /// </summary>
    public partial class IndexPage : Page
    {
        private WardService _wardService;
        UserService _userService;
        DivisionService _divisionService;
        HealthFacilityService _healthFacilityService;
        private ObservableCollection<WardInfo> _wards;
        private ObservableCollection<DivisionResponse> divList;
        private ObservableCollection<UserResponse> userList;

        UserResponse user;
        UserResponse selectedInCharg;
        DivisionResponse selectedDivision;


        HealthFacilityResponse healthFacility;
        public IndexPage()
        {
            InitializeComponent();
            _wards = new ObservableCollection<WardInfo>();
            _wardService = new WardService(GlobalClass.CheckCoonection);
            _divisionService = new DivisionService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            _healthFacilityService = new HealthFacilityService(GlobalClass.CheckCoonection);

            var check = Support.TryGetSession("user", out string userData);
            user = JsonConvert.DeserializeObject<UserResponse>(userData);

            divList = new ObservableCollection<DivisionResponse>();
            userList = new ObservableCollection<UserResponse>();

            WardDataList.ItemsSource = _wards;

            ComboBoxItemsUI();

            

        }

        void ComboBoxItemsUI()
        {
            Task.Run(() =>
            {
                healthFacility = _healthFacilityService.GetByDirector(user.Id).Data;

                var wards = _wardService.GetWardsByCenter(healthFacility.Id);
                if (wards.Check)
                {
                    foreach (var ww in wards.Data)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            _wards.Add(new WardInfo
                            {
                                Date = ww.CreatedOn.ToString(),
                                Description = ww.Description,
                                Incharge = _userService.GetUserByUserId(ww?.InchargeId)?.Data?.FirstName,
                                Name = ww.Name,
                                ID = ww.Id,
                                MaximumHoursAday = ww.MaximumHoursAday,
                                MinimunHoursAday = ww.MinimunHoursAday,
                                CenterId = healthFacility.Id
                            });
                        });
                    }
                }
            });
        }
        public void Wards()
        {
            //TODO: Load incharges
            var division = "";
        }
        private void ViewWardOrDepartmentbtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var _ward = button.DataContext as WardInfo;
            var id = _ward.ID;

            int index = this.WardDataList.Items.IndexOf(_ward);
            Support.CreateSession("index", index.ToString());
            var _window = new EditWardWindow(id);
            _window.ShowDialog();
            
        }
        private void ViewListingForWard_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            var _ward = button.DataContext as WardInfo;
            var id = _ward.ID;

            int index = this.WardDataList.Items.IndexOf(_ward);
            Support.CreateSession("index", index.ToString());
            Support.CreateSession("ward-id", _ward.ID);
            Support.CreateSession("ward-name", _ward.Name);
            var _window = new AllUser();
            _window.ShowDialog();
        }
        public void AddItemToList()
        {
            Support.TryGetSession("user", out string jsonString);
            var _user = JsonConvert.DeserializeObject<LoginResponse>(jsonString);
            var _ward = _wardService.GetWards();
            if (_ward != null && _ward.Check)
            {
                var _wardList = _ward.Data.Where(x => x.InchargeId == _user.Id).ToList();
                _wardList.ForEach((x) =>
                {
                    var AddItem = new Action(() => _wards.Add(new WardInfo
                    {
                        Date = x.CreatedOn.ToString(),
                        Description = x.Description,
                        Incharge = _userService.GetUserByUserId(x?.InchargeId)?.Data?.FirstName,
                        Name = x.Name,
                        ID = x.Id
                    }));
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, AddItem);
                });
            }
        }

        private void AddnewWardDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddNewWard().ShowDialog();
        }
    }
    public class WardInfo
    {
        public string Name { get; set; }
        public string Incharge { get; set; }
        public string CenterId { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public int MinimunHoursAday { get; set; }
        public int MaximumHoursAday { get; set; }
    }
}
