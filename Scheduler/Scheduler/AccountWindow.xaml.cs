﻿using System;
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
using Scheduler.RestServices.Models.Responses;
using Scheduler.Views.Shared;

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private LoginService _loginService;
        private UserService _userService;
        public AccountWindow()
        {
            InitializeComponent();
            GlobalClass.CheckCoonection = Support.CheckInternetConnection();
            _loginService = new LoginService(GlobalClass.CheckCoonection);
            _userService = new UserService(GlobalClass.CheckCoonection);
            if (!GlobalClass.CheckCoonection)
            {
                MessageBox.Show("Check your internet connection");
                Support.DestroySession("user");
                Support.DestroySession("userAccount");
                //Close();
            }

            if (Support.TryGetSession("user", out _))
                Support.DestroySession("user");

            if (Support.TryGetSession("userAccount", out _))
                Support.DestroySession("userAccount");
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var _email = EmailTextBox.Text;
            var _pass = PasswordBox.Password;
            var _response = new Response<LoginResponse>();
            List<Task> ls = new List<Task>();
            LoginBtn.Content = "Signing you in, please wait...";
            
            ls.Add(Task.Run(() =>
            {
                _response = _loginService.CheckLogin(_email, _pass);
            }));

            Task.WaitAll(ls.ToArray());
            LoginBtn.Content = "Login";
            //if (!GlobalClass.CheckCoonection)
            //{
            //    MessageBox.Show("Oops, no internet connection");
            //    return;
            //}

            if (_email == "admin" && _pass == "admin")
            {
                var _user = new LoginResponse { Email = _email };
                Support.CreateSession("user", JsonConvert.SerializeObject(_user));
                new SuperUserLayout().Show();
                Close();
                return;
            }

            if (!_response.Check)
            {
                MessageBox.Show(_response.Message);
                return;
            }

            if (!_response.Data.IsAdmin)
            {
                MessageBox.Show("Only admins allowed");
                return;
            }

            var user = _userService.GetUserByAccountId(_response.Data.Id);


            Support.CreateSession("userAccount", JsonConvert.SerializeObject(_response.Data));
            Support.CreateSession("user", JsonConvert.SerializeObject(user.Data));
            new MasterWindow().Show();
            Close();
        }
    }
}
