using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerWebApi.Controllers
{
    public class DirectorsController : ControllerBase
    {
        private readonly SchedulerContext _context;
        public DirectorsController(SchedulerContext context)
        {
            _context = context;
        }

        [HttpPost, Route("directors")]
        public IActionResult Add([FromBody] Director director)
        {
            var message = "";
            if (string.IsNullOrEmpty(director.Name))
            {
                return Ok(new
                {
                    code = -1,
                    message = "Name is required"
                });
            }
            var _director = new Director
            {
                CreatedOn = DateTime.UtcNow,
                Dob = director.Dob,
                Id = Guid.NewGuid().ToString("N"),
                IsDeleted = false,
                Name = director.Name,
                AccountId = director.AccountId
            };
            _context.Directors.Add(_director);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex) { _director = null; }
            return Ok(new
            {
                code = _director == null ? -1 : 0,
                message = _director == null ? "Oops, something wrong" : default,
                data = _director
            });
        }

        [HttpGet, Route("directors")]
        public IActionResult Get()
        {
            var _directors = new List<Director>();
            var message = "";
            try
            {
                _directors = _context.Directors.OrderByDescending(x => x.CreatedOn).ToList();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Ok(new
            {
                code = message == "" ? 0 : -1,
                message,
                data = _directors
            });
        }

        [HttpGet, Route("directors/{id}")]
        public IActionResult GetDirector(string id)
        {
            var _director = new Director();
            var message = "";
            try
            {
                _director = _context.Directors.Find(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Ok(new
            {
                code = message == "" ? -1 : 0,
                message,
                data = _director
            });
        }
    }
}