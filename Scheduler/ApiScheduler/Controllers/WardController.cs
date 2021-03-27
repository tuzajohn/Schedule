using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;
using ApiScheduler.Models.Responses;
using ApiScheduler.Services;

namespace ApiScheduler.Controllers
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class WardController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private IUser _userService;
        private IWard _wardService;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public WardController()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _userService = new UserService();
            _wardService = new WardService();
        }

        /// <summary>
        /// Add new ward
        /// </summary>
        /// <param name="ward">Ward Id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("wards")]
        public IHttpActionResult AddWard([FromBody]WardViewModel ward)
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
            (Ward ward, string message, bool check) _response = _wardService.Add(new Ward
            {
                Id = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.UtcNow,
                Description = ward.Description,
                Name = ward.Name,
                MaximumHoursAday = ward.MaximumHoursAday,
                MinimunHoursAday = ward.MinimunHoursAday,
                NumberOfWorkers = ward.NumberOfWorkers
            });

            return Ok(new ApiResponse<Ward>
            {
                Data = _response.ward,
                Check = _response.check,
                Message = _response.message
            });
        }
        /// <summary>
        /// Get a ward by ward id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("wards/{id}")]
        public IHttpActionResult GetWard(string id)
        {
            var (ward, message, check) = _wardService.Get(id);
            var data = new Ward();
            if (check)
            {
                data = ward;
                message = null;
            }
            else { data = ward; }
            return Ok(new ApiResponse<Ward>
            {
                Data = data,
                Check = check,
                Message = message
            });
        }

        /// <summary>
        /// Fetches all personells under one ward
        /// </summary>
        /// <param name="id">Ward Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("wards/{id}/users")]
        public IHttpActionResult GetUsersForWard(string id)
        {
            var _ward = _wardService.Get(id);
            var message = "";
            var data = new List<User>();
            var check = false;
            if (_ward.ward != null)
            {
                var _users = _userService.Get().users.Where(x => x.WardId == id).OrderByDescending(x => x.CreatedOn);
                if (!_users.Any())
                    message = "Zero result!";
                else
                {
                    check = true;
                    data = _users.ToList();
                }
            }
            else
            {
                data = null;
                message = _ward.message;
            }
            return Ok(new { message, data, check });
        }


        /// <summary>
        /// Fetches all wards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("wards")]
        public IHttpActionResult GetAllWards()
        {
            (IEnumerable<Ward> wards, string message, bool check) wards = _wardService.Get();

            return Ok(new ApiResponse<IEnumerable<Ward>>
            {
                Data = wards.wards.OrderByDescending(x => x.CreatedOn),
                Check = wards.wards.Count() == 0 ? false : true,
                Message = wards.message
            });
        }

        /// <summary>
        /// Update certain ward details
        /// </summary>
        /// <param name="id">Ward Id</param>
        /// <param name="ward">Ward Data</param>
        /// <returns></returns>
        [HttpPut]
        [Route("wards/{id}")]
        public IHttpActionResult UpdateWard(string id, WardViewModel ward)
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

            var _ward = _wardService.Get(id);
            if (_ward.ward != null)
            {
                _ward.ward.Name = ward.Name ?? _ward.ward.Name;

                _ward.ward.DivisionId = ward.DivisionId ?? _ward.ward.DivisionId;

                _ward.ward.Description = ward.Description ?? _ward.ward.Description;

                _ward.ward.InchargeId = ward.InChargeId ?? _ward.ward.InchargeId;

                _ward.ward.MaximumHoursAday = ward.MaximumHoursAday == 0 ? _ward.ward.MaximumHoursAday : ward.MaximumHoursAday;

                _ward.ward.MinimunHoursAday = ward.MinimunHoursAday == 0 ? _ward.ward.MinimunHoursAday : ward.MinimunHoursAday;

                _ward.ward.NumberOfWorkers = ward.NumberOfWorkers == 0 ? _ward.ward.NumberOfWorkers : ward.NumberOfWorkers;

                _wardService.Update(_ward.ward);
            }
            return Ok(new { message = _ward.message, data = _ward.ward, check = _ward.check });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WardViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InChargeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DivisionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinimunHoursAday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaximumHoursAday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfWorkers { get; set; }
    }
}
