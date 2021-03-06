﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;
using ApiScheduler.Models.Responses;
using ApiScheduler.Services;

namespace ApiScheduler.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        IUser _userService;
        IAccount _accountService;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UserController()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _userService = new UserService();
            _accountService = new AccountService();
        }


        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">user to be added</param>
        /// <returns></returns>
        [HttpPost]
        [Route("users")]
        public IHttpActionResult AddUser([FromBody]User user)
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

            (User user, string message, bool check) _response = _userService.Add(user); 
            
            return Ok(new { data = _response.user, _response.message, _response.check});
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">user data</param>
        /// <returns></returns>
        [HttpPut]
        [Route("users/{id}")]
        public IHttpActionResult UpdateUser(string id, User user)
        {
            var _request = Request;
            var headers = _request.Headers;

            if (!headers.Contains("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers.GetValues("xlog").First();
            if (token != "admin")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var _user = _userService.Get(id);
            if (_user.check)
            {
                _user.user = user;
                _user.user.Id = id;
                _user = _userService.Update(_user.user);
            }

            return Ok(new { data = _user.user, _user.message, _user.check });
        }

        /// <summary>
        /// Get user using the account id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/account/{id}")]
        public IHttpActionResult GetUserByAccountId(string id)
        {
            var (account, message, check) = _accountService.Get(id);
            var data = new User();
            message = "";
            if (check)
            {
                var _user = _userService.Get().users.SingleOrDefault(x => x.AccountId == id);
                if (_user != null)
                {
                    data = _user;
                    message = null;
                    check = true;
                }
                else { data = null; }
            }
            else { data = null; }

            return Ok(new ApiResponse<User>
            {
                Data = data,
                Check = check,
                Message = message
            });
        }


        /// <summary>
        /// Get user using user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{id}")]
        public IHttpActionResult GetUserByUserId(string id)
        {
            var (user, message, check) = _userService.Get(id);
            var data = new User();
            if (check)
            {
                data = user;
                message = null;
            }
            else { data = user; }
            return Ok(new ApiResponse<User>
            {
                Data = data,
                Check = check,
                Message = message
            });
        }


        /// <summary>
        /// Fetches all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users")]
        public IHttpActionResult Users()
        {
            (IEnumerable<User> users, string message, bool check) users = _userService.Get();

            return Ok(new ApiResponse<IEnumerable<User>>
            {
                Data = users.users.OrderByDescending(x => x.FirstName),
                Check = users.users.Count() == 0 ? false : true,
                Message = users.message
            });
        }
    }
}