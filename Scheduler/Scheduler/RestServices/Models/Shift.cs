using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string WardId { get; set; }
        public StartTime StartTime { get; set; }
        public EndTime EndTime { get; set; }
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class StartTime
    {
        public double ticks { get; set; }
        public int days { get; set; }
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public double totalDays { get; set; }
        public double totalHours { get; set; }
        public double totalMilliseconds { get; set; }
        public double totalMinutes { get; set; }
        public double totalSeconds { get; set; }

    }
    public class EndTime
    {
        public double ticks { get; set; }
        public int days { get; set; }
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public double totalDays { get; set; }
        public double totalHours { get; set; }
        public double totalMilliseconds { get; set; }
        public double totalMinutes { get; set; }
        public double totalSeconds { get; set; }

    }
    
}
