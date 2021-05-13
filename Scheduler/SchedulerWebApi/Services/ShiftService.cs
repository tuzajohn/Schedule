using System;
using System.Collections.Generic;
using System.Linq;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ShiftService : IShift
    {
        private SchedulerContext _context;
        public ShiftService(SchedulerContext context)
        {
            _context = context;
        }
        public (Shift shift, string message, bool check) Add(Shift shift)
        {
            //var _shift = _context.Shifts.SingleOrDefault(x => x.UserId == shift.UserId && x.EndDay == shift.StartDay);
            //if (_shift != null)
            //{
            //    if (_shift.EndDay >= _shift.StartDay)
            //    {
            //        var start = _shift.StartDay;
            //        shift.StartDay = _shift.EndDay + 1;
            //        shift.EndDay = shift.StartDay == start ? shift.EndDay : shift.EndDay + 1;
            //    }
            //}
            try
            {
                var cc = _context.Shifts.Add(shift);
                var ccc = _context.SaveChanges();
                return (shift, null, true);
            }
            catch (Exception ex) { return (null, ex.Message, true); }
        }

        public (string message, bool check) Delete(string id)
        {
            var _shift = _context.Shifts.Find(id);
            _context.Shifts.Remove(_shift);
            _context.SaveChanges();
            return ("", true);
        }

        public (string message, bool check) DeleteRange(IEnumerable<Shift> shifts)
        {
            _context.Shifts.RemoveRange(shifts);
            //_context.SaveChanges();
            return ("", true);
        }

        public (Shift shift, string message, bool check) Get(string id)
        {
            var _shift = _context.Shifts.Find(id);
            return (_shift, _shift == null ? "Does not exist" : null, _shift == null ? false : true);
        }

        public (IEnumerable<Shift> shifts, string message, bool check) Get()
        {
            var _shifts = _context.Shifts.OrderBy(x => x.CreatedOn);
            return (_shifts, !_shifts.Any() ? "No shifts yet" : null, _shifts.Any());
        }

        public (Shift shift, string message, bool check) GetByDate(string day, string userId)
        {
            var _d = int.Parse(day);
            var _shift = _context.Shifts.SingleOrDefault(x => x.UserId == userId && x.StartDay == _d);
            return (_shift, _shift == null ? "Does not exist" : null, _shift == null ? false : true);
        }

        public (IEnumerable<Shift> shifts, string message, bool check) GetByUserId(string id)
        {
            var _shift = _context.Shifts.Where(x => x.UserId == id);

            return (_shift, _shift == null ? "Does not exist" : null, _shift == null ? false : true);
        }

        public (IEnumerable<Shift> shifts, string message, bool check) GetByWardId(string id)
        {
            var _shift = _context.Shifts.Where(x => x.WardId == id);

            return (_shift, _shift == null ? "Does not exist" : null, _shift == null ? false : true);
        }

        public (Shift shift, string message, bool check) Update(string id, Shift shift)
        {
            var _shift = _context.Shifts.Find(id);
            if (_shift != null)
            {
                _shift = shift;
                _context.Shifts.Update(_shift);
                var _response = _context.SaveChanges();
                if (_response <= 0)
                {
                    return (null, "Oops, something went wrong", false);
                }
                return (shift, null, true);
            }
            return (null, "Does not exist", false);
        }
    }
}