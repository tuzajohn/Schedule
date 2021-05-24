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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler.Views.SuperUser
{
    /// <summary>
    /// Interaction logic for Directors.xaml
    /// </summary>
    public partial class Directors : Page
    {
        ObservableCollection<DirectorViewModel> DirectorList;
        HealthFacilityService _healthFacilityService;
        private DirectorService _directorService;
        private LoginService loginService;
        public Directors()
        {
            InitializeComponent();
            _directorService = new DirectorService(Support.CheckInternetConnection());
            loginService = new LoginService(Support.CheckInternetConnection());

            directors.ItemsSource = DirectorList = new ObservableCollection<DirectorViewModel>();
            LoadDirectors();
        }

        private void LoadDirectors()
        {
            var directorResponse = _directorService.GetAll();

            foreach (var director in directorResponse)
            {
                var account = loginService.GetAccount(director.Id);
                DirectorList.Add(new DirectorViewModel
                {
                    Id = director.Id,
                    Name = director.Name,
                    Username = account.Data?.Email,
                    CreatedOn = director.CreatedOn.ToString("MM/dd/yyyy")
                });
            }
        }

        private void AddnewDirectorBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDirector = new NewDirector();
            newDirector.ShowDialog();
        }
    }
}
