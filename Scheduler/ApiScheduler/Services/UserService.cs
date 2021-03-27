using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;

namespace ApiScheduler.Services
{
    public class UserService : IUser
    {
        private readonly SchedulerContext _context;
        private AccountService _accountService;
        public UserService()
        {
            _context = new SchedulerContext();
            _accountService = new AccountService();
        }
        public (User user, string message, bool check) Add(User user)
        {
            var (account, message, check) = _accountService.Get(user.AccountId);
            if (!check)
            {
                message = "Opps, could not add this personel!";
                return (null, message, check);
            }
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return (user, null, true);
            }
            catch (Exception)
            {
                _accountService.Delete(account);
                return (null, "Oops, something went wrong. Please try again later.", false);
            }

        }

        public (string message, bool check) Delete(User user)
        {
            try
            {
                (Account account, string message, bool check) _acount = _accountService.Get(user.AccountId);

                if (!_acount.check)
                {
                    return ("Oops, could not remove this personel successfuly", _acount.check);
                }
                _accountService.Delete(_acount.account);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return (null, true);
            }
            catch (Exception)
            {
                return ("Oops, something went wrong. Please try again later", false);
            }
        }

        public (User user, string message, bool check) Get(string id)
        {
            var _user = _context.Users.Find(id);
            var message = "";
            var check = false;
            if (_user is null)
                message = "Oops, it appears that this personel does not exist.";
            else
            {
                check = true;
                message = null;
            }

            return (_user, message, check);
        }

        public (IEnumerable<User> users, string message, bool check) Get()
        {
            IEnumerable<User> _users = new List<User>();
            var message = "";
            try
            {
                _users = _context.Users;
            }
            catch (Exception)
            {
                message = "Oops, Something went wrong please try again later!";
            }

            return (_users, message, !_users.Any());
        }

        public (User user, string message, bool check) Update(User user)
        {
            var _users = _context.Users.Find(user.Id);
            var message = "";
            var check = false;
            if (_users is null)
                message = "Oops, it appears that this personel does not exist.";
            else
            {
                try
                {
                    _context.Users.AddOrUpdate(user);
                    _context.SaveChanges();
                    check = true;
                    message = "Successfully updates account information.";
                }
                catch (Exception)
                {
                    message = "Oops, Something went wrong please try again later!";
                }

            }

            return (_users, message, check);
        }
    }
}