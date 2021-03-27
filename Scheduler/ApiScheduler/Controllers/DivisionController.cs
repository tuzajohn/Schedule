using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiScheduler.Models.Interfaces;
using ApiScheduler.Services;

namespace ApiScheduler.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DivisionController : ApiController
    {
        private IDivision _divisionService;
        private IWard _wardService;
        public DivisionController()
        {
            _divisionService = new DivisionService();
            _wardService = new WardService();
        }
        /// <summary>
        /// Fetches all divisions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions")]
        public IHttpActionResult Get()
        {
            var _division = _divisionService.Get();
            return Ok(new
            {
                data = _division.divisions,
                message = _division.message,
                check = _division.check
            });
        }
        /// <summary>
        /// Fetch a single division
        /// </summary>
        /// <param name="id">division id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions/{id}")]
        public IHttpActionResult GetDivision(string id)
        {
            var _division = _divisionService.Get(id);
            return Ok(new
            {
                data = _division.division,
                message = _division.message,
                check = _division.check
            });
        }
        /// <summary>
        /// Creates a new division
        /// </summary>
        /// <param name="name">Name of the division</param>
        /// <returns></returns>
        [HttpPost]
        [Route("divisions")]
        public IHttpActionResult CreateDivision(string name)
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
            var _division = _divisionService.Add(new Models.Division { Name = name });
            return Ok(new
            {
                data = _division.division,
                message = _division.message,
                check = _division.check
            });
        }
        /// <summary>
        /// Get wards by division id
        /// </summary>
        /// <param name="id">division id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions/{id}/wards")]
        public IHttpActionResult GetWards(string id)
        {
            var _ward = _divisionService.GetWard(id);
            return Ok(new
            {
                data = _ward.wards,
                message = _ward.message,
                check = _ward.check
            });
        }
        /// <summary>
        /// Updates a division
        /// </summary>
        /// <param name="id">division id</param>
        /// <param name="name">division name</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("divisions/{id}")]
        public IHttpActionResult UpdateDivision(string id, string name)
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
            var _division = _divisionService.Get(id);
            if (_division.check)
            {
                _division = _divisionService.Update(new Models.Division
                {
                    Name = _division.division.Name = name,
                    CreatedOn = _division.division.CreatedOn,
                    Id = _division.division.Id
                });
            }
            return Ok(new
            {
                data = _division.division,
                message = _division.message,
                check = _division.check
            });
        }
        /// <summary>
        /// Deletes a certain division
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("divisions/{id}/delete")]
        public IHttpActionResult Delete(string id)
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
            var _division = _divisionService.Delete(id);
            return Ok(new
            {
                message = _division.message,
                check = _division.check
            });
        }
    }
}
