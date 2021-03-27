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
using Newtonsoft.Json;
using Scheduler.Models;
using Scheduler.RestServices;

namespace Scheduler.Views.Wards
{
    /// <summary>
    /// Interaction logic for EditWardWindow.xaml
    /// </summary>
    public partial class EditWardWindow : Window
    {
        private string Id { get; set; }
        private WardService _wardService;
        public EditWardWindow(string id)
        {
            InitializeComponent();
            ComboBoxItemsUI();
            Closed += EditWardWindow_Closed;

            #region center
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
            #endregion

            _wardService = new WardService();
            Id = id;
            var ward = new WardService(Support.CheckInternetConnection()).GetWardById(id);
            WardName.Text = ward.Data.Name;
            WardDescription.Text = ward.Data.Description;
            MinHours.Text = ward.Data.MinimunHoursAday.ToString();
            MaxHours.Text = ward.Data.MaximumHoursAday.ToString();
            TimeBlock.Text = ward.Data.CreatedOn.AddHours(3).ToString("MMM dd, yyyy");

            Title = $"Setting [{ward.Data.Name}]";
        }

        private void EditWardWindow_Closed(object sender, EventArgs e)
        {
            Support.DestroySession("index");
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MaxHours.Text.IsValidNumber() || !MinHours.Text.IsValidNumber())
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
            var _ward = new Ward
            {
                Name = WardName.Text,
                Description = WardDescription.Text,
                MaximumHoursAday = int.Parse(MaxHours.Text),
                MinimunHoursAday = int.Parse(MinHours.Text)
            };

            var _response = _wardService.Update(id: Id, ward: _ward);

            if (_response.Check)
            {
                Support.CreateSession("description", _response.Data.Description);
                Support.CreateSession("name", _response.Data.Name);
                Support.CreateSession("max-hours", _response.Data.MaximumHoursAday.ToString());
                Support.CreateSession("min-hours", _response.Data.MinimunHoursAday.ToString());
                Close();
            }
            else
            {
                MessageBox.Show(_response.Message);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon");
        }
        void ComboBoxItemsUI()
        {
            for (int i = 1; i <= 24; i++)
            {
                MaxHours.Items.Add(i);
                MinHours.Items.Add(i);
            }
        }
    }
}
