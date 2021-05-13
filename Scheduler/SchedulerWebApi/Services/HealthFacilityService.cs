using System;
using System.Collections.Generic;
using System.Linq;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Services
{
    public class HealthFacilityService : IHealtFacility
    {
        private readonly SchedulerContext _context;

        public HealthFacilityService(SchedulerContext context)
        {
            _context = context;
        }
        public (HealthCenter healthCenter, string message, bool check) Add(HealthCenter healthCenter)
        {
            try
            {
                _context.HealthCenters.Add(healthCenter);
                _context.SaveChanges();
                return (healthCenter, null, true);
            }
            catch (Exception ex)
            {

                return (healthCenter, ex.Message, false);
            }
        }

        public (string message, bool check) Delete(string id)
        {
            try
            {
                var _healthCenter = _context.HealthCenters.Find(id);
                _context.HealthCenters.Remove(_healthCenter);
                _context.SaveChanges();
                return (null, true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }

        public (HealthCenter healthCenter, string message, bool check) Get(string id)
        {
            try
            {
                var _healthCenter = _context.HealthCenters.Find(id);
                return (_healthCenter, null, true);
            }
            catch (Exception ex)
            {
                return (null, ex.Message, false);
            }
        }

        public (IEnumerable<HealthCenter> healthCenters, string message, bool check) Get()
        {
            return (_context.HealthCenters.OrderByDescending(x => x.CreatedOn), null, true);
        }

        public (HealthCenter healthCenter, string message, bool check) Update(HealthCenter healthCenter)
        {
            throw new NotImplementedException();
        }
    }
}