using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ApiScheduler.Models;
using ApiScheduler.Models.Interfaces;

namespace ApiScheduler.Services
{
    public class HistoryShiftService : IHistoryShift
    {
        private SchedulerContext _context;
        private IShift _shiftService;
        public HistoryShiftService()
        {
            _context = new SchedulerContext();
            _shiftService = new ShiftService();
        }
        public (HistoryShift historyShift, string message, bool check) Add(Shift _shift)
        {
            var historyShift = new HistoryShift
            {
                CreatedOn = _shift.CreatedOn,
                WardId = _shift.WardId,
                UserId = _shift.UserId,
                StartDay = _shift.StartDay,
                EndDay = _shift.EndDay,
                EndTime = _shift.EndTime,
                Id = Guid.NewGuid().ToString(),
                StartTime = _shift.StartTime,
                ShiftId = _shift.Id
            };
            var _response = _shiftService.Delete(_shift.Id);
            if (!_response.check)
            {
                return (null, _response.message, false);
            }
            var _historyShift = _context.HistoryShifts.SingleOrDefault(x => x.UserId == historyShift.UserId && x.StartDay == historyShift.StartDay);
            if (_historyShift != null)
            {
                return (null, "Already set", false);
            }
            try
            {
                _context.HistoryShifts.Add(historyShift);
                _context.SaveChanges();
                return (historyShift, null, true);
            }
            catch (Exception ex) { return (null, ex.Message, true); }
        }

        public (string message, bool check) Delete(string id)
        {
            var _historyShift = _context.HistoryShifts.Find(id);
            if (_historyShift != null)
            {
                _context.HistoryShifts.Remove(_historyShift);
                var _response = _context.SaveChanges();
                if (_response > 0)
                {
                    return (null, true);
                }
                return ("Something went wrong", false);
            }
            return ("Does not exist", false);
        }

        public (HistoryShift historyShift, string message, bool check) Get(string id)
        {
            var _historyShift = _context.HistoryShifts.Find(id);
            return (_historyShift, _historyShift == null ? "Does not exist" : null, _historyShift == null ? false : true);
        }

        public (IEnumerable<HistoryShift> historyShifts, string message, bool check) Get()
        {
            var _historyShift = _context.HistoryShifts.OrderBy(x => x.CreatedOn);
            return (_historyShift, !_historyShift.Any() ? "No shifts yet" : null, _historyShift.Any());
        }

        public (HistoryShift historyShift, string message, bool check) GetByUserId(string id)
        {
            var _historyShift = _context.HistoryShifts.SingleOrDefault(x=>x.UserId == id);
            return (_historyShift, _historyShift == null ? "Does not exist" : null, _historyShift == null ? false : true);
        }

        public (HistoryShift historyShift, string message, bool check) GetByWardId(string id)
        {
            var _historyShift = _context.HistoryShifts.SingleOrDefault(x => x.WardId == id);
            return (_historyShift, _historyShift == null ? "Does not exist" : null, _historyShift == null ? false : true);
        }

        public (HistoryShift historyShift, string message, bool check) Update(string id, HistoryShift historyShift)
        {
            var _historyShift = _context.HistoryShifts.Find(id);
            if (_historyShift != null)
            {
                _historyShift = historyShift;
                _context.HistoryShifts.AddOrUpdate(_historyShift);
                var _response = _context.SaveChanges();
                if (_response <= 0)
                {
                    return (null, "Oops, something went wrong", false);
                }
                return (historyShift, null, true);
            }
            return (null, "Does not exist", false);
        }
    }
}