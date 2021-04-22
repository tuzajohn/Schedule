using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;
using SchedulerWebApi.Services;

namespace SchedulerWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : ControllerBase
    {
        private IAccount _accountService;
        private IUser _userService;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AccountController(IAccount accountService, IUser userService)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _accountService = accountService;
            _userService = userService;
        }


        /// <summary>
        /// Used to signin users
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("accounts/signin")]
        public IActionResult Login(string email, string password)
        {
            var account = new AccountViewModel
            {
                Email = email,
                Password = password
            };

            var message = "";
            var check = false;
            var data = new Account();
            if (string.IsNullOrEmpty(account.Email) || string.IsNullOrEmpty(account.Password))
            {
                data = null;
                message = "Please, fill in all fields!";
            }
            else
            {
                var _pass = Support.GetMd5(account.Password);
                var _account = _accountService.Get().accounts.SingleOrDefault(x => x.Email == account.Email && x.Password == _pass);
                if (_account is null)
                {
                    data = null;
                    message = "Wrong username or password";
                }
                else
                {
                    data = _account;
                    message = null;
                    check = true;
                }
            }
            return Ok(new { data, message, check });
        }


        /// <summary>
        /// Saves an account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>200</returns>
        [HttpPost]
        [Route("accounts")]
        public IActionResult SaveAccount(string email, string password, string isadmin)
        {
            var _request = Request;
            var headers = _request.Headers;

            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var account = _accountService.Get().accounts.SingleOrDefault(x => x.Email == email);
            var data = new Account();
            var message = "";
            var check = false;
            if (account != null)
            {
                data = null;
                message = "This acount exist already";
            }
            else
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    data = null;
                    message = "Please, provide all necessary information";
                }
                else
                {
                    var checkBoll = bool.TryParse(isadmin, out bool IsAdmin);

                    if (!checkBoll)
                    {
                        data = null;
                        message = "isadmin should be a proper boolean";
                        check = false;
                        return Ok(new { data, message, check });
                    }

                    var _account = new Account
                    {
                        Date = DateTime.Now,
                        Email = email,
                        Password = Support.GetMd5(password),
                        Id = Guid.NewGuid().ToString(),
                        IsAdmin = IsAdmin
                    };

                    var accountResponse = _accountService.Add(_account);

                    data = accountResponse.account;
                    message = accountResponse.message;
                    check = accountResponse.check;
                }
            }
            //
            return Ok(new { data, message, check });
        }
        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <param name="newpassword">New Password</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("accounts/{id}/changepassword")]
        public IActionResult UpdateAccount(string id, string newpassword)
        {
            var _request = Request;
            var headers = _request.Headers;
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var _account = _accountService.Get(id);

            if (_account.account != null)
            {
                var password = Support.GetMd5(newpassword);
                _account.account.Password = password;
                _account = _accountService.Update(_account.account);
            }


            return Ok(new { _account.message, data = _account.account, _account.check });
        }
    }


    public class AccountViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}