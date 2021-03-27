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
using System.Windows.Threading;
using Scheduler.Models;
using Scheduler.RestServices;
using Scheduler.RestServices.Models.Responses;

using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Scheduler.Views.Wards
{
    /// <summary>
    /// Interaction logic for IndexPage.xaml
    /// </summary>
    public partial class IndexPage : Page
    {
        private WardService _wardService;
        private UserService _userService;
        private ObservableCollection<WardInfo> _wards;
        public IndexPage()
        {
            InitializeComponent();
            _wards = new ObservableCollection<WardInfo>();
            _userService = new UserService(Support.CheckInternetConnection());
            _wardService = new WardService(Support.CheckInternetConnection());

            AddItemToList();
            ComboBoxItemsUI();

            WardDataList.ItemsSource = _wards;

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

        private void PopupBox_Opened(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_Closed(object sender, RoutedEventArgs e)
        {

        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void AddWardOrDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MaxHours.Text.IsValidNumber() || !MinHours.Text.IsValidNumber() )
            {
                MessageBox.Show("Please, use right format for the hours!");
                return;
            }

            if (int.Parse(MaxHours.Text) == 0 && int.Parse(MinHours.Text) == 0)
            {
                MessageBox.Show("Max and mean can be the same but not '0'");
                return;
            }
            if (int.Parse(MaxHours.Text) < int.Parse(MinHours.Text))
            {
                MessageBox.Show("Please, maximum hours can not be less than the minimum hours!");
                return;
            }
            var _response = _wardService.Add(new Ward
            {
                Description = DescriptionBox.Text,
                Name = NameBox.Text,
                InchargeId = InchargeBox.Text == "" ? null : InchargeBox.Text,
                MaximumHoursAday = int.Parse(MaxHours.Text),
                MinimunHoursAday = int.Parse(MinHours.Text)
            });


            if (!_response.Check)
            {
                MessageBox.Show(_response.Message);
                return;
            }
            _wards.Add(new WardInfo
            {
                Date = _response.Data.CreatedOn.ToString(),
                Description = _response.Data.Description,
                Incharge = _userService.GetUserByUserId(_response.Data?.InchargeId)?.Data?.FirstName,
                Name = _response.Data.Name,
                ID = _response.Data.Id,
                MaximumHoursAday = int.Parse(MaxHours.Text),
                MinimunHoursAday = int.Parse(MinHours.Text)
            });
        }

        private void DeleteWardorDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var _ward = button.DataContext as WardInfo;
            var id = _ward.ID;
            MessageBox.Show(id);
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
            UpdateDat();
        }

        private void UpdateDat()
        {
            var _check = Support.TryGetSession("index", out string elementIndex);
            if (_check)
            {
                Support.TryGetSession("description", out string description);
                Support.TryGetSession("name", out string name);
                Support.TryGetSession("max-hours", out string maxHours);
                Support.TryGetSession("min-hours", out string minHours);
                _wards[int.Parse(elementIndex)].Description = description;
                _wards[int.Parse(elementIndex)].Name = name;
                _wards[int.Parse(elementIndex)].MaximumHoursAday = int.Parse(maxHours);
                _wards[int.Parse(elementIndex)].MinimunHoursAday = int.Parse(minHours);
                CollectionViewSource.GetDefaultView(_wards).Refresh();
                Support.DestroySession("description");
                Support.DestroySession("name");
                Support.DestroySession("max-hours");
                Support.DestroySession("min-hours");
                Support.DestroySession("index");
            }
        }

        void ComboBoxItemsUI()
        {
            for (int i = 1; i <= 24; i++)
            {
                MaxHours.Items.Add(i);
                MinHours.Items.Add(i);
            }
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
    }
    public class WardInfo
    {
        public string Name { get; set; }
        public string Incharge { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public int MinimunHoursAday { get; set; }
        public int MaximumHoursAday { get; set; }
    }
}
