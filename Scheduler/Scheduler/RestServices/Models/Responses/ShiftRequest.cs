using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices.Models.Responses
{
    public class ShiftRequest
    {
        public string UserId { get; set; }
        public string WardId { get; set; }
        public int MaxOrMin { get; set; }
        public DateTime StartingDateTime { get; set; }
    }
}
