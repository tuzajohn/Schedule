using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;

namespace ApiScheduler.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class DivisionService : IDivision
    {
        private SchedulerContext _context;
        public DivisionService()
        {
            _context = new SchedulerContext();
        }
        public (Division division, string message, bool check) Add(Division division)
        {
            var message = "";
            var check = false;
            var _division = _context.Divisions.SingleOrDefault(x => x.Name == division.Name);
            if (_division!=null)
            {
                message = "This division exist!";
            }
            else
            {
                try
                {
                    _division = new Division
                    {
                        CreatedOn = DateTime.UtcNow,
                        Id = Guid.NewGuid().ToString(),
                        Name = division.Name
                    };
                    _context.Divisions.Add(_division);
                    _context.SaveChanges();
                    check = true;
                    message = null;
                }
                catch (Exception)
                {
                    message = "Oops, somthing went wrong. Please try again later!";
                }
            }
            return (division = _division, message, check);
        }

        public (string message, bool check) Delete(string id)
        {
            var message = "";
            var check = false;
            var _division = _context.Divisions.Find(id);
            if (_division == null)
            {
                message = "This division does not exist!";
            }
            else
            {
                try
                {
                    var wards = GetWard(id);
                    wards.wards.ToList().ForEach((x) =>
                    {
                        x.DivisionId = "";
                        new WardService().Update(x);
                    });

                    _context.Divisions.Remove(_division);
                    _context.SaveChanges();
                    message = null;
                    check = true;
                }
                catch { message = "Oops, something went wrong. Please, try again later!"; }
            }
            return (message, check);
        }

        public (Division division, string message, bool check) Get(string id)
        {
            var check = false;
            var message = "";
            var _division = _context.Divisions.Find(id);
            if (_division != null) { check = true; message = null; }
            else { message = "Does not exist!"; }

            return (_division, message, check);
        }

        public (IEnumerable<Division> divisions, string message, bool check) Get()
        {
            var check = false;
            var message = "";
            var _divisions = _context.Divisions;
            if (_divisions.Any()) { check = true; message = null; }
            else { message = "No divisions found!"; }

            return (_divisions, message, check);
        }

        public (IEnumerable<Ward> wards, string message, bool check) GetWard(string id)
        {
            var check = false;
            var message = "";
            var wards = new WardService().Get();
            var _division = _context.Divisions.Find(id);
            if (_division != null)
            {
                check = true; message = null;
                wards.wards = wards.wards.Where(x => x.DivisionId == id).OrderByDescending(x => x.CreatedOn);
            }
            else { message = "Does not exist!"; wards.wards = null; }

            return (wards.wards, message, check);
        }

        public (Division division, string message, bool check) Update(Division division)
        {
            var message = "";
            var check = false;
            try
            {
                _context.Divisions.AddOrUpdate(division);
                _context.SaveChanges();
                message = null;
                check = true;
            }
            catch (Exception)
            {
                message = "Oops, something went wrong. Please try again later!";
                division = null;
            }

            return (division, message, check);
        }
    }
}