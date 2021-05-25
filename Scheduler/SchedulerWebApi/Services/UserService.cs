using System;
using System.Collections.Generic;
using System.Linq;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Services
{
    public class UserService : IUser
    {
        private readonly SchedulerContext _context;
        private IAccount _accountService;
        public UserService(SchedulerContext context, IAccount accountService)
        {
            _context = context;
            _accountService = accountService;
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
            var message = "";
            var check = false;
            try
            {
                _context.Users.Update(user);
                var count = _context.SaveChanges();
                if (count == 0)
                {
                    user = null;
                    check = true;
                    message = "Failed to update information.";
                }
                else
                {
                    check = true;
                    message = "Successfully updates account information.";
                }
                check = true;
                message = "Successfully updates account information.";
            }
            catch (Exception)
            {
                message = "Oops, Something went wrong please try again later!";

                user = null;
            }

            return (user, message, check);
        }
    }
}