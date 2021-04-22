using System;
using SchedulerWebApi.Models;

namespace SchedulerWebApi.ViewModels
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