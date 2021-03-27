using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;

namespace ApiScheduler.Services
{
    public class AccountService : IAccount
    {
        private readonly SchedulerContext _context;
        public AccountService()
        {
            _context = new SchedulerContext();
        }
        public (Account account, string message, bool check) Add(Account account)
        {
            var check = false;
            var message = "";
            var _account = _context.Accounts.SingleOrDefault(x => x.Email == account.Email);
            if (_account != null)
                message = "This email already exist in the system!";
            else
            {
                try
                {
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                    check = true;
                    message = null;
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong, please try again later!";
                }
            }
            return (account, message, check);
        }

        public (string message, bool check) Delete(Account account)
        {
            var _account = _context.Accounts.Find(account.Id);
            var message = "";
            var check = false;
            if (_account is null)
            {
                message = "Oops, it appears that this personel does not exist.";
            }
            else
            {
                try
                {
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                    check = true;
                    message = null;
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong, please try again later!";
                }
            }
            return (message, check);
        }

        public (Account account, string message, bool check) Get(string id)
        {
            var _account = _context.Accounts.Find(id);
            var message = "";
            var check = false;
            if (_account is null)
                message = "Oops, it appears that this personel does not exist.";
            else
            {
                check = true;
                message = null;
            }

            return (_account, message, check);
        }

        public (IEnumerable<Account> accounts, string message, bool check) Get()
        {
            IEnumerable<Account> _accounts = new List<Account>();
            var message = "";
            try
            {
                _accounts = _context.Accounts;
            }
            catch (Exception)
            {
                message = "Oops, Something went wrong please try again later!";
            }

            return (_accounts, message, !_accounts.Any());
        }

        public (Account account, string message, bool check) Update(Account account)
        {

            var _account = _context.Accounts.Find(account.Id);
            var message = "";
            var check = false;
            if (_account is null)
                message = "Oops, it appears that this personel does not exist.";
            else
            {
                try
                {
                    _context.Accounts.AddOrUpdate(account);
                    _context.SaveChanges();
                    check = true;
                    message = "Successfully updates account information.";
                }
                catch (Exception)
                {
                    message = "Oops, Something went wrong please try again later!";
                }

            }

            return (_account, message, check);
        }
    }
}