using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DivisionController : ControllerBase
    {
        private IDivision _divisionService;
        private IWard _wardService;
        public DivisionController(IDivision divisionService, IWard wardService)
        {
            _divisionService =divisionService;
            _wardService = wardService;
        }
        /// <summary>
        /// Fetches all divisions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions")]
        public IActionResult Get()
        {
            var _division = _divisionService.Get();
            return Ok(new
            {
                data = _division.divisions,
                _division.message,
                _division.check
            });
        }
        /// <summary>
        /// Fetch a single division
        /// </summary>
        /// <param name="id">division id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions/{id}")]
        public IActionResult GetDivision(string id)
        {
            var _division = _divisionService.Get(id);
            return Ok(new
            {
                data = _division.division,
                _division.message,
                _division.check
            });
        }


        /// <summary>
        /// Fetch a all divisions under a certain facility
        /// </summary>
        /// <param name="id">healt facility id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions/healthcenter/{id}")]
        public IActionResult GetDivisionByHealthFacility(string id)
        {
            var _division = _divisionService.Get();
            if (_division.divisions != null)
            {
                _division.divisions = _division.divisions.Where(x => x.HealthFacilityId == id);
            }
            return Ok(new
            {
                data = _division.divisions,
                _division.message,
                _division.check
            });
        }

        /// <summary>
        /// Creates a new division
        /// </summary>
        /// <param name="name">Name of the division</param>
        /// <returns></returns>
        [HttpPost]
        [Route("divisions")]
        public IActionResult CreateDivision(string name, string healthFacilityId)
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

            var _division = _divisionService.Add(new Models.Division { Name = name, HealthFacilityId = healthFacilityId });
            return Ok(new
            {
                data = _division.division,
                _division.message,
                _division.check
            });
        }
        /// <summary>
        /// Get wards by division id
        /// </summary>
        /// <param name="id">division id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("divisions/{id}/wards")]
        public IActionResult GetWards(string id)
        {
            var _ward = _divisionService.GetWard(id);
            return Ok(new
            {
                data = _ward.wards,
                _ward.message,
                _ward.check
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
        public IActionResult UpdateDivision(string id, string name, string healthFacilityId)
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
            var _division = _divisionService.Get(id);
            if (_division.check)
            {
                _division = _divisionService.Update(new Models.Division
                {
                    Name = _division.division.Name = name,
                    CreatedOn = _division.division.CreatedOn,
                    Id = _division.division.Id,
                    HealthFacilityId = healthFacilityId
                });
            }
            return Ok(new
            {
                data = _division.division,
                _division.message,
                _division.check
            });
        }
        /// <summary>
        /// Deletes a certain division
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("divisions/{id}/delete")]
        public IActionResult Delete(string id)
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
            var _division = _divisionService.Delete(id);
            return Ok(new
            {
                _division.message,
                _division.check
            });
        }
    }
}
