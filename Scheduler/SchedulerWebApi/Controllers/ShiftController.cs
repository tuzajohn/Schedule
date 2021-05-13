using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;

namespace SchedulerWebApi.Controllers
{
    public class ShiftController : ControllerBase
    {
        private IShift _shiftService;
        private IHistoryShift _historyShiftService;
        private IUser _userService;
        private IWard _wardService;
        private IDivision _divisionService;
        public ShiftController(IShift shiftService, IHistoryShift historyShiftService, IUser userService, IWard wardService, IDivision divisionService)
        {
            _shiftService = shiftService;
            _historyShiftService = historyShiftService;
            _userService = userService;
            _wardService = wardService;
            _divisionService = divisionService;
        }

        /// <summary>
        /// Set shifts for an individual
        /// </summary>
        /// <param name="shift">Shift object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("shifts")]
        public IActionResult SetShift(ShiftPost shift)
        {

            #region headerCheck
            var headers = Request.Headers;
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }

            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            #endregion


            #region BackUp
            var _oldShifts = _shiftService.GetByUserId(shift.UserId).shifts.ToList();
            if (_oldShifts.Any())
            {
                var count = _oldShifts.Count();
                for (int i = 0; i < count; i++)
                {
                    var _oldShift = _oldShifts[i];
                    _historyShiftService.Add(_oldShift);
                }
                _shiftService.DeleteRange(_oldShifts);
            }
            #endregion


            #region init
            string userId = shift.UserId;
            string wardId = shift.WardId;
            int maxOrMin = shift.MaxOrMin == 0 ? -1 : shift.MaxOrMin;

            var _user = _userService.Get(userId);
            var _ward = _wardService.Get(wardId);

            if (!_user.check) return Ok(new { data = _user.user, _user.message, _user.check });
            if (!_ward.check) return Ok(new { data = _ward.ward, _ward.message, _ward.check });
            if (_ward.ward.MaximumHoursAday == 0 || _ward.ward.MinimunHoursAday == 0) return Ok(new { data = "Hours can not be 0, please set them" });

            var today = DateTime.UtcNow;

            var hours = _ward.ward.MinimunHoursAday;
            if (maxOrMin != -1)
            {
                hours = _ward.ward.MaximumHoursAday;
            }


            var _division = _divisionService.Get(_ward.ward.DivisionId);


            var maxDayHours = _division.division.Name.ToLower().Contains("matern") ? 24 : 12;

            //var totalHours = hours * 7;

            var hoursList = new List<int>();

            for (int i = 1; i <= maxDayHours; i += hours) hoursList.Add(i);//list of all starting times of a shift

            var random = new Random();

            var errors = new List<string>();

            var arra = new int[] { 1, 2, 3, 4 };

            var lastDayInMonth = DateTime.DaysInMonth(shift.StartingDateTime.Year, shift.StartingDateTime.Month);

            var contactHours = maxDayHours * 5 * (lastDayInMonth - shift.StartingDateTime.Day);

            var _shift = new Shift();
            int workingDays = 5;
            var freeDays = 2;
            #endregion

            #region processing
            var shifts = _shiftService.GetByWardId(wardId).shifts.Where(x => x.CreatedOn.Month < DateTime.UtcNow.Month);
            //TransaferToHistory(shifts.ToList());
            var ShiftsForTheInWard = _shiftService.Get().shifts.Where(s => s.WardId == wardId).ToList();
            for (int i = shift.StartingDateTime.Day; i <= lastDayInMonth; i++)
            {
                if (workingDays == 0)
                {
                    if (freeDays > 0)
                    {
                        freeDays--;
                        continue;
                    }
                    workingDays = 5;
                }
                else
                {
                    workingDays--;
                }

                var ShiftsForTheDayInWard = ShiftsForTheInWard.Where(s => s.StartDay == i && s.CreatedOn >= shift.StartingDateTime).ToList();
                var start = hoursList[random.Next(0, hoursList.Count)];//get a random start time
                if (ShiftsForTheDayInWard.Count == 0)
                {
                    _shift = IndividualShift(userId, wardId, hours, i, start, lastDayInMonth);
                    _shiftService.Add(_shift);

                    contactHours -= hours;
                    //ensures if the contact hours are depleted therefore free days are set.
                    if (contactHours == 0)
                        break;

                    continue;
                }
                List<TimeSpan> registeredTimes = (from obj in ShiftsForTheDayInWard
                                                  select obj.StartTime).ToList();

                var result = hoursList.Where(p => !registeredTimes.Any(p2 => TimeSpan.FromHours(p) == p2)).ToList();
                if (result.Count() != 0)//getting a slot that isnt occupied within the day
                    _shift = IndividualShift(userId, wardId, hours, i, result[random.Next(0, result.Count)], lastDayInMonth);
                else
                {//in case all slotes are already occupied, then get the time with the least number of staff!
                    var ordered = ShiftsForTheDayInWard
                    .GroupBy(x => x.StartTime)
                    .Select(group => new { group.Key, Count = group.Count() })
                    .OrderBy(x => x.Count);

                    var minOccurrenceCount = ordered.First().Count;

                    var leastOccurredTime = ordered
                        .TakeWhile(x => x.Count == minOccurrenceCount)
                        .Select(x => x.Key).ToList();

                    _shift = IndividualShift(userId, wardId, hours, i, Convert.ToInt32(leastOccurredTime[random.Next(0, leastOccurredTime.Count)].Hours), lastDayInMonth);
                }

                var _response = _shiftService.Add(_shift);

                contactHours -= hours;
                //ensures if the contact hours are depleted therefore free days are set.
                if (contactHours == 0)
                    break;
            }

            IEnumerable<Shift> _shifts = new List<Shift>();
            if (errors.Any())
            {
                return Ok(new { data = _shifts, message = "Something happened", check = false });
            }
            _shifts = _shiftService.Get().shifts.Where(x => x.UserId == userId && x.WardId == wardId);
            #endregion

            return Ok(new { data = _shifts, message = _shifts == null ? "No information found!" : null, check = _shifts.Any() });

        }

        private static Shift IndividualShift(string staffId, string wardId, int duration, int day, int start, int lastDay)
        {
            var endDay = day;
            var endTime = start + duration;
            if (endTime - 24 > 0)
            {
                endTime -= 24;
                endDay++;
            }

            //if (endTime < start) { endDay += 1; }
            if (endDay > lastDay) endDay = lastDay - endDay;
            //endDay = day;
            Shift shift = new Shift
            {
                Id = Guid.NewGuid().ToString("N"),
                StartDay = day,
                UserId = staffId,
                WardId = wardId,
                StartTime = TimeSpan.FromHours(start),
                EndTime = TimeSpan.FromHours(endTime),
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EndDay = endDay
            };
            return shift;
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets one shift
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("shifts/{id}")]
        public IActionResult GetShift(string id)
        {
            var _shift = _shiftService.Get(id);

            return Ok(new { data = _shift.shift, _shift.message, _shift.check });
        }
        [HttpGet]
        [Route("shifts/{day}/users/{userid}")]
        public IActionResult GetShiftByDayUserID(int day, string userid)
        {
            var _shift = _shiftService.GetByDate(day.ToString(), userid);

            return Ok(new { data = _shift.shift, _shift.message, _shift.check });
        }

        /// <summary>
        /// Get the sole shft of ward
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("shifts/ward/{id}")]
        public IActionResult GetShiftByWardId(string id)
        {
            var _shift = _shiftService.GetByWardId(id);

            return Ok(new { data = _shift.shifts.OrderBy(x => x.CreatedOn).ToList(), _shift.message, _shift.check });
        }

        /// <summary>
        /// Gets the sole shift of an individual
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("shifts/user/{id}")]
        public IActionResult GetShiftByUsId(string id)
        {
            var _shift = _shiftService.GetByUserId(id);
            return Ok(new { data = _shift.shifts.OrderBy(x => x.CreatedOn).ToList(), _shift.message, _shift.check });
        }

        private void TransferToHistory(List<Shift> shifts)
        {
            var taskList = new List<Task>();
            var count = shifts.Count;
            Task.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    _historyShiftService.Add(shifts[i]);
                    _shiftService.Delete(shifts[i].Id);
                }
            });
        }
    }
    public class ShiftPost
    {
        public string UserId { get; set; }
        public string WardId { get; set; }
        public int MaxOrMin { get; set; }
        public DateTime StartingDateTime { get; set; }
    }
}