﻿using Scheduler.Models;
using Scheduler.RestServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler.Views.SuperUser
{
    /// <summary>
    /// Interaction logic for NewDirector.xaml
    /// </summary>
    public partial class NewDirector : Window
    {
        private DirectorService _directorService;
        private LoginService _loginService;
        private UserService userService;
        public NewDirector()
        {
            InitializeComponent();
            _directorService = new DirectorService(GlobalClass.CheckCoonection);
            _loginService = new LoginService(GlobalClass.CheckCoonection);
            userService = new UserService(GlobalClass.CheckCoonection);
        }

        private void SaveDirector_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                MessageBox.Show("Director's name is required");
                name.Focus();
                return;
            }
            if (string.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Director's email is required");
                email.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Director's email is required");
                password.Focus();
                return;
            }

            if (password.Password != confirmpassword.Password)
            {
                MessageBox.Show("Passwords do not match");
                confirmpassword.Password = "";
                confirmpassword.Focus();
                return;
            }

            var _account = _loginService.SendLogin(new Models.Account
            {
                Date = DateTime.UtcNow,
                Email = email.Text,
                Password = password.Password,
                IsAdmin = true
            });

            var _director = _directorService.AddDirector(name.Text, _account.Data.Id);
            var user = new UserBody
            {
                Id = Guid.NewGuid().ToString(),
                AccountId = _account.Data.Id,
                CreatedOn = DateTime.UtcNow,
                DoB = DateTime.UtcNow,
                Email = email.Text,
            };

            var userResponse = userService.SendUser(user);

            MessageBox.Show("Director has been added");
            name.Text = "";
            email.Text = "";
            password.Password = "";
            confirmpassword.Password = "";
            this.Close();
        }
    }
}
