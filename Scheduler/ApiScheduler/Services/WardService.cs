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
    public class WardService : IWard
    {
        private SchedulerContext _context;
        /// <summary>
        /// 
        /// </summary>
        public WardService()
        {
            _context = new SchedulerContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        public (Ward ward, string message, bool check) Add(Ward ward)
        {
            var _ward = _context.Wards.Where(x => x.Name.Contains(ward.Name) || x.Id == ward.Id);
            var message = "";
            var check = false;
            var data = new Ward();
            if (_ward.Any())
            {
                data = null;
                message = "This ward already exist.";
            }
            else{

                try
                {
                    _context.Wards.Add(ward);
                    _context.SaveChanges();
                    data = ward;
                    message = "";
                    check = true;
                }
                catch (Exception)
                {
                    data = null;
                    message = $"Oops, somethnig went wrong and the ward {ward.Name} could not be deleted";
                }

            }
            return (data, message, check);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        public (string message, bool check) Delete(Ward ward)
        {
            var check = false;
            var message = "";
            try
            {
                _context.Wards.Remove(ward);
                _context.SaveChanges();
                message = null;
                check = true;
            }
            catch (Exception)
            {
                message = $"Oops, somethnig went wrong and the ward {ward.Name} could not be deleted";
            }
            return (message, check);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (Ward ward, string message, bool check) Get(string id)
        {
            var message = "";
            var check = false;
            var data = new Ward();
            data = _context.Wards.Find(id);
            if (data == null)
            {
                message = "This ward does not exist";
                data = null;
            }
            else
            {
                try
                {
                    data = _context.Wards.Find(id);
                    check = true;
                    message = null;
                }
                catch (Exception)
                {
                    data = null;
                    message = "Oops, something went wrong with this action";
                }
            }

            return (data, message, check);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public (IEnumerable<Ward> wards, string message, bool check) Get()
        {
            var message = "";
            var check = false;
            var data = _context.Wards;
            return (data, message, check);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        public (Ward ward, string message, bool check) Update(Ward ward)
        {
            var _ward = _context.Wards.Find(ward.Id);
            var message = "";
            var data = new Ward();
            var check = false;
            if (_ward == null)
            {
                message = "Can not update this ward since it does not exist";
            }
            else
            {
                try
                {
                    _ward.Description = ward.Description ?? _ward.Description;
                    _ward.Name = ward.Name ?? _ward.Name;
                    _ward.DivisionId = ward.DivisionId ?? _ward.DivisionId;
                    _ward.CreatedOn = DateTime.UtcNow;
                    _context.Wards.AddOrUpdate(_ward);
                    _context.SaveChanges();
                    data = _ward;
                    check = true;
                    message = "";
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong on updating this ward";
                }
            }
            return (data, message, check);
        }
    }
}