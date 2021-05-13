using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Shift
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HistoryShift
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShiftId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EndDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}