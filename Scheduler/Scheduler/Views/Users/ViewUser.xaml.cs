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

namespace Scheduler.Views.Users
{
    /// <summary>
    /// Interaction logic for ViewUser.xaml
    /// </summary>
    public partial class ViewUser : Window
    {
        public ViewUser(UserResponse user, LoginResponse loginResponse)
        {
            InitializeComponent();


            Email.Text = loginResponse.Email;
            Fname.Text = user.FirstName;
            Lname.Text = user.LastName;
            Gender.Text = user.Gender;
            Dob.Text = user.DoB.ToString("MMM dd, yyyy");
            Contact.Text = user.Contact;
            MaritalStatus.Text = user.MaritalStatus;
            MedicalHistory.Text = user.MedicalIssues;

        }
    }
}
