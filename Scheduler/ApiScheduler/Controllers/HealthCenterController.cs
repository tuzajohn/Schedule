using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;
using ApiScheduler.Services;

namespace ApiScheduler.Controllers
{
    public class HealthCenterController : ApiController
    {
        IHealtFacility _healthCenterService;
        public HealthCenterController()
        {
            _healthCenterService = new HealthFacilityService();
        }

        [HttpPost]
        [Route("healthfacility")]
        public IHttpActionResult AddNewCenter(HealthFacilityViewModel healthFacility)
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

            var _response = _healthCenterService.Add(new HealthCenter
            {
                Address = healthFacility.Address,
                CreatedOn = DateTime.UtcNow,
                Director = healthFacility.Director,
                Name = healthFacility.Name,
                Id = Guid.NewGuid().ToString()
            });

            return Ok(new
            {
                data = _response.healthCenter,
                message = _response.message,
                check = _response.check
            });
        }

        [HttpGet]
        [Route("healthfacility")]
        public IHttpActionResult GetAllCenters()
        {
            var _response = _healthCenterService.Get();

            return Ok(new
            {
                data = _response.healthCenters,
                message = _response.message,
                check = _response.check
            });
        }
        [HttpGet]
        [Route("healthfacility/(id)")]
        public IHttpActionResult GetOneCenters(string id)
        {
            var _response = _healthCenterService.Get(id);

            return Ok(new
            {
                data = _response.healthCenter,
                message = _response.message,
                check = _response.check
            });
        }

        [HttpDelete]
        [Route("healthfacility/(id)")]
        public IHttpActionResult DeleteOneCenters(string id)
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

            var _response = _healthCenterService.Delete(id);

            return Ok(new
            {
                message = _response.message,
                check = _response.check
            });
        }
    }

    public class HealthFacilityViewModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }
    }
}
