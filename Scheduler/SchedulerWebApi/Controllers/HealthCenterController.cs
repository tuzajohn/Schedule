using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Controllers
{
    public class HealthCenterController : ControllerBase
    {
        private IHealtFacility _healthCenterService;
        public HealthCenterController(IHealtFacility healthCenterService)
        {
            _healthCenterService = healthCenterService;
        }

        [HttpPost]
        [Route("healthfacility")]
        public IActionResult AddNewCenter([FromBody]HealthFacilityViewModel healthFacility)
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
                _response.message,
                _response.check
            });
        }

        [HttpGet]
        [Route("healthfacility")]
        public IActionResult GetAllCenters()
        {
            var _response = _healthCenterService.Get();

            return Ok(new
            {
                data = _response.healthCenters,
                _response.message,
                _response.check
            });
        }

        [HttpGet]
        [Route("healthfacility/{id}")]
        public IActionResult GetOneCenters(string id)
        {
            var _response = _healthCenterService.Get(id);

            return Ok(new
            {
                data = _response.healthCenter,
                _response.message,
                _response.check
            });
        }
        [HttpGet]
        [Route("healthfacility/director/{id}")]
        public IActionResult GetOneCenterByDirector(string id)
        {
            var _response = _healthCenterService.Get();
            var center = new HealthCenter();
            if (_response.healthCenters != null)
            {
                center = _response.healthCenters.FirstOrDefault(x => x.Director == id);
            }
                

            return Ok(new
            {
                data = center,
                _response.message,
                _response.check
            });
        }

        [HttpDelete]
        [Route("healthfacility/{id}")]
        public IActionResult DeleteOneCenters(string id)
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

            var _response = _healthCenterService.Delete(id);

            return Ok(new
            {
                _response.message,
                _response.check
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
