using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.ViewModel
{
    public class ShiftViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string WardId { get; set; }
        public string UserName { get; set; }
        public string WardName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
