using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiScheduler.Models;
using ApiScheduler.Services;

namespace ApiScheduler.ViewModels
{
    public class UserAccount : User
    {
        public new string AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Date { get; set; }

    }
}