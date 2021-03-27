using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;
using ApiScheduler.Services;

namespace ApiScheduler.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : ApiController
    {
        private IAccount _accountService;
        private IUser _userService;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AccountController()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _accountService = new AccountService();
            _userService = new UserService();
        }


        /// <summary>
        /// Used to signin users
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("accounts/signin")]
        public IHttpActionResult Login(string email, string password)
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
        public IHttpActionResult SaveAccount(string email, string password, string isadmin)
        {
            var _request = Request;
            var headers = _request.Headers;

            if (!headers.Contains("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)"});
            }

            var token = headers.GetValues("xlog").First();
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
                        return Json(new { data, message, check });
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
            return Json(new { data, message, check });
        }
        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <param name="newpassword">New Password</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("accounts/{id}/changepassword")]
        public IHttpActionResult UpdateAccount(string id, string newpassword)
        {
            var _request = Request;
            var headers = _request.Headers;
            if (!headers.Contains("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers.GetValues("xlog").First();
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


            return Ok(new { message = _account.message, data = _account.account, check = _account.check });
        }
    }


    public class AccountViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}