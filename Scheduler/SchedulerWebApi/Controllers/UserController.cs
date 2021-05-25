using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;
using SchedulerWebApi.Models.Responses;

namespace SchedulerWebApi.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        public readonly IUser _userService;
        public readonly IAccount _accountService;
        public readonly IHealtFacility _healtFacility;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UserController(IUser userService, IAccount accountService, IHealtFacility healtFacility)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _userService = userService;
            _accountService = accountService;
            _healtFacility = healtFacility;
        }


        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">user to be added</param>
        /// <returns></returns>
        [HttpPost]
        [Route("users")]
        public IActionResult AddUser([FromBody] User user)
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

            (User user, string message, bool check) _response = _userService.Add(user);

            return Ok(new { data = _response.user, _response.message, _response.check });
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">user data</param>
        /// <returns></returns>
        [HttpPut]
        [Route("users/{id}")]
        public IActionResult UpdateUser(string id, [FromBody]User user)
        {
            var _request = Request;
            var headers = _request.Headers;

            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers["xlog"].First();
            if (token != "admin")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var _user = _userService.Update(user);

            return Ok(new { data = _user.user, _user.message, _user.check });
        }

        /// <summary>
        /// Get users using the account id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/account/{id}")]
        public IActionResult GetUserByAccountId(string id)
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
        /// Get users using the division id
        /// </summary>
        /// <param name="id">division id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/center/{id}")]
        public IActionResult GetUserByDivisionId(string id)
        {
            var (center, message, check) = _healtFacility.Get(id);
            var data = new User();
            message = "";
            if (check)
            {
                var _user = _userService.Get().users.SingleOrDefault(x => x.CenterId == id);
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
        public IActionResult GetUserByUserId(string id)
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
        public IActionResult Users()
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